namespace ClientLibrary.Model
{
    public class TennisLiveScore
    {
        public string MatchId { get; set; }
        public TennisPlayer PlayerA { get; set; }
        public TennisPlayer PlayerB { get; set; }
        public string Stage { get; set; }
        public int PlayerASet { get; set; }
        public int PlayerBSet { get; set; }
        public int PlayerAGame { get; set; }
        public int PlayerBGame { get; set; }
        public string PlayerAPoint { get; set; }
        public string PlayerBPoint { get; set; }
        public bool PlayerALostServe { get; set; }
        public bool PlayerABreakPoint { get; set; }
        public bool PlayerBBreakPoint { get; set; }
        public bool PlayerASetPoint { get; set; }
        public bool PlayerBSetPoint { get; set; }
        public bool PlayerAMatchPoint { get; set; }
        public bool PlayerBMatchPoint { get; set; }
        public bool PlayerBLostServe { get; set; }
        public bool PlayerAServing { get; set; }
        public bool PlayerBServing { get; set; }
    }
}