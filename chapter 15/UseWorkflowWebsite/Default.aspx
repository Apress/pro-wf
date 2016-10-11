<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Invoke a Workflow</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Dividend:"></asp:Label><br />
        <asp:TextBox ID="dividend" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Divisor:"></asp:Label><br />
        <asp:TextBox ID="divisor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Calculate" /><br />
        <asp:Label ID="Label3" runat="server" Text="Quotient:"></asp:Label>
        <br />
        <asp:TextBox ID="quotient" runat="server" ReadOnly="True"></asp:TextBox><br />
        &nbsp;
        <br />
    
    </div>
    </form>
</body>
</html>
