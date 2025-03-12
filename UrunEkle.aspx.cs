using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["yonetici"] == null)
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    KategorileriGetir();
                }
            }
        }
        private void KategorileriGetir()
        {
            var Kats = (from kategori in ent.Kategoriler
                        where kategori.silindi == false
                        select new { kategori.id, kategori.kategoriad, kategori.aciklama }).ToList();
            ddlKategoriler.DataTextField = "kategoriad";
            ddlKategoriler.DataValueField = "id";
            ddlKategoriler.DataSource = Kats;
            ddlKategoriler.DataBind();
        }
        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            AltKategorileriGetir(Convert.ToInt32(ddlKategoriler.SelectedValue));
        }
        private void AltKategorileriGetir(int kategoriID)
        {
            var AltKats = (from altkategori in ent.AltKategoriler
                           where altkategori.silindi == false && altkategori.kategorino == kategoriID
                           select new { altkategori.id, altkategori.altkategoriad, altkategori.aciklama, altkategori.kategorino }).ToList();
            ddlAltKategoriler.DataTextField = "altkategoriad";
            ddlAltKategoriler.DataValueField = "id";
            ddlAltKategoriler.DataSource = AltKats;
            ddlAltKategoriler.DataBind();
        }
        protected void ddlAltKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriGetir(Convert.ToInt32(ddlKategoriler.SelectedValue), Convert.ToInt32(ddlAltKategoriler.SelectedValue));
        }
        private void UrunleriGetir(int katno, int altkatno)
        {
            var Products = (from urun in ent.Urunler
                            where urun.silindi == false && urun.urunkategorino == katno && urun.urunaltkategorino == altkatno
                            select urun).ToList();
            gvUrunler.DataSource = Products;
            gvUrunler.DataBind();
        }

        protected void gvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (fuResim1.HasFile)
            {
                fuResim1.SaveAs(Server.MapPath("~/images" + fuResim1.FileName));
            }
            if (fuResim2.HasFile)
            {
                fuResim2.SaveAs(Server.MapPath("~/images/buyuk/" + fuResim2.FileName));
            }
            Urunler u = new Urunler();
            u.urunkodu = txtUrunKodu.Text;
            u.urunad = txtUrunAdi.Text;
            u.urunkategorino = Convert.ToInt32(ddlKategoriler.SelectedValue);
            u.urunaltkategorino = Convert.ToInt32(ddlAltKategoriler.SelectedValue);
            u.urunbilgisi = txtUrunBilgisi.Text;
            u.miktar = Convert.ToInt32(txtMiktar.Text);
            u.urunfiyat = Convert.ToDecimal(txtFiyat.Text);
            u.resimyolu1 = "images/" + fuResim1.FileName;
            u.resimyolu2 = "images/buyuk/" + fuResim2.FileName;
            ent.Urunler.Add(u);
            ent.SaveChanges();
            UrunleriGetir(Convert.ToInt32(ddlKategoriler.SelectedValue), Convert.ToInt32(ddlAltKategoriler.SelectedValue));
            Temizle();
        }
        private void Temizle()
        {
            txtUrunKodu.Text = "";
            txtUrunAdi.Text = "";
            txtUrunBilgisi.Text = "";

        }
    }
}