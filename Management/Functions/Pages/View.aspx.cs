using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Functions_Pages_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PageID = ((Page.RouteData.Values["PageID"] != null) ? Page.RouteData.Values["PageID"].ToString() : string.Empty);

        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(PageID))
            {
                GetPageDetails(PageID);
            }
            else
            {
                Response.Redirect("~/Management/Functions/Pages/", false);
            }
        }
    }

    private void GetPageDetails(string PageID)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString.ToString());
        try
        {
            string cmdString = "SELECT TOP 1 * FROM [Pages] where [PageID]='" + HttpUtility.HtmlEncode(PageID) + "'";
            SqlCommand cmd = new SqlCommand(cmdString, conn);

            conn.Open();
            SqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            while (myReader.Read())
            {
                txtTitolo.Text = HttpUtility.HtmlDecode(myReader["Title"].ToString());
                txtDescrizione.Text = HttpUtility.HtmlDecode(myReader["MetaDescription"].ToString());
                txtTag.Text = HttpUtility.HtmlDecode(myReader["MetaTag"].ToString());
                txtContenuto.Text = myReader["Content"].ToString();
                txtSocialTitle.Text = HttpUtility.HtmlDecode(myReader["SocialTitle"].ToString());
                txtSocialDesc.Text = HttpUtility.HtmlDecode(myReader["SocialDesc"].ToString());
                txtSocialImage.Text = HttpUtility.HtmlDecode(myReader["SocialImage"].ToString());

                if (myReader["MetaDescription"].ToString().Length < 80)
                    lblMetaDescPageLenght.ForeColor = Color.Red;

                if (myReader["SocialDesc"].ToString().Length < 80)
                    lblSocialDescPage.ForeColor = Color.Red;

                conn.Close();
                return;
            }

            conn.Close();
            Response.Redirect("~/Management/Functions/Pages/", false);
        }
        catch (Exception ex)
        {
            conn.Close();
            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateError, "Fn_DPL", Server.HtmlEncode(ex.Message));
            throw new Exception(ex.Message);
        }
    }

    private void UpdatePageDetails()
    {
        try
        {
            SqlConnection conn;
            SqlCommand cmd;
            string cmdString = "Update [Pages] Set " +
                " [Title]='" + Server.HtmlEncode(txtTitolo.Text) + "', " +
                " [PageContent]='" + txtContenuto.Text + "', " +
                " [MetaTag]='" + Server.HtmlEncode(txtTag.Text) + "', " +
                " [MetaDescription]='" + Server.HtmlEncode(txtDescrizione.Text) + "', " +
                " [SocialTitle]='" + Server.HtmlEncode(txtSocialTitle.Text) + "', " +
                " [SocialDesc]='" + Server.HtmlEncode(txtDescrizione.Text) + "', " +
                " [SocialImage]='" + Server.HtmlEncode(txtSocialImage.Text) + "' " +
                " Where [PageID]='" + Server.HtmlEncode(Page.RouteData.Values["ID"].ToString()) + "'";

            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString.ToString());
            cmd = new SqlCommand(cmdString, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateSuccess, "PROJ", "EDIT", string.Format("Modified sub project details for: {0}",
            //        Server.HtmlEncode(txtSubProjectName.Text)));
            //lblResult.Text = AngyStatic.CreateNewActionMessageResponse("Modifiche apportate con successo.", AngyStatic.StateSuccess);
        }
        catch (Exception ex)
        {
            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateError, "PROJ", "EDIT", string.Format("Cannot edit sub project details for: {0}; {1}",
            //        Server.HtmlEncode(txtSubProjectName.Text), Server.HtmlEncode(ex.Message)));

            //lblResult.Text = AngyStatic.CreateNewActionMessageResponse("Impossibile apportare le modifiche, ti preghiamo di riprovare piú tardi!" + ex.Message, AngyStatic.StateError);
        }
    }

    protected void bttEdit_Click(object sender, EventArgs e)
    {
        UpdatePageDetails();
    }
}