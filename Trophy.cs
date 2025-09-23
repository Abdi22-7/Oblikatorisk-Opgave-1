namespace Oblikatorisk_Opgave_1
{
    using System;

    public class Trophy
    {
        private int _id;
        private string _competition;
        private int _year;
        private Trophy found;

        public int Id
        {
            get => _id;
            set
            {
                // Antagelse: Id skal være et helt tal 
                _id = value;
            }
        }

        public string Competition
        {
            get => _competition;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(Competition), "Competition må ikke være null.");
                if (value.Trim().Length < 3)
                    throw new ArgumentException("Competition skal være mindst 3 tegn langt.", nameof(Competition));

                _competition = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1970 || value > 2025)
                    throw new ArgumentOutOfRangeException(nameof(Year), "Year skal være mellem 1970 og 2025 (inklusive).");

                _year = value;
            }
        }

        public Trophy(int id, string competition, int year)
        {
            Id = id;               // bruger property for at få validering
            Competition = competition;
            Year = year;
        }

        // tom konstruktør 
        public Trophy() { }

        public Trophy(Trophy found)
        {
            this.found = found;
        }

        // ToString override
        public override string ToString()
        {
            return $"Trophy (Id={Id}, Competition=\"{Competition}\", Year={Year})";
        }
    }

}
