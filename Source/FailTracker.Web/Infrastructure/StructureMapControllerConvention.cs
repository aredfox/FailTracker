using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.Pipeline;
using StructureMap.TypeRules;
using System;
using System.Web.Mvc;

namespace FailTracker.Web.Infrastructure
{
    public class StructureMapControllerConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes()) {
                Process(type, registry);
            }
        }
        private void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract) {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}