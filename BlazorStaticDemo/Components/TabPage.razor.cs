using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStaticDemo.Components;

partial class TabPage
{
    [CascadingParameter]
    public TabControl Owner { get; set; } = null!;

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }


    string? IsActiveClass => (this == Owner.ActivePage) ? "active" : null;

    protected override void OnInitialized()
    {
        if (Owner == null)
        {
            throw new InvalidOperationException("Een TabPage moet op een TabControl staan");
        }
        Owner.NewPage(this);
    }

    private void DoClick()
    {
        Owner.ActivatePage(this);
    }
}
