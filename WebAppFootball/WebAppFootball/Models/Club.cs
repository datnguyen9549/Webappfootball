using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int StadiumId { get; set; }
        public int CoachId { get; set; }
        public string LogoUrl { get; set; }
        public string FullName { get; set; }
        public string StadiumName { get; set; }
    }
}
