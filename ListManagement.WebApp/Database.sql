CREATE DATABASE ListManagement

USE ListManagement

CREATE TABLE Items(
      Id int IDENTITY(1,1) NOT NULL
    , [Name] nvarchar(100) NOT NULL
    , [Description] nvarchar(2048) NULL
    , EndDate datetime2(7) NULL
    , GroupId int NULL
    , StatusId int NULL
    ,CONSTRAINT PK__Items PRIMARY KEY(Id)
    ,CONSTRAINT FK__Groups FOREIGN KEY(GroupId)  REFERENCES Groups(Id)
    ,CONSTRAINT FK__Statuses FOREIGN KEY(StatusId)  REFERENCES Statuses(Id)
)

CREATE TABLE Groups(
      Id int IDENTITY(1,1) NOT NULL
    , [Name] nvarchar(100) NOT NULL
    , CONSTRAINT PK__Groups PRIMARY KEY(Id)
)

CREATE TABLE Statuses(
    Id int NOT NULL
    , [Name] nvarchar(100) NOT NULL
    , CONSTRAINT PK__Statuses PRIMARY KEY(Id)
)

INSERT INTO Statuses(Id, [Name])
VALUES
  (1, 'Новая'),
  (2, 'В работе'),
  (3, 'Выполнена'),
  (4, 'Отменена')
