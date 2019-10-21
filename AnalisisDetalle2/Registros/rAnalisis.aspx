<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rAnalisis.aspx.cs" Inherits="AnalisisDetalle2.Registros.rAnalisis" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel" style="background-color: #ff7101">
        <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align:center; color: Black">Registro de Pago</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="PagoIdNumericUpDown" class="col-md-1   control-label input-sm" style="font-size: small">AnalisisId</label>
                <div class="col-md-2 ">
                    <asp:TextBox ID="AnalisisIdNumericUpDown" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="AnalisisIdNumericUpDown" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-4 ">
                          <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>
                    <%--Fecha--%>
                         <label for="FechaTebox" class="col-md-2 control-label input-sm" style="font-size: small">Fecha</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                        
                    </div>
            </div>

                    <%-- Paciente--%>
              <div class="form-group">
                    <label for="PAcienteTebox" class="col-md-1  control-label input-sm" style="font-size: small">Paciente</label>
                    <div class="col-md-3">
                        <asp:DropDownList runat="server" ID="PacienteDropDownList" CssClass="form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                    </div>


            </div>

            <%--TipoAnalisisId--%>
        

                     <div class="form-group row">
                       <label for="TipoAnalisis" class="col-md-1 control-label input-sm" style="font-size: small">TipoAnalisis</label>
                       <div class="col-md-3">
                          <asp:DropDownList runat="server" AutoPostBack="true" ID="TiposAnalisisDropDown" CssClass="form-control input-sm" OnSelectedIndexChanged="TiposAnalisisDropDown_SelectedIndexChanged" OnTextChanged="TiposAnalisisDropDown_TextChanged"></asp:DropDownList>
                       </div>
                    <div class="col-md-1">
                        <asp:LinkButton runat="server" ID="TiposModal" CausesValidation="false" CssClass="btn btn-info btn-md" data-toggle="modal" data-target="#rTiposAnalisis" Text="+"></asp:LinkButton>
                    </div>

                 <%--Precio--%>
                      <label for="PrecioTexBox" class="col-md-1  control-label input-sm" style="font-size: small">Precio</label>
                          <div class="col-md-1">
                                 <asp:TextBox ID="PrecioTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Analisis" MaxLength="200" ControlToValidate="PrecioTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                           </div>

                    <%--Resultado--%>
                      <label for="Resultado" class="col-md-1 control-label input-sm" style="font-size: small">Resultado</label>
                          <div class="col-md-3">
                              <asp:TextBox ID="ResultadoTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RFVResultado" runat="server" ValidationGroup="Analisis" MaxLength="200" ControlToValidate="ResultadoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                         </div>
                      <div class="col-sm-1">
                        <asp:LinkButton runat="server" ID="AgregarGrid" ValidationGroup="Analisis" CssClass="btn btn-outline-info btn-md" Text="Agregar" OnClick="AgregarGrid_Click"></asp:LinkButton>
                    </div>


                    
                    
                </div>

               

    </div>
            <%--GRID--%>
                <asp:GridView ID="Grid" CssClass=" col-md-offset-2 col-md-offset-2" runat="server" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="767px" AutoGenerateColumns="false" OnRowDeleted="Grid_RowDeleted" OnRowDeleting="Grid_RowDeleting">                         
                    <Columns>
                        <asp:BoundField DataField="TipoAnalisisId" HeaderText="TipoAnalisisId" /><asp:BoundField />
                        <asp:BoundField DataField="Resultado" HeaderText="Resultado" /><asp:BoundField />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" /><asp:BoundField />


                       
                    </Columns>     
                    <EmptyDataTemplate><div style="text-align:center">No hay datos en el Grid.</div></EmptyDataTemplate>
                         <AlternatingRowStyle BackColor="White" />

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>


                   <%-- Precio--%>
              <div class="col-md-6 col-md-offset-6">
                 <div class="form-group">
                     <label for="MontoTextBox" class="col-md-2 control-label input-sm" style="font-size: small" >Monto</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="MontoTextBox" ReadOnly="true"  runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                   </div>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
               </div>
             </div>
            

               <%-- Balance--%>
                    <div class="col-md-6 col-md-offset-6">
            <div class="form-group">
                <label for="BalanceTextBox" class="col-md-2 control-label input-sm" style="font-size: small" > Balance</label>
                <div class="col-md-6">
                    <asp:TextBox ID="BalanceTextBox" ReadOnly ="true" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
               </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="BalanceTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
               </div>
            </div>

            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click"   />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click"  />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click"  />
                    </div>
                </div>
            </div>
        </div>
            </div>
   
</asp:Content>