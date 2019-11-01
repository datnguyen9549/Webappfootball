namespace WebAppFootball.Models
{
    public class AppReposiroty
    {
        // fileds
        ClubRepository club;
        CoachRepository coach;
        StadiumRepository stadium;
        PlayerRepository player;
        PositionRepository position;
        CountryRepository country;
        MatchRepository match;
        public PositionRepository Position
        {
            get
            {
                if(position is null)
                {
                    position = new PositionRepository();
                }
                return position;
            }
        }
        public CountryRepository Country
        {
            get
            {
                if (country is null)
                {
                    country = new CountryRepository();
                }
                return country;
            }
        }
        public PlayerRepository Player
        {
            get
            {
                if(player is null)
                {
                    player = new PlayerRepository();
                }
                return player;
            }
        }
        // properties
        public ClubRepository Club
        {
            get
            {
                if(club is null)
                {
                    club = new ClubRepository();
                }
                return club;
            }
        }
        public CoachRepository Coach
        {
            get
            {
                if (coach is null)
                {
                    coach = new CoachRepository();
                }
                return coach;
            }
        }
        public StadiumRepository Stadium
        {
            get
            {
                if (stadium is null)
                {
                    stadium = new StadiumRepository();
                }
                return stadium;
            }
        }
        public MatchRepository Match
        {
            get
            {
                if(match is null)
                {
                    match = new MatchRepository();
                }
                return match;
            }
        }
    }
}
