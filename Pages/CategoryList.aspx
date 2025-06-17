<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="InventoryManagementSystem.CategoryList" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Category List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Category List</h2>

            <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="False"
                          CssClass="table table-bordered" DataKeyNames="CategoryID"
                          OnRowCommand="GridViewCategories_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Category Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit"
                                        CommandName="EditCategory" CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn btn-sm btn-warning" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                        CommandName="DeleteCategory" CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn btn-sm btn-danger ms-2" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <a href="AddCategory.aspx" class="btn btn-primary mt-3">Add New Category</a>
        </div>
        <asp:Literal ID="ltScript" runat="server"></asp:Literal>
        
    </form>
</body>
</html>
