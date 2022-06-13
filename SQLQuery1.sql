
CREATE TABLE Firm (
    FirmID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirmName VARCHAR(15) NOT NULL,
);
GO

INSERT INTO Firm (FirmName)
VALUES
  ('Jacobs'),
  ('Dirol'),
  ('Dirol'),
  ('Dirol'),
  ('Orbit'),
  ('Pringles'),
  ('Milka'),
  ('Milka'),
  ('Greenfield'),
  ('Dirol'),
  ('Curtis'),
  ('Lays'),
  ('Heinz'),
  ('Greenfield'),
  ('Orbit'),
  ('Lays'),
  ('Oreo'),
  ('Jaffa'),
  ('Danone'),
  ('Oreo'),
  ('Oreo');

  SELECT * FROM Firm
  DROP TABLE Firm
  GO

CREATE TABLE BrokerageCompany (
    BrokerageCompanyID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    CompanyName VARCHAR(30) NOT NULL,
);
GO

INSERT INTO BrokerageCompany (CompanyName)
VALUES
  ('TradeKing'),
  ('Vanguard'),
  ('Forex'),
  ('Interactive Brokers Group'),
  ('Tinkoff'),
  ('OptionsHouse'),
  ('OptionsHouse'),
  ('Tinkoff'),
  ('OptionsHouse'),
  ('Vanguard'),
  ('Cobra trading'),
  ('OptionsHouse'),
  ('Scottrade'),
  ('TradeStation'),
  ('Tinkoff'),
  ('Vanguard'),
  ('Vanguard'),
  ('Forex'),
  ('TradeKing'),
  ('Interactive Brokers Group'),
  ('TradeKing');
  
  GO
    SELECT * FROM Product
  DROP TABLE Product
  GO


CREATE TABLE Product (
    ProductID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirmID INT NOT NULL FOREIGN KEY REFERENCES Firm(FirmID),
    ProductName NVARCHAR(15) NOT NULL,
    GuaranteePeriod INT CHECK (GuaranteePeriod>=7 AND GuaranteePeriod<=180) NOT NULL,
    Unit NVARCHAR(15) NOT NULL,
    Price INT CHECK (Price>=20 AND Price<=100) NOT NULL,
    DateManufacture DATE NOT NULL,
);
GO

INSERT INTO Product (FirmID,ProductName,GuaranteePeriod,Unit,Price,DateManufacture)
VALUES
  (1,N'Молоко',139,N'килограмм',60,'08.20.22'),
  (2,N'Печенье',177,N'порция',54,'07.08.22'),
  (3,N'Кофе',54,N'килограмм',85,'09.09.22'),
  (4,N'Пиво',18,N'килограмм',62,'09.09.22'),
  (5,N'Сок',161,N'порция',47,'09.10.22'),
  (6,N'Крупа',66,N'упаковка',48,'09.19.22'),
  (7,N'Морепродукты',88,N'порция',92,'09.29.22'),
  (8,N'Печенье',54,N'килограмм',50,'08.28.22'),
  (9,N'Пельмени',21,N'литр',62,'08.07.22'),
  (10,N'Пельмени',91,N'порция',46,'08.07.22'),
  (11,N'Печенье',116,N'грамм',57,'09.09.22'),
  (12,N'Сок',11,N'штука',89,'08.09.22'),
  (13,N'Молоко',49,N'литр',57,'09.08.22'),
  (14,N'Йогурт',153,N'упаковка',54,'09.07.22'),
  (15,N'Пиво',76,N'штука',54,'08.08.22'),
  (16,N'Какао',175,N'порция',63,'09.07.22'),
  (17,N'Чипсы',144,N'порция',64,'08.09.22'),
  (18,N'Йогурт',166,'килограмм',63,'07.08.22'),
  (19,N'Чипсы',87,'упаковка',76,'09.08.22'),
  (20,N'Морепродукты',72,'упаковка',71,'09.17.22');
 


    CREATE TABLE Broker (
  BrokerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FullName NVARCHAR(100) NOT NULL,
);
  SELECT * FROM Broker;

INSERT INTO [Broker] (FullName)
VALUES
  (N'Гримов Валерий Вадимович'),
  (N'Евтушенко Андрей Максимович'),
  (N'Заяц Полина Юрьевна'),
  (N'Заяц Максим Максимович'),
  (N'Иванов Иван Иванович'),
  (N'Крупка Елизавета Андреевна'),
  (N'Жилина Аделина Платоновна'),
  (N'Быков Борис Николаевич'),
  (N'Токарева Елизавета Арсентьевна'),
  (N'Божков Олкг Олегович'),
  (N'Калаш Анлрей Агафонович'),
  (N'Сокольникова Елена Артемовна'),
  (N'Евтушенко Влад Вадимович'),
  (N'Морозов Иван Пантелеймонович'),
  (N'Нестерова Полианна Тарасовна'),
  (N'Гримов Андрей Максимович'),
  (N'Нестеровськая Дарья Игорьевна'),
  (N'Макарова Ева Тимуровна'),
  (N'Маслова Анна Николаевна'),
  (N'Шапошникова Мария Максимовна');
  
  GO
  CREATE TABLE Consignment (

    ConsignmentID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BrokerID  INT NOT NULL  FOREIGN KEY REFERENCES Broker(BrokerID),
    BrokerageCompanyID  INT NOT NULL FOREIGN KEY REFERENCES BrokerageCompany(BrokerageCompanyID),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(ProductID),
    QuantityOfUnits INT NOT NULL,
    DeliveryCondition NVARCHAR(20) NOT NULL,
    ShippingDate DATE NULL,
   
);
GO
drop table Consignment

SELECT * FROM Consignment
INSERT INTO [Consignment] (BrokerID,BrokerageCompanyID,ProductID,QuantityOfUnits,DeliveryCondition,ShippingDate)
VALUES
  (1,1,1,123,N'По предоплате','07.19.22'),
  (2,2,2,155,N'Без предоплаты','07.05.22'),
  (3,3,3,168,N'Без предоплаты','07.07.22'),
  (4,4,4,139,N'По предоплате','06.12.22'),
  (5,5,5,53,N'Без предоплаты','06.13.22'),
  (6,6,6,156,N'По предоплате','06.16.22'),
  (7,7,7,95,N'По предоплате','06.11.22'),
  (8,8,8,146,N'По предоплате','06.09.22'),
  (9,9,9,117,N'По предоплате','06.05.22'),
  (10,10,10,144,N'По предоплате','06.04.22'),
  (11,11,11,172,N'По предоплате','06.25.22'),
  (12,12,12,85,N'По предоплате','06.24.22'),
  (13,13,13,138,N'По предоплате','06.23.22'),
  (14,14,14,103,N'По предоплате','06.26.22'),
  (15,15,15,57,N'По предоплате','06.24.22'),
  (16,16,16,118,N'По предоплате','07.28.22'),
  (17,17,17,125,N'Без предоплаты','06.12.22'),
  (18,18,18,138,N'По предоплате','07.23.22'),
  (19,19,19,103,N'По предоплате','06.19.22'),
  (20,20,20,65,N'По предоплате','06.14.22');