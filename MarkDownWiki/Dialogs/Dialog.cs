using DialogHostAvalonia;
using MarkDownWiki.Dialogs.Models;
using MarkDownWiki.Dialogs.ViewModels;
using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki.Dialogs;

public static class Dialog
{
    public static void ShowPopStackMessage(string message, MaterialIconKind icon = MaterialIconKind.InformationBoxOutline)
    {
        var msg = new PopUpStackMessage(message, icon);
        var msgVM = new PopUpStackMessageViewModel(msg);

        _ = DialogHost.Show(msgVM, "PopUpStackHost");
    }

    public static void GetOpenDialogHostInstances()
    {
 
    }
}

public enum Result
{
    Confirm,
    Cancel,
    Yes,
    No
}

public class Interactable
{
    public Interactable(string label = "OK", Result result = Result.Confirm)
    {
        Label = label;
        Result = result;
    }

    public string Label { get; }
    public Result Result { get; }
}