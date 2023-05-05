<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="EmployeeDetails.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" width="50%" border="1">
                <tr>
                    <td colspan="2" style="font-size:large;text-align:center">Employee Details</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddEmployee.aspx">Add Employee</asp:HyperLink>

                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/update_DeleteEmployee.aspx">Update/Delete Employee</asp:HyperLink>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
