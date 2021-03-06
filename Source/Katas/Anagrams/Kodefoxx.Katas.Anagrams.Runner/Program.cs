﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kodefoxx.Katas.Anagrams.Shared;
using Kodefoxx.Katas.Anagrams.Strategies.CharacterKeyAnagramSolverStrategy;
using Kodefoxx.Katas.Anagrams.Strategies.MetadataAnagramSolverStrategy;

namespace Kodefoxx.Katas.Anagrams.Runner
{
    class Program
    {
        static void Main(string[] args)
        {            
            var anagramSolvers = FindAnagramSolvers().ToList();
            var wordLists = LoadWordListFromFile(args);
            var results = new Dictionary<string, AnagramSolverResult>();

            Console.Clear();

            foreach (var wordList in wordLists)
            {
                Console.WriteLine($"-- {wordList.Name}");
                foreach (var anagramSolver in anagramSolvers)
                {
                    var solverName = anagramSolver.GetType().Name;
                    PrintHeader(solverName);
                    var result = anagramSolver.GetAnagrams(wordList.Words).Result;
                    results.Add($"{anagramSolver.GetType().Name}_{wordList.Name}", result);
                    PrintResult(result, wordList.Words);
                    PrintFooter();
                }
                Console.WriteLine($"-----------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                
                string searchParameter = "";                
                do
                {
                    if (searchParameter.Equals(":quit")) return;                    

                    if (String.IsNullOrWhiteSpace(searchParameter))
                    {
                        Console.Write("| Search for an anagram or type ':quit' to exit.");
                        Console.WriteLine();
                        Console.Write("> ");
                        searchParameter = Console.ReadLine();
                    }
                    else
                    {
                        foreach (var result in results)
                        {
                            var anagram = result.Value.Search(searchParameter);
                            Console.WriteLine($" | {result.Key}");
                            Console.WriteLine(anagram == null
                                ? $" - no anagrams found."
                                : $" - {String.Join(", ", anagram.Words)}."
                            );
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        searchParameter = "";
                    }
                } while (true);
            }

            Console.ReadLine();            
        }

        private static List<(string Name, List<string> Words)> LoadWordListFromFile(params string[] fileNames)
        {
            fileNames = (fileNames ?? new string[] { }).Length == 0
                ? new []{ "wordlist.txt" }
                : fileNames;

            var wordLists = new List<(string, List<string>)>();

            foreach (var fileName in fileNames)
            {
                Console.WriteLine($"Loading wordlist \"{fileName}\"...");
                wordLists.Add((fileName, File.ReadAllLines(fileName).ToList()));
            }            

            return wordLists;
        }

        private static IEnumerable<IAnagramSolver> FindAnagramSolvers()
        {
            Console.WriteLine("Getting IAnagramSolver implementations...");
            return new List<IAnagramSolver>
            {                
                new CharacterKeyAnagramSolver(),
                new MetadataAnagramSolver()
            };
        }        

        private static void PrintHeader(string solverName)
        {
            Console.WriteLine("//");
            Console.WriteLine($"/// {solverName}");
        }

        private static void PrintFooter()
        {
            Console.WriteLine("///");
            Console.WriteLine("//");
            Console.WriteLine();
        }

        private static void PrintResult(AnagramSolverResult result, List<string> wordList)
        {
            Console.WriteLine($" - Found {result.Count} anagram(s) out of {wordList.Count} word(s).");
            Console.WriteLine($"   Took {ToHoursMinutesSecondsAndMillisecondsString(result.Duration)} to process.");
        }

        private static string ToHoursMinutesSecondsAndMillisecondsString(TimeSpan duration)
            => $"{duration.Hours}hrs {duration.Minutes}min {duration.Seconds}sec {duration.Milliseconds}ms";
        
    }
}
