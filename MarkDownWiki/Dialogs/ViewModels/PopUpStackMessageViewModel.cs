using AsyncAwaitBestPractices;
using Avalonia.Threading;
using MarkDownWiki.Dialogs.Models;
using MarkDownWiki.ViewModels;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarkDownWiki.Dialogs.ViewModels;

public class PopUpStackMessageViewModel : ViewModelBase
{
    [Reactive] public double Progress { get; set; }

    public PopUpStackMessage Message { get; }

    private CancellationToken _closingCancellationToken;

    //private Progress<double> _progessReport;

    public PopUpStackMessageViewModel(PopUpStackMessage message)
    {
        Message = message;
        //Progress = 100d;

        //CancellationTokenSource tokenSource = new CancellationTokenSource();

        //_closingCancellationToken = tokenSource.Token;
        //var stepSize = Progress / Message.VisibleFor.TotalSeconds;

        //Dispatcher.UIThread.InvokeAsync(() => Close(stepSize), DispatcherPriority.MaxValue);
    }

    private async Task Close(double stepSize)
    {
        await Task.Run(async () =>
        {
            while (Progress > 0)
            {
                await Task.Delay(1000);
                Progress = 0;
                //Progress -= stepSize;
                //progressReport.Report(value);
            }
        });
    }
}
