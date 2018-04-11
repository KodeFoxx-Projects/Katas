namespace Kodefoxx.Katas.FourInARow.Board
{
    /// <summary>
    /// Represents the size of the board.
    /// </summary>
    public sealed class BoardSize
    {
        /// <summary>
        /// Creates a new <see cref="BoardSize"/>
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        public BoardSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Creates a new <see cref="BoardSize"/>
        /// </summary>
        /// <param name="widthAndHeight">The width and height of the board.</param>
        public BoardSize(int widthAndHeight) 
            : this(widthAndHeight, widthAndHeight)
        { }

        /// <summary>
        /// The width of the board.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the board.
        /// </summary>
        public int Height { get; }

        /// <inheritdocs/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            var boardSize = obj as BoardSize;
            if (boardSize == null) return false;

            return
                boardSize.GetHashCode() == GetHashCode()
             && boardSize.Width == boardSize.Width
             && boardSize.Height == boardSize.Height;
        }

        /// <inheritdocs/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                return hash;
            }
        }
    }
}
