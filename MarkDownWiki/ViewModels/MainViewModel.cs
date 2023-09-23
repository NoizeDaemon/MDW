using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Reactive;

namespace MarkDownWiki.ViewModels;

public class MainViewModel : ViewModelBase
{

    [Reactive] public ViewModelBase CurrentPage { get; set; }

    public ReactiveCommand<string, Unit> ChangePageCommand { get; set; }
    private readonly Dictionary<string, ViewModelBase> Pages;


    public MainViewModel()
    {

        Pages = new Dictionary<string, ViewModelBase>
            {
                { "WelcomeView", new WelcomeViewModel() },
                { "ArticleView", new ArticleViewModel() }
            };
        CurrentPage = Pages["WelcomeView"];
        ChangePageCommand = ReactiveCommand.Create<string>(page => ChangePage(page));
    }

    public void ChangePage(string page)
    {
        CurrentPage = Pages[page];
    }
}
