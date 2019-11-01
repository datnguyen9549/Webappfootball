using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime DateOfMatch { get; set; }
        public int HomeClub { get; set; }
        public string HomeClubName { get; set; }
        public string HomeLogo { get; set; }
        public int AwayClub { get; set; }
        public string AwayClubName { get; set; }
        public string AwayLogo { get; set; }
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public byte Round { get; set; }
        public DateTime ExtraTime { get; set; }
        public string Result { get; set; }
        public byte Status { get; set; }
    }
}
