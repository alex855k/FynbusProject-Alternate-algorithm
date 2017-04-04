using System.Collections.Generic;

namespace FynbusProject
{
    public class AvaliableHours
    {

        private static AvaliableHours _instance = null;

        public static AvaliableHours Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AvaliableHours();
                }
                return _instance;

            }
        }

        public static Dictionary<int, RouteAvaliableHours> routesAvaliableHours = new Dictionary<int, RouteAvaliableHours>();

        private AvaliableHours()
        {
           InitializeData();
        }

        private void InitializeData()
        {
            //Inputting available hours for different routes
            routesAvaliableHours.Add(1, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 0,
                AvaliabilityPeriodWeekDays = 9,
                AvaliabilityPeriodHolidays = 0
            });

            routesAvaliableHours.Add(2, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 0
            });

            routesAvaliableHours.Add(3, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 3,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 0
            });

            routesAvaliableHours.Add(4, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 11,
                AvaliabilityPeriodWeekDays = 15,
                AvaliabilityPeriodHolidays = 11
            });

            routesAvaliableHours.Add(5, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 6,
                AvaliabilityPeriodHolidays = 0
            });

            routesAvaliableHours.Add(6, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 6,
                AvaliabilityPeriodHolidays = 6
            });

            routesAvaliableHours.Add(7, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 10,
                AvaliabilityPeriodHolidays = 4
            });

            routesAvaliableHours.Add(8, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 6
            });

            routesAvaliableHours.Add(9, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 7,
                AvaliabilityPeriodWeekDays = 8,
                AvaliabilityPeriodHolidays = 2
            });

            routesAvaliableHours.Add(10, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 14,
                AvaliabilityPeriodHolidays = 3
            });

            routesAvaliableHours.Add(11, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 10
            });

            routesAvaliableHours.Add(12, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 6
            });

            routesAvaliableHours.Add(13, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 5,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 5
            });

            routesAvaliableHours.Add(14, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 8,
                AvaliabilityPeriodWeekDays = 13,
                AvaliabilityPeriodHolidays = 4
            });

            routesAvaliableHours.Add(15, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 8,
                AvaliabilityPeriodHolidays = 1
            });

            routesAvaliableHours.Add(16, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 18,
                AvaliabilityPeriodHolidays = 6
            });

            routesAvaliableHours.Add(17, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 3
            });

            routesAvaliableHours.Add(18, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 6,
                AvaliabilityPeriodWeekDays = 12,
                AvaliabilityPeriodHolidays = 3
            });

            routesAvaliableHours.Add(19, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 7,
                AvaliabilityPeriodWeekDays = 15,
                AvaliabilityPeriodHolidays = 6
            });

            routesAvaliableHours.Add(20, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 2
            });

            routesAvaliableHours.Add(21, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 7
            });

            routesAvaliableHours.Add(22, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 5,
                AvaliabilityPeriodWeekDays = 7,
                AvaliabilityPeriodHolidays = 2
            });

        }


        public int GetAvaliableHours(int routeNumber)
        {
            // Calculates the needed hours on that specific route object
            return routesAvaliableHours[routeNumber].AmountOfHoursContractPeriod();
        }
    }
}
