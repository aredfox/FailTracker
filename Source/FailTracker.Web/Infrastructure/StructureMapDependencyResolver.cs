using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FailTracker.Web.Infrastructure
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {

        public object GetService(Type serviceType)
        {
            if (serviceType == null) { return null; }

            return serviceType.IsAbstract || serviceType.IsInterface
                ? StructureMapObjectFactory.Container.TryGetInstance(serviceType)
                : StructureMapObjectFactory.Container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return StructureMapObjectFactory.Container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}