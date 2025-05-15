CREATE DATABASE CosmeticShop;

use CosmeticShop;
drop table Goods;
CREATE TABLE Goods (
    id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    Brand NVARCHAR(MAX),
    ImagePath NVARCHAR(MAX),
    Buy NVARCHAR(MAX),
    DeleteCommand NVARCHAR(MAX),
    Price FLOAT
);


INSERT INTO Goods("Name","Description","Brand","ImagePath","Buy","DeleteCommand","Price")
VALUES
('Essence gelly-grip primer','Праймер','Essence','D:/лабораторные работы/ооп/lab4_5/pics/essence-primer-jelly-grip.jpg','Купить','Удалить',123),
('L''OREAL PARIS panorama','Тушь для ресниц','L''OREAL','D:/лабораторные работы/ооп/lab4_5/pics/L''OREAL-PARIS-panorama.jpg','Купить','Удалить',245),
('Maybelline Fit Me Matte','Праймер','Maybelline','D:/лабораторные работы/ооп/lab4_5/pics/Maybelline-Fit-Me-Matte.jpg','Купить','Удалить',189),
('NYX HD Studio Photogenic','Консилер','NYX','D:/лабораторные работы/ооп/lab4_5/pics/NYX HD Studio Photogenic.jpg','Купить','Удалить',210),
('Revolution Banana Powder','Пудра','Revolution','D:/лабораторные работы/ооп/lab4_5/pics/Revolution Banana Powder.jpg','Купить','Удалить',275),
('L''OREAL PARIS Infallible 24H','Тональный крем','L''OREAL','D:/лабораторные работы/ооп/lab4_5/pics/L''OREAL PARIS Infallible 24H Fresh Wear Foundation.jpg','Купить','Удалить',390),
('Maybelline Lash Sensational Sky High','Тушь для ресниц','Maybelline','D:/лабораторные работы/ооп/lab4_5/pics/Maybelline Lash Sensational Sky High.jpg','Купить','Удалить',198),
('Essence Stay All Day 16h Foundation','Тональный крем','Essence','D:/лабораторные работы/ооп/lab4_5/pics/Essence Stay All Day 16h Foundation.jpg','Купить','Удалить',165),
('NYX Can''t Stop Won''t Stop Setting Powder','Фиксирующая пудра','NYX','D:/лабораторные работы/ооп/lab4_5/pics/NYX Can''t Stop Won''t Stop Setting Powder.jpg','Купить','Удалить',223),
('Revolution Conceal & Define Concealer','Консилер','Revolution','D:/лабораторные работы/ооп/lab4_5/pics/Revolution Conceal & Define Concealer.jpg','Купить','Удалить',155),
('Maybelline SuperStay Matte Ink','Жидкая матовая помада','Maybelline','D:/лабораторные работы/ооп/lab4_5/pics/Maybelline SuperStay Matte Ink.jpg','Купить','Удалить',199),
('Essence Lash Princess Mascara','Тушь для ресниц','Essence','D:/лабораторные работы/ооп/lab4_5/pics/Essence Lash Princess False Lash Effect Mascara.jpg','Купить','Удалить',145);

CREATE TABLE "Users" (
    "Id" INT PRIMARY KEY,
    "Role" VARCHAR(50),
    "Username" VARCHAR(50) DEFAULT 'User',
    "Login" VARCHAR(100) NOT NULL UNIQUE,
    "Password" VARCHAR(100),
    "Pfp" VARCHAR(255) DEFAULT 'D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\DefaultPfp.png'
);

insert into Users ("Id", "Role", "Username", "Login", "Password", "Pfp")
values
(1, 'Admin', 'User', 'qwerty', '1234', 'D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\DefaultPfp.png'),
(2, 'Client', 'User', 'йцукен', '1234', 'D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\DefaultPfp.png')