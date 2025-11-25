BE BitcoinAPI Rest API v NET.8 běží na adrese http://localhost:5893, lze změnit v appsetting.json.
FE BtcClient je Webforms aplikace v FrameWork 4.8, base URL HttpClienta lze změnit ve Web.config :  <add key="ApiBaseUrl" value="http://localhost:5893/" /> 
Data ukládá BitcoinAPI do MSSQL, ConnectionString je v appsetting.json.
Zvolen přístup Code First, DB a tabulka BtcRateData se vytvoří přes PM příkaz Update-Database.
Po spuštění BitcoinAPI se zobrazí Swagger, kde je možné otestovat metody obou kontrolerů, Postman není potřeba.
Logování přes Serilog na konzoli a složky Logs.

BtcClient:
Řazení proběhne po kliknutí na název sloupce, po dalším kliknutí se změní směr řazení.
Filtruje se podle sloupce Cena v čase (Datum od, Datum do) a Cena v CZK (Cena od, Cena do).
