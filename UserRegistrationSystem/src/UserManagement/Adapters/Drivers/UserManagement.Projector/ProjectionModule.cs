using Autofac;
using Framework.Core.Events;
using Framework.Persistence.ES;
using LoanManagement.Projections.Sql.Handlers;
using LoanManagement.Projections.Sql.Handlers.Model;
using System.Linq;

using UserManagement.Projector.Framework;

namespace UserManagement.Projector
{
    public class ProjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacEventBus>().As<IEventBus>();
            builder.RegisterType<FakeCursor>().As<ICursor>();
            builder.RegisterType<EventTypeResolver>().As<IEventTypeResolver>();
            builder.RegisterGenericDecorator(typeof(CursorAwareHandler<>), typeof(IEventHandler<>));

            //**********--------------

            builder.RegisterAssemblyTypes(typeof(UserRegisteredHandler).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IEventHandler<>))))
                .InstancePerLifetimeScope();
            builder.Register(a => new UsersContext()).InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
