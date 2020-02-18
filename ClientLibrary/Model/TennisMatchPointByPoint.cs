using System;

namespace ClientLibrary.Model
{
    public class TennisMatchPointByPoint
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public string Stage { get; set; }
        public int PlayerAGames { get; internal set; }
        public int PlayerBGames { get; internal set; }
        public string PlayerAPoint { get; internal set; }
        public string PlayerBPoint { get; internal set; }
        public bool BreakPoint { get; internal set; }
        public bool SetPoint { get; internal set; }
        public bool MatchPoint { get; internal set; }
        public bool PlayerAServing { get; internal set; }
        public bool PlayerBServing { get; internal set; }
    }
}