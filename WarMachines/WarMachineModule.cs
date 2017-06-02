namespace WarMachines
{
    using System.Linq;
    using Commands;
    using Enums;
    using Factories;
    using Models;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;
    using Providers;

    public class WarMachineModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPilot>().To<Pilot>();
            Bind<IFighter>().To<Fighter>();
            Bind<ITank>().To<Tank>();

            Bind(typeof(IWriter), typeof(IInputOutputProvider)).To<InputOutputProvider>().InSingletonScope();

            Bind(typeof(IFighterAdder), typeof(IFighterFinder), typeof(ITankFinder), typeof(IPilotAdder), typeof(IPilotFinder),
                typeof(ITankAdder), typeof(IMachineFinder)).To<MachineProvider>().InSingletonScope();

            Bind<IPilotFactory>().ToFactory().InSingletonScope();
            Bind<IFighterFactory>().ToFactory().InSingletonScope();
            Bind<ITankFactory>().ToFactory().InSingletonScope();
            Bind<ICommandFactory>().ToFactory().InSingletonScope();

            Bind<ICommand>().To<AttackCommand>().InSingletonScope();
            Bind<ICommand>().To<DefenseModeCommand>().InSingletonScope();
            Bind<ICommand>().To<EngageCommand>().InSingletonScope();
            Bind<ICommand>().To<HirePilotCommand>().InSingletonScope();
            Bind<ICommand>().To<ManufactureFighterCommand>().InSingletonScope();
            Bind<ICommand>().To<ManufactureTankCommand>().InSingletonScope();
            Bind<ICommand>().To<ReportCommand>().InSingletonScope();
            Bind<ICommand>().To<StealthModeCommand>().InSingletonScope();

            Bind<ICommand>().ToMethod(context =>
            {
                CommandTypes type = (CommandTypes) context.Parameters.First().GetValue(context, null);

                switch (type)
                {
                    case CommandTypes.Attack:
                        return Kernel.Get<AttackCommand>();
                    case CommandTypes.DefenseMode:
                        return Kernel.Get<DefenseModeCommand>();
                    case CommandTypes.Engage:
                        return Kernel.Get<EngageCommand>();
                    case CommandTypes.HirePilot:
                        return Kernel.Get<HirePilotCommand>();
                    case CommandTypes.ManufactureFighter:
                        return Kernel.Get<ManufactureFighterCommand>();
                    case CommandTypes.ManufactureTank:
                        return Kernel.Get<ManufactureTankCommand>();
                    case CommandTypes.Report:
                        return Kernel.Get<ReportCommand>();
                    case CommandTypes.StealthMode:
                        return Kernel.Get<StealthModeCommand>();
                    default:
                        return null;
                }
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(CommandTypes.None));

            Bind<IWarMachineEngine>().To<WarMachineEngine>().InSingletonScope();
        }
    }
}
