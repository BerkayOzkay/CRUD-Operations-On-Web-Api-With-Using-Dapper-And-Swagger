# CRUD-Operations-On-Web-Api-With-Using-Dapper-And-Swagger
Making CRUD operations with using Dapper(Mikro ORM) and Swagger(UI) technologies.

<h1>SQL CODES</h1>
<pre>
CREATE TABLE [dbo].[OfisAraclari] ( <br>
    [SiparisKod] UNIQUEIDENTIFIER NOT NULL,<br>
    [Miktar]     INT              NULL,<br>
    [Ad]         NVARCHAR (70)    NULL,<br>
    [Maliyet]    FLOAT (53)       NULL,<br>
    CONSTRAINT [PK_OfisAraclari] PRIMARY KEY CLUSTERED ([SiparisKod] ASC)
);
</pre>
 
