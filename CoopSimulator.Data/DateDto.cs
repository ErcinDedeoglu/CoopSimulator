using System;
using CoopSimulator.Helper;

namespace CoopSimulator.Data
{
    public class DateDto
    {
        private readonly Enums.DatePeriod _datePeriod;
        private readonly int _datePeriodValue;
        private readonly EventHandler _datePeriodTriggered = null;
        private static DateTime _date;
        private static DateTime _lastTriggeredDate;

        public DateDto(Enums.DatePeriod datePeriod, int datePeriodValue, EventHandler datePeriodTriggered)
        {
            _datePeriodTriggered = datePeriodTriggered;
            _datePeriod = datePeriod;
            _datePeriodValue = datePeriodValue;
        }

        public System.DateTime Date
        {
            get { return _date; }
            set
            {
                if (!_date.Equals(new DateTime()))
                {
                    if (_datePeriod == Enums.DatePeriod.Day && (value - _lastTriggeredDate).TotalDays >= _datePeriodValue)
                    {
                        _lastTriggeredDate = value;
                        _datePeriodTriggered?.Invoke(null, null);
                    }
                    else if (_datePeriod == Enums.DatePeriod.Week && DateHelper.WeekDifferenceBetweenTwoDate(_lastTriggeredDate, value) >= _datePeriodValue)
                    {
                        _lastTriggeredDate = value;
                        _datePeriodTriggered?.Invoke(null, null);
                    }
                    else if (_datePeriod == Enums.DatePeriod.Month && DateHelper.MonthDifferenceBetweenTwoDate(value, _lastTriggeredDate) >= _datePeriodValue)
                    {
                        _lastTriggeredDate = value;
                        _datePeriodTriggered?.Invoke(null, null);
                    }
                    else if (_datePeriod == Enums.DatePeriod.Year && DateHelper.YearDifferenceBetweenTwoDate(_lastTriggeredDate, value) >= _datePeriodValue)
                    {
                        _lastTriggeredDate = value;
                        _datePeriodTriggered?.Invoke(null, null);
                    }
                }

                _date = value;
            }
        }
    }
}