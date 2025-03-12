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
    public partial class Urunler1 : System.Web.UI.Page
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();
        cSepet spt = new cSepet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int kategorino = Convert.ToInt32(Request.QueryString["katid"]);
                int altkategorino = Convert.ToInt32(Request.QueryString["altkatid"]);
                if (kategorino == 0 || altkategorino == 0)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    var Products = (from urun in ent.Urunler
                                    where urun.silindi == false && urun.urunkategorino == kategorino && urun.urunaltkategorino == altkategorino
                                    select new { urun.urunid, urun.urunkodu, urun.urunad, urun.urunfiyat, urun.urunbilgisi, urun.resimyolu1, urun.resimyolu2 }).ToList();
                    dlstUrunler.DataSource = Products;
                    dlstUrunler.DataBind();

                    if (Session["sepet"] != null)
                    {
                        DataTable dt = (DataTable)Session["sepet"];
                        GridView gvOzet = (GridView)this.Master.FindControl("gvSepetOzet");
                        gvOzet.Columns[0].FooterText = "Toplam: ";
                        gvOzet.Columns[0].FooterStyle.ForeColor = Color.White;
                        gvOzet.Columns[0].FooterStyle.Font.Bold = true;
                        gvOzet.Columns[1].FooterText = string.Format("{0:#,##0.00}", ToplamTutarBul());
                        gvOzet.DataSource = dt;
                        gvOzet.DataBind();
                    }
                }
            }
        }

        protected void dlstUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {
            dlstUrunler.SelectedIndex = e.Item.ItemIndex;
            if (e.CommandName == "sepet")
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = spt.YeniSepet();
                }

                DataTable dt = (DataTable)Session["sepet"];
                DataRow dr;
                dr = dt.NewRow();
                dr["urunID"] = Convert.ToInt32(dlstUrunler.SelectedValue);
                Label UrunKodu = (Label)e.Item.FindControl("lblUrunKodu");
                dr["urunKodu"] = UrunKodu.Text;
                Label UrunAdi = (Label)e.Item.FindControl("lblUrunAdi");
                dr["urunAd"] = UrunAdi.Text;
                Label Fiyat = (Label)e.Item.FindControl("lblUrunFiyat");
                dr["fiyat"] = Convert.ToDecimal(Fiyat.Text);
                TextBox Adet = (TextBox)e.Item.FindControl("txtAdet");
                dr["adet"] = Convert.ToInt32(Adet.Text);
                dr["tutar"] = Convert.ToInt32(Adet.Text) * Convert.ToDecimal(Fiyat.Text);
                dt.Rows.Add(dr);
                Session["sepet"] = dt;

                GridView gvOzet = (GridView)this.Master.FindControl("gvSepetOzet");
                gvOzet.Columns[0].FooterText = "Toplam: ";
                gvOzet.Columns[0].FooterStyle.ForeColor = Color.White;
                gvOzet.Columns[0].FooterStyle.Font.Bold = true;
                gvOzet.Columns[1].FooterText = string.Format("{0:#,##0.00}", ToplamTutarBul());
                gvOzet.DataSource = dt;
                gvOzet.DataBind();

                Response.Redirect("Sepet.aspx");
            }
            else
            {
                Response.Redirect("UrunDetay.aspx?ID=" + Convert.ToInt32(dlstUrunler.SelectedValue));
            }
        }
        private int ToplamAdetBul()
        {
            int toplamAdet = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamAdet += Convert.ToInt32(dr["adet"]);
            }
            return toplamAdet;
        }
        private decimal ToplamTutarBul()
        {
            decimal toplamTutar = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamTutar += Convert.ToInt32(dr["tutar"]);
            }
            return toplamTutar;
        }

    }
}