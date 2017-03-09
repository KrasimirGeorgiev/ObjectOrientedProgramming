namespace MobileDevices.GSM.Tests
{
    using System;
    using System.Collections.Generic;
    using MobileDevices;
    using MobileDevices.Parts;

    class GSMCallHistoryTest
    {
        private const decimal pricePerMinute = 0.37m;

        public static void CallTests()
        {
            Console.WriteLine("Creating an instance of GSM");

            var gsm = new GSM("Bazooka",
                            "Razni Imigrantï",
                            new Battery(BatteryCellType.Experimental),
                            new Display("Nai Golemiya", "Resprom", 7.2f, 5000000f));

            Console.WriteLine("\n Generating 3 Calls");

            gsm.AddCall(new Call(DateTime.Now, "0883 45 98 12", TimeSpan.Parse("0:00:5")));
            gsm.AddCall(new Call(DateTime.Now, "0898 12 34 56", TimeSpan.Parse("0:10:0")));
            gsm.AddCall(new Call(DateTime.Now, "0888 01 23 98", TimeSpan.Parse("1:05:15")));

            Console.WriteLine("\nDisplaying Call information: ");
            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call.GetCallInformation());
            }

            Console.WriteLine("Calculation total call price based on {0:C} per minute tariff", pricePerMinute);

            Console.WriteLine("{0:C}",gsm.ReturnAllCallsCosts(pricePerMinute));

            Console.WriteLine("\nRemoving the longest call and recalculation costs");

            gsm.RemoveCall(2);

            Console.WriteLine("{0:C}", gsm.ReturnAllCallsCosts(pricePerMinute));

            Console.WriteLine("Clearing call history");

            gsm.ClearCallHistory();

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call.GetCallInformation());
            }
        }
    }
}
