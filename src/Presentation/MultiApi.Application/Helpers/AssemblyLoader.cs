using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MultiApi.Application.Helpers
{
    public static class AssemblyLoader
    {
        public static List<Assembly> LoadDependentAssemblies(string startsWithName)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith(startsWithName))
                .ToList();

            var loadedPaths = loadedAssemblies.Select(assembly => assembly.Location).ToArray();
            var refPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{startsWithName}*.dll");

            var toLoad = refPaths
                .Where(path => !loadedPaths.Contains(path, StringComparer.OrdinalIgnoreCase));

            foreach (var path in toLoad)
            {
                loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
            }

            return loadedAssemblies;
        }
    }
}
