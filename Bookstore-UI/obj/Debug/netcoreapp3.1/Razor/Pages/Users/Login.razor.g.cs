#pragma checksum "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91a437f422eca43d1a719d328bbd99bbb105a3cc"
// <auto-generated/>
#pragma warning disable 1591
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
#line 10 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Contracts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "card");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<h3 class=\"card-title\">Login</h3>\r\n");
#nullable restore
#line 8 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
     if (!_response)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "        ");
            __builder.AddMarkupContent(5, "<div class=\"alert alert-danger\">\r\n            <p>Something went wrong</p>\r\n        </div>\r\n");
#nullable restore
#line 13 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "    ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "card-body");
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(10);
            __builder.AddAttribute(11, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 15 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                         _loginModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 15 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                                                     HandleLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(14, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(15);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(17);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\r\n            ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "class", "form-group");
                __builder2.AddMarkupContent(21, "\r\n                ");
                __builder2.AddMarkupContent(22, "<label for=\"email\">Email address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(23);
                __builder2.AddAttribute(24, "id", "email");
                __builder2.AddAttribute(25, "class", "form-control");
                __builder2.AddAttribute(26, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                                                                        _loginModel.EmailAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _loginModel.EmailAddress = __value, _loginModel.EmailAddress))));
                __builder2.AddAttribute(28, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _loginModel.EmailAddress));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(29, "\r\n                ");
                __Blazor.Bookstore_UI.Pages.Users.Login.TypeInference.CreateValidationMessage_0(__builder2, 30, 31, 
#nullable restore
#line 21 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                                          () => _loginModel.EmailAddress

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(32, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n            ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "form-group");
                __builder2.AddMarkupContent(36, "\r\n                ");
                __builder2.AddMarkupContent(37, "<label for=\"password\">Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(38);
                __builder2.AddAttribute(39, "id", "password");
                __builder2.AddAttribute(40, "type", "password");
                __builder2.AddAttribute(41, "class", "form-control");
                __builder2.AddAttribute(42, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                                                                                           _loginModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(43, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _loginModel.Password = __value, _loginModel.Password))));
                __builder2.AddAttribute(44, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _loginModel.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(45, "\r\n                ");
                __Blazor.Bookstore_UI.Pages.Users.Login.TypeInference.CreateValidationMessage_1(__builder2, 46, 47, 
#nullable restore
#line 26 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
                                          () => _loginModel.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(48, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, "\r\n            ");
                __builder2.AddMarkupContent(50, "<button type=\"submit\" class=\"btn btn-primary\">Login</button>\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(51, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\Aleksandar Nikolov\source\repos\Bookstrore\Bookstore-UI\Pages\Users\Login.razor"
       
    private readonly LoginModel _loginModel = new LoginModel();
    private bool _response = true;

    private async Task HandleLogin()
    {
        _response = await _authRepo.Login(_loginModel);
        if (_response)
        {
            _navMan.NavigateTo("/");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navMan { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationRepository _authRepo { get; set; }
    }
}
namespace __Blazor.Bookstore_UI.Pages.Users.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
