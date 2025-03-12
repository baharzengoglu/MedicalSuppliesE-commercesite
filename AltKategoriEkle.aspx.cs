using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class AltKategoriEkle : System.Web.UI.Page
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
                       select new {kategori.id, kategori.kategoriad, kategori.aciklama }).ToList();
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
            gvAltKategoriler.DataSource = AltKats;
            gvAltKategoriler.DataBind();
        }
        protected void lbYeniEkle_Click(object sender, EventArgs e)
        {
            pnlEkle.Visible = true;
            txtAltKategoriAdi.Focus();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAltKategoriAdi.Text != "")
            {
                AltKategoriler ak = new AltKategoriler();
                ak.altkategoriad = txtAltKategoriAdi.Text;
                ak.aciklama = txtAciklama.Text;
                ak.kategorino = Convert.ToInt32(ddlKategoriler.SelectedValue);
                ent.AltKategoriler.Add(ak);
                ent.SaveChanges();
                pnlEkle.Visible = false;
                AltKategorileriGetir(Convert.ToInt32(ddlKategoriler.SelectedValue));
            }
        }



    }
}