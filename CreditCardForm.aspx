<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCardForm.aspx.cs" Inherits="CreditCard.CreditCardForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BorderStyle="Solid" BorderWidth="2px" Text="PAYMENT INFORMATION"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" ForeColor="#999999" Text="Name"></asp:Label>
            <br />
&nbsp;<asp:TextBox ID="txtName" runat="server" Width="205px" Height="23px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCardNumber" runat="server" ForeColor="#999999" Text="Card Number"></asp:Label>
            <br />
&nbsp;<asp:TextBox ID="txtCardNo" runat="server" Width="205px" Height="23px"></asp:TextBox>
            <asp:CustomValidator ID="custCardNumber" runat="server" ErrorMessage="Invalid Card Number" ForeColor="Red">*Credit card number is invalid</asp:CustomValidator>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblExpire" runat="server" ForeColor="#999999" Text="Expiration (mm/yyyy)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCVV" runat="server" ForeColor="#999999" Text="CVV Code"></asp:Label>
            <br />
&nbsp;<asp:TextBox ID="txtExpire" runat="server" Width="88px" Height="22px"></asp:TextBox>
            <asp:CustomValidator ID="custValidExpire" runat="server" ErrorMessage="Invalid Expire Date" ForeColor="Red">*Invalid Expire Date</asp:CustomValidator>
            &nbsp; <asp:TextBox ID="txtCVV" runat="server" Width="87px" Height="23px"></asp:TextBox>
            <asp:CustomValidator ID="custValidCVV" runat="server" ErrorMessage="Invalid CVV Code" ForeColor="Red">* Invalid CVV Code</asp:CustomValidator>
            <br />
            <br />
            &nbsp;<asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" Height="30px" Width="69px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCardType" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </form>
    <p>
        &nbsp;</p>
</body>
</html>
