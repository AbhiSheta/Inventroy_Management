<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="InventoryManagementSystem.EditProduct" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Edit Product</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Edit Product</h2>

            <asp:HiddenField ID="hfProductID" runat="server" />

            <div class="mb-3">
                <label class="form-label">Product Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
            </div>

            <div class="mb-3">
                <label class="form-label">Quantity</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

            <div class="mb-3">
                <label class="form-label">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

            <div class="mb-3">
                <label class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Current Image</label><br />
                <asp:Image ID="imgCurrent" runat="server" Width="120" />
            </div>

            <div class="mb-3">
                <label class="form-label">Replace Image (optional)</label>
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-success"></asp:Label>
        </div>
    </form>
</body>
</html>
