using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hermit.Plugin;

namespace Hermit
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Screen
    {
        private const string name = "Hermit";

        private readonly IWindowManager windowManager;

        public Shell PluginShell { get; set; }

        [ImportingConstructor]
        public ShellViewModel()
        {
            this.DisplayName = name;
            windowManager = new WindowManager();
            PluginShell = new Shell();

            PluginManager p = new PluginManager();

            PluginShell = (Shell)p.GetShell();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }

        public void ShowSettings()
        {
            windowManager.ShowWindow(new SettingsViewModel());
        }
    }
}
