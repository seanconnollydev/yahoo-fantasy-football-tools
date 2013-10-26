using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis
{
    internal static class FantasizerExtensions
    {
        public static bool CanBeFilledBy(this Position position, Player player)
        {
            foreach (var eligiblePosition in player.EligiblePositions)
            {
                if (eligiblePosition.Equals(position))
                {
                    return true;
                }

                foreach (var possiblePosition in position.PossiblePositions)
                {
                    if (eligiblePosition.Equals(possiblePosition))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
