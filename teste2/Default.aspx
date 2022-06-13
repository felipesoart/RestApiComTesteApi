<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="teste2.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Verificação de número romano</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="alert alert-dismissable" runat="server" id="divMensagem" visible="false" enableviewstate="false">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                </div>
            </div>
        </div>

    </div>

    <div class="form-group col-lg-10">
        <div class="col-lg-4">
            <label for="txtDigite">Palavra:</label>
            <asp:TextBox ID="txtDigite" runat="server" CssClass="form-control" placeholder="Exp.: AXDELIS"></asp:TextBox>
            <asp:HiddenField ID="hdDigite" runat="server" />
            <%-- <input type="text" id="txtDigite" placeholder="Exp.: AXDELIS"><br>--%>
        </div>
        <div runat="server" id="divOptin" class="col-lg-2" style="padding-top: 25px">
            <asp:Button runat="server" ID="btnSolicitarVarificacao" Text="Solicitar Varificação" CssClass="btn btn-default" OnClick="btnSolicitarVarificacao_Click" />

        </div>
    </div>
    
    <div class="col-lg-12">
        <div class="form-group">
            <label class="control-label" style="display: block">Retorno Json:</label>
            <br />
            <div class="form-group" style="display: inline-block;">
                <asp:Label ID="lbjson" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ScriptFinal">
</asp:Content>
