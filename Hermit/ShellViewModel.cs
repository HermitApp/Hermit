using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hermit
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Screen
    {
        private const string name = "Hermit";

        private readonly IWindowManager windowManager;

        [ImportingConstructor]
        public ShellViewModel()
        {
            this.DisplayName = name;
            windowManager = new WindowManager();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }


    }
}
