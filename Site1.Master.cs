using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Categories = from kategori in ent.Kategoriler
                                 where kategori.silindi == false
                                 select new { kategori.id, kategori.kategoriad };
                foreach (var item in Categories)
                {
                    MenuItem mitm = new MenuItem();
                    mitm.Text = item.kategoriad;
                    mitm.Value = item.id.ToString();
                    mnuKategoriler.Items.Add(mitm);
                    var SubCategories = from altkategori in ent.AltKategoriler
                                     where altkategori.silindi == false && altkategori.kategorino == item.id
                                     select new { altkategori.id, altkategori.altkategoriad};
                    foreach (var citem in SubCategories)
                    {
                        MenuItem citm = new MenuItem();
                        citm.Text  = citem.altkategoriad;
                        citm.Value = citem.id.ToString();
                        mitm.ChildItems.Add(citm);
                    }
                }
            }
        }

        protected void mnuKategoriler_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Depth != 0)
            {
                //string sec1 = e.Item.Text + ", " + e.Item.Value;
                string[] secim = e.Item.ValuePath.Split('/');
                Response.Redirect("Urunler.aspx?katid=" + secim[0] + "&altkatid=" + secim[1]);
            }
        }
    }
}