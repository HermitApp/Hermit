using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hermit.Plugin;

namespace Hermit
{
    public class SettingsViewModel : Screen
    {
        private PluginManager plugins;
        private List<ISettingsItem> _PluginSettings = new List<ISettingsItem>();

        public List<ISettingsItem> PluginSettings
        {
            get { return _PluginSettings; }
            set
            {
                _PluginSettings = value;
            }
        }

        public SettingsViewModel()
        {
            this.DisplayName = "Settings";
            plugins = new PluginManager();
            _PluginSettings = plugins.GetPlugins<IPlugin>().ToList<IPlugin>().Select(plug => plug.Settings).ToList<ISettingsItem>();
        }

    }
}
