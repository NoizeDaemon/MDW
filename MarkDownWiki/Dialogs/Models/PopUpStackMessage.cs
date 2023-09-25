using Material.Icons;
using Material.Icons.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki.Dialogs.Models;

public class PopUpStackMessage
{

    public PopUpStackMessage(string text, MaterialIconKind icon = MaterialIconKind.InfoBoxOutline, int visibleForSeconds = 5)
    {
        Text = text;
        Icon = icon;
        VisibleFor = new TimeSpan(0, 0, visibleForSeconds);
    }

    public string Text { get; }
    public MaterialIconKind Icon { get; }
    public TimeSpan VisibleFor { get; }
    public string IconName() => Enum.GetName(Icon)!;
}
