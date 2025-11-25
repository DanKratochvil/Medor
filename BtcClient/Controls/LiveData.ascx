<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveData.ascx.cs" Inherits="BtcClient.Controls.LiveData" %>
<%--<div>
    <h4>Aktuální kurz Bitcoinu</h4>
</div>--%>
<div class="card-body">
    <asp:Button ID="btnLive" runat="server" Text="Načíst Live Data"
        OnClick="btnLive_Click" CssClass="btn btn-success "/>
    <asp:Button ID="btnSave" runat="server" Text="Save"
        OnClick="btnSave_Click" CssClass="btn btn-success "/>
    <br />
    <br />
    <asp:GridView ID="gvLiveData" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="RateUpdate" HeaderText="Cena v čase" />
            <asp:BoundField DataField="RateEUR" HeaderText="Cena v EUR" />
            <asp:BoundField DataField="RateCZK" HeaderText="Cena v CZK" />
            <asp:BoundField DataField="RateEUR_CZK" HeaderText="EUR/CZK" />
        </Columns>
    </asp:GridView>
</div>


