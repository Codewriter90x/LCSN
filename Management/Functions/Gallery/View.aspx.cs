using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Functions_Gallery_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PhotoID = ((Page.RouteData.Values["ID"] != null) ? Page.RouteData.Values["ID"].ToString() : string.Empty);

        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(PhotoID))
            {
                GetPhotoDetails(int.Parse(PhotoID));
            }
            else
            {
                Response.Redirect("~/Management/Functions/products/", false);
            }
        }
    }

    private void GetPhotoDetails(int PhotoID)
    {
        SqlConnection conn = new SqlConnection(MultiLanguageHandler.getLanguageDB());
        try
        {
            string cmdString = "SELECT TOP 1 * FROM [Gallery] where [ID]='" + PhotoID + "'";
            SqlCommand cmd = new SqlCommand(cmdString, conn);

            conn.Open();
            SqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            while (myReader.Read())
            {
                txtNome.Text = HttpUtility.HtmlDecode(myReader["Title"].ToString());
                txtContenuto.Text = myReader["TextContent"].ToString();


                ImgNews.ImageUrl = myReader["ImageUrl"].ToString();


                txtPosNo.Text = HttpUtility.HtmlDecode(myReader["PositionNO"].ToString());

                conn.Close();
                return;
            }

            conn.Close();
            Response.Redirect("~/Management/Functions/Products/", false);
        }
        catch (Exception ex)
        {
            conn.Close();
            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateError, "Fn_DPL", Server.HtmlEncode(ex.Message));
            throw new Exception(ex.Message);
        }
    }

    private void UpdatePhotoDetails()
    {
        try
        {
            SqlConnection conn;
            SqlCommand cmd;
            string cmdString = "Update [Gallery] Set " +
                " [Title]='" + Server.HtmlEncode(txtNome.Text) + "', " +
                " [TextContent]='" + txtContenuto.Text.Replace("'", "&#39;") + "', " +
                " [PositionNO]='" + Server.HtmlEncode(txtPosNo.Text) + "' " +
                " Where [ID]='" + Server.HtmlEncode(Page.RouteData.Values["ID"].ToString()) + "'";

            conn = new SqlConnection(MultiLanguageHandler.getLanguageDB());
            cmd = new SqlCommand(cmdString, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateSuccess, "PROJ", "EDIT", string.Format("Modified sub project details for: {0}",
            //        Server.HtmlEncode(txtSubProjectName.Text)));
            lblResult.Text = AngyStatic.CreateNewActionMessageResponse("Modifiche apportate con successo.", AngyStatic.StateSuccess);
        }
        catch (Exception ex)
        {
            //AngyStatic.StoreNewUserActionRecord(AngyStatic.StateError, "PROJ", "EDIT", string.Format("Cannot edit sub project details for: {0}; {1}",
            //        Server.HtmlEncode(txtSubProjectName.Text), Server.HtmlEncode(ex.Message)));

            lblResult.Text = AngyStatic.CreateNewActionMessageResponse("Impossibile apportare le modifiche, ti preghiamo di riprovare piú tardi! " + ex.Message, AngyStatic.StateError);
        }
    }

    protected void bttEdit_Click(object sender, EventArgs e)
    {
        UpdatePhotoDetails();
    }
}