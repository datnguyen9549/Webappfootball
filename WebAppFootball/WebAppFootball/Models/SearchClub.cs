using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    // Tao mot doi tuong SearchClub
    public class SearchClub
    {
        public int? StadiumId { get; set; }
        public int? CoachId { get; set; }
        public string ShortName { get; set; }
        public string ClubName { get; set; }
    }
}
