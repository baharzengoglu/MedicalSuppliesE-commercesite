using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class KategoriEkle : System.Web.UI.Page
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
                    VeriGetir();
                }
            }
        }
        private void VeriGetir()
        {
            var Categories = (from category in ent.Kategoriler
                              where category.silindi == false
                              select new { category.id, category.kategoriad, category.aciklama }).ToList();
            gvKategoriler.DataSource = Categories;
            gvKategoriler.DataBind();
        }
        protected void lbYeniKategori_Click(object sender, EventArgs e)
        {
            pnlEkle.Visible = true;
            txtKategoriAdi.Focus();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text != "")
            {
                Kategoriler k = new Kategoriler();
                k.kategoriad = txtKategoriAdi.Text;
                k.aciklama = txtAciklama.Text;
                ent.Kategoriler.Add(k);
                ent.SaveChanges();
                pnlEkle.Visible = false;
                VeriGetir();
            }
        }
    }
}