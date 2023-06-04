<%@ Page Title="檢視後台訂單" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4><br />
    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回點餐頁面" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" />
    </h4>
    <h4>&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="讀取訂單資料" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" />
    &nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button9_Click" Text="點餐機台排序" />
&nbsp;&nbsp;
        <asp:Button ID="Button10" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button10_Click" Text="金額排序" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;</h4>
    <h4>
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="交班總結" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" />
    </h4>
    <h4>
        機台:
        <asp:Button ID="Button15" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button15_Click" Text="全部機台總額" />
        &nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="機台1" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button5_Click" Text="機台2" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button6_Click" Text="機台3" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button7" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button7_Click" Text="機台4" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button8_Click" Text="機台5" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h4>
    <h4>
        月/週/日: <asp:Button ID="Button16" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button16_Click" Text="全部月份總額" />
&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button12" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" Text="本月" OnClick="Button12_Click" />
&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button11" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" Text="週結" OnClick="Button11_Click" />
&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="Button13" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button13_Click" Text="日結" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button14" runat="server" BackColor="#FFC72C" BorderColor="White" ForeColor="#DA291C" Height="38px" OnClick="Button14_Click" Text="月結" />
        ：<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>2022-01</asp:ListItem>
            <asp:ListItem>2022-02</asp:ListItem>
            <asp:ListItem>2022-03</asp:ListItem>
            <asp:ListItem>2022-04</asp:ListItem>
            <asp:ListItem>2022-05</asp:ListItem>
            <asp:ListItem>2022-06</asp:ListItem>
            <asp:ListItem>2022-07</asp:ListItem>
            <asp:ListItem>2022-08</asp:ListItem>
            <asp:ListItem>2022-09</asp:ListItem>
        </asp:DropDownList>
    <br />
    </h4>
    <asp:GridView ID="GridView1" runat="server" BackColor="#FF9966" BorderColor="#FF9966" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="270px" Width="1243px">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <h4>
    &nbsp;<span style="font-size: x-large">共&nbsp; 
    <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
&nbsp;元&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></h4>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Table1]"></asp:SqlDataSource>
&nbsp;
</asp:Content>
