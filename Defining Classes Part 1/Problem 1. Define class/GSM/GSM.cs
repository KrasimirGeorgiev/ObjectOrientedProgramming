namespace MobileDevices.GSM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Parts;

    public class GSM : FactoryProduct
    {
        private string owner;

        private static int currentId = 1;

        private static readonly GSM Iphone4s;

        static GSM()
        {
            Iphone4s = new GSM("Iphone 4s",
                                "Apple",
                                new Battery("2550mAh", "Samsung", BatteryCellType.LiIon),
                                new Display("Xreality", "Sony", 4.3f, 16e6f));
        }

        public GSM(string model, string manufacturer)
            : base(model, manufacturer)
        {
            this.Id = currentId++;
            this.Owner = "Store";
            this.Battery = new Battery();
            this.Display = new Display();
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model can't be empty");
                }

                this.owner = value;
            }
        }

        public decimal Price { get; set; }

        public Battery Battery { get; private set; }

        public Display Display { get; set; }

        public List<Call> CallHistory { get; private set; }

        public static GSM Iphone4S => Iphone4s;

        public void ChangeOwner(string newOwner)
        {
            this.Owner = newOwner;
        }

        public void SwichBattery(GSM mobile2)
        {
            var mobile1Bat = this.TakeOutBattery();
            var mobile2Bat = mobile2.TakeOutBattery();

            this.Battery = mobile2Bat;
            mobile2.Battery = mobile1Bat;
        }

        public Battery SwichBattery(Battery bat)
        {
            var old = this.TakeOutBattery();
            this.Battery = bat;

            return old;
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            int index = this.CallHistory.IndexOf(call);

            if (index != -1)
            {
                this.CallHistory.RemoveAt(index);
            }
            else
            {
                throw new KeyNotFoundException("No such call in the call history");
            }
        }

        public void RemoveCall(int index)
        {
            if (index > 0 && index < this.CallHistory.Count)
            {
                this.CallHistory.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal ReturnAllCallsCosts(decimal pricePerMinute)
        {
            TimeSpan totalDuration = new TimeSpan(0, 0, 0);

            foreach (var call in this.CallHistory)
            {
                totalDuration += call.CallDuration;
            }

            return ((totalDuration.Hours * 60) + totalDuration.Minutes) * pricePerMinute;
        }

        public override string ToString()
        {
            const string standardFormat = "{0}: {1}\n";
            const string indentFormat = "\t\t" + standardFormat;

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("********** GSM ***********************");
            strBuilder.AppendFormat(standardFormat, "Id", this.Id);
            strBuilder.AppendFormat(standardFormat, "Model", this.Model);
            strBuilder.AppendFormat(standardFormat, "Manufacturer", this.Manufacturer);
            strBuilder.AppendLine($"Price: {this.Price:C}");
            strBuilder.AppendFormat(standardFormat, "Owner", this.Owner);
            strBuilder.AppendLine();

            strBuilder.AppendLine("\tBattery");
            strBuilder.AppendFormat(indentFormat, "Id", this.Battery.Id);
            strBuilder.AppendFormat(indentFormat, "Model", this.Battery.Model);
            strBuilder.AppendFormat(indentFormat, "Manufacturer", this.Battery.Manufacturer);
            strBuilder.AppendFormat(indentFormat, "Cell Type", this.Battery.CellType);
            strBuilder.AppendLine($"\t\tStandby Time: {this.Battery.HoursIdle}h");
            strBuilder.AppendLine($"\t\tTalk Time: {this.Battery.HoursTalk}h");

            strBuilder.AppendLine("\tDisplay");
            strBuilder.AppendFormat(indentFormat, "Id", this.Display.Id);
            strBuilder.AppendFormat(indentFormat, "Model", this.Display.Model);
            strBuilder.AppendFormat(indentFormat, "Manufacturer", this.Display.Manufacturer);
            strBuilder.AppendLine($"\t\tSize: {this.Display.Size}in");
            strBuilder.AppendLine($"\t\tCollors: {this.Display.NumberOfColors / 1000000f:F1}M");

            strBuilder.Append("**************************************");

            return strBuilder.ToString();
        }

        private Battery TakeOutBattery()
        {
            var bat = this.Battery;
            this.Battery = null;

            return bat;
        }
    }
}
