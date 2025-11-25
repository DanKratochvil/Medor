<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterControl.ascx.cs" Inherits="BtcClient.Controls.FilterControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div class="filter-panel">

    <asp:Label ID="lblFromDate" runat="server" Text="Datum od:" />
    <asp:TextBox ID="txtFromDate" runat="server" CssClass="date-input" />
    <ajaxToolkit:CalendarExtender ID="ceFromDate" runat="server"
        TargetControlID="txtFromDate" Format="dd.MM.yyyy" />

    <asp:Label ID="lblToDate" runat="server" Text="Datum do:" />
    <asp:TextBox ID="txtToDate" runat="server" CssClass="date-input" />
    <ajaxToolkit:CalendarExtender ID="ceToDate" runat="server"
        TargetControlID="txtToDate" Format="dd.MM.yyyy" />

    <asp:Label ID="lblMinPrice" runat="server" Text="Cena od:" />
    <asp:TextBox ID="txtMinPrice" runat="server" CssClass="decimal-input" />
    <ajaxToolkit:MaskedEditExtender ID="meeMinPrice" runat="server"
        TargetControlID="txtMinPrice"
        Mask="9999999" MaskType="Number" />

    <asp:Label ID="lblMaxPrice" runat="server" Text="Cena do:" />
    <asp:TextBox ID="txtMaxPrice" runat="server" CssClass="decimal-input" />
    <ajaxToolkit:MaskedEditExtender ID="meeMaxPrice" runat="server"
        TargetControlID="txtMaxPrice"
        Mask="9999999" MaskType="Number" />


    <asp:Button ID="btnApplyFilter" runat="server" Text="Filtrovat"
        CssClass="btn btn-primary" OnClick="btnApplyFilter_Click" />
    <asp:Button ID="btnClearFilter" runat="server" Text="Smazat Filtr"
        CssClass="btn btn-secondary" OnClick="btnClearFilter_Click" />

</div>
