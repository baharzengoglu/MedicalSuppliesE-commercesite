<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="webSaglikProjesi.UrunEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ddlKategoriler" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:DropDownList ID="ddlAltKategoriler" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlAltKategoriler_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:GridView ID="gvUrunler" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="urunid" ForeColor="#333333" GridLines="None" Width="470px" OnSelectedIndexChanged="gvUrunler_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="urunid" HeaderText="ID" ItemStyle-Width="20px"></asp:BoundField>
            <asp:BoundField DataField="urunkodu" HeaderText="Ürün Kodu"  ItemStyle-Width="120px"/>
            <asp:BoundField DataField="urunad" HeaderText="Ürün Adı"  ItemStyle-Width="170px"/>
            <asp:BoundField DataField="urunkategorino" HeaderText="KategoriNo" Visible="False" />
            <asp:BoundField DataField="urunaltkategorino" HeaderText="AltKategoriNo" Visible="False" />
            <asp:BoundField DataField="miktar" HeaderText="Miktar" />
            <asp:BoundField DataField="urunfiyat" HeaderText="Fiyat" />
            <asp:BoundField DataField="urunbilgisi" HeaderText="Ürün Bilgisi"  ItemStyle-Width="100px"/>
            <asp:BoundField DataField="resimyolu1" HeaderText="Küçük Resim" Visible="False" />
            <asp:BoundField DataField="resimyolu2" HeaderText="Büyük Resim" Visible="False" />
        </Columns>
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
    <asp:Label ID="lblUrunID" runat="server"></asp:Label>
    <br />
    <table>
        <tr>
            <td width="120px"><asp:Label ID="Label1" runat="server" Text="Ürün Kodu :"></asp:Label></td>
            <td width="200px"><asp:TextBox ID="txtUrunKodu" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label2" runat="server" Text="Ürün Adı :"></asp:Label></td>
            <td width="200px"><asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label3" runat="server" Text="Ürün Miktar:"></asp:Label></td>
            <td width="200px"><asp:TextBox ID="txtMiktar" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label4" runat="server" Text="Ürün Fiyat:"></asp:Label></td>
            <td width="200px"><asp:TextBox ID="txtFiyat" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label5" runat="server" Text="Ürün Bilgisi:"></asp:Label></td>
            <td width="200px"><asp:TextBox ID="txtUrunBilgisi" runat="server" Height="41px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label6" runat="server" Text="Küçük Resim:"></asp:Label></td>
            <td width="200px"><asp:FileUpload ID="fuResim1" runat="server" /></td>
        </tr>
        <tr>
            <td width="120px"><asp:Label ID="Label7" runat="server" Text="Büyük Resim:"></asp:Label></td>
            <td width="200px"><asp:FileUpload ID="fuResim2" runat="server" /></td>
        </tr>
        <tr>
            <td width="120px" align="right">
                <asp:Button ID="btnDegistir" runat="server" Text="Değiştir" /></td>
            <td width="200px" align="center">
                <asp:Button ID="btnEkle" runat="server" Text="Ürün Ekle" OnClick="btnEkle_Click" /></td>
        </tr>
    </table>
</asp:Content>
