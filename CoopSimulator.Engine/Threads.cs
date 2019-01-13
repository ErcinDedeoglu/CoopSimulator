using System;
using System.Collections.Generic;
using System.Linq;
using CoopSimulator.Helper;

namespace CoopSimulator.Engine
{
    public class Threads
    {
        public Threads()
        {
            Util.ColdStart();
            ThreadHelper.ExecuteThread(Date);
        }

        public void Date()
        {
            while (true)
            {
                Program.Date.Date = Program.Date.Date.AddDays(1);

                #region Mating

                List<Data.PoultryDto> possibleFemalePoultryList = Program.PoultryList.Where(a => !a.Pregnant && a.Sex == Data.Enums.PoultrySex.Female && (Program.Date.Date-a.BirthDate).TotalDays >= Program.Configuration.PoultryDetail.AdolescenceAge.FemaleAge && (Program.Date.Date - a.BirthDate).TotalDays < Program.Configuration.PoultryDetail.OldAge.Value).ToList();

                if (possibleFemalePoultryList.Any())
                {
                    Data.PoultryDto malePoultry = Program.PoultryList.FirstOrDefault(a => a.Sex == Data.Enums.PoultrySex.Male && (Program.Date.Date - a.BirthDate).TotalDays >= Program.Configuration.PoultryDetail.AdolescenceAge.MaleAge);

                    if (malePoultry != null)
                    {
                        possibleFemalePoultryList.ToList().ForEach(a =>
                        {
                            a.Pregnant = true;
                            a.PregnantDate = Program.Date.Date;
                        });
                    }
                }
                #endregion

                #region Birth
                List<Data.PoultryDto> femalePoultryList = Program.PoultryList.Where(a => a.Pregnant && a.PregnantDate != null && (Program.Date.Date - (DateTime)a.PregnantDate).TotalDays >= Program.Configuration.PoultryDetail.DurationOfPregnancy.Value).ToList();

                foreach (Data.PoultryDto poultry in femalePoultryList)
                {
                    int babyCount = RandomHelper.Number(Program.Configuration.PoultryDetail.NumberOfBabiesForEachPregnancy.Low, Program.Configuration.PoultryDetail.NumberOfBabiesForEachPregnancy.High);

                    for (int i = 1; i <= babyCount; i++)
                    {
                        Data.Enums.PoultrySex poultrySex = Data.Enums.PoultrySex.Female;

                        if (RandomHelper.Number(1, 100) > 60)
                        {
                            poultrySex = Data.Enums.PoultrySex.Male;
                        }

                        Program.PoultryHandler.Add(new Data.PoultryDto()
                        {
                            Pregnant = false,
                            BirthDate = Program.Date.Date,
                            PregnantDate = null,
                            Sex = poultrySex
                        });
                    }

                    poultry.Pregnant = false;
                }
                #endregion

                #region Death
                Program.PoultryHandler.RemoveAll(a => (Program.Date.Date - a.BirthDate).TotalDays >= Program.Configuration.PoultryDetail.MaxAge.Value);
                #endregion
            }
        }
    }
}