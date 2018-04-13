using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Players
{
    public sealed class Player
    {
        /// <summary>
        /// Creates a new <see cref="Player"/>.
        /// </summary>        
        internal Player(string name, BoardSlotValue type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the player.
        /// </summary>
        public BoardSlotValue Type { get; }
    }
}
