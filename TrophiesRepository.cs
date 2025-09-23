namespace Oblikatorisk_Opgave_1
{
   
        public class TrophiesRepository
        {
            private readonly List<Trophy> _trophies;

            // Copy constructor til Trophy
            
            private Trophy CopyTrophy(Trophy t)
            {
                return new Trophy(t.Id, t.Competition, t.Year);
            }

            public TrophiesRepository()
            {
                _trophies = new List<Trophy>
        {
            new Trophy(1, "Champions League", 2020),
            new Trophy(2, "Europa League", 2018),
            new Trophy(3, "World Cup", 2014),
            new Trophy(4, "La Liga", 2021),
            new Trophy(5, "European Championship", 1992)
        };
            }

           
            /// Returnerer en kopi af hele listen
            
            public List<Trophy> Get()
            {
                return _trophies.Select(t => CopyTrophy(t)).ToList();
            }

            /// Returnerer en kopi af listen, filtreret på Year
         
            public List<Trophy> Get(int year)
            {
                return _trophies
                    .Where(t => t.Year == year)
                    .Select(t => CopyTrophy(t))
                    .ToList();
            }
        }
    }

