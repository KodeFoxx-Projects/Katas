using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public abstract class WinStateCalculator : IWinStateCalculator
    {

        /// <inhertidocs/>
        public abstract WinMethod WinMethod { get; }

        /// <inhertidocs/>
        public abstract WinStateCalculatorResult Calculate(IBoardGrid boardGrid);

        /// <summary>
        /// Creates a <see cref="WinStateCalculatorResult"/> based on the defined <see cref="WinMethod"/> without a winner.
        /// </summary>        
        protected WinStateCalculatorResult NoWinnerResult()
            => new WinStateCalculatorResult(WinMethod);

        /// <summary>
        /// Creates a <see cref="WinStateCalculatorResult"/> based on the defined <see cref="WinMethod"/> with the given <paramref name="winner"/>.
        /// </summary>
        /// <param name="winner">The one that has won the game.</param>        
        protected WinStateCalculatorResult WinnerResult(BoardSlotValue winner)
            => new WinStateCalculatorResult(WinMethod, winner);

        /// <summary>
        /// Calculates a <see cref="WinStateCalculatorResult"/> based on the defined <see cref="boardSlotDictionary"/> and the <see cref="orderFunction"/>.
        /// </summary>
        /// <param name="boardSlotDictionary">The dictionary/collection of <see cref="BoardSlot"/>s to count.</param>
        /// <param name="orderFunction">Function that determines how to order each set of <see cref="BoardSlot"/>s before counting.</param>        
        /// <param name="winningCount">The amount needed for a win.</param>
        protected WinStateCalculatorResult CalculateWinStateCalculatorResultForBoardSlotDictionary(
            IDictionary<int, IEnumerable<BoardSlot>> boardSlotDictionary,
            Func<IEnumerable<BoardSlot>, IOrderedEnumerable<BoardSlot>> orderFunction,
            int winningCount = 4)
        {
            foreach (var boardSlots in boardSlotDictionary.Values)
            {
                var orderedSlots = orderFunction(boardSlots);
                var result = CalculateForOrderedBoardSlotValues(orderedSlots, winningCount);
                if (result.Winner.HasValue)
                    return result;
            }

            return NoWinnerResult();
        }

        /// <summary>
        /// Counts successive values based on an ordered enumerable of <see cref="BoardSlot"/>s.
        /// </summary>
        /// <param name="orderedSlots">The order <see cref="BoardSlot"/>s</param>        
        /// <param name="winningCount">The amount needed for a win.</param>
        private WinStateCalculatorResult CalculateForOrderedBoardSlotValues(
            IOrderedEnumerable<BoardSlot> orderedSlots, int winningCount = 4)
        {
            var counter = 0;
            var valueToCount = BoardSlotValue.Empty;
            foreach (var slotValue in orderedSlots.ToList())
            {
                if (slotValue.Value == BoardSlotValue.Empty)
                {
                    counter = 0;
                    valueToCount = BoardSlotValue.Empty;
                }
                else
                {
                    if (valueToCount == BoardSlotValue.Empty)
                        valueToCount = slotValue.Value;

                    if (valueToCount == slotValue.Value)
                        counter++;
                    else
                    {
                        valueToCount = slotValue.Value;
                        counter = 1;
                    }
                }

                if (counter == winningCount)
                    return WinnerResult(valueToCount);
            }

            return NoWinnerResult();
        }
    }
}
