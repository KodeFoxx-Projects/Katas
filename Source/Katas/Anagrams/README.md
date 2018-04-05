###### original source: http://codekata.com/kata/kata06-anagrams/

## "Anagrams" Problem Description
In England, I used to waste hour upon hour doing newspaper crosswords. As crossword fans will know, English cryptic crosswords have a totally different feel to their American counterparts: most clues involve punning or word play, and there are lots of anagrams to work through. For example, a recent Guardian crossword had:

```
Down:
    ..
    21. Most unusual form of arrest (6)
```

The hint is the phrase ‘form of,’ indicating that we’re looking for an anagram. Sure enough ‘arrest’ has six letters, and can be arranged nicely into ‘rarest,’ meaning ‘most unusual.’ (Other anagrams include raster, raters, Sartre, and starer)

A while back we had a thread on the Ruby mailing list about finding anagrams, and I’d like to resurrect it here. The challenge is fairly simple: given a file containing one word per line, print out all the combinations of words that are anagrams; each line in the output contains all the words from the input that are anagrams of each other. For example, your program might include in its output:

```
  kinship pinkish
  enlist inlets listen silent
  boaster boaters borates
  fresher refresh
  sinks skins
  knits stink
  rots sort
```

If you run this on the [word list here](http://codekata.com/data/wordlist.txt) you should find 20683 sets of anagrams (a total of 48162 words), including all-time favorites such as

```
crepitus cuprites pictures piecrust
paste pates peats septa spate tapes tepas
punctilio unpolitic
sunders undress
```