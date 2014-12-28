using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;
using System.Windows;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows.Media;
using System.Windows.Input;
using Hermit.Plugin;
using Hermit.Commands;

namespace Hermit.Settings
{
    [Export(typeof(IPlugin))]
    public class AppearanceSettingsViewModel : SettingsItem
    {
        public AppearanceSettings Appearance { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AppearanceSettingsViewModel()
        {
            this.DisplayName = "Appearance";

            Appearance = new AppearanceSettings();

            this.Appearance.AccentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();

            this.Appearance.ThemeColors = ThemeManager.AppThemes
                                           .Select(a => new ThemeColorData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();
        }

        
    }
}
