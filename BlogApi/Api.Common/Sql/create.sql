﻿CREATE TABLE [dbo].[Comentario] (
    [Id] [uniqueidentifier] NOT NULL,
    [IdPost] [uniqueidentifier] NOT NULL,
    [Data] [datetime] NOT NULL,
    [IdUsuario] [uniqueidentifier] NOT NULL,
    [Mensagem] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Comentario] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_IdPost] ON [dbo].[Comentario]([IdPost])
CREATE INDEX [IX_IdUsuario] ON [dbo].[Comentario]([IdUsuario])
CREATE TABLE [dbo].[Post] (
    [Id] [uniqueidentifier] NOT NULL,
    [Data] [datetime] NOT NULL,
    [IdUsuario] [uniqueidentifier] NOT NULL,
    [Titulo] [nvarchar](max) NOT NULL,
    [Corpo] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Post] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_IdUsuario] ON [dbo].[Post]([IdUsuario])
CREATE TABLE [dbo].[PostTag] (
    [Id] [uniqueidentifier] NOT NULL,
    [IdPost] [uniqueidentifier] NOT NULL,
    [IdTag] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.PostTag] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_IdPost] ON [dbo].[PostTag]([IdPost])
CREATE INDEX [IX_IdTag] ON [dbo].[PostTag]([IdTag])
CREATE TABLE [dbo].[Tag] (
    [Id] [uniqueidentifier] NOT NULL,
    [Nome] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Tag] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Usuario] (
    [Id] [uniqueidentifier] NOT NULL,
    [Email] [nvarchar](max) NOT NULL,
    [Nome] [nvarchar](max) NOT NULL,
    [Senha] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Comentario] ADD CONSTRAINT [FK_dbo.Comentario_dbo.Post_IdPost] FOREIGN KEY ([IdPost]) REFERENCES [dbo].[Post] ([Id])
ALTER TABLE [dbo].[Comentario] ADD CONSTRAINT [FK_dbo.Comentario_dbo.Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([Id])
ALTER TABLE [dbo].[Post] ADD CONSTRAINT [FK_dbo.Post_dbo.Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([Id])
ALTER TABLE [dbo].[PostTag] ADD CONSTRAINT [FK_dbo.PostTag_dbo.Post_IdPost] FOREIGN KEY ([IdPost]) REFERENCES [dbo].[Post] ([Id])
ALTER TABLE [dbo].[PostTag] ADD CONSTRAINT [FK_dbo.PostTag_dbo.Tag_IdTag] FOREIGN KEY ([IdTag]) REFERENCES [dbo].[Tag] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201508101501169_Create', N'Api.Common.Migrations.Configuration',  0x1F8B0800000000000400E55CDD6EDB3614BE1FB0771074B50DA99574375B60B748DDA408D624459C14BB0B1889768849942A52818D614FB68B3DD25E61D41F45F1C7926C59761614416D8AE7E3F9F9481E9127F9F7EF7FC6EF97816F3DC398A0104FEC93D1B16D41EC861EC28B899DD0F99B5FECF7EFBEFF6E7CEE054BEB6BD9EFE7B41F93C464623F511A9D3A0E719F6000C828406E1C92704E476E1838C00B9DB7C7C7BF3A27270E641036C3B2ACF16D82290A60F6857D9D86D885114D807F157AD027453B7B32CB50AD6B10401201174EECB3088DA661108498FD87295CD2D0B6CE7C04982A33E8CF6D0B601C524099A2A7F704CE681CE2C52C620DC0BF5B4590F59B039FC0C280D3AA7B5B5B8EDFA6B638956009E52684864147C0939F0BE738B2F8462EB6B9F398FBCE999BE92AB53A73E1C4669E8398821831A7C9C39D4EFD38ED3AB13F24046148C82893477054891D59F2C3234E0BC69EF4DF91354D7C9AC47082614263E01F595F92471FB9BFC1D55DF807C4139CF8BEA827D3943DAB35B0A62F7118C198AE6EE1BCD0FED2B32DA72EE7C8825C4C90C9ADFA9420F6F99A8D0D1E7DC859E034887F0909DD0AE223A0A004609FE11D63FE067ADC93248FDB16AA5C414CC0020625089B1C6CA2DBD615587E8678419F5817B0B4AD0BB4845ED95220DF63C4D6052644E3A485FED7E0192D325E493AE4FEBC857EF6903CA1289FB8A3F4C143C534C2D488C3E036F40B21F1D9C31D8817308D4B68E8300B93D8EDA01677AF46B30AF78177AB74539FF2C14BED345D4A0344FDC64E3561D74EE3DC871D26702AF0DAA6EE01CDBB3B44133F1C60D649E34EC3381A6258E3ACAA4DE76DE7BC3CAB8C8B4297A5E80E2CCCAAB1870FF95CABAB55B66B9721FEB0CF252803D42C3E62BBDE41BD2D38CCAECE6B0E93796DCB4E0F19C3A597F9BA0BC266DB6D23BF758C52C8DF5695CCA8359A64CF5545D21F931EF9CF16C4EE4AEA5748E8EB30DD3777BB87B48E175F023BC4AC90796D713B0F00F287CF3986A08B3AEA0CE227B02F969E1112BA28A3A1B0EAD6F29ABAF2E7D8B39A929CDC92727D64C63066A28871912930B14F1487ACC1E4594A85291E04D4917F5290198B61CC7A23E04FD9C2CDE605C254A53CC22E8A80DF609824D772B2A4BEE723C84F3EC208628F0DD4607FBBA1736FABC3F351A459DCE49DB123D0A399357C4B5E175D757FAEB325DBD59AC26A80D490A51D0137A6893CF44014919DF862E89146B72994B5A4A9177288A99680A841EB991AC2C00332437060BB513347EC8D17FCDD70EDA6A0BC28AE9FE34DB450DE2D053C9EA8ED8C1BF2E843ED2C9213DB0DCBDDB11786680E304D715D779AB959FAB0167B70E6987518803F66E71E1E8BF25437BD636312302E0F551FAB5B37E515EC9EC0E22D8C14F9B4CC84147206A9E636AACAAC3514531855C7C9D72E0541B7556B65B3A55B2BAE59D41504BD741B491E4E45DA1068716AD74DA81FA20ADD4C07AD32815ABC9270F54B8F2B2C6CF10E2280AC89B05337B4A513AAE32CBD03F4B97573762D19AEDFE91BD2E906E76D6171A68ED960255B6CCC173734574C100508DD44D8CCD8EAFCDBC06FEDDED69C0575E6B5BC790900A689DBDD62DDA5A36A77D3CEDE766F6F352DDB6EE65BF9A33C64E13B0F7F3676F27290A261EC18EA46C657208A105E087524458B35CB8B48A66F66DD8B2B821CC37189A6C6826BCB47A2610C16507A9ABACD8317282634BD9E7C04E911D3D40B946EC23E6BD843CA8194AD540D59B9B99422E9E75C4C534D333243558EBC60B6A5BD3233A19E3C8AB095D6F3001FC49A73CE69E82701362759EBA4F3495B47D04F64334A7E592C62E42D5DF4E05CAFAB624CDACC58559D860855B5AA4863478A8C92202A349026A44CAC56B433ECA6DD08A703694135BDD86E487658F428CB0944A0B2AD3D4A511C2082144D07452F7DFED29D611A9C9624D34A1EF262561C46D541B469DCDE22DB4754378BE880D1CCAFC244F9BCE560A2604E19BB45C280D3221A46C9DD44A4B81315018AA65D44D584505C568A1045D3C0CC50726DB90B1F9DE7DC526E3D2EF2DCE6C26D25F1CDBBD81673CE33F2D2A477B6221406A3B4C368F6CD9FFA88D95B75B80218CD215B8FB39B78FBEDF1C95BA9F4FB70CAB01D423C5FF39EA0AFC5AE476C80828204A36F0944E979219A23186F59E5A4C229678397D883CB89FD67267F6A5DFEFE90431C5937318BEDA9756CFDB55589A70728A4BD94786E680D2F33D9C220B9401B3F83D87D02F10F0158FED8570D8DE67AF92550EE7F17EC7A55709750AB58B54ADF9DB146BD797E09C4398CB5AA56D4B9A11259F5616B1D3A1541BEBCB08A85663B61BCFEAAF425B8A656FAB7DDC2B2A99755A45A895E1F01DBB2EC6EAB1A3BF1907CE8B2BA616FAA5F4E5D5463D9DCD65595C20ADEAD9CEAA0636D3E1D3BD040AF2B809343D4AA3E6D9F516EEFF901837CE0C56C520EDFAD6CA8E39AD05398CD47643B09F50116146D5596D653C4F7B56D0F18FDCE3BF7FE8BCAD43B71C3E975D7BAB1FC8871627B8F69BCF304B3AFBA321D765F156726EC2DCBD174B03DD5A9E9A0F75DC4D6ADB24725D54117A9752F5B1288B1AEB66B5F9568B27A2DCBCE7668520FF566D2CC595712D53DC2875154B6A9897DCEB70E3563EA7D15DBCE843F47C4F65382161544FAC78930746B1B19EF7389E761B9A54A1A955D94037E0A3CB6CB9DC514CD814BD963171292FDBAE257E027D9E1CD23F42EF14D42A384329361F0E8AF4467A4FBF2BAF1B3C2B8BACEE39B28FBA5EB3E4C606AA2F4FCFD067F4890EF71BD2F342737068874C3FF04597B1E4B963F50B85871A4EB10B7042ADCC7F3943B18443E03233778069EE126BADD13F8192E80BB2AAF1DCD20CD81A8BB7DFC1181450C02526054F2EC2BE3B0172CDFFD07B5F42717954B0000 , N'6.1.3-40302')

INSERT USUARIO VALUES (NEWID(),'Teste@teste.com','Usuario Teste','1234')
INSERT POST VALUES ('475991E5-EDA1-4B3C-8D2A-5DEF826F6C7B',GETDATE(),'336BAA5D-575D-42E8-83DC-B99DB6096823','Neque porro quisquam','Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."  "Não há ninguém que ame a dor por si só, que a busque e queira tê-la, simplesmente por ser dor...')
INSERT COMENTARIO VALUES ('C5A99812-5D2D-454F-8B5D-6B7043069F8A','475991E5-EDA1-4B3C-8D2A-5DEF826F6C7B',GETDATE(),'336BAA5D-575D-42E8-83DC-B99DB6096823','Primeira comentário teste')
INSERT POSTTAG VALUES ('D1261373-33C7-4B7E-AB2D-6BA7E670204F','475991E5-EDA1-4B3C-8D2A-5DEF826F6C7B','B9DA5AC8-4E11-4467-B181-331705BF2D24')
