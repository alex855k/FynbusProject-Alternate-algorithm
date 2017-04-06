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

        public static Dictionary<int, RouteAvaliableHours> RoutesAvaliableHours = new Dictionary<int, RouteAvaliableHours>();

        private AvaliableHours()
        {
           InitializeData();
        }

        private void InitializeData()
        {
            //Inputting available hours for different routes
            RoutesAvaliableHours.Add(1, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 0,
                AvaliabilityPeriodWeekDays = 9,
                AvaliabilityPeriodHolidays = 0
            });

            RoutesAvaliableHours.Add(2, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 0
            });

            RoutesAvaliableHours.Add(3, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 3,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 0
            });

            RoutesAvaliableHours.Add(4, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 11,
                AvaliabilityPeriodWeekDays = 15,
                AvaliabilityPeriodHolidays = 11
            });

            RoutesAvaliableHours.Add(5, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 6,
                AvaliabilityPeriodHolidays = 0
            });

            RoutesAvaliableHours.Add(6, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 6,
                AvaliabilityPeriodHolidays = 6
            });

            RoutesAvaliableHours.Add(7, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 10,
                AvaliabilityPeriodHolidays = 4
            });

            RoutesAvaliableHours.Add(8, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 6
            });

            RoutesAvaliableHours.Add(9, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 7,
                AvaliabilityPeriodWeekDays = 8,
                AvaliabilityPeriodHolidays = 2
            });

            RoutesAvaliableHours.Add(10, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 14,
                AvaliabilityPeriodHolidays = 3
            });

            RoutesAvaliableHours.Add(11, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 10
            });

            RoutesAvaliableHours.Add(12, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 6
            });

            RoutesAvaliableHours.Add(13, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 5,
                AvaliabilityPeriodWeekDays = 11,
                AvaliabilityPeriodHolidays = 5
            });

            RoutesAvaliableHours.Add(14, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 8,
                AvaliabilityPeriodWeekDays = 13,
                AvaliabilityPeriodHolidays = 4
            });

            RoutesAvaliableHours.Add(15, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 2,
                AvaliabilityPeriodWeekDays = 8,
                AvaliabilityPeriodHolidays = 1
            });

            RoutesAvaliableHours.Add(16, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 18,
                AvaliabilityPeriodHolidays = 6
            });

            RoutesAvaliableHours.Add(17, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 3
            });

            RoutesAvaliableHours.Add(18, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 6,
                AvaliabilityPeriodWeekDays = 12,
                AvaliabilityPeriodHolidays = 3
            });

            RoutesAvaliableHours.Add(19, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 7,
                AvaliabilityPeriodWeekDays = 15,
                AvaliabilityPeriodHolidays = 6
            });

            RoutesAvaliableHours.Add(20, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 9,
                AvaliabilityPeriodWeekDays = 17,
                AvaliabilityPeriodHolidays = 2
            });

            RoutesAvaliableHours.Add(21, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 10,
                AvaliabilityPeriodWeekDays = 16,
                AvaliabilityPeriodHolidays = 7
            });

            RoutesAvaliableHours.Add(22, new RouteAvaliableHours()
            {
                AvaliabilityPeriodWeekends = 5,
                AvaliabilityPeriodWeekDays = 7,
                AvaliabilityPeriodHolidays = 2
            });

        }


        public int GetAvaliableHours(int routeNumber)
        {
            // Calculates the needed hours on that specific route object
            return RoutesAvaliableHours[routeNumber].AmountOfHoursContractPeriod();
        }
    }
}
