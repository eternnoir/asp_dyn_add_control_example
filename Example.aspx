<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Example.aspx.cs" Inherits="Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="textPanel" runat="server">
            <asp:Button ID="btnAddText" runat="server" Text="Add One Text" OnClick="btnAddText_Click"></asp:Button>
            <br>           
        </asp:Panel>
        <br>
        <br>
        <asp:Panel ID="dropListPanel" runat="server">
            <asp:Button ID="bntAddDropList" runat="server" Text="Add One DropDownList" OnClick="bntAddDropList_Click"> </asp:Button>
            <br>           
        </asp:Panel>
    </div>
    </form>
</body>
</html>
