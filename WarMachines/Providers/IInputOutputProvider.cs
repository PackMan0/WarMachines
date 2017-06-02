namespace WarMachines.Providers
{
    public interface IInputOutputProvider : IWriter
    {
        string Read();
    }
}
