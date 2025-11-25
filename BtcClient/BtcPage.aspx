<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="BtcPage.aspx.cs" Inherits="BtcClient.BtcPage" %>

<%@ Register Src="~/Controls/LiveData.ascx" TagPrefix="uc" TagName="LiveData" %>
<%@ Register Src="~/Controls/SavedData.ascx" TagPrefix="uc" TagName="SavedData" %>
<%@ Register Src="~/Controls/FilterControl.ascx" TagPrefix="uc" TagName="FilterControl" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bitcoin Data</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container my-4">
            <h4>Aktuální kurz Bitcoinu</h4>
            <uc:LiveData ID="ucLiveData" runat="server" />
            <div class="mt-5">
                <h4>Uložené Hodnoty</h4>
            </div>
            <uc:FilterControl ID="ucFilterControl" runat="server" OnFilterApplied="ucFilterControl_FilterApplied" />
            <div class="mt-3">
                <uc:SavedData ID="ucSavedData" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

