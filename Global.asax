<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Configuration" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        ck_ConnectionString();
        WebControl.DisabledCssClass = "form-control";

        RouteTable.Routes.MapPageRoute("Home", "", "~/Default.aspx");
        RouteTable.Routes.MapPageRoute("Login", "Login", "~/Login.aspx");
        RouteTable.Routes.MapPageRoute("Register", "Register", "~/Register.aspx");

        //Pages
        RouteTable.Routes.MapPageRoute("About", "About", "~/pages/About.aspx");
        RouteTable.Routes.MapPageRoute("Contacts", "Contacts", "~/pages/Contacts.aspx");
        RouteTable.Routes.MapPageRoute("FAQ", "FAQ", "~/pages/FAQ.aspx");

        // Properties
        RouteTable.Routes.MapPageRoute("Properties", "Properties", "~/Properties/Default.aspx");
        RouteTable.Routes.MapPageRoute("PropertiesView", "Properties/View/{PropertyID}", "~/Properties/View.aspx");

        // Team
        RouteTable.Routes.MapPageRoute("Team", "Team", "~/Team/Default.aspx");
        RouteTable.Routes.MapPageRoute("TeamView", "Team/View/{PropertyID}", "~/Team/View.aspx");

        // Errors handling
        RouteTable.Routes.MapPageRoute("Err401", "Error/401/", "~/Error/401.aspx");
        RouteTable.Routes.MapPageRoute("Err404", "Error/404/", "~/Error/404.aspx");
        RouteTable.Routes.MapPageRoute("Err403", "Error/403/", "~/Error/403.aspx");
        RouteTable.Routes.MapPageRoute("Err500", "Error/500/", "~/Error/500.aspx");



        //Admin Panel
        RouteTable.Routes.MapPageRoute("ViewPage", "Management/Functions/Pages/View/{PageID}/{name}", "~/Management/Functions/Pages/view.aspx");

        RouteTable.Routes.MapPageRoute("ViewNews", "Management/Functions/News/View/{id}/{name}", "~/Management/Functions/News/view.aspx");
        RouteTable.Routes.MapPageRoute("ViewProducts", "Management/Functions/Products/View/{id}/{name}", "~/Management/Functions/Products/view.aspx");
        RouteTable.Routes.MapPageRoute("ViewGallery", "Management/Functions/Gallery/View/{id}/{name}", "~/Management/Functions/Gallery/view.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Codice eseguito all'arresto dell'applicazione
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Codice eseguito in caso di errore non gestito
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Codice eseguito all'avvio di una nuova sessione
    }

    void Session_End(object sender, EventArgs e)
    {
        // Codice eseguito al termine di una sessione.
        // Nota: l'evento Session_End viene generato solo quando la modalità sessionstate
        // è impostata su InProc nel file Web.config. Se la modalità è impostata su StateServer
        // o SQLServer, l'evento non viene generato.
    }

    void ck_ConnectionString()
    {
        var configuration = WebConfigurationManager.OpenWebConfiguration("~");
        var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
        if (string.IsNullOrEmpty(section.ConnectionStrings["DefaultConnectionString"].ConnectionString))
        {
            //Server.Transfer("ErrorPage.aspx");
            //HttpContext.Current.Response.Redirect("~/Login.aspx", true);
        }

        //configuration.Save();
    }

</script>
