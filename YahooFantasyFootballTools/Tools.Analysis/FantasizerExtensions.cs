using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis
{
    internal static class FantasizerExtensions
    {
        private const char FLEX_DELIMITER = '/';

        public static bool CanFill(this Player player, Position position)
        {
            return player.EligiblePositions.Contains(position);
        }

        public static bool IsFlex(this Position position)
        {
            return position.Name.Contains(FLEX_DELIMITER);
        }

        public static bool CanBeFilledBy(this Position position, Player player)
        {
            string[] positionNames = position.Name.Split(FLEX_DELIMITER);

            foreach (var positionName in positionNames)
            {
                // TODO: This is so ugly, get it out of my face.
                string normalizedPositionName = positionName;
                if (normalizedPositionName.Equals("W", StringComparison.OrdinalIgnoreCase))
                {
                    normalizedPositionName = "WR";
                }
                else if (normalizedPositionName.Equals("R", StringComparison.OrdinalIgnoreCase))
                {
                    normalizedPositionName = "RB";
                }

                foreach (var eligiblePosition in player.EligiblePositions)
                {
                    if (eligiblePosition.Name.Equals(normalizedPositionName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
