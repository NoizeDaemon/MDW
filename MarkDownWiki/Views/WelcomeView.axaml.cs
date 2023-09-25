using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using DialogHostAvalonia;
using MarkDownWiki.Dialogs;
using MarkDownWiki.Dialogs.Models;
using MarkDownWiki.Dialogs.ViewModels;
using Material.Icons;
using Material.Icons.Avalonia;
using System.Linq;

namespace MarkDownWiki.Views;

public partial class WelcomeView : UserControl
{
    public WelcomeView()
    {
        InitializeComponent();

        var buttons = BrushCopyStackPanel.GetVisualChildren().Where(x => x is Button);

        foreach (var button in buttons) ((Control)button).AddHandler(PointerPressedEvent, OnBrushButtonPointerPressed, RoutingStrategies.Tunnel);
    }

    private async void OnBrushButtonPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is not Button button) return;
        if (string.IsNullOrEmpty(button?.Tag?.ToString())) return;

        var brushname = button!.Tag.ToString();
        var topLevel = TopLevel.GetTopLevel(button);

        await topLevel!.Clipboard!.SetTextAsync(brushname);

        Dialog.ShowPopStackMessage($"'{brushname}' copied to clipboard!", MaterialIconKind.ContentCopy);

    }
}