#pragma checksum "C:\Users\davo-\OneDrive\Escritorio\PruebaTecnicaClima\Wheather\WeatherApp\Core\Views\Weather\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b41ccb0caac3d315d08c14b7a766a2d8b05cbd6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Weather_Index), @"mvc.1.0.view", @"/Views/Weather/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\davo-\OneDrive\Escritorio\PruebaTecnicaClima\Wheather\WeatherApp\Core\Views\_ViewImports.cshtml"
using Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\davo-\OneDrive\Escritorio\PruebaTecnicaClima\Wheather\WeatherApp\Core\Views\_ViewImports.cshtml"
using Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b41ccb0caac3d315d08c14b7a766a2d8b05cbd6a", @"/Views/Weather/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"033f1c583a2f505a1749a640e329a23fb745adbf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Weather_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Weather>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\davo-\OneDrive\Escritorio\PruebaTecnicaClima\Wheather\WeatherApp\Core\Views\Weather\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Dictionary<string, string> clima = new Dictionary<string, string>()
    {
        { "soleado", "https://cdn-icons-png.flaticon.com/512/1146/1146869.png" },
        { "caluroso", "https://cdn-icons-png.flaticon.com/512/869/869869.png" },
        { "lluvioso", "https://cdn-icons-png.flaticon.com/512/3104/3104619.png"},
        { "nublado", "https://cdn-icons-png.flaticon.com/512/1163/1163624.png"},
        { "nevado", "https://icons-for-free.com/iconfiles/png/512/snow+snowflake+icon-1320196576576887593.png"}
    };
    string img = "", condicion = "", fondo = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Climas de ciudades de Colombia</h1>\r\n</div>\r\n");
#nullable restore
#line 18 "C:\Users\davo-\OneDrive\Escritorio\PruebaTecnicaClima\Wheather\WeatherApp\Core\Views\Weather\Index.cshtml"
  /*
 *
                    * <a asp-action="WeatherController" asp-controller="Home" asp-route-idWeather="0" class="btn btn-success btn-sm">Nuevo clima</a>

<div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100" style="width: 100%">
        @foreach (var item in Model)
        {
            @if (item.Temperature is > 24  and < 31)
            {
                img = clima["soleado"];
                condicion = "Soleado";
            }
            @if (item.Temperature is > 31)
            {
                img = clima["caluroso"];
                condicion = "Caluroso";
            }
            @if (item.Temperature <= 10)
            {
                img = clima["lluvioso"];
                condicion = "Lluvioso";
            }
            @if (item.Temperature is > 10 and < 24)
            {
                img = clima["nublado"];
                condicion = "Nublado";
            }
            @if (item.Temperature is < 10)
            {
                img = clima["nevado"];
                condicion = "Nevando";
            }

            <div class="col-md-8 col-lg-6 col-xl-4" style="padding-bottom: 1.5em">

                <div class="card" style="color: #4B515D; border-radius: 20px;">
                    <div class="card-body p-4">

                        <div class="d-flex">
                            <h2 class="flex-grow-1" style="margin: auto;">@item.City</h2>
                        </div>

                        <div class="d-flex flex-column text-center mt-5 mb-4">
                            <h6 class="display-4 mb-0 font-weight-bold" style="color: #1C2331;"> @item.Temperature°C </h6>
                            <span class="small" style="color: #868B94; font-size: 30px">@condicion</span>
                        </div>

                        <div class="d-flex align-items-center" style="justify-content: center;">
                            <div>
                                <img src=@img
                                 width="100px">
                            </div>
                        </div>
                        <div style="align-items: center; margin-top:1em">
                            <a asp-action="Weather" asp-controller="Home" style="width: 45%; margin:auto" asp-route-idWeather="@item.Id" class="btn btn-primary btn-sm">Editar</a>
                            <a asp-action="Delete" asp-controller="Home" style="width: 45%;  margin:auto" asp-route-idWeather="@item.Id" class="btn btn-danger btn-sm">Eliminar</a>
                        </div>
                    </div>
                </div>

            </div>
        }
    </div>


</div>


                    */

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Weather>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
