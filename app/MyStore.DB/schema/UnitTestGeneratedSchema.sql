
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBE6AB380FD63DCD9]') AND parent_object_id = OBJECT_ID('ProductCategories'))
alter table ProductCategories  drop constraint FKBE6AB380FD63DCD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AE81882404AE6E]') AND parent_object_id = OBJECT_ID('Products_ProductCategories'))
alter table Products_ProductCategories  drop constraint FK49AE81882404AE6E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AE8188FD63DCD9]') AND parent_object_id = OBJECT_ID('Products_ProductCategories'))
alter table Products_ProductCategories  drop constraint FK49AE8188FD63DCD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD3A519ED5296816]') AND parent_object_id = OBJECT_ID('Cars'))
alter table Cars  drop constraint FKD3A519ED5296816


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8848AC766BD34DF1]') AND parent_object_id = OBJECT_ID('Answers'))
alter table Answers  drop constraint FK8848AC766BD34DF1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8848AC76A552E82C]') AND parent_object_id = OBJECT_ID('Answers'))
alter table Answers  drop constraint FK8848AC76A552E82C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099B36683F41]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099B36683F41


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D21F01B6BD34DF1]') AND parent_object_id = OBJECT_ID('TicetPersonAssignations'))
alter table TicetPersonAssignations  drop constraint FK6D21F01B6BD34DF1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D21F01B5EEE2A4]') AND parent_object_id = OBJECT_ID('TicetPersonAssignations'))
alter table TicetPersonAssignations  drop constraint FK6D21F01B5EEE2A4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB3BC66EA34AC580B]') AND parent_object_id = OBJECT_ID('OrderLineItems'))
alter table OrderLineItems  drop constraint FKB3BC66EA34AC580B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB3BC66EA2404AE6E]') AND parent_object_id = OBJECT_ID('OrderLineItems'))
alter table OrderLineItems  drop constraint FKB3BC66EA2404AE6E


    if exists (select * from dbo.sysobjects where id = object_id(N'ProductCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ProductCategories

    if exists (select * from dbo.sysobjects where id = object_id(N'Products_ProductCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products_ProductCategories

    if exists (select * from dbo.sysobjects where id = object_id(N'People') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table People

    if exists (select * from dbo.sysobjects where id = object_id(N'Owners') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Owners

    if exists (select * from dbo.sysobjects where id = object_id(N'Cars') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Cars

    if exists (select * from dbo.sysobjects where id = object_id(N'Answers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Answers

    if exists (select * from dbo.sysobjects where id = object_id(N'Orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Orders

    if exists (select * from dbo.sysobjects where id = object_id(N'Customers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customers

    if exists (select * from dbo.sysobjects where id = object_id(N'Tickets') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tickets

    if exists (select * from dbo.sysobjects where id = object_id(N'TicetPersonAssignations') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TicetPersonAssignations

    if exists (select * from dbo.sysobjects where id = object_id(N'Questions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Questions

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

    create table Owners (
        Id INT IDENTITY NOT NULL,
       primary key (Id)
    )

    create table Cars (
        Id INT IDENTITY NOT NULL,
       OwnerFk INT null,
       primary key (Id)
    )

    create table Answers (
        Id INT IDENTITY NOT NULL,
       Text NVARCHAR(255) null,
       DateCreated DATETIME null,
       DateUpdated DATETIME null,
       PersonFk INT null,
       QuestionFk INT null,
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

    create table Tickets (
        Id INT IDENTITY NOT NULL,
       Created DATETIME null,
       Title NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       TicketStatus INT null,
       primary key (Id)
    )

    create table TicetPersonAssignations (
        Id INT IDENTITY NOT NULL,
       PersonFk INT null,
       TicketFk INT null,
       AssignationStart DATETIME null,
       AssignationEnd DATETIME null,
       primary key (Id)
    )

    create table Questions (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       Content NVARCHAR(255) null,
       DateCreated DATETIME null,
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

    alter table Cars 
        add constraint FKD3A519ED5296816 
        foreign key (OwnerFk) 
        references Owners

    alter table Answers 
        add constraint FK8848AC766BD34DF1 
        foreign key (PersonFk) 
        references People

    alter table Answers 
        add constraint FK8848AC76A552E82C 
        foreign key (QuestionFk) 
        references Questions

    alter table Orders 
        add constraint FK318A099B36683F41 
        foreign key (CustomerFk) 
        references Customers

    alter table TicetPersonAssignations 
        add constraint FK6D21F01B6BD34DF1 
        foreign key (PersonFk) 
        references People

    alter table TicetPersonAssignations 
        add constraint FK6D21F01B5EEE2A4 
        foreign key (TicketFk) 
        references Tickets

    alter table OrderLineItems 
        add constraint FKB3BC66EA34AC580B 
        foreign key (OrderFk) 
        references Orders

    alter table OrderLineItems 
        add constraint FKB3BC66EA2404AE6E 
        foreign key (ProductFk) 
        references Products
