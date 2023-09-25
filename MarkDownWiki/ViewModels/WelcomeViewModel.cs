using Material.Colors;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
       public ReactiveCommand<string, Unit> CopyMaterialBrushCommand { get; set; }

        public WelcomeViewModel()
        {
            CopyMaterialBrushCommand = ReactiveCommand.Create<string>(CopyMaterialBrush);
        }

        private void CopyMaterialBrush(string obj)
        {
            Debug.WriteLine($"TestCommand fired: {obj.ToString()}");
        }
    }
}
