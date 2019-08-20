<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="Day5_8.Sample" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment_5</title>
        <script type="text/javascript">
        function DeleteConfirm()
        {
            var Ans = confirm("Do you want to Delete Selected Record?");
            if (Ans)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        </script>
        <style type="text/css">
            .heading
            {
                display: flex;
                flex-direction: column;
                justify-content: center;
                text-align: center;
            }
            table
            {
                width:400px;
                margin-left: auto;
                margin-right: auto;
            }
            table th
            {
                font-weight: bold;
            }
            .auto-style1 {
                width: 105px;
            }
            .auto-style2 {
                height: 202px;
                width: 611px;
            }
            .auto-style3 {
                width: 105px;
                height: 73px;
            }
            .auto-style4 {
                height: 73px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; text-align:center">
        <h2 class="heading">Add Territory Record for the New Employee Record</h2>
    <table class="auto-style2"> 
        <tr><td class="auto-style1"><asp:Label ID="LabelEmployeeID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td>
                <asp:TextBox ID="textEmployeeID" runat="server" MaxLength="6" Width="179px"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="RegEmployeeID" runat="server" ControlToValidate="textEmployeeID" ErrorMessage="Invalid EmployeeID" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator><br />
                <asp:RequiredFieldValidator ID="ReqEmployeeID" runat="server" ErrorMessage="Enter EmployeeID" ControlToValidate="textEmployeeID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td class="auto-style3"><asp:Label ID="LabelTerritoryID" runat="server" Text="TerritoryID"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="textTerritoryID" runat="server" MaxLength="6" Width="179px"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="RegTerritoryID" runat="server" ControlToValidate="textTerritoryID" ErrorMessage="Invalid TerritoryID" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator><br />
                <asp:RequiredFieldValidator ID="ReqTerritoryID" runat="server" ErrorMessage="Enter TerritoryID" ControlToValidate="textTerritoryID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td class="auto-style1"><asp:Label ID="LabelTerritoryDescription" runat="server" Text="TerritoryDescription"></asp:Label></td>
            <td>
                <asp:TextBox ID="textTerritoryDescription" runat="server" Width="179px"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="RegTerDesc" runat="server" ControlToValidate="textTerritoryDescription" ErrorMessage="Invalid TerritoryDescription" ForeColor="Red" ValidationExpression="^[a-zA-Z]*$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ReqTerDesc" runat="server" ErrorMessage="Enter TerritoryDescription" ControlToValidate="textTerritoryDescription" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td class="auto-style1"><asp:Label ID="LabelRegionID" runat="server" Text="RegionID"></asp:Label></td>
            <td>
                <asp:TextBox ID="textRegionID" runat="server" MaxLength="1" Width="179px"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="RegRegionID" runat="server" ControlToValidate="textRegionID" ErrorMessage="Invalid RegionID" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ReqRegionID" runat="server" ErrorMessage="Enter RegionID" ControlToValidate="textRegionID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th colspan="2"><asp:Button ID="ButtonAdd" runat="server" Text="Add" onclick="AddButtonClick" Width="178px" Height="41px" /></th>
        </tr>
    </table>

                    <%--Gridview for Territories Table--%>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" DataKeyNames="TerritoryID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="80%" CssClass="auto-style1" AllowPaging="True" PageSize="5">  
                    <Columns>
                        <asp:TemplateField HeaderText="TerritoryID">              
                            <ItemTemplate>
                                <asp:Label ID="LabelGridTerritoryID" runat="server" Text='<%# Eval("TerritoryID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textGridTerritoryID" runat="server" Text='<%# Eval("TerritoryID") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TerritoryDescription">
                            <ItemTemplate>
                                <asp:Label ID="LabelGridTerritoryDescription" runat="server" Text='<%# Eval("TerritoryDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textGridTerritoryDescription" runat="server" Text='<%# Eval("TerritoryDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RegionID">
                            <ItemTemplate>
                                <asp:Label ID="LabelGridRegionID" runat="server" Text='<%# Eval("RegionID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textGridRegionID" runat="server" Text='<%# Eval("RegionID") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="CheckBoxDelHeader" Text="Delete" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="CheckBoxDelete"/>
                            </ItemTemplate>                        
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView><br /><br />
        <div style="width: 100%; text-align:center">
            <asp:Button ID="ButtonDeleteRecord" runat="server" CausesValidation="false" Text="Delete" OnClick="ButtonDeleteRecord_Click" />
        </div>
    </div>
    </form>
</body>
</html>