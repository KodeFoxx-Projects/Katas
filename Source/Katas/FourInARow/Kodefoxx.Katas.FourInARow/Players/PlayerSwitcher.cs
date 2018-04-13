using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Kodefoxx.Katas.FourInARow.Players
{
    /// <summary>
    /// Takes control over who can play.
    /// </summary>
    internal sealed class PlayerSwitcher
    {
        private readonly List<Player> _players;
        private int _currentPlayerIndex = 0;

        /// <summary>
        /// Creates a new <see cref="PlayerSwitcher"/>.
        /// </summary>
        /// <param name="players">The <see cref="Player"/>s to participate.</param>
        public PlayerSwitcher(IEnumerable<Player> players)
            => _players = players.ToList();

        /// <summary>
        /// Gets the current <see cref="Player"/>.
        /// </summary>
        public Player CurrentPlayer => _players[_currentPlayerIndex];

        /// <summary>
        /// Moves the state to the next <see cref="Player"/>.
        /// </summary>        
        public Player NextPlayer()
            => MoveState();

        private Player MoveState()
        {
            if (_currentPlayerIndex >= _players.Count - 1)
                _currentPlayerIndex = 0;
            else
                _currentPlayerIndex++;

            return CurrentPlayer;
        }
    }
}
