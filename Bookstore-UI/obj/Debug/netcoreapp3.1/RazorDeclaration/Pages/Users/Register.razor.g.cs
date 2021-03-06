// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Bookstore_UI.Pages.Users
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Bookstore_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Register.razor"
using Bookstore_UI.Contracts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Register.razor"
using Bookstore_UI.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Register.razor"
       
    private readonly RegistrationModel _registrationModel = new RegistrationModel();
    private bool _isFailed = false;

    private async Task HandleRegistration()
    {
        var response = await _authenticationRepository.Register(_registrationModel);
        if (response)
        {
            _navigationManager.NavigateTo("/login");
        }
        else
        {
            _isFailed = true;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationRepository _authenticationRepository { get; set; }
    }
}
#pragma warning restore 1591
