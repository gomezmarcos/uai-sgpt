<%@ Page Title="Autenticar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Autenticar.aspx.cs" Inherits="GUI.Autenticar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aqui puede ingresar al sistema</h3>

    <div class = "container">

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="exampleInputEmail1">Usuario</label>
                    <asp:TextBox CssClass="form-control" ID="txtAlias" runat="server" >Ingrese usuario</asp:TextBox>
                    <small id="emailHelp" class="form-text text-muted">Nunca compartiremos tus datos.</small>
                </div>
            </div>
        </div>
        <asp:RequiredFieldValidator id="vUsuairo" runat="server"
            ControlToValidate="txtAlias"
            ErrorMessage="El Alias es un dato obligatorio."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="exampleInputPassword1">Contrasena</label>
                    <asp:TextBox TextMode="Password" CssClass="form-control" ID="txtPassword" runat="server" >Ingrese contrasena</asp:TextBox>
                </div>
            </div>
        </div>
        <asp:RequiredFieldValidator id="vPassword" runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="El Password es un dato obligatorio."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Button id="submitButton" runat="server" Text="Submit" CssClass="btn btn-primary " OnClick="SubmitForm" />
                </div>
            </div>
        </div>

    </div>

    <input type="hidden" id="tieneError" runat="server" value="false" ClientIDMode="Static"/>
    <!-- Modal -->
    <div id="myModal" class="modal" role="dialog">
        <div class="modal-dialog">
        <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </p>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>

    <script>
        $(document).ready(function(){
            if ( JSON.parse($("#tieneError").val()) ) {
                $("#myModal").modal("show");
            }
        });
</script>
</asp:Content>