<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rPago.aspx.cs" Inherits="AnalisisDetalle2.Registros.rPago" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel" style="background-color: #ff7101">
        <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align:center; color: Black">Registro de Pago</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="PagoIdNumericUpDown" class="col-md-3 control-label input-sm" style="font-size: small">PagoId</label>
                <div class="col-md-2 ">
                    <asp:TextBox ID="PagoIdNumericUpDown" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="PagoIdNumericUpDown" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                          <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>

                         <label for="FechaTebox" class="col-md-2 control-label input-sm" style="font-size: small">Fecha</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" MaxLength="200" ControlToValidate="FechaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
            </div>

          


                  <div class="form-group">
                      <label for="Paciente" class="col-md-3 control-label input-sm" style="font-size: small" >Paciente</label>
                         <div class="col-md-4">
                            <asp:DropDownList   runat="server"  AutoPostBack="true" ID="PacienteIdTextBox"   class="form-control input-sm" Style="font-size: small" OnSelectedIndexChanged="PacienteIdTextBox_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
              

                     </div>

                  <%--AnalisisId--%>
           <div class="form-group">
                      <label for="Analisis" class="col-md-3 control-label input-sm" style="font-size: small" >Analisis</label>
                         <div class="col-md-4">
                            <asp:DropDownList   runat="server" AutoPostBack="true" ID="AnalisisIdTextbox" class="form-control input-sm" Style="font-size: small" OnSelectedIndexChanged="AnalisisIdTextbox_SelectedIndexChanged" OnTextChanged="AnalisisIdTextbox_TextChanged" ></asp:DropDownList>
                        </div>
      
                     </div>

            

           <div class="form-group">
             
                  <%--Monto a pagar--%>

                 <label for="MontoTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >MontoAnalisis</label>
                         <div class="col-md-2">
                            <asp:TextBox ID="MontoAnalisisTextBox"  runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                        </div>
                 
                 <%--Monto--%>
                <div class="form-group row">

                     <label for="MontoAPagar" class="col-md-5 control-label input-sm" style="font-size: small">Monto A Pagar</label>
                      <div class="col-md-3 ">
                         <asp:TextBox ID="MontoAPagarTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="MontoAPagarTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
           
                    
                      <div class="col-md-1 ">
                         <asp:Button ID="Agregar" runat="server" Text="Agregar" class="btn btn-primary" OnClick="Agregar_Click"  />
                     </div>

                     </div>
                 </div>
    </div>
            <%--GRID--%>
                <asp:GridView ID="Grid" CssClass=" col-md-offset-4 col-sm-offset-4" runat="server" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="767px" AutoGenerateColumns="false">                         
                    <Columns>
                        <asp:BoundField DataField="PagoId" HeaderText="Pago Id" /><asp:BoundField />
                  
                        <asp:BoundField DataField="AnalisisId" HeaderText="AnalisisId" /><asp:BoundField />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" /><asp:BoundField />
                        <asp:BoundField DataField="MontoAnalisis" HeaderText="Monto Analisis" /><asp:BoundField /> 
                        <asp:BoundField DataField="BalancePendiente" HeaderText="Balance" /><asp:BoundField />
                        <asp:BoundField DataField="MontoPagado" HeaderText="Monto Pagado" /><asp:BoundField />

                       
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

                <%--Monto a pagar--%>
             <div class="form-group row">
                  <label for="MontoAPagar" class="col-md-8 control-label input-sm" style="font-size: small">Monto Total</label>
                      <div class="col-md-2 ">
                         <asp:TextBox ID="MontoTotalTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="MontoAPagarTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
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