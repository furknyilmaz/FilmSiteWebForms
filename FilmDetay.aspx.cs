using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmWebFormsApp
{
    public partial class FilmDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //SqlConnection sqlConnection = new SqlConnection("Data Source =.; Initial Catalog = SampleDB; Integrated Security = True");
            //sqlConnection.Open();

            //SqlCommand ara = new SqlCommand("select * from filmler where adi like '%" + TextBox1.Text + "%'", sqlConnection);
            SqlDataSource1.SelectCommand = "select * from filmler where adi like '%" + TextBox1.Text + "%'";
            //ara.ExecuteNonQuery();
            TextBox1.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilmEkle.aspx");
        }

        protected void Unnamed1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                var filmAdi = (e.CommandArgument.ToString());
                SqlConnection sqlConnection = new SqlConnection("Data Source =.; Initial Catalog = SampleDB; Integrated Security = True");
                sqlConnection.Open();
                SqlCommand sil = new SqlCommand("delete from filmler where adi='" + filmAdi + "'", sqlConnection);
                sil.ExecuteNonQuery();
                Response.Redirect("FilmDetay.aspx");
            }
            if (e.CommandName == "Guncelle")
            {
                var filmAdi = (e.CommandArgument);
                Response.Redirect("FilmGuncelle.aspx?film=" + filmAdi);
            }
        }
    }
}
