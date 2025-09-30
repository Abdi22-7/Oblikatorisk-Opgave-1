namespace Oblikatorisk_Opgave_1
{

    public class TrophiesRepository : ITrophies
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

        

        public List<Trophy> Get(int year)
        {
            return _trophies
                .Where(t => t.Year == year)
                .ToList(); // laver en ny liste, men med de samme objekter
        }
        public Trophy? GetById(int id)
        {
            return _trophies.FirstOrDefault(t => t.Id == id); // returnerer id eller null
        }

        public void Add(Trophy trophy)
        {
            if (trophy is null)
                throw new ArgumentNullException(nameof(trophy), "Trophy må ikke være null.");
            // Tjek om der allerede findes en trophy med samme Id
            if (_trophies.Any(t => t.Id == trophy.Id))
                throw new ArgumentException($"En trophy med Id {trophy.Id} findes allerede.", nameof(trophy));
            _trophies.Add(CopyTrophy(trophy)); // Tilføj en kopi af trofæet
        }
        public bool Remove(int id)
        {
            var trophyToRemove = _trophies.FirstOrDefault(t => t.Id == id);
            if (trophyToRemove != null)
            {
                _trophies.Remove(trophyToRemove);
                return true; // Fjernelse lykkedes
            }
            return false; // Ingen trophy med det givne Id blev fundet
        }

        public Trophy? Update(int id, Trophy values)
        {
            // Find det eksisterende objekt med samme id
            var existingTrophy = _trophies.FirstOrDefault(t => t.Id == id);

            if (existingTrophy is null)
                return null; // fandt ikke noget

            // Opdaterer felterne fra values (Id ændres ikke)
            existingTrophy.Competition = values.Competition;
            existingTrophy.Year = values.Year;

            return existingTrophy;
        }

    }
}

