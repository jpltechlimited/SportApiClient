using System;
using System.Collections.Generic;

namespace ClientLibrary.Model
{
    public class TennisMatch
    {
        public string Id { get; set; }
        public DateTime? DayOfYear { get; set; }
        public TennisPlayer Player1 { get; set; }
        public TennisPlayer Player2 { get; set; }
        public string Event { get; set; }
        public string Location { get; set; }
        public string CourtType { get; set; }
        public string TournamentStage { get; set; }
        public List<TennisMatchPointByPoint> PointByPointData { get; set; }
    }
}