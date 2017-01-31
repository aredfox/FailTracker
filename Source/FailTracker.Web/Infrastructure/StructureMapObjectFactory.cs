using StructureMap;
using System;
using System.Threading;

namespace FailTracker.Web.Infrastructure
{
    public static class StructureMapObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(
                    CreateDefaultContainer,
                    LazyThreadSafetyMode.ExecutionAndPublication
                );

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container CreateDefaultContainer()
        {
            return new Container();
        }
    }
}