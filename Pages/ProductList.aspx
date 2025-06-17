<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="InventoryManagementSystem.ProductList" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product List</title>
 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Product List</h2>
            <div class="row mb-3">
    <div class="col-md-4">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by name" />
    </div>
    <div class="col-md-4">
        <asp:DropDownList ID="ddlFilterCategory" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterCategory_SelectedIndexChanged" />
    </div>
    <div class="col-md-4">
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary w-100" OnClick="btnSearch_Click" />
    </div>
</div>

            <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False"
    CssClass="table table-bordered" DataKeyNames="ProductID"
    OnRowCommand="GridViewProducts_RowCommand"
    AllowPaging="True" PageSize="5"
    OnPageIndexChanging="GridViewProducts_PageIndexChanging">

                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="imgProduct" runat="server" 
                           ImageUrl='<%# Eval("ImagePath") %>' 
                           Width="100" Height="100" />
            </ItemTemplate>
        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning"
                                        CommandName="EditProduct" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger"
            CommandName="DeleteProduct" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
        <asp:Literal ID="ltScript" runat="server"></asp:Literal>

    </form>
</body>
</html>
