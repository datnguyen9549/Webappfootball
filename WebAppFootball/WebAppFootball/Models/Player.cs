using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Fullname { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public string Nationality { get; set; }
        public string CountryName { get; set; }
        public byte Number { get; set; }
        public DateTime? DOB { get; set; }
    }
}
