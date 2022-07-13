using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Functions_Pages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListViewPages.DataSource = GetPages();
        ListViewPages.DataBind();
    }

    private IEnumerable<Page> GetPages()
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString.ToString());
        try
        {
            string cmdString = "SELECT TOP 150 * FROM [Pages] ORDER BY [DateIns] ASC";
            SqlCommand cmd = new SqlCommand(cmdString.ToString(), conn);

            conn.Open();
            SqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            List<Page> pages = new List<Page>();

            while (myReader.Read())
            {
                Page page = new Page();
                page.ID = myReader["PageID"].ToString();
                page.Code = myReader["Code"].ToString();
                page.Title = myReader["Name"].ToString() + "(" + myReader["Title"].ToString()  + ")";
                page.DateIns = DateTime.Parse(myReader["DateIns"].ToString()).ToString("dd MMMM yyyy");

                if (myReader["MetaDescription"].ToString().Length < 80 || myReader["MetaTag"].ToString().Length < 5)
                    page.GoogleTagsStatus = "<a class='danger p-0' data-original-title='' title=''><i class='ft-x font-medium-3 mr-2'></i></a>";
                else
                    page.GoogleTagsStatus = "<a class='success p-0' data-original-title='' title=''><i class='ft-check font-medium-3 mr-2'></i></a>";

                if (myReader["SocialTitle"].ToString().Length < 6 || myReader["SocialDescription"].ToString().Length < 80 || !myReader["SocialImage"].ToString().StartsWith("http"))
                    page.SocialTagsStatus = "<a class='danger p-0' data-original-title='' title=''><i class='ft-x font-medium-3 mr-2'></i></a>";
                else
                    page.SocialTagsStatus = "<a class='success p-0' data-original-title='' title=''><i class='ft-check font-medium-3 mr-2'></i></a>";
                pages.Add(page);
            }

            conn.Close();
            return pages;
            //employees.Sort((x) => string.Compare(x.Name, x.Surname));
        }
        catch (Exception)
        {
            conn.Close();
            throw;
        }
    }

    public struct Page
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string GoogleTagsStatus { get; set; }
        public string SocialTagsStatus { get; set; }
        public string DateIns { get; set; }
    }
}