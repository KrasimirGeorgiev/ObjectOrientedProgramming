namespace Telerik.Homeworks.OOP.Principles.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double hypotenuse, double height)
            : base(hypotenuse, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = (this.Height * this.Width) / 2;

            return surface;
        }
    }
}
