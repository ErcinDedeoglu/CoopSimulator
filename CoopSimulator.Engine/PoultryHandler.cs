using System;

namespace CoopSimulator.Engine
{
    public class PoultryHandler
    {
        private static readonly System.Object Locker = new System.Object();

        public void Add(Data.PoultryDto poultry)
        {
            lock (Locker)
            {
                Program.PoultryList.Add(poultry);
            }
        }

        public void Remove(Data.PoultryDto poultry)
        {
            lock (Locker)
            {
                Program.PoultryList.Remove(poultry);
            }
        }

        public void RemoveAll(Predicate<Data.PoultryDto> predicate)
        {
            lock (Locker)
            {
                Program.PoultryList.RemoveAll(predicate);
            }
        }
    }
}