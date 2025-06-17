<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="InventoryManagementSystem.AddProduct" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Add Product</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Add New Product</h2>

            <div class="mb-3">
                <label for="txtName" class="form-label">Product Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDescription" class="form-label">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
            </div>

            <div class="mb-3">
                <label for="txtQuantity" class="form-label">Quantity</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

            <div class="mb-3">
                <label for="txtPrice" class="form-label">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

     <div class="mb-3">
                <label for="ddlCategory" class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-- Select Category --" Value="" />
                </asp:DropDownList>
            </div>

            <div class="mb-3">
    <label for="fuImage" class="form-label">Product Image</label>
    <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
</div>


            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add Product" OnClick="btnAdd_Click" />
        </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block"></asp:Label>
    </form>
</body>
</html>
