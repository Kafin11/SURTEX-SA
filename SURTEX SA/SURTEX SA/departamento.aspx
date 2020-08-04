<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas.Master" AutoEventWireup="true" CodeBehind="departamento.aspx.cs" Inherits="SURTEX_SA.departamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
       <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>
        <asp:HiddenField ID="hdf_dep" runat="server"></asp:HiddenField>
            <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<div class="row">
		<ol class="breadcrumb">
				<li><a href="#">
					<em class="fa fa-home"></em>
				</a></li>
				<li class="active">Listar Departamentos</li>
			</ol>

			<div class="panel-body articles-container" >
			<div class="panel panel-default articles">
			
			<table class="table table-striped table-bordered table-hover dataTable no-footer dtr-inline collapsed">
                <tr>
                                                <td>
                                                Departamento:
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="Txt_dep" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                <tr>
                  <td >
                            
                                                Nombre:
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="Txt_nom" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                Apellido:
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="Txt_ape" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                Descripcion:
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="Txt_des" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td>
                                                Empresa:
                                                </td>
                                                <td align="center">
                                                    <asp:DropDownList ID="Dr_emp" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>

                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />&nbsp;&nbsp;<asp:Button ID="btn_actulizar" OnClick="btn_actulizar_Click" CssClass="btn btn-warning"  runat="server" Text="Actulizar"  />&nbsp;&nbsp;<asp:Button ID="btn_eliminar" OnClick="btn_eliminar_Click" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('esta seguro de eliminar?')"  />
                                                </td>
                                            </tr>
              <tr>
                                        <td colspan="4">
                                            <div>
                                            <asp:GridView ID="Grv_dep"  AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-striped table-bordered table-hover dataTable no-footer dtr-inline collapsed"  ViewStateMode="Enabled">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                            
                                                            <asp:BoundField DataField="dep_id" HeaderText="id" />
                                                            <asp:BoundField DataField="dep_nombre" HeaderText="Departamento" />
                                                            <asp:BoundField DataField="dep_nombre_jefe" HeaderText="Nombre" />
                                                            <asp:BoundField DataField="dep_apellido_jefe" HeaderText="Apellido" />
                                                            <asp:BoundField DataField="dep_descripcion" HeaderText="Descripcion" />
                                                            <asp:BoundField DataField="dep_estado" HeaderText="Estado" />
                                                            <asp:BoundField DataField="emp_id" HeaderText="Empresa" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="Lnk_Seleccionar" CommandArgument='<%#Eval("dep_id") %>' OnClick="Lnk_Seleccionar_Click"  runat="server">Seleccionar</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                  
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </td>
                        </tr>
                           
                </td>
            </tr>
                   
			</table>
                </div>
                </div>
            </div>
                </div>
            </ContentTemplate>
    </asp:UpdatePanel>
        </form>
</asp:Content>
