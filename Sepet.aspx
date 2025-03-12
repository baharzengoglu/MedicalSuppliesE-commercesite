<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="webSaglikProjesi.Sepet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="images/sepetonay2.jpg" /><br />
<asp:GridView ID="gvSepet" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="436px" OnRowDeleting="gvSepet_RowDeleting" ShowFooter="True">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="urunKodu" HeaderText="ÜrünKodu" />
        <asp:BoundField DataField="urunad" HeaderText="Ürün Adı">
        <ItemStyle Width="200px" />
        </asp:BoundField>
        <asp:BoundField DataField="fiyat" HeaderText="Fiyat">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="adet" HeaderText="Adet">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="tutar" HeaderText="Tutar">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:CommandField DeleteText="sil" ShowDeleteButton="True">
        <ItemStyle ForeColor="Red" />
        </asp:CommandField>
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
<asp:Button ID="btnTemizle" runat="server" OnClick="btnTemizle_Click" Text="Sepeti Boşalt" Width="102px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnDevam" runat="server" OnClick="btnDevam_Click" Text="Alışverişe Devam" Width="111px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnSatinAl" runat="server" Text="Satın Al" Width="84px" OnClick="btnSatinAl_Click" />

</asp:Content>
