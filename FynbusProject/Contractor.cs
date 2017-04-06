using System;

namespace FynbusProject
{
    public class Contractor
    {
        public string Number { get; private set; }
        public string CompanyName { get; private set; }
        public string PersonName { get; private set; }
        public string EmailAddress { get; private set; }
        public int TypeV2 { get; private set; }
        public int TypeV3 { get; private set; }
        public int TypeV5 { get; private set; }
        public int TypeV6 { get; private set; }
        public int TypeV7 { get; private set; }

        public int GetAmountOfVehicleOfType(int vehType)
        {
            int value = 0;
            switch (vehType)
            {
                case 2:
                    value = TypeV2;
                    break;
                case 3:
                    value = TypeV3;
                    
                    break;
                case 5:
                    value = TypeV5;
                    break;
                case 6:
                    value = TypeV6;
                    break;
                case 7:
                    value = TypeV7;
                    break;
                default:
                    value = 0;
                    break;
            }
            // Returns amout of vehicles left from the Vehtype that was passed
            return value;
        }

        public void DecrementAmountOfVehicleOfType(int vehType)
        {
            switch (vehType)
            {
                case 2:
                    TypeV2--;
                    break;
                case 3:
                    TypeV3--;
                    break;
                case 5:
                    TypeV5--;
                    break;
                case 6:
                    TypeV6--;
                    break;
                case 7:
                    TypeV7--;
                    break;
            }
        }

        public Contractor(string number, string compName, string persName, string email, int t2, int t3, int t5, int t6, int t7)
        {
            Number = number;
            CompanyName = compName;
            PersonName = persName;
            EmailAddress = email;
            TypeV2 = t2;
            TypeV3 = t3;
            TypeV5 = t5;
            TypeV6 = t6;
            TypeV7 = t7;
        }

        public override string ToString()
        {
            return Number + " " + CompanyName + " " + PersonName + " " + EmailAddress + " " + TypeV2 + " " + TypeV3 + " " + TypeV5 + " " + TypeV6 + " " + TypeV7;
        }
    }
}
