# FacturacionAPI

sistema de de facturación basico
## Requisitos Previos

- .NET 6.0 o superior
- SQL Server


### Backend

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/tuusuario/tu-repositorio.git
   cd tu-repositorio

2. Configurar la cadena de conexión de la base de datos en appsettings.json
3. Relaciono Insert de bases para pruebas :

   INSERT INTO [dbo].[CatTipoCliente] (TipoCliente) VALUES ('Empresa');
INSERT INTO [dbo].[CatTipoCliente] (TipoCliente) VALUES ('Particular');



INSERT INTO [dbo].[TblClientes] (RazonSocial, IdTipoCliente, FechaCreacion, RFC)
VALUES ('Acme Corp', 1, '2024-07-30', 'ACME123456');

INSERT INTO [dbo].[TblClientes] (RazonSocial, IdTipoCliente, FechaCreacion, RFC)
VALUES ('Olimpica', 2, '2024-07-30', 'O123456');



INSERT INTO [dbo].[CatProductos] (NombreProducto, ImagenProducto, PrecioUnitario, ext)
VALUES ('Laptop Gaming', NULL, 1200.00, 'jpg');

INSERT INTO [dbo].[CatProductos] (NombreProducto, ImagenProducto, PrecioUnitario, ext)
VALUES ('Smartphone', NULL, 800.00, 'png');

INSERT INTO [dbo].[CatProductos] (NombreProducto, ImagenProducto, PrecioUnitario, ext)
VALUES ('Auriculares Bluetooth', NULL, 150.00, 'jpeg');

 

