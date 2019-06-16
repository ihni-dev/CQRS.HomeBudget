using Autofac;

namespace CQRS.HomeBudget.CompositionRoot
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterModules(this ContainerBuilder builder)
        {
            //            builder.RegisterModule(new AutofacModule());

            return builder;
        }
    }
}