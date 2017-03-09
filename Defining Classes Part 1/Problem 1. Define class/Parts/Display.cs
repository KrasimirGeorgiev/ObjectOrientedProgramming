namespace MobileDevices.Parts
{
    public class Display : FactoryProduct
    {
        private static int currentId = 1;

        public Display(string model = "generic", string manufacturer = "generic")
            : base(model, manufacturer)
        {
            this.Id = currentId++;
            this.NumberOfColors = 160000;
            this.Size = 4.2f;
        }

        public Display(string model, string manufacturer, float size, float colors)
            : this(model, manufacturer)
        {
            this.NumberOfColors = colors;
            this.Size = size;
        }

        public float Size { get; private set; }

        public float NumberOfColors { get; private set; }
    }
}
