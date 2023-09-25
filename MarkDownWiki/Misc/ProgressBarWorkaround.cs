using Avalonia.Controls;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki;

public class ProgressBarWorkaround
{
    public static AvaloniaProperty<double> ValueProperty =
        AvaloniaProperty.RegisterAttached<ProgressBarWorkaround, ProgressBar, double>("Value");

    public static void SetValue(ProgressBar pb, double value) =>
        pb.SetValue(ValueProperty, value);

    static ProgressBarWorkaround()
    {
        ValueProperty.Changed.Subscribe(ev =>
        {
            ((ProgressBar)ev.Sender).Value = ev.NewValue.GetValueOrDefault(100.0d);
        });
    }
}
