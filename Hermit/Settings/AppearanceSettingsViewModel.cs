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
        private List<AccentColorData> accentColors;

        private List<ThemeColorData> themeColors;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AppearanceSettingsViewModel()
        {
            this.DisplayName = "Appearance";

            this.accentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();

            this.themeColors = ThemeManager.AppThemes
                                           .Select(a => new ThemeColorData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();
        }

        /// <summary>
        /// List of all accent colors supported by MahApps.Metro
        /// </summary>
        public List<AccentColorData> AccentColors
        {
            get { return accentColors; }
            set
            {
                if (value != accentColors)
                {
                    accentColors = value;
                    NotifyOfPropertyChange(() => AccentColors);
                }
            }
        }

        public List<ThemeColorData> ThemeColors
        {
            get { return themeColors; }
            set
            {
                if (value != themeColors)
                {
                    themeColors = value;
                    NotifyOfPropertyChange(() => ThemeColors);
                }
            }
        }

        /// <summary>
        /// Change the theme to the Dark Theme
        /// </summary>
        public void SetThemeDark()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, theme.Item1);
        }

        /// <summary>
        /// Change the theme to the Light Theme
        /// </summary>
        public void SetThemeLight()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, theme.Item1);
        }
    }

    public abstract class ColorData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeColorCommand;

        public ICommand ChangeColorCommand
        {
            get
            {
                return this.changeColorCommand ?? (changeColorCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeColor(x) });
            }
        }

        public virtual void DoChangeColor(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }

    public class AccentColorData : ColorData
    {

    }

    public class ThemeColorData : ColorData
    {
        public override void DoChangeColor(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }
}
