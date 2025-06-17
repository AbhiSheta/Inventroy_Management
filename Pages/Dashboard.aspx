<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1" CodeBehind="Dashboard.aspx.cs" Inherits="InventoryManagementSystem.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard - Inventory Management System</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    <style>
        .card:hover {
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.2);
            cursor: pointer;
            transition: 0.3s;
        }
        .logout-btn {
            position: fixed;
            top: 20px;
            right: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">

            <div class="d-flex justify-content-between align-items-center mb-4">
                <h2><i class="bi bi-speedometer2 me-2"></i>Dashboard Summary</h2>
                <div>
                    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" SkinID="PrimaryButton"  OnClick="btnAddProduct_Click" />
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-success" OnClick="btnAddCategory_Click" />
                </div>
            </div>

            <div class="row g-4">
                <div class="col-md-3">
                    <asp:LinkButton ID="lnkTotalProducts" runat="server" OnClick="lnkTotalProducts_Click" CssClass="card text-decoration-none text-dark">
                        <div class="card-body text-center">
                            <h5><i class="bi bi-box-seam me-2"></i>Total Products</h5>
                            <asp:Label ID="lblTotalProducts" runat="server" CssClass="display-6 fw-bold"></asp:Label>
                        </div>
                    </asp:LinkButton>
                </div>

                <div class="col-md-3">
                    <asp:LinkButton ID="lnkTotalCategories" runat="server" OnClick="lnkTotalCategories_Click" CssClass="card text-white bg-success text-center text-decoration-none">
                        <div class="card-body">
                            <h5><i class="bi bi-tags-fill me-2"></i>Total Categories</h5>
                            <asp:Label ID="lblTotalCategories" runat="server" CssClass="display-6 fw-bold"></asp:Label>
                        </div>
                    </asp:LinkButton>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-warning text-center">
                        <div class="card-body">
                            <h5><i class="bi bi-stack me-2"></i>Total Quantity</h5>
                            <asp:Label ID="lblTotalQuantity" runat="server" CssClass="display-6 fw-bold"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-info text-center">
                        <div class="card-body">
                            <h5><i class="bi bi-currency-rupee me-2"></i>Total Value</h5>
                            <asp:Label ID="lblTotalValue" runat="server" CssClass="display-6 fw-bold"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="divLowStock" runat="server" CssClass="alert alert-danger mt-4" Visible="false">
    <h5><i class="bi bi-exclamation-triangle-fill me-2"></i>Low Stock Alerts:</h5>
    <ul class="mb-0">
        <asp:Repeater ID="rptLowStock" runat="server">
            <ItemTemplate>
                <li><%# Container.DataItem %></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Panel>

        <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" CssClass="btn btn-danger logout-btn" />
    </form>
</body>
</html>
