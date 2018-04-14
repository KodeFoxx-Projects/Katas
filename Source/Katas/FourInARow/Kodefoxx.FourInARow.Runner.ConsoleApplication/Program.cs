using System;
using System.Linq;
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

            Game = new FourInARowGame(AskPlayerName("one"), AskPlayerName("two"), new BoardSize(9, 7));

            while (!Game.HasWinner() || Game.GetWinState().Method == WinMethod.Draw)
            {                                
                VisualiseGame(Game, isDone: false);
                Game.PlayValueInColumn(AskPlayerForColumnIndex());
            }

            VisualiseGame(Game, isDone: true);

            Console.ReadLine();
        }

        private int AskPlayerForColumnIndex()
        {
            ChangeToColor(ConsoleColor.Cyan);
            Console.SetCursorPosition(HeaderPaddingLeft + 2 + Game.CurrentPlayer.Name.Length + 36, 8);
            var givenColumnIndex = Console.ReadLine();

            return Int32.Parse(givenColumnIndex);
        }
        private void PrintAskPlayerForColumnIndex()
        {
            ChangeToColor(ConsoleColor.Cyan);
            Console.WriteLine();
            Console.Write($"{GeneratePadding(HeaderPaddingLeft + 2)}> ");
            ChangeToColor(ConsoleColor.White);
            Console.Write($"{Game.CurrentPlayer.Name}, enter the number of the column: ");            
        }

        /// <summary>
        /// Asks the player name via console input.
        /// </summary>        
        private string AskPlayerName(string playerName)
        {
            PrintGameHeader(clearScreen: true);            

            ChangeToColor(ConsoleColor.Cyan);
            Console.WriteLine();
            Console.Write($"{GeneratePadding(HeaderPaddingLeft + 2)}> ");
            ChangeToColor(ConsoleColor.White);
            Console.Write($"Player {playerName}'s name: ");
            PrintGameHeader(clearScreen: false);

            ChangeToColor(ConsoleColor.Cyan);
            Console.SetCursorPosition(HeaderPaddingLeft + 2 + playerName.Length + 18, 6);
            var givenPlayerName = Console.ReadLine();

            ChangeToDefaultColor();

            return String.IsNullOrWhiteSpace(givenPlayerName) ? playerName : givenPlayerName;
        }

        /// <summary>
        /// Visualises the <paramref name="game"/>.
        /// </summary>        
        private void VisualiseGame(IFourInARowGame game, bool isDone = false)
        {
            PrintGameHeader(clearScreen: true);

            var winMethodLabel = "Win method";
            var winMethodValue = game.GetWinState().Method == WinMethod.None ? "The game is still on!" : game.GetWinState().Method.ToString();
            PrintTopInfoBox(winMethodLabel, winMethodValue, HeaderSize.Height, HeaderSize.Width - 6 - winMethodLabel.Length - winMethodValue.Length);

            var currentPlayerLabel = isDone ? "Winner" : "Current player";
            var currentPlayerValue = isDone 
                ? game.GetWinState().Winner.HasValue
                    ? game.GetWinState().Winner.Value == BoardSlotValue.P1
                      ? game.PlayerOne.Name
                      : game.PlayerTwo.Name
                    : "Draw"
                : game.CurrentPlayer.Name;
            PrintTopInfoBox(currentPlayerLabel, currentPlayerValue, HeaderSize.Height, 0, HeaderPaddingLeft + 2);

            if(!isDone)
                PrintAskPlayerForColumnIndex();            

            Console.WriteLine();
            Console.WriteLine();
            PrintBoard(game.Board, HeaderPaddingLeft + 2);

            PrintGameHeader(clearScreen: false);
        }

        /// <summary>
        /// Prints the board
        /// </summary>
        private void PrintBoard(IReadOnlyBoardGrid board, int paddingLeft)
        {            
            var boardSize = board.ToBoardSize();
            paddingLeft = ((HeaderSize.Width / 2) - ((boardSize.Width * 7) + 2 + 4)/2);

            var columnHeader = String.Join("", Enumerable.Range(1, boardSize.Width).Select(columnIndex => $"    {columnIndex:00} "));
            Console.WriteLine($"{GeneratePadding(paddingLeft + 4)}{columnHeader}");
            Console.WriteLine($"{GeneratePadding(paddingLeft+4)}+{GeneratePadding(boardSize.Width * 7, '+')}+");

            foreach (var rowIndex in Enumerable.Range(1, boardSize.Height))
            {
                Console.WriteLine($"{GeneratePadding(paddingLeft+4)}+{RepeatString(boardSize.Width, "+     +")}+");
                Console.WriteLine($"{GeneratePadding(paddingLeft)}{rowIndex:00}  +{RepeatString(boardSize.Width, "+     +")}+");
                Console.WriteLine($"{GeneratePadding(paddingLeft+4)}+{RepeatString(boardSize.Width, "+     +")}+");
                Console.WriteLine($"{GeneratePadding(paddingLeft+4)}+{RepeatString(boardSize.Width, "+++++++")}+");
            }            
        }


        /// <summary>
        /// Prints an infobox below the header.
        /// </summary>        
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

            if (!clearScreen)
            {
                Console.WriteLine($"{GeneratePadding(HeaderPaddingLeft)}{HeaderBottom}");
                return;
            }
            
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
            $"/{new string('*', 105)}\\";

        private string HeaderTitle => "F O U R   I N   A   R O W";        

        private string GeneratePadding(int length, char @char = ' ') => $"{new string(@char, length)}";

        private string RepeatString(int length, string @string = " ") =>
            String.Join("", Enumerable.Range(0, length).Select(x => @string));

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
