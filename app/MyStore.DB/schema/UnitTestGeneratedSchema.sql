
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBE6AB380FD63DCD9]') AND parent_object_id = OBJECT_ID('ProductCategories'))
alter table ProductCategories  drop constraint FKBE6AB380FD63DCD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AE81882404AE6E]') AND parent_object_id = OBJECT_ID('Products_ProductCategories'))
alter table Products_ProductCategories  drop constraint FK49AE81882404AE6E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AE8188FD63DCD9]') AND parent_object_id = OBJECT_ID('Products_ProductCategories'))
alter table Products_ProductCategories  drop constraint FK49AE8188FD63DCD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099B36683F41]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099B36683F41


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB3BC66EA34AC580B]') AND parent_object_id = OBJECT_ID('OrderLineItems'))
alter table OrderLineItems  drop constraint FKB3BC66EA34AC580B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB3BC66EA2404AE6E]') AND parent_object_id = OBJECT_ID('OrderLineItems'))
alter table OrderLineItems  drop constraint FKB3BC66EA2404AE6E


    if exists (select * from dbo.sysobjects where id = object_id(N'ProductCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ProductCategories

    if exists (select * from dbo.sysobjects where id = object_id(N'Products_ProductCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products_ProductCategories

    if exists (select * from dbo.sysobjects where id = object_id(N'People') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table People

    if exists (select * from dbo.sysobjects where id = object_id(N'Orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Orders

    if exists (select * from dbo.sysobjects where id = object_id(N'Customers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customers

    if exists (select * from dbo.sysobjects where id = object_id(N'Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products

    if exists (select * from dbo.sysobjects where id = object_id(N'OrderLineItems') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table OrderLineItems

    create table ProductCategories (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       ProductCategoryFk INT null,
       primary key (Id)
    )

    create table Products_ProductCategories (
        ProductCategoryFk INT not null,
       ProductFk INT not null
    )

    create table People (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       BirthDate DATETIME null,
       primary key (Id)
    )

    create table Orders (
        Id INT IDENTITY NOT NULL,
       PlacedOn DATETIME null,
       OrderStatusTypeFk INT null,
       CustomerFk INT null,
       primary key (Id)
    )

    create table Customers (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       StreetAddress NVARCHAR(255) null,
       ZipCode NVARCHAR(255) null,
       primary key (Id)
    )

    create table Products (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Amount DECIMAL(19,5) null,
       primary key (Id)
    )

    create table OrderLineItems (
        Id INT IDENTITY NOT NULL,
       OrderFk INT null,
       Amount DECIMAL(19,5) null,
       ProductFk INT null,
       Quantity INT null,
       primary key (Id)
    )

    alter table ProductCategories 
        add constraint FKBE6AB380FD63DCD9 
        foreign key (ProductCategoryFk) 
        references ProductCategories

    alter table Products_ProductCategories 
        add constraint FK49AE81882404AE6E 
        foreign key (ProductFk) 
        references Products

    alter table Products_ProductCategories 
        add constraint FK49AE8188FD63DCD9 
        foreign key (ProductCategoryFk) 
        references ProductCategories

    alter table Orders 
        add constraint FK318A099B36683F41 
        foreign key (CustomerFk) 
        references Customers

    alter table OrderLineItems 
        add constraint FKB3BC66EA34AC580B 
        foreign key (OrderFk) 
        references Orders

    alter table OrderLineItems 
        add constraint FKB3BC66EA2404AE6E 
        foreign key (ProductFk) 
        references Products
