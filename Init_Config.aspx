<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>

<!DOCTYPE html>

<script runat="server">
    //Data Source=localhost;Initial Catalog=;User ID=;Password=!;Integrated Security=False;
        
    protected void Page_Load(object sender, EventArgs e)
    {
        //File.Delete(Server.MapPath("~/Init_Config.aspx"));
        Init_Admin tst = new Init_Admin();
        //Response.Redirect("~/Management/");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            sas
        </div>
    </form>
</body>
</html>
