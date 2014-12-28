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

        public PluginManager()
        {
            plugins = new List<IPlugin>();

            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public IList<T> GetPlugins<T>() where T : IPlugin
        {
            return plugins.OfType<T>().ToList<T>();
        }
    }
}
