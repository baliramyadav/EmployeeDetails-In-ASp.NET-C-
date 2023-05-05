<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EmployeeDetails.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
   <caption>Employee Details</caption>
   <tr>
      <td>Emp Id:</td>
      <td><asp:TextBox ID="txtId" runat="server" ReadOnly="true" /></td>
   </tr>
   <tr>
      <td>Emp Name:</td>
      <td><asp:TextBox ID="txtName" runat="server" /></td>
   </tr>
   <tr>
      <td>Emp Job:</td>
      <td><asp:TextBox ID="txtJob" runat="server" /></td>
   </tr>
   <tr>
      <td>Emp Salary:</td>
      <td><asp:TextBox ID="txtSalary" runat="server" /></td>
   </tr>
   <tr>
      <td>Department Id:</td>
      <td><asp:DropDownList ID="ddlDept" runat="server" Width="169px" /></td>
   </tr>
   <tr>
      <td colspan="2" align="center">
         <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="60" OnClick="btnInsert_Click" />
         <asp:Button ID="btnReset" runat="server" Text="Reset" Width="60" OnClick="btnReset_Click" />
      </td>
   </tr>
</table>

        </div>
    </form>
</body>
</html>
