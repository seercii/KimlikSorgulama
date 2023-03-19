<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Kisiler.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <label for="TextBoxAd">Ad:</label>
            <asp:TextBox ID="TextBoxAd" runat="server"></asp:TextBox>
            <br />
            <label for="TextBoxSoyad">Soyad:</label>
            <asp:TextBox ID="TextBoxSoyad" runat="server"></asp:TextBox>
            <br />
            <label for="TextBoxTelefonNo">Telefon No:</label>
            <asp:TextBox ID="TextBoxTelefonNo" runat="server"></asp:TextBox>
            <br />
            <label for="TextBoxTCKimlikNo">T.C. Kimlik No:</label>
            <asp:TextBox ID="TextBoxTCKimlikNo" runat="server"></asp:TextBox>
            <br />
            <label for="TextBoxDogumTarihi">Doğum Tarihi:</label>
            <asp:TextBox ID="TextBoxDogumTarihi" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonKaydet" runat="server" Text="Kaydet" OnClick="ButtonKaydet_Click" />
            <br />
            <br />
            <asp:Label ID="SuccessLabel" runat="server" ForeColor="Green"></asp:Label>
            <asp:Label ID="HataLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
