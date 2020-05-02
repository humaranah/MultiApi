using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiApi.Application.Helpers
{
    public static class ModulesIntegrationHelper
    {
        public static IEnumerable<TDefinition> FindInstancesOf<TDefinition>()
        {
            var moduleAssemblies = AssemblyLoader.LoadDependentAssemblies("MultiApi.Module");

            foreach (var moduleAssembly in moduleAssemblies)
            {
                var baseType = typeof(TDefinition);
                var implementation = moduleAssembly.GetTypes()
                    .Where(type => type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
                    .SingleOrDefault();

                if (implementation != null)
                {
                    yield return (TDefinition)Activator.CreateInstance(implementation);
                }
            }
        }
    }
}
