using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Hermit.Plugin;

namespace Hermit
{
    public class PluginManager
    {
        [ImportMany]
        private IList<IPlugin> plugins;

        [ImportMany]
        private IList<Shell> shells;

        public PluginManager()
        {
            plugins = new List<IPlugin>();
            shells = new List<Shell>();

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog("./Plugins"));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public IList<T> GetPlugins<T>() where T : IPlugin
        {
            return plugins.OfType<T>().ToList<T>();
        }

        public IShell GetShell()
        {
            if(shells.Count != 0)
            {
                return shells.OfType<Shell>().First();    
            }

            return null;
            
        }
    }
}
