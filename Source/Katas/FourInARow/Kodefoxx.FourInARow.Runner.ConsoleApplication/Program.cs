using System;
using System.Security.Claims;
using Kodefoxx.Katas.FourInARow;
using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.FourInARow.Runner.ConsoleApplication
{
    class FourInARowConsoleGame
    {
        /// <summary>
        /// Creates a new <see cref="FourInARowConsoleGame"/> object and runs it.
        /// </summary>
        /// <param name="args">Array of strings with arguments to the application.</param>
        public static void Main(string[] args)
            => new FourInARowConsoleGame().Run();        

        /// <summary>
        /// Creates a new <see cref="FourInARowConsoleGame"/>.
        /// </summary>
        private FourInARowConsoleGame() { }

        /// <summary>
        /// Gets the <see cref="IFourInARowGame"/>.
        /// </summary>
        private IFourInARowGame Game { get; set; }

        /// <summary>
        /// Starts the game.
        /// </summary>
        private void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Game = new FourInARowGame(AskPlayerName("one"), AskPlayerName("two"), new BoardSize(7, 5));

            while (!Game.HasWinner() || Game.GetWinState().Method == WinMethod.Draw)
            {
                VisualiseGame(Game);
                Console.ReadLine();
            }

            Console.ReadLine();
        }        

        /// <summary>
        /// Asks the player name via console input.
        /// </summary>        
        private string AskPlayerName(string playerName)
        {
            PrintGameHeader(clearScreen: true);            

            ChangeToColor(ConsoleColor.Cyan);
            Console.WriteLine();
            Console.Write($"{GeneratePadding(HeaderPaddingLeft + 2)}> Player {playerName}'s name: ");

            ChangeToColor(ConsoleColor.DarkCyan);
            var givenPlayerName = Console.ReadLine();

            ChangeToDefaultColor();

            return String.IsNullOrWhiteSpace(givenPlayerName) ? playerName : givenPlayerName;
        }

        /// <summary>
        /// Visualises the <paramref name="game"/>.
        /// </summary>        
        private void VisualiseGame(IFourInARowGame game)
        {
            PrintGameHeader(clearScreen: true);

            var winMethodLabel = "Win method";
            var winMethodValue = game.GetWinState().Method == WinMethod.None ? "The game is still on!" : game.GetWinState().Method.ToString();
            PrintTopInfoBox(winMethodLabel, winMethodValue, HeaderSize.Height, HeaderSize.Width - 6 - winMethodLabel.Length - winMethodValue.Length);

            var currentPlayerLabel = "Current player";
            var currentPlayerValue = game.CurrentPlayer.Name;
            PrintTopInfoBox(currentPlayerLabel, currentPlayerValue, HeaderSize.Height, 0, HeaderPaddingLeft + 2);            
        }

        private void PrintTopInfoBox(string label, string content, int topPosition, int leftPosition, int paddingLeft = 0)
        {
            ChangeToColor(ConsoleColor.DarkCyan);

            Console.SetCursorPosition(leftPosition, topPosition);
            Console.Write($"{GeneratePadding(paddingLeft)}<| ");
            ChangeToColor(ConsoleColor.Cyan);
            Console.Write($"{label.ToUpper()}");
            ChangeToColor(ConsoleColor.DarkGray);
            Console.Write($" : ");
            ChangeToColor(ConsoleColor.White);
            Console.Write($"{content.ToUpperInvariant()}");
            ChangeToColor(ConsoleColor.DarkCyan);
            Console.WriteLine($" |>");

            Console.SetCursorPosition(leftPosition, topPosition + 1);
            Console.WriteLine($"{GeneratePadding(paddingLeft)}{new string('*', 9 + label.Length + content.Length)}");

            ChangeToDefaultColor();            
        }

        /// <summary>
        /// Prints the header.
        /// </summary>
        /// <param name="clearScreen">Determines whether to clear the scren or not.</param>
        private void PrintGameHeader(bool clearScreen = true)
        {
            if(clearScreen) Console.Clear();
            
            ChangeToColor(ConsoleColor.DarkCyan);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{GeneratePadding(HeaderPaddingLeft)}{HeaderTop}");

            Console.Write($"{ GeneratePadding(HeaderPaddingLeft)}|** *  *   "); //11
            ChangeToColor(ConsoleColor.Cyan);
            Console.Write("*    "); //5
            ChangeToColor(ConsoleColor.White);
            var headerTitlePaddingSize = (HeaderTop.Length - (/* stars => */(11 + 5 + 1) * 2)/**/ - HeaderTitle.Length) / 2;
            Console.Write($"*{GeneratePadding(headerTitlePaddingSize)}{HeaderTitle}{GeneratePadding(headerTitlePaddingSize)}*");
            ChangeToColor(ConsoleColor.Cyan);
            Console.Write("    *"); //5
            ChangeToColor(ConsoleColor.DarkCyan);
            Console.WriteLine("   *  * **|"); //11

            Console.WriteLine($"{GeneratePadding(HeaderPaddingLeft)}{HeaderBottom}");

            ChangeToDefaultColor();
        }
        private (int Height, int Width) HeaderSize
            => new ValueTuple<int, int>(5, HeaderTop.Length);

        private int HeaderPaddingLeft => 5;
        private string HeaderBottom =>
            $"\\{new string('*', HeaderTop.Length - 2)}/";
        private string HeaderTop =>
            $"/{new string('*', 95)}\\";

        private string HeaderTitle => "F O U R   I N   A   R O W";        

        private string GeneratePadding(int length, char @char = ' ') => $"{new string(@char, length)}";

    /// <summary>
    /// Changes the foreground color.
    /// </summary>
    /// <param name="newColor"></param>
    private void ChangeToColor(ConsoleColor newColor)
            => Console.ForegroundColor = newColor;

        /// <summary>
        /// Changes the forground color to the default color.
        /// </summary>
        private void ChangeToDefaultColor()
            => ChangeToColor(ConsoleColor.White);
    }
}
