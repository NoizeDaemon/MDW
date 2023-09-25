using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWiki.Dialogs.Models;

public class PopUpContent
{
    public PopUpContent(string message, string? title = null, Interactable[]? interactables = null)
    {
        Message = message;
        Title = title;
        Interactables = interactables ?? new[] { new Interactable() };
    }

    public string Message { get; }
    public string? Title { get; }
    public Interactable[] Interactables { get; }
}
