<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_DeleteEmployee.aspx.cs" Inherits="EmployeeDetails.update_DeleteEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update/Delete Emp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
   <caption>Employee Details</caption>
   <tr>
      <td>Emp Id:</td>
      <td><asp:DropDownList ID="ddlEmp" runat="server" Width="169px" AutoPostBack="true" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged" /></td>
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
         <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="60" OnClick="btnUpdate_Click" />
         <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="60" OnClick="btnDelete_Click" />
      </td>
   </tr>
</table>

        </div>
    </form>
</body>
</html>
