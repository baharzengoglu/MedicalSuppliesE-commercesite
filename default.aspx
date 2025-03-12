<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webSaglikProjesi._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlstUrunler" runat="server" CellPadding="4" ForeColor="#333333" RepeatColumns="3" DataKeyField="urunid" OnItemCommand="dlstUrunler_ItemCommand" OnSelectedIndexChanged="dlstUrunler_SelectedIndexChanged">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <ItemTemplate>
            <div class="resim">
                <asp:Label ID="lblUrunKodu" runat="server" Text='<%#Eval("urunkodu") %>'></asp:Label><br />
                <asp:Label ID="lblUrunAdi" runat="server" Text='<%#Eval("urunad") %>'></asp:Label><br />
                <asp:ImageButton ID="imgResim" ImageUrl='<%#Eval("resimyolu1") %>' runat="server" AlternateText='<%#Eval("urunad") %>' Width="100px" Height="120px" /><br />
                <asp:Label ID="lblUrunFiyat" runat="server" Text='<%#Eval("urunfiyat","{0:N}") %>'></asp:Label>
                <asp:TextBox ID="txtAdet" runat="server" Width="20px" Text="1"></asp:TextBox><br />
                <asp:Button ID="btnEkle" runat="server" Text="Sepete Ekle" CommandName="sepet" /> 
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
