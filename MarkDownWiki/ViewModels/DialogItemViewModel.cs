using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarkDownWiki.ViewModels
{
    public class DialogItemViewModel : ViewModelBase
    {
        public DialogItemViewModel(string header, Func<IAsyncEnumerable<string>> handler)
        {
            Header = header;
            commandHandler = handler;

            Command = ReactiveCommand.Create<object>(OnExecuteCommandHandler);
        }

        private readonly Func<IAsyncEnumerable<string>> commandHandler;

        [Reactive] public ICommand Command { get; set; }
        [Reactive] public string Header { get; set; }
        [Reactive] public string? Result { get; set; }

        private async void OnExecuteCommandHandler(object arg)
        {
            Result = "Waiting result...";

            var builder = new StringBuilder();

            await foreach (var str in commandHandler())
            {
                builder.AppendLine(str);
                Result = builder.ToString();
            }
        }
    }
}
