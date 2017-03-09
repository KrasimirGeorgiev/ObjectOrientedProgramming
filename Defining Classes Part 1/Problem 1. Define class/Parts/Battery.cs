namespace MobileDevices.Parts
{
    using System;

    public class Battery : FactoryProduct
    {
        private static int currentId = 1;
        private BatteryCellType cellType;

        private static Random rnd = new Random();

        public Battery(string model = "generic", string manufacturer = "generic")
            : base(model, manufacturer)
        {
            this.Id = currentId++;
            this.CellType = (BatteryCellType)rnd.Next(0, 5);
        }

        public Battery(BatteryCellType cell)
            : this()
        {
            this.CellType = cell;
        }

        public Battery(string model, string manufacturer, BatteryCellType cell)
            : this(model, manufacturer)
        {
            this.CellType = cell;
        }

        public float HoursIdle { get; private set; }

        public float HoursTalk { get; private set; }

        public BatteryCellType CellType
        {
            get
            {
                return this.cellType;
            }
            private set
            {
                switch (value)
                {
                    case BatteryCellType.LiIon:
                        this.HoursIdle = 340;
                        this.HoursTalk = 120;
                        break;
                    case BatteryCellType.LiIonPolymer:
                        this.HoursIdle = 380;
                        this.HoursTalk = 140;
                        break;
                    case BatteryCellType.NiCd:
                        this.HoursIdle = 200.5f;
                        this.HoursTalk = 99.9f;
                        break;
                    case BatteryCellType.NiMH:
                        this.HoursIdle = 265;
                        this.HoursTalk = 130;
                        break;
                    case BatteryCellType.Experimental:
                        this.HoursIdle = rnd.Next(0, 1101);
                        this.HoursTalk = rnd.Next(0, (int)this.HoursIdle);
                        break;
                    default:
                        throw new ArgumentException("Invalid Cell Type");
                }

                this.cellType = value;
            }
        }
    }
}
