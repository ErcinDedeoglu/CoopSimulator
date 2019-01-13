using System;
using System.Collections.Generic;
using System.Linq;

namespace CoopSimulator.Engine
{
    class Program
    {
        public static Data.DateDto Date { get; set; }
        public static Data.ConfigurationDto.Configuration Configuration { get; set; }
        public static Threads Threads { get; set; }
        public static List<Data.PoultryDto> PoultryList = new List<Data.PoultryDto>();
        public static PoultryHandler PoultryHandler = new PoultryHandler();


        private static void Main(string[] args)
        {
            Program.Configuration = Util.Configuration();

            Program.Date = new Data.DateDto(Configuration.GlobalSetting.Reporting.DatePeriod, Configuration.GlobalSetting.Reporting.Value, DatePeriodTriggered)
            {
                Date = new DateTime(2000, 1, 1)
            };

            Console.WriteLine("WELCOME TO COOP SIMULATOR OF " + Configuration.PoultryDetail.Name);

            Util.Init();

            Console.ReadLine();
        }

        private static void DatePeriodTriggered(object sender, EventArgs eventArgs)
        {
            Console.WriteLine(Program.Date.Date.ToString("dd-MM-yyyy") + " | F:" + Program.PoultryList.Count(a => a.Sex == Data.Enums.PoultrySex.Female) + " M:" + Program.PoultryList.Count(a => a.Sex == Data.Enums.PoultrySex.Male) + " AVG AGE: " + (int)Program.PoultryList.Average(a => (Program.Date.Date - a.BirthDate).TotalDays) + " day");
        }
    }
}