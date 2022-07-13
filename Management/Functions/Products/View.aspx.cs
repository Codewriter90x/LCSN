using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Functions_Products_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ProdID = ((Page.RouteData.Values["ID"] != null) ? Page.RouteData.Values["ID"].ToString() : string.Empty);

        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(ProdID))
            {
                GetProductDetails(int.Parse(ProdID));
            }
            else
            {
                Response.Redirect("~/Management/Functions/products/", false);
            }
        }
    }

    private void GetProductDetails(int ProdID)
    {
        SqlConnection conn = new SqlConnection(MultiLanguageHandler.getLanguageDB());
        try
        {
            string cmdString = "SELECT TOP 1 * FROM [Products] where [ID]='" + ProdID + "'";
            SqlCommand cmd = new SqlCommand(cmdString, conn);

            conn.Open();
            SqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            while (myReader.Read())
            {
                txtNome.Text = HttpUtility.HtmlDecode(myReader["Name"].ToString());
                txtSecondName.Text = HttpUtility.HtmlDecode(myReader["SecondName"].ToString());
                txtDescrizione.Text = HttpUtility.HtmlDecode(myReader["MetaDescription"].ToString());
                txtTag.Text = HttpUtility.HtmlDecode(myReader["MetaTag"].ToString());
                txtContenuto.Text = myReader["Description"].ToString();
                
                txtSocialTitle.Text = HttpUtility.HtmlDecode(myReader["SocialTitle"].ToString());
                txtSocialDesc.Text = HttpUtility.HtmlDecode(myReader["SocialDescription"].ToString());
                txtSocialImage.Text = HttpUtility.HtmlDecode(myReader["SocialImage"].ToString());

                ImgNews.ImageUrl = myReader["PrevImage"].ToString();

                if (myReader["MetaDescription"].ToString().Length < 80)
                    lblMetaDescPageLenght.ForeColor = Color.Red;

                if (myReader["SocialDescription"].ToString().Length < 80)
                    lblSocialDescPage.ForeColor = Color.Red;

                
                
                txtPosNo.Text = HttpUtility.HtmlDecode(myReader["Position"].ToString());

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

    private void UpdateProductDetails()
    {
        try
        {
            SqlConnection conn;
            SqlCommand cmd;
            string cmdString = "Update [Products] Set " +
                " [Name]='" + Server.HtmlEncode(txtNome.Text) + "', " +
                " [SecondName]='" + txtSecondName.Text.Replace("'", "&#39;") + "', " +
                " [Description]='" + txtContenuto.Text.Replace("'", "&#39;") + "', " +
                " [Position]='" + Server.HtmlEncode(txtPosNo.Text) + "', " +
                " [MetaTag]='" + Server.HtmlEncode(txtTag.Text) + "', " +
                " [MetaDescription]='" + Server.HtmlEncode(txtDescrizione.Text) + "', " +
                " [SocialTitle]='" + Server.HtmlEncode(txtSocialTitle.Text) + "', " +
                " [SocialDescription]='" + Server.HtmlEncode(txtDescrizione.Text) + "', " +
                " [SocialImage]='" + Server.HtmlEncode(txtSocialImage.Text) + "' " +
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

            lblResult.Text = AngyStatic.CreateNewActionMessageResponse("Impossibile apportare le modifiche, ti preghiamo di riprovare piú tardi!", AngyStatic.StateError);
        }
    }

    protected void bttEdit_Click(object sender, EventArgs e)
    {
        UpdateProductDetails();
    }
}