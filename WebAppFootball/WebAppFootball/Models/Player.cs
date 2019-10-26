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
        public string Position { get; set; }
        public string Nationality { get; set; }
        public byte Number { get; set; }
        public DateTime? DOB { get; set; }
    }
}
