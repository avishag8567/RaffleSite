<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RaffleSite.Default" %>

<!DOCTYPE html>
<html lang="he" dir="rtl">
<head runat="server">
    <meta charset="utf-8" />
    <title>הגרלות תלמידות</title>
<style>
body {
    background-image: url('עיצוב ללא שם.png');
    background-repeat: no-repeat;
    background-position: center center;
    background-size: contain; /* לא cover אלא contain!! */
    background-color: white; /* צבע רקע מתחת */
    min-height: 100vh;
    margin: 0;
    font-family: Arial, sans-serif;
    text-align: center;
}

form {
    margin-top: 300px; /* תשחקי עם המספר לפי כמה שצריך */
}


.btn {
    padding: 10px 20px;
    margin: 10px;
    font-size: 18px;
    background-color: #6c5ce7;
    color: white;
    border: none;
    border-radius: 10px;
    cursor: pointer;
}
.combo {
    margin: 20px;
}
#result {
    font-size: 30px;
    margin-top: 30px;
    color: #2d3436;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnRaffleClass" runat="server" Text="הגרלת כיתה" CssClass="btn" OnClick="btnRaffleClass_Click" />
        <asp:Button ID="btnRaffleStudent" runat="server" Text="הגרלת שם" CssClass="btn" OnClick="btnRaffleStudent_Click" />
        
        <div class="combo">
            <asp:DropDownList ID="ddlClasses" runat="server" CssClass="btn"></asp:DropDownList>
            <asp:Button ID="btnRaffleStudentFromClass" runat="server" Text="הגרלת בת מהכיתה" CssClass="btn" OnClick="btnRaffleStudentFromClass_Click" />
        </div>

        <div id="result" runat="server"></div>
    </form>
</body>
</html>
