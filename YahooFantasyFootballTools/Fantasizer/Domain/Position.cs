using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fantasizer.Domain
{
    public class Position : IEqualityComparer<Position>
    {
        private Position(PositionAbbreviation abbreviation, PositionType type, string displayName, bool isFlex, ICollection<Position> possiblePositions)
            :this(abbreviation, type, displayName, isFlex)
        {
            this.Abbreviation = abbreviation;
            this.Type = type;
            this.DisplayName = displayName;
            this.IsFlex = isFlex;
            this.PossiblePositions = possiblePositions;
        }

        private Position(PositionAbbreviation abbreviation, PositionType type, string displayName, bool isFlex)
        {
            this.PossiblePositions = new List<Position>() { this };
        }

        public PositionAbbreviation Abbreviation { get; private set; }
        public PositionType Type { get; private set; }
        public string DisplayName { get; private set; }
        public bool IsFlex { get; private set; }
        public ICollection<Position> PossiblePositions { get; private set; }

        public bool Equals(Position x, Position y)
        {
            return x.Abbreviation == y.Abbreviation;
        }

        public int GetHashCode(Position obj)
        {
            return obj.Abbreviation.GetHashCode();
        }

        public static Position GetPosition(string name)
        {
            return _positionMap[name];
        }

        public static Position Quarterback = new Position(PositionAbbreviation.QB, PositionType.Offense, "Quarterback", false);
        public static Position WideReceiver = new Position(PositionAbbreviation.WR, PositionType.Offense, "Wide Receiver",false);
        public static Position RunningBack = new Position(PositionAbbreviation.RB, PositionType.Offense, "Running Back", false);
        public static Position TightEnd = new Position(PositionAbbreviation.TE, PositionType.Offense, "Tight End", false);
        public static Position Kicker = new Position(PositionAbbreviation.K, PositionType.Kickers, "Kicker", false);
        public static Position Defense = new Position(PositionAbbreviation.DEF, PositionType.Defense_SpecialTeams, "Defense/Special Teams", false);
        public static Position DefensiveBack = new Position(PositionAbbreviation.DB, PositionType.DefensivePlayers, "Defensive Back", false);
        public static Position DefensiveLineman = new Position(PositionAbbreviation.DL, PositionType.DefensivePlayers, "Defensive Lineman", false);
        public static Position Linebacker = new Position(PositionAbbreviation.LB, PositionType.DefensivePlayers, "Linebacker", false);
        public static Position DefensiveTackle = new Position(PositionAbbreviation.DT, PositionType.DefensivePlayers, "Defensive Tackle", false);
        public static Position DefensiveEnd = new Position(PositionAbbreviation.DE, PositionType.DefensivePlayers, "Defensive End", false);
        public static Position CornerBack = new Position(PositionAbbreviation.CB, PositionType.DefensivePlayers, "Cornerback", false);
        public static Position Safety = new Position(PositionAbbreviation.S, PositionType.DefensivePlayers, "Safety", false);
        public static Position Bench = new Position(PositionAbbreviation.BN, PositionType.Defense_SpecialTeams, "Bench", false);
        public static Position InjuredReserve = new Position(PositionAbbreviation.IR, PositionType.Defense_SpecialTeams, "Injured Reserve", false);

        public static Position WideReceiverTightEnd = new Position(PositionAbbreviation.W_T, PositionType.Offense, "Wide Receiver/Tight End", true, new Collection<Position>() {WideReceiver, TightEnd});
        public static Position WideReceiverRunningBack = new Position(PositionAbbreviation.W_R, PositionType.Offense, "Wide Receiver/Running Back", true, new Collection<Position>(){WideReceiver, RunningBack});
        public static Position WideReceiverRunningBackTightEnd = new Position(PositionAbbreviation.W_R_T, PositionType.Offense, "Wide Receiver/Running Back/Tight End", true, new Collection<Position>(){WideReceiver, RunningBack, TightEnd});
        public static Position QuarterBackWideReceiverRunningBackTightEnd = new Position(PositionAbbreviation.Q_W_R_T, PositionType.Offense, "Quarterback/Wide Receiver/Running Back/Tight End", true, new Collection<Position>(){Quarterback, WideReceiver, RunningBack, TightEnd});
        public static Position DefensivePlayer = new Position(PositionAbbreviation.D, PositionType.DefensivePlayers, "Defensive Player", true, new Collection<Position>() { DefensiveBack, DefensiveLineman, Linebacker, DefensiveTackle, DefensiveEnd, CornerBack, Safety });

        private static Dictionary<string, Position> _positionMap = new Dictionary<string, Position>()
        {
            {"QB", Quarterback},
            {"WR", WideReceiver},
            {"RB", RunningBack},
            {"TE", TightEnd},
            {"W/T", WideReceiverTightEnd},
            {"W/R", WideReceiverRunningBack},
            {"W/R/T", WideReceiverRunningBackTightEnd},
            {"Q/W/R/T", QuarterBackWideReceiverRunningBackTightEnd},
            {"K", Kicker},
            {"DEF", Defense},
            {"DB", DefensiveBack},
            {"DL", DefensiveLineman},
            {"LB", Linebacker},
            {"DT", DefensiveTackle},
            {"DE", DefensiveEnd},
            {"CB", CornerBack},
            {"S", Safety},
            {"D", DefensivePlayer},
            {"BN", Bench},
            {"IR", InjuredReserve},
        };
    }
}