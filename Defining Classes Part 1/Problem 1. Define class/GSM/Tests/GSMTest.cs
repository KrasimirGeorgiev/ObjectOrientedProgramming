namespace MobileDevices.GSM.Tests
{
    using System;
    using System.Collections.Generic;
    using Parts;

    public class GSMTest
    {
        public static void MainTest()
        {
            List<GSM> testCandidates = GenerateInstances();

            var swap = new Battery("Yaha", "Vartar", BatteryCellType.LiIonPolymer);

            testCandidates[1].SwichBattery(swap);

            foreach (var phone in testCandidates)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine($"\nAnd now the benchmark:\n\n {GSM.Iphone4S}");
        }

        private static List<GSM> GenerateInstances()
        {
            var mobiles = new List<GSM>();
            for (int i = 0; i < 5; i++)
            {
                var prototypeGsm = new GSM("S Fenerche", "Stony");
                prototypeGsm.SwichBattery(new Battery("Alkanie", "Toshoba"));
                mobiles.Add(prototypeGsm);
            }

            return mobiles;
        }
    }
}
