namespace CoopSimulator.Data
{
    public class ConfigurationDto
    {
        public class Reporting
        {
            public Enums.DatePeriod DatePeriod { get; set; }
            public int Value { get; set; }
        }

        public class GlobalSetting
        {
            public Reporting Reporting { get; set; }
        }

        public class ColdStart
        {
            public int MalePopulation { get; set; }
            public int FemalePopulation { get; set; }
        }

        public class NumberOfBabiesForEachPregnancy
        {
            public int Low { get; set; }
            public int High { get; set; }
        }

        public class MaxAge
        {
            private static int _value;
            public Enums.DatePeriod DatePeriod { get; set; }
            public int Value
            {
                get { return _value; }

                set
                {
                    if (DatePeriod == Enums.DatePeriod.Year)
                    {
                        _value = 365 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Month)
                    {
                        _value = 30 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Week)
                    {
                        _value = 7 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Day)
                    {
                        _value = value;
                    }

                    DatePeriod = Enums.DatePeriod.Day;
                }
            }

        }

        public class DurationOfPregnancy
        {
            private static int _value;
            public Enums.DatePeriod DatePeriod { get; set; }
            public int Value
            {
                get { return _value; }

                set
                {
                    if (DatePeriod == Enums.DatePeriod.Year)
                    {
                        _value = 365 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Month)
                    {
                        _value = 30 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Week)
                    {
                        _value = 7 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Day)
                    {
                        _value = value;
                    }

                    DatePeriod = Enums.DatePeriod.Day;
                }
            }
        }

        public class AdolescenceAge
        {
            public Enums.DatePeriod DatePeriod { get; set; }
            private static int _maleAge;
            private static int _femaleAge;

            public int MaleAge
            {
                get { return _maleAge; }

                set
                {
                    if (DatePeriod == Enums.DatePeriod.Year)
                    {
                        _maleAge = 365 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Month)
                    {
                        _maleAge = 30 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Week)
                    {
                        _maleAge = 7 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Day)
                    {
                        _maleAge = value;
                    }
                }
            }

            public int FemaleAge
            {
                get { return _femaleAge; }

                set
                {
                    if (DatePeriod == Enums.DatePeriod.Year)
                    {
                        _femaleAge = 365 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Month)
                    {
                        _femaleAge = 30 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Week)
                    {
                        _femaleAge = 7 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Day)
                    {
                        _femaleAge = value;
                    }

                    DatePeriod = Enums.DatePeriod.Day;
                }
            }
        }

        public class OldAge
        {
            private static int _value;
            public Enums.DatePeriod DatePeriod { get; set; }
            public int Value
            {
                get { return _value; }

                set
                {
                    if (DatePeriod == Enums.DatePeriod.Year)
                    {
                        _value =  365 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Month)
                    {
                        _value = 30 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Week)
                    {
                        _value = 7 * value;
                    }
                    else if (DatePeriod == Enums.DatePeriod.Day)
                    {
                        _value = value;
                    }

                    DatePeriod = Enums.DatePeriod.Day;
                }
            }
        }

        public class PoultryDetail
        {
            public string Name { get; set; }
            public MaxAge MaxAge { get; set; }
            public DurationOfPregnancy DurationOfPregnancy { get; set; }
            public AdolescenceAge AdolescenceAge { get; set; }
            public OldAge OldAge { get; set; }
            public NumberOfBabiesForEachPregnancy NumberOfBabiesForEachPregnancy { get; set; }
        }

        public class Configuration
        {
            public ColdStart ColdStart { get; set; }
            public PoultryDetail PoultryDetail { get; set; }
            public GlobalSetting GlobalSetting { get; set; }
        }
    }
}