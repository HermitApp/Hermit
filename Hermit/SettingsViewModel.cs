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
        private List<ISettingsItem> _Settings = new List<ISettingsItem>();

        public List<ISettingsItem> Settings
        {
            get { return _Settings; }
            set
            {
                _Settings = value;
            }
        }

        public SettingsViewModel()
        {
            this.DisplayName = "Settings";
            plugins = new PluginManager();
            _Settings = plugins.GetPlugins<ISettingsItem>().ToList<ISettingsItem>();
        }

    }
}
