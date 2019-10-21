<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rPacientes.aspx.cs" Inherits="AnalisisDetalle2.Registros.rPacientes" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel" style="background-color: #ff7101">
        <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align:center; color: Black">Registro de Pacientes</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="PacienteIdTextBox" class="col-md-3 control-label input-sm" style="font-size: small">PacienteId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="PacienteIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="PacienteIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click" />
                </div>
            </div>

            <%-- Nombres--%>
            <div class="form-group">
                <label for="NombreTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >Nombre</label>
                <div class="col-md-6">
                    <asp:TextBox ID="NombreTextBox" runat="server"  onkeypress="return isLetterKey(event)" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
          <%-- Precio--%>
             <div class="form-group">
                <label for="BalanceTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Precio Analisis</label>
                <div class="col-md-2">
                    <asp:TextBox ID="BalanceTextBox" ReadOnly ="true" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="BalanceTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
          
            </div>

            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click1"  />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
            </div>
    </div>
</asp:Content>
