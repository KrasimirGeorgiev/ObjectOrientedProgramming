namespace MobileDevices.Contracts
{
    public interface IManufacturedItem
    {
        int Id { get; }

        string Model { get; }

        string Manufacturer { get; }
    }
}
