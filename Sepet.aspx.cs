using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace webSaglikProjesi
{
    public partial class Sepet : System.Web.UI.Page
    {
        int toplamAdet = 0;
        decimal toplamTutar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sepet"] != null)
                {
                    DataTable dt = (DataTable)Session["sepet"];
                    SepetleriGoster(dt);
                }

            }
        }

        protected void btnDevam_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void gvSepet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows.RemoveAt(e.RowIndex);
            gvSepet.DataSource = dt;
            gvSepet.DataBind();

            Session["sepet"] = dt;
            SepetleriGoster(dt);

        }
        private void SepetleriGoster(DataTable dt)
        {
            gvSepet.Columns[0].FooterText = "Toplam: ";
            gvSepet.Columns[0].FooterStyle.ForeColor = Color.White;
            gvSepet.Columns[0].FooterStyle.Font.Bold = true;
            gvSepet.Columns[3].FooterText = ToplamAdetBul().ToString();
            gvSepet.Columns[3].FooterStyle.Font.Bold = true;
            gvSepet.Columns[3].FooterStyle.HorizontalAlign = HorizontalAlign.Center;
            gvSepet.Columns[4].FooterText = string.Format("{0:#,##0.00}", Convert.ToDecimal(ToplamTutarBul()));
            gvSepet.Columns[4].FooterStyle.Font.Bold = true;
            gvSepet.DataSource = dt;
            gvSepet.DataBind();

            GridView gvOzet = (GridView)this.Master.FindControl("gvSepetOzet");
            gvOzet.Columns[0].FooterText = "Toplam: ";
            gvOzet.Columns[0].FooterStyle.ForeColor = Color.White;
            gvOzet.Columns[0].FooterStyle.Font.Bold = true;
            gvOzet.Columns[1].FooterText = string.Format("{0:#,##0.00}", Convert.ToDecimal(ToplamTutarBul()));
            gvOzet.DataSource = dt;
            gvOzet.DataBind();
        }
        private int ToplamAdetBul()
        {
            toplamAdet = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamAdet += Convert.ToInt32(dr["adet"]);
            }
            return toplamAdet;
        }
        private decimal ToplamTutarBul()
        {
            toplamTutar = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamTutar += Convert.ToDecimal(dr["tutar"]);
            }
            return toplamTutar;
        }

        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Clear();
            Session["sepet"] = dt;
            Response.Redirect("default.aspx");
        }

        protected void btnSatinAl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adres.aspx");
        }
    }
}