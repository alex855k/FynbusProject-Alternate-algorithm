namespace FynbusProject
{
    public class RouteAvaliableHours
    {
        //Amount of hoAurs that the flex vehicle is avaliable during a normal week day
        public int AvaliabilityPeriodWeekDays { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a day in the weekend 
        public int AvaliabilityPeriodWeekends { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a day that's a holiday
        public int AvaliabilityPeriodHolidays { get; set; }

        // Amount of days for 2-year period
        private static int AmountOfHolidays = 14 * 2;
        private static int AmountOfWeekDays = 261 * 2;
        private static int AmountOfWeekendsDays = 100 * 2;
        
        public int AmountOfHoursContractPeriod()
        {
            //Calculates the available hours needed for a specific route object
            return ((AvaliabilityPeriodWeekDays * AmountOfWeekDays) +
                   (AvaliabilityPeriodHolidays * AmountOfHolidays) +
                   (AvaliabilityPeriodWeekends * AmountOfWeekendsDays));
        }

    }
}
