create database LogAndOst;

use LogAndOst;

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE Genders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    CountryId INT NOT NULL,
    GenderId INT NOT NULL,
    
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    CONSTRAINT FK_Users_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id),
    CONSTRAINT FK_Users_Genders FOREIGN KEY (GenderId) REFERENCES Genders(Id)
);

insert into Roles (Name) values('мененджер');
insert into Roles (Name) values('админ');
insert into Roles (Name) values('клиент');

insert into Countries(Name) values('Авганистан');
insert into Countries(Name) values('USA');
insert into Countries(Name) values('Россия');

insert into Genders(Name) values('Мужчина');
insert into Genders(Name) values('Женщина');

insert into Users(Name,RoleId,CountryId,GenderId) values('Бобэк',1,1,1);
insert into Users(Name,RoleId,CountryId,GenderId) values('Роберт',2,3,1);
insert into Users(Name,RoleId,CountryId,GenderId) values('Ольга',3,2,2);