#pragma checksum "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf3935a3c87c38c98616edda40f31f0409a10632"
// <auto-generated/>
#pragma warning disable 1591
namespace Bookstore_UI.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Bookstore_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Contracts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\_Imports.razor"
using Bookstore_UI.Models;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href>Bookstore-UI</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(7, "\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(17);
            __builder.AddAttribute(18, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(19, "\r\n                ");
                __builder2.OpenElement(20, "li");
                __builder2.AddAttribute(21, "class", "nav-item px-3");
                __builder2.AddMarkupContent(22, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(23);
                __builder2.AddAttribute(24, "class", "nav-link");
                __builder2.AddAttribute(25, "href", "/");
                __builder2.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(27, "\r\n                        <span class=\"oi oi-globe\" aria-hidden=\"true\"></span> ");
                    __builder3.AddContent(28, 
#nullable restore
#line 14 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
                                                                              context.User.Identity.Name

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddMarkupContent(29, "\r\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n                ");
                __builder2.OpenElement(32, "li");
                __builder2.AddAttribute(33, "class", "nav-item px-3");
                __builder2.AddMarkupContent(34, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(35);
                __builder2.AddAttribute(36, "class", "nav-link");
                __builder2.AddAttribute(37, "href", "logout");
                __builder2.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(39, "\r\n                        <span class=\"oi oi-globe\" aria-hidden=\"true\"></span> Log Out\r\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(40, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n            ");
            }
            ));
            __builder.AddAttribute(42, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(43, "\r\n                ");
                __builder2.OpenElement(44, "li");
                __builder2.AddAttribute(45, "class", "nav-item px-3");
                __builder2.AddMarkupContent(46, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(47);
                __builder2.AddAttribute(48, "class", "nav-link");
                __builder2.AddAttribute(49, "href", "login");
                __builder2.AddAttribute(50, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(51, "\r\n                        <span class=\"oi oi-globe\" aria-hidden=\"true\"></span> Login\r\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(52, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n                ");
                __builder2.OpenElement(54, "li");
                __builder2.AddAttribute(55, "class", "nav-item px-3");
                __builder2.AddMarkupContent(56, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(57);
                __builder2.AddAttribute(58, "class", "nav-link");
                __builder2.AddAttribute(59, "href", "register");
                __builder2.AddAttribute(60, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(61, "\r\n                        <span class=\"oi oi-book\" aria-hidden=\"true\"></span> Register\r\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(62, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(63, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(64, "\r\n        ");
            __builder.OpenElement(65, "li");
            __builder.AddAttribute(66, "class", "nav-item px-3");
            __builder.AddMarkupContent(67, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(68);
            __builder.AddAttribute(69, "class", "nav-link");
            __builder.AddAttribute(70, "href", "");
            __builder.AddAttribute(71, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 37 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(72, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(73, "\r\n                <span class=\"oi oi-home\" aria-hidden=\"true\"></span> Home\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(74, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n        ");
            __builder.OpenElement(76, "li");
            __builder.AddAttribute(77, "class", "nav-item px-3");
            __builder.AddMarkupContent(78, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(79);
            __builder.AddAttribute(80, "class", "nav-link");
            __builder.AddAttribute(81, "href", "authors/");
            __builder.AddAttribute(82, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(83, "\r\n                <span class=\"oi oi-plus\" aria-hidden=\"true\"></span> Author\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(84, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n        ");
            __builder.OpenElement(86, "li");
            __builder.AddAttribute(87, "class", "nav-item px-3");
            __builder.AddMarkupContent(88, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(89);
            __builder.AddAttribute(90, "class", "nav-link");
            __builder.AddAttribute(91, "href", "books");
            __builder.AddAttribute(92, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(93, "\r\n                <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Books data\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(94, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(96);
            __builder.AddAttribute(97, "Roles", "Administrator");
            __builder.AddAttribute(98, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(99, "\r\n            ");
                __builder2.OpenElement(100, "li");
                __builder2.AddAttribute(101, "class", "nav-item px-3");
                __builder2.AddMarkupContent(102, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(103);
                __builder2.AddAttribute(104, "class", "nav-link");
                __builder2.AddAttribute(105, "href", "books");
                __builder2.AddAttribute(106, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(107, "\r\n                    <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Admin books\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(108, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(109, "\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(110, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(111);
            __builder.AddAttribute(112, "Roles", "Customer");
            __builder.AddAttribute(113, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(114, "\r\n            ");
                __builder2.OpenElement(115, "li");
                __builder2.AddAttribute(116, "class", "nav-item px-3");
                __builder2.AddMarkupContent(117, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(118);
                __builder2.AddAttribute(119, "class", "nav-link");
                __builder2.AddAttribute(120, "href", "books");
                __builder2.AddAttribute(121, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(122, "\r\n                    <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Customer books\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(123, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(124, "\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(125, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "C:\Users\Aleksandar Nikolov\source\repos\BookStore-API\Bookstore-UI\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
