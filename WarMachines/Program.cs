namespace WarMachines
{
    using Ninject;

    public class Program
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new WarMachineModule());

            IWarMachineEngine engine = kernel.Get<IWarMachineEngine>();
            engine.Start();
        }
    }
}
