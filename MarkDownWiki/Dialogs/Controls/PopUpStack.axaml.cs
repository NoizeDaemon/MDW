using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using DialogHostAvalonia;
using MarkDownWiki.Dialogs.Models;
using MarkDownWiki.Dialogs.ViewModels;
using MarkDownWiki.Dialogs.Views;
using MarkDownWiki.ViewModels;
using Material.Icons;
using Material.Icons.Avalonia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarkDownWiki.Dialogs.Controls;

public partial class PopUpStack : StackPanel
{
    public PopUpStack()
    {
        InitializeComponent();

        _dataTemplates = this.DataTemplates;

        //AddNewInternal("This is the direct input.", MaterialIconKind.Lan);

        var msgVM = new PopUpStackMessageViewModel(new Models.PopUpStackMessage("Passing as ViewModel!"));
        AddNewInternal(msgVM);

        var msgV = new PopUpStackMessageView();
        var msgVM2 = new PopUpStackMessageViewModel(new Models.PopUpStackMessage("Passing as View!"));
        msgV.DataContext = msgVM2;
        AddNewInternal(msgV);

        var msgO = new PopUpStackMessage("Passing as Model!");
        AddNewInternal(msgO);

        
    }

    #region Properties

    public static readonly StyledProperty<string?> IdentifierProperty =
    AvaloniaProperty.Register<PopUpStack, string?>(nameof(Background));

    public string? Identifier
    {
        get => GetValue(IdentifierProperty);
        set => SetValue(IdentifierProperty, value);
    }

    #endregion

    #region Functionality

    private DataTemplates _dataTemplates;

    public static void AddNew(object? content, string? popUpStackIdentifier = null)
    {
        GetInstance(popUpStackIdentifier).AddNewInternal(content);
    }
    
    public static void AddNew(string message, MaterialIconKind icon = MaterialIconKind.InfoBoxOutline, int visibleForSeconds = 5, string? popUpStackIdentifier = null)
    {
        var data = new PopUpStackMessageViewModel(new Models.PopUpStackMessage(message, icon, visibleForSeconds));

        GetInstance(popUpStackIdentifier).AddNewInternal(data);
    }

    private void AddNewInternal(object? content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (content is Control view)
        {
            this.Children.Insert(0, view);
            return;
        }

        if (content is ViewModelBase viewModel)
        {
            var contentPresenter = new ContentControl();
            contentPresenter.Content = viewModel;
            this.Children.Insert(0, contentPresenter);
            return;
        }

        var matchingDataTemplates = _dataTemplates.Where(dt => dt.Match(content)).ToList();
        if (matchingDataTemplates.Count == 1)
        {
            var modelView = matchingDataTemplates[0].Build(content);
            modelView.DataContext = content;
            this.Children.Insert(0, modelView);
            return;
        }
        if (matchingDataTemplates.Count > 1)
        {
            throw new ArgumentException($"Found no distinct match for {nameof(content)} in DataTemplates.");
        }

        throw new ArgumentException($"{nameof(content)} is neither Control nor ViewModelBase.");
    }

    #endregion

        #region Instance-Handling

    private static readonly HashSet<PopUpStack> LoadedInstances = new HashSet<PopUpStack>();

    private static PopUpStack GetInstance(string? popUpStackIdentifier)
    {
        if (LoadedInstances.Count == 0)
        {
            throw new InvalidOperationException("No loaded PopUpStack instances.");
        }

        List<PopUpStack> list = LoadedInstances.Where((PopUpStack ps) => popUpStackIdentifier == null || object.Equals(ps.Identifier, popUpStackIdentifier)).ToList();
        if (list.Count == 0)
        {
            throw new InvalidOperationException($"No loaded PopUpStack have an Identifier property matching popUpStackIdentifier {popUpStackIdentifier} argument.");
        }

        if (list.Count > 1)
        {
            throw new InvalidOperationException("Multiple viable PopUpStacks. Specify a unique Identifier on each PopUpStack, especially where multiple Windows are a concerned.");
        }

        return list[0];
    }


    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        LoadedInstances.Add(this);
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        LoadedInstances.Remove(this);
    }

    #endregion
}