<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="InventoryManagementSystem.AddCategory" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Add Category</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Add New Category</h2>

            <div class="mb-3">
                <label for="txtName" class="form-label">Category Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDescription" class="form-label">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
            </div>

            <asp:Button ID="btnAdd" runat="server" Text="Add Category" OnClick="btnAdd_Click" CssClass="btn btn-success" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success ms-3"></asp:Label>
        </div>
    </form>
</body>
</html>
