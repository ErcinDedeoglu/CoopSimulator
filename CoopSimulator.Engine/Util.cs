using CoopSimulator.Helper;
using Newtonsoft.Json;

namespace CoopSimulator.Engine
{
    public class Util
    {
        public static void Init()
        {
            Program.Threads = new Threads();
        }

        public static Data.ConfigurationDto.Configuration Configuration()
        {
            Data.ConfigurationDto.Configuration result = null;

            try
            {
                string configurationJson = FileHelper.ReadFile(System.AppDomain.CurrentDomain.BaseDirectory + "Configuration.json");

                if (!string.IsNullOrEmpty(configurationJson))
                {
                    result = JsonConvert.DeserializeObject<Data.ConfigurationDto.Configuration>(configurationJson);
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }

        public static void ColdStart()
        {
            for (int i = 1; i <= Program.Configuration.ColdStart.FemalePopulation; i++)
            {
                Program.PoultryHandler.Add(new Data.PoultryDto(){ BirthDate = Program.Date.Date, Pregnant = false, PregnantDate = null, Sex = Data.Enums.PoultrySex.Female});
            }

            for (int i = 1; i <= Program.Configuration.ColdStart.MalePopulation; i++)
            {
                Program.PoultryHandler.Add(new Data.PoultryDto() { BirthDate = Program.Date.Date, Pregnant = false, PregnantDate = null, Sex = Data.Enums.PoultrySex.Male });
            }
        }
    }
}