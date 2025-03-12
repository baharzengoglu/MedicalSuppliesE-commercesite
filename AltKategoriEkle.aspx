<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AltKategoriEkle.aspx.cs" Inherits="webSaglikProjesi.AltKategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="Kategori Seçiniz"></asp:Label>
        <br />
    <asp:DropDownList ID="ddlKategoriler" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged">
    </asp:DropDownList>

        <br />

        <br />
        <asp:GridView ID="gvAltKategoriler" runat="server" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" Width="259px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lbYeniEkle" runat="server" OnClick="lbYeniEkle_Click" >Yeni Alt Kategori</asp:LinkButton>
        <br />
        <br />
    <asp:Panel ID="pnlEkle" runat="server" Visible="false">
        <asp:Label ID="Label1" runat="server" Text="AltKategori Adı : "></asp:Label>
        <asp:TextBox ID="txtAltKategoriAdi" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Açıklama : "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAciklama" runat="server"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" Width="84px" OnClick="btnKaydet_Click" />
    </asp:Panel>
    </div>
</asp:Content>
