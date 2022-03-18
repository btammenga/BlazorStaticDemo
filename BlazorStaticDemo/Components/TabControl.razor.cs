using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStaticDemo.Components;

partial class TabControl
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    internal TabPage? ActivePage { get; private set; }
    internal void NewPage(TabPage page)
    {
        // optie: pagina's opslaan

        if (ActivePage == null)
        {
            ActivatePage(page);
        }
    }

    internal void ActivatePage(TabPage page)
    {
        ActivePage = page;
        StateHasChanged();
    }
}
