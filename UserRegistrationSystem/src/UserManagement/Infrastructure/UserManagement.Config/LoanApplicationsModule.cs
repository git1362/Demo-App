using Autofac;
using Framework.Application;
using System.Linq;
using UserManagement.Application;
using UserManagement.Domain;
using UserManagement.Persistence.ES;

namespace UserManagement.Config
{
    public class LoanApplicationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserHandlers).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        }

    }
}