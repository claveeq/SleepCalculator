using System;
using System.Collections.Generic;

namespace SleepCalculator
{
    class SleepTime
    {
        DateTime _dateTime;
        List<DateTime> _suggestedTimeList;

        public SleepTime(DateTime time)
        {
            _dateTime = time;
            _suggestedTimeList = new List<DateTime>();
        }

        internal List<DateTime> SuggestedAlarms()
        {
            _suggestedTimeList.Clear();
            DateTime time;
            for(int i = 1; i <= 6; i++)
            {
                if(i == 1)
                    time = _dateTime.AddHours(1 * i).AddMinutes(44 * i);
                else
                    time = _dateTime.AddHours(1 * i).AddMinutes(30 * i).AddMinutes(14);
                _suggestedTimeList.Add(time);
            }
            return _suggestedTimeList;
        }

        internal List<DateTime> SpecificAlarms(DateTime dateTime)
        {
            _suggestedTimeList.Clear();
            DateTime time;
            for(int i = 1; i <= 6; i++)
            {
                if(i == 1)
                    time = dateTime.AddHours(-1 * i).AddMinutes(-44 * i);
                else
                    time = dateTime.AddHours(-1 * i).AddMinutes(-30 * i).AddMinutes(14);
                _suggestedTimeList.Add(time);
            }
            return _suggestedTimeList;
        }
    }
}