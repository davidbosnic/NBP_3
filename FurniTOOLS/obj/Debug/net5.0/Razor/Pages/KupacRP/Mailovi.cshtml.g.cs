#pragma checksum "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WEBFurniTOOLS.Pages.KupacRP.Pages_KupacRP_Mailovi), @"mvc.1.0.razor-page", @"/Pages/KupacRP/Mailovi.cshtml")]
namespace WEBFurniTOOLS.Pages.KupacRP
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
#line 1 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\_ViewImports.cshtml"
using WEBFurniTOOLS;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc34", @"/Pages/KupacRP/Mailovi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9107db4051539750c2a5480f256e36e3d322758e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_KupacRP_Mailovi : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Obrisi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Obrisi"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("ImeKupca", async() => {
                WriteLiteral("\r\n  ");
#nullable restore
#line 4 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
Write(Model.getUserString("imeKupca"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 4 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                              Write(Model.getUserString("prezimeKupca"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n  \r\n");
            }
            );
            DefineSection("MailKupca", async() => {
                WriteLiteral("\r\n ");
#nullable restore
#line 8 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
Write(Model.getUserString("emailKupca"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n");
            }
            );
#nullable restore
#line 10 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
  
     Layout="_LayoutKupac";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section>\r\n  <div class=\"square_box box_three\"></div>\r\n  <div class=\"square_box box_four\"></div>\r\n  <div class=\"container mt-5\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 18 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
         if (Model.Narudzbine != null)
        {
      

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
       foreach (var item in @Model.Narudzbine)
      {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
         if (item.Procitana == false)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc347992", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
             if (item.Status == "Potvrdjeno")
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""col-sm-12"">
                <div class=""alert fade alert-simple alert-primary alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show"" role=""alert"" data-brk-library=""component__alert"">
                  <i class=""start-icon fa fa-thumbs-up faa-bounce animated""></i>
                  <strong class=""font__weight-semibold"">Potvrda!</strong> Vaš proizvod (");
#nullable restore
#line 31 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                   Write(item.NarucenProizvod_.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral(") naručen ");
#nullable restore
#line 31 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                         Write(item.VremeNarucivanja);

#line default
#line hidden
#nullable disable
                WriteLiteral(" je u fazi izrade.\r\n                  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc349681", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                 WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                  </div>\r\n              </div>\r\n");
#nullable restore
#line 35 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
               if (item.Status == "Isporuceno")
              {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"              <div class=""col-sm-12"">
                <div class=""alert fade alert-simple alert-success alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show"">
                  <i class=""start-icon far fa-check-circle faa-tada animated""></i>
                  <strong class=""font__weight-semibold"">Isporuka!</strong> Vaš proizvod (");
#nullable restore
#line 42 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                    Write(item.NarucenProizvod_.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral(") naručen ");
#nullable restore
#line 42 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                          Write(item.VremeNarucivanja);

#line default
#line hidden
#nullable disable
                WriteLiteral(" je poslat na adresu \"");
#nullable restore
#line 42 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                                                                      Write(item.ProfilKorisnika_.Adresa);

#line default
#line hidden
#nullable disable
                WriteLiteral("\". Očekujte isporuku u narednim danima.\r\n                 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc3414260", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n              </div>\r\n");
#nullable restore
#line 46 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
              }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
               if (item.Status == "Odbijeno")
              {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"              <div class=""col-sm-12"">
                <div class=""alert fade alert-simple alert-danger alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show"" role=""alert"" data-brk-library=""component__alert"">
                  <i class=""start-icon far fa-times-circle faa-pulse animated""></i>
                  <strong class=""font__weight-semibold"">Odbijeno!</strong> Vaša narudžbina (");
#nullable restore
#line 52 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                       Write(item.NarucenProizvod_.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral(") zahtevana ");
#nullable restore
#line 52 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                               Write(item.VremeNarucivanja);

#line default
#line hidden
#nullable disable
                WriteLiteral(" je odbijena uz sledeću napomenu prodavca: \"");
#nullable restore
#line 52 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                                                                                                 Write(item.Napomena);

#line default
#line hidden
#nullable disable
                WriteLiteral("\".\r\n                 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc3418898", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                               WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n              </div>\r\n");
#nullable restore
#line 56 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
              }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
               if (item.Status == "Narucen")
              {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"              <div class=""col-sm-12"">
                <div class=""alert fade alert-simple alert-warning alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show"" role=""alert"" data-brk-library=""component__alert"">
                  <i class=""start-icon fa fa-info-circle faa-flash animated""></i>
                  <strong class=""font__weight-semibold"">Naručeno!</strong> Vaša narudžbina (");
#nullable restore
#line 62 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                       Write(item.NarucenProizvod_.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral(") zahtevana ");
#nullable restore
#line 62 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                                                                               Write(item.VremeNarucivanja);

#line default
#line hidden
#nullable disable
                WriteLiteral(" je u fazi obrade.\r\n                 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bb460ea8d9b6b4abf9c05611e3676e1a8d0ebc3423092", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
                                                                WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n              </div>\r\n");
#nullable restore
#line 66 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
              }

#line default
#line hidden
#nullable disable
                WriteLiteral("          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 68 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"

        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
         
      }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\Begota\Documents\GitHub\NBP_3\FurniTOOLS\Pages\KupacRP\Mailovi.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n  </div>\r\n</section>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEBFurniTOOLS.Pages.KupacRP.MailoviModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBFurniTOOLS.Pages.KupacRP.MailoviModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBFurniTOOLS.Pages.KupacRP.MailoviModel>)PageContext?.ViewData;
        public WEBFurniTOOLS.Pages.KupacRP.MailoviModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
