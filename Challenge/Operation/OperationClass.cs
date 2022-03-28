using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Operation
{
    public class OperationClass
    {
        public static List<Premium> getPremium(string plan, string state, string dateOfBirth, int age)
        {
            var monthOfBirth = Convert.ToDateTime(dateOfBirth);

            var premium=  evaluateByPlan(plan, state.Trim(), monthOfBirth.Month, age);

            return premium;
        }

        private static List<Premium> evaluateByPlan(string plan, string state, int monthOfBirth, int age)
        {
            var premiumList = new List<Premium>();

           if(plan == "A" || plan == "C")
            {
                
                if (age >= 18 && age <= 65)
                {
                    if (state == "NY")
                    {
                        premiumList.Add(new Premium("Qwerty", 120.99));
                    } 

                    premiumList.Add(new Premium("Qwerty", 90.00));

                    premiumList.Add(new Premium("", 89.99));
                }

            }

           if(plan == "B" || plan == "C")
            {
                if (state == "AK")
                {
                    if (age >= 18 && age <= 65)
                    {
                        premiumList.Add(new Premium("Qwerty", 120.99));
                    }
                }
            }

           if (plan == "A")
            {
                if(state == "NY")
                {
                    if(monthOfBirth == 9 && age >= 21 && age <= 45)
                    {
                        premiumList.Add(new Premium("Qwerty", 150.00));
                    }

                    if (age >= 18 && age <= 65)
                    {
                        premiumList.Add(new Premium("Asdf", 129.95));
                    }

                }

                if (state == "AL")
                {
                    if (monthOfBirth == 11 && age >= 18 && age <= 65)
                    {
                        premiumList.Add(new Premium("Asdf", 84.5));
                        premiumList.Add( new Premium("Qwerty", 85.5));
                    }

                }
                if (state == "AK")
                {
                    if (monthOfBirth == 12 )
                    {
                        if (age >= 65 && age <= 120)
                        {
                            premiumList.Add( new Premium("Qwerty", 175.20));
                        }
                        if (age >= 18 && age <= 64)
                        {
                            premiumList.Add( new Premium("Qwerty", 125.16));
                        }

                    }

                }

            }
            if (plan == "B")
            {
                if (state == "NY")
                {
                    if (monthOfBirth == 1 && age >= 46 && age <= 65)
                    {
                        premiumList.Add( new Premium("Qwerty", 200.50));
                        premiumList.Add( new Premium("Adfs", 184.50));
                    }

                }
                if(state == "WY") {
                    if (age >= 18 && age <= 65)
                    {
                        premiumList.Add(new Premium("Qwerty", 100.00));
                    }

                }
                if (state == "AK")
                {
                    if (age >= 18 && age <= 65)
                    {
                        premiumList.Add( new Premium("Qwerty", 100.80));
                    }

                }
            }
            if (plan == "C")
            {

                if (state == "AL")
                {
                    if ( age >= 18 && age <= 65)
                    {
                        premiumList.Add( new Premium("Qwerty", 100.00));
                    }

                }
            }

            return premiumList;

        }

        public static string[] getStates()
        {
            return new string[] { "AK - Alaska",
                "AL - Alabama",
                "AR - Arkansas",
                "AS - American Samoa",
                "AZ - Arizona",
                "CA - California",
                "CO - Colorado",
                "CT - Connecticut",
                "DC - District of Columbia",
                "DE - Delaware",
                "FL - Florida",
                "GA - Georgia",
                "GU - Guam",
                "HI - Hawaii",
                "IA - Iowa",
                "ID - Idaho",
                "IL - Illinois",
                "IN - Indiana",
                "KS - Kansas",
                "KY - Kentucky",
                "LA - Louisiana",
                "MA - Massachusetts",
                "MD - Maryland",
                "ME - Maine",
                "MI - Michigan",
                "MN - Minnesota",
                "MO - Missouri",
                "MS - Mississippi",
                "MT - Montana",
                "NC - North Carolina",
                "ND - North Dakota",
                "NE - Nebraska",
                "NH - New Hampshire",
                "NJ - New Jersey",
                "NM - New Mexico",
                "NV - Nevada",
                "NY - New York",
                "OH - Ohio",
                "OK - Oklahoma",
                "OR - Oregon",
                "PA - Pennsylvania",
                "PR - Puerto Rico",
                "RI - Rhode Island",
                "SC - South Carolina",
                "SD - South Dakota",
                "TN - Tennessee",
                "TX - Texas",
                "UT - Utah",
                "VA - Virginia",
                "VI - Virgin Islands",
                "VT - Vermont",
                "WA - Washington",
                "WI - Wisconsin",
                "WV - West Virginia",
                "WY - Wyoming" };
        }
    }
}