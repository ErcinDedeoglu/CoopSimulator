using System.Runtime.Serialization;

namespace CoopSimulator.Data
{
    public class Enums
    {
        public enum PoultrySex
        {
            Female = 1,
            Male = 2
        }

        public enum DatePeriod
        {
            [EnumMember(Value = "day")]
            Day = 1,
            [EnumMember(Value = "week")]
            Week = 2,
            [EnumMember(Value = "month")]
            Month = 3,
            [EnumMember(Value = "year")]
            Year = 4
        }
    }
}