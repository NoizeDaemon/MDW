using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using DialogHostAvalonia;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace MarkDownWiki.Dialogs.Views;

public partial class PopUpStackMessageView : UserControl
{
    //private string? _dialogHostName;
    //private ItemsRepeater _parentRepeater;

    public PopUpStackMessageView()
    {
        InitializeComponent();
        //RemainingTimeProgressBar.AttachedToVisualTree += OnAttachedToVisualTree;
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        //RemainingTimeProgressBar.AttachedToVisualTree -= OnAttachedToVisualTree;
        //RemainingTimeProgressBar.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(object? sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
    {
        if (e.NewValue <= 0)
        {
            e.Handled = true;
            //RemainingTimeProgressBar.ValueChanged -= OnValueChanged;
        }
    }

}