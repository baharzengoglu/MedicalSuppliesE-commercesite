<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="webSaglikProjesi.UrunDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlstUrunler" runat="server" CellPadding="4" ForeColor="#333333"  OnItemCommand="dlstUrunler_ItemCommand" DataKeyField="urunid">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <ItemTemplate>
            <div class="resim">
                <asp:Label ID="lblUrunKodu" runat="server" Text='<%#Eval("urunkodu") %>'></asp:Label><br />
                <asp:Label ID="lblUrunAdi" runat="server" Text='<%#Eval("urunad") %>'></asp:Label><br />
                <asp:ImageButton ID="imgResim" ImageUrl='<%#Eval("resimyolu2") %>' runat="server" AlternateText='<%#Eval("urunad") %>' Width="220px" Height="240px" /><br />
                <asp:Label ID="lblUrunFiyat" runat="server" Text='<%#Eval("urunfiyat","{0:N}") %>'></asp:Label>
                <asp:TextBox ID="txtAdet" runat="server" Width="20px" Text="1"></asp:TextBox><br />
                <asp:Button ID="btnEkle" runat="server" Text="Sepete Ekle"  CommandName="sepet"/> <br />
                <br /><br />
                <asp:Label ID="lblUrunBilgi" runat="server" Text='<%#Eval("urunbilgisi") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
