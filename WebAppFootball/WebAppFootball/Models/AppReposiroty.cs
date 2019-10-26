namespace WebAppFootball.Models
{
    public class AppReposiroty
    {
        // fileds
        ClubRepository club;
        CoachRepository coach;
        StadiumRepository stadium;
        PlayerRepository player;
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
    }
}
