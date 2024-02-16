DROP DATABASE IF exists RAG;
CREATE DATABASE IF NOT EXISTS RAG;
USE RAG;

CREATE TABLE Manufacturer (
    ManufacturerID INT AUTO_INCREMENT,
    ManufacturerName VARCHAR(50) NOT NULL,
    PRIMARY KEY (ManufacturerID)
);

CREATE TABLE Customer (
    CustomerID INT AUTO_INCREMENT,
    CustFirst VARCHAR(25) NOT NULL,
    CustLast VARCHAR(25) NOT NULL,
    PRIMARY KEY (CustomerID)
);

CREATE TABLE Service (
    ServiceID INT AUTO_INCREMENT,
    ServiceName VARCHAR(25) NOT NULL,
    ServiceRate DECIMAL(4 , 2 ) NOT NULL,
    PRIMARY KEY (ServiceId)
);

CREATE TABLE PositionDescription (
    PositionID INT AUTO_INCREMENT,
    PositionName VARCHAR(25) NOT NULL,
    PRIMARY KEY (PositionID)
);

CREATE TABLE Dealership (
    DealershipID INT,
    DealershipName VARCHAR(25) NOT NULL,
    DealershipStreet VARCHAR(25) NOT NULL,
    DealershipCity VARCHAR(25) NOT NULL,
    DealershipState CHAR(2) NOT NULL,
    DealershipZip CHAR(9) NOT NULL,
    PRIMARY KEY (DealershipID)
);

CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT,
    EmpFirst VARCHAR(25) NOT NULL,
    EmpLast VARCHAR(25) NOT NULL,
    EmpAddress VARCHAR(40) NOT NULL,
    EmpCity VARCHAR(25) NOT NULL,
    EmpState CHAR(2) NOT NULL,
    EmpZip CHAR(9) NOT NULL,
    EmpPhone CHAR(10) NOT NULL,
    EmpDOB DATE NOT NULL,
    PRIMARY KEY (EmployeeID)
);

CREATE TABLE Model (
    ModelID INT AUTO_INCREMENT,
    ModelName VARCHAR(50) NOT NULL,
    ManufacturerID INT NOT NULL,
    PRIMARY KEY (ModelID),
    FOREIGN KEY (ManufacturerID)
        REFERENCES Manufacturer (ManufacturerID)
);

CREATE TABLE VehicleTrim (
    TrimID INT AUTO_INCREMENT,
    TrimName VARCHAR(50) NOT NULL,
    ModelID INT NOT NULL,
    PRIMARY KEY (TrimID),
    FOREIGN KEY (ModelID)
        REFERENCES Model (ModelID)
);

CREATE TABLE Vehicle (
    VehID INT AUTO_INCREMENT,
    VehVIN VARCHAR(25) NOT NULL,
    VehYear CHAR(2) NOT NULL,
    VehColor VARCHAR(25) NOT NULL,
    VehMileage DECIMAL(8 , 2),
    TrimID INT NOT NULL,
    PRIMARY KEY (VehID),
    FOREIGN KEY (TrimID)
        REFERENCES VehicleTrim (TrimID)
);

CREATE TABLE Inventory (
    InventoryID INT AUTO_INCREMENT,
    InvWholesale DECIMAL(8 , 2 ) NOT NULL,
    InvRetail DECIMAL(8 , 2 ) NOT NULL,
    VehID INT NOT NULL,
    PRIMARY KEY (InventoryID),
    FOREIGN KEY (VehID)
        REFERENCES Vehicle (VehID)
);

CREATE TABLE Invoice (
    InvoiceID INT AUTO_INCREMENT,
    InvoiceDate DATE NOT NULL,
    InvoiceAmount DECIMAL(8 , 2 ) NOT NULL,
    InventoryID INT NOT NULL,
    CustomerID INT NOT NULL,
    EmployeeID INT NOT NULL,
    PRIMARY KEY (InvoiceID),
    FOREIGN KEY (InventoryID)
        REFERENCES Inventory (InventoryID),
    FOREIGN KEY (CustomerID)
        REFERENCES Customer (CustomerID),
    FOREIGN KEY (EmployeeID)
        REFERENCES Employee (EmployeeID)
);

ALTER TABLE Invoice AUTO_INCREMENT = 2001;

CREATE TABLE PayHistory (
    PHID INT AUTO_INCREMENT,
    PHBeginDate DATE NOT NULL,
    PHEndDate DATE,
    PHRate DECIMAL(8 , 2 ) NOT NULL,
    PHPayType CHAR(1) NOT NULL,
    PHCommission DECIMAL(8 , 2 ),
    EmployeeID INT NOT NULL,
    PositionID INT NOT NULL,
    DealershipID INT NOT NULL,
    PRIMARY KEY (PHID),
    FOREIGN KEY (EmployeeID)
        REFERENCES Employee (EmployeeID),
    FOREIGN KEY (PositionID)
        REFERENCES PositionDescription (PositionID),
    FOREIGN KEY (DealershipID)
        REFERENCES Dealership (DealershipID)
);

CREATE TABLE ServiceTicket (
    STID INT AUTO_INCREMENT = 100,
    VehID INT NOT NULL,
    CustID INT NOT NULL,
    STTimeIN DATETIME NOT NULL,
    STTimeOUT DATETIME NOT NULL,
    STComments VARCHAR(255),
    PRIMARY KEY (STID),
    FOREIGN KEY (VehID)
        REFERENCES Vehicle (VehID),
    FOREIGN KEY (CustID)
        REFERENCES Customer (CustomerID)
);
ALTER TABLE ServiceTicket AUTO_INCREMENT = 10001;

CREATE TABLE Part (
    PartID INT AUTO_INCREMENT,
    PartName VARCHAR(25) NOT NULL,
    PartRetail DECIMAL(8 , 2 ) NOT NULL,
    PRIMARY KEY (PartID)
);
ALTER TABLE Part AUTO_INCREMENT = 5001;

CREATE TABLE ServiceTicketDetails (
    STDID INT AUTO_INCREMENT,
    STDQty TINYINT NOT NULL,
    STDComments VARCHAR(255),
    STDWarrantyItem CHAR(1) NOT NULL,
    STID INT NOT NULL,
    EmployeeID INT NOT NULL,
    ServiceID INT NOT NULL,
    PRIMARY KEY (STDID),
    FOREIGN KEY (STID)
        REFERENCES ServiceTicket (STID),
    FOREIGN KEY (EmployeeID)
        REFERENCES Employee (EmployeeID),
    FOREIGN KEY (ServiceID)
        REFERENCES Service (ServiceID)
);

CREATE TABLE PartsUsed (
    PUID INT AUTO_INCREMENT,
    PUQty TINYINT NOT NULL,
    PartID INT NOT NULL,
    STDID INT NOT NULL,
    PRIMARY KEY (PUID),
    FOREIGN KEY (PartID)
        REFERENCES Part (PartID),
    FOREIGN KEY (STDID)
        REFERENCES ServiceTicketDetails (STDID)
);


Insert INTO dealership
Values (7111,'RAG Clearfield','123 Main Street','Clearfield','UT',84104),
(5626,'Relational Group Ogden','123 Jackson Ave','Ogden','UT',84108),
(7845,'RAG Layton','123 Pioneer Dr','Layton','UT',84101),
(1236,'Holliday','123 Christmas Cir','Holladay','UT',84117),
(8988,'RAG SugarHouse','123 Easy Way','Salt Lake City','UT',84106);
INSERT INTO positiondescription (positionName)
VALUES ('Sales'),
('Mechanic'),
('Office');
INSERT INTO Service (ServiceName, ServiceRate)
VALUES ('Oil Change',29.95),
('Tire Rotation',15.95),
('Safety Inspection',12),
('Emissions Testing',28),
('Labor - General',89),
('Disposal Fees',4.95),
('Cash Wash',7.5),
('Vacuum',2.5);
INSERT INTO Employee (EmpFirst, EmpLast, EmpAddress, EmpCity, EmpState, EmpZip,
EmpPhone, EmpDOB)
VALUES ('Rodriguez','Herminio','135 Pacocha Square','Rock
Springs','WY','82901','3079796360','1969-07-07'),
('Schimmel','Melba','2781 Casper Villages','Ogden','UT','84408','8016356458','1964-10-10'),
('Oberbrunner','Tyrell','3553 Elise Meadow','Salt Lake City','UT','84117','8015452187','1994-07-31'),
('Dickinson','Alvah','4247 FramiSprings','Evanston','WY','82930','3074587412','1977-02-21'),
('Hane','Olaf','6991 Laurence Wall','Salt Lake City','UT','84106','8012578964','1990-10-18'),
('Muller','Sharon','3721 Halie Gateway','Park City','UT','84101','3853339978','1982-01-15'),
('Murray',' Jadyn','6569 Khalil Expressway','Layton','UT','84404','3857891234','2000-05-02'),
('Ebert','Aiyana','400 Cecelia Mountains','Clearfield','UT','84405','8015456318','1966-06-06'),
('Schaden','Kattie','203 Schneider Plains','Ogden','UT','84408','8016356874','1998-08-07'),
('Langosh','Kenneth','245 Ebert Prairie','Park City','UT','84101','3857554422','1998-11-08');
INSERT INTO customer (CustFirst, CustLast)
VALUES ('Schuster','Ryann'),
('Mayer','Jane'),
('Marvin','Richard'),
('Crist','Lafayette'),
('Johns','Maggie'),
('Flatley','Austen'),
('Yost','Maurice'),
('Graham','Fiona'),
('Wisozk','Mariano'),
('Russel','Sherwood'),
('Fisher','Madyson'),
('Grady','Cecilia'),
('Kautzer','Sister'),
('Kilback','Brennan'),
('Bednar','Brenda'),
('Kovacek','Amari'),
('Marquardt','Juwan'),
('Rogahn','Travon'),
('Hudson','Yadira'),
('Gislason','Jeramie'),
('Grimes','Kattie'),
('Pollich','Lela'),
('Howell','Brianne'),
('Nader','Patricia'),
('Wisoky','Anderson'),
('Marks','Ryley'),
('Hane','Lola'),
('Jast','Monique'),
('Heller','Elisabeth'),
('Aufderhar','Archibald'),
('Murray','Antonio'),
('Abshire','Kade'),
('Ebert','Clark'),
('Hirthe','Lora'),
('Tromp','Gianni'),
('Mayer','Makenzie'),
('Dach','Natalie'),
('Kiehn','Kadin'),
('Wolf','Chaz'),
('Bogan','Sadye'),
('Olson','Ciara'),
('Leffler','Florencio'),
('Cassin','Demond'),
('Rohan','Hallie'),
('Gottlieb','Leilani'),
('Bruen','Lydia'),
('Corwin','Veda'),
('Tromp','Shana'),
('Carroll','Ernestina'),
('Koepp','Yadira'),
('Powlowski','Doris'),
('Cummerata','Grace'),
('Halvorson','Meda'),
('Heller','Jarret'),
('Sauer','Telly'),
('Batz','Felipe'),
('Towne','Harvey'),
('Batz','Ansley'),
('Brekke','Emmitt'),
('Koch','Dorthy'),
('Daniel','Piper'),
('Schiller','Carol'),
('Parisian','Milo'),
('Halvorson','Lambert'),
('Reichel','Delmer'),
('Ziemann','Omari'),
('Powlowski','Mario'),
('OKeefe','Kamille'),
('OKeefe','Felicity'),
('Mohr','Hadley'),
('Fadel','Doyle'),
('DuBuque','Cesar'),
('Hagenes','Dillan'),
('OConner','Walker'),
('Hayes','Armani'),
('Hilpert','Elsa'),
('Gleichner','Novella'),
('Stiedemann','Allene'),
('Bernhard','Eldon'),
('Harris','Willie'),
('Larson','Tom'),
('Trantow','Seth'),
('Torphy','Leland'),
('Bashirian','Kris'),
('Beier','Joe'),
('Mertz','Daphney'),
('Wintheiser','Erika'),
('Luettgen','Carmine'),
('Friesen','Kenyatta'),
('Lueilwitz','Laverne'),
('Durgan','Eldon'),
('Kilback','Preston'),
('Bernhard','Sophia'),
('Kuhic','Verna'),
('Bauch','Carmel'),
('Hintz','Presley'),
('Lindgren','Rosie'),
('Hegmann','Johathan'),
('Kreiger','Sammy'),
('Hermiston','Sigmund'),
('Murazik','Weston'),
('Predovic','Juston'),
('Hermann','Malika'),
('Jaskolski','Kendra'),
('Kunde','Rosamond'),
('Becker','Anibal'),
('Hane','Reta'),
('Crona','Kyla'),
('McClure','Chaya'),
('Goldner','Myriam'),
('Bergstrom','Abdul'),
('Veum','Cleve'),
('Collins','Christopher'),
('Murray','Milford'),
('Hudson','Jevon'),
('Wyman','Emory'),
('Bauch','Dorothea'),
('Dibbert','Judson'),
('Conroy','Sean'),
('Gerlach','Coby'),
('Stark','Dustin'),
('Guann','Pearl'),
('Shanahan','Davon'),
('Fritsch','Shayna'),
('Sauer','Gail'),
('Nitzsche','Mariam'),
('Harvey','Krystel'),
('Casper','Annabell'),
('VonRueden','Katherine'),
('Spencer','Sienna'),
('Erdman','Dolores'),
('Veum','Jan'),
('Braun','Matteo'),
('Jewess','Raven'),
('Tremblay','Helga'),
('Lemke','Tess'),
('Corwin','Haylie'),
('Towne','Santino'),
('Williamson','Orpha'),
('Lindgren','Rebekah'),
('Kozey','Clarissa'),
('Hilll','Domingo'),
('Rolfson','Juston'),
('Schmitt','Amya'),
('Lehner','Stanley'),
('Bergstrom','Justina'),
('Schiller','Cathrine'),
('Kuhlman','Green'),
('Wolff','Kade'),
('Roberts','Pablo'),
('Buckridge','Arianna'),
('Aufderhar','Cynthia'),
('Monahan','Deontae'),
('Rice','Javonte'),
('Cormier','Colton'),
('Kuhn','Alyce'),
('DAmore','Lisa'),
('Rempel','Celestino'),
('Russel','Addie'),
('Gleichner','Kevon'),
('Ryan','Jean'),
('OConnell','Trever'),
('Gleichner','Karen'),
('Marquardt','Irving'),
('Schulist','Bridgette'),
('Bernier','Vivianne'),
('Kertzmann','Buford'),
('Abshire','Alessandro'),
('Fahey','Walker'),
('Ziemann','Whitney'),
('Abbott','Joy'),
('Sauer','Hilton'),
('Shields','Aron'),
('Schaefer','Cyrus');
INSERT INTO Manufacturer (ManufacturerName)
VALUES ('BMW'),
('Ford'),
('Toyota'),
('Nissan'),
('Dodge'),
('Honda');
INSERT INTO Part (PartName, PartRetail)
VALUES ('Oil Filter','11.95'),
('Fuse','1.99'),
('Coolant - Quart','3.95'),
('Spark Plug','4'),
('Air Filter','24.95'),
('Carburetor','99.99'),
('AntiFreeze - Gallon','7.77'),
('Tire Valve','0.58'),
('Rain X - Application','4.95'),
('Oil - 10W40','4.95'),
('Oil - Synthetic','7.6');
INSERT INTO Model (ModelName, ManufacturerID)
VALUES ('3-Series','1'),
('5-Series','1'),
('F-150','2'),
('F-250','2'),
('F-350','2'),
('Camry','3'),
('Camry Hybrid','3'),
('Corolla','3'),
('Highlander','3'),
('Accord','6'),
('RAM','5'),
('Pathfinder','4'),
('Rogue','4');
INSERT INTO VehicleTrim (TrimName, ModelID)
VALUES ('318i 4dr Sedan','1'),
('328i 4dr Sedan','1'),
('318ti 2dr Hatchback','1'),
('323i 2dr Convertible','1'),
('328i 2dr Convertible','1'),
('323is 2dr Coupe','1'),
('328is 2dr Coupe','1'),
('M5 4dr Sedan','2'),
('M5 2dr Coupe','2'),
('M5 2dr Convertible','2'),
('2dr Extended Cab SB','3'),
('2dr Extended Cab LB','3'),
('2dr Extended Cab 4WD LB','3'),
('2dr Extended Cab 4WD SB','3'),
('XLT Lariat 2dr Extended Cab LB','3'),
('XLT Lariat 2dr Extended Cab SB','3'),
('XLT Lariat 2dr Extended Cab 4WD LB','3'),
('XLT Lariat 2dr Extended Cab 4WD SB','3'),
('XL 2dr Extended Cab LB','4'),
('XL 2dr Extended Cab SB','4'),
('XL 2dr Extended Cab 4WD LB','4'),
('XL 2dr Extended Cab 4WD SB','4'),
('2dr Regular Cab SB','5'),
('2dr Regular Cab LB','5'),
('2dr Regular Cab 4WD LB','5'),
('2dr Regular Cab 4WD SB','5'),
('LE V6 2dr Coupe','6'),
('DX 2dr Coupe','6'),
('LE 2dr Coupe','6'),
('4dr Sedan ','7'),
('LE Hybrid','7'),
('LE 4dr Sedan ','7'),
('DX 4dr Wagon','8'),
('LE V6 4dr Sedan','8'),
('LX 4dr','10'),
('Laramie Edition','11'),
('2dr Short Bed','11'),
('Eddie Bauer Edition','9'),
('Eddie Bauer Edition','12'),
('LX V6 4dr','13');
INSERT INTO Vehicle (VehVIN, VehYear, VehColor, VehMileage, TrimID)
VALUES ('1D4RD4GG9BC660306','18','Red','1234','2'),
('3GCCA05V89S596155','18','White','5678','4'),
('2CNBE1869T6300748','18','Blue','15456','8'),
('2FZACFDK36AW46451','18','Celestial Silver','25212','11'),
('2HGFF384744W44RF3','18','White',NULL,'14'),
('87JHF5RE3NBV678AA','19','Gray Metallic',NULL,'17'),
('4LKJ44829NB442DF3','19','Silver Metallic',NULL,'20'),
('5HHHF332AS3000FGB','19','Tan',NULL,'23'),
('6JDHGJ88KIGHJFDJC','19','Forrest Green',NULL,'26'),
('3JGFKDJDLS855NFCK','20','Blue',NULL,'27'),
('6YYDFJS739002NFH2','20','Red',NULL,'28'),
('6FHFK3748MJVND029','20','Black',NULL,'29'),
('11FJJFJSMHHFHF383','20','Brown',NULL,'30'),
('7FNFNW6223KFJHGHG','20','Blue Aqua',NULL,'31'),
('6NFJFJFWWNCFNEFH2','21','Pearl White',NULL,'32'),
('3638NNFNFLSS33041','21','Sandy Beach',NULL,'33'),
('13749NFHDL3733YYR','21','Sandy Beach',NULL,'34'),
('144FJFHFMZXZCCVMJ','22','Pearl White',NULL,'33'),
('5GHGJFKFQWWEEW32R','22','Barcelona Red',NULL,'34'),
('2WSSDFSOSJFGK393U','22','Blue Streak',NULL,'35'),
('3ERTY4839FNNBBVEF','22','Blue Streak',NULL,'36'),
('8DFSDFSDFSDFVML33','22','Aloe Green',NULL,'37'),
('6HM1111EFVL335332','22','Classic Silver',NULL,'38'),
('4DFHDFKDFDKFJASS3','22','Barcelona Red',NULL,'39'),
('74MNMF90ERTUFF91R','22','Silver Metallic',NULL,'40'),
('1123FGDSJH7654GFV','21','White','47547','30'),
('7FNFN14223KFJHGHG','21','Blue','42333','31'),
('5NFJFJFWWNXXNEFH2','22','White','58595','32'),
('234HGDCBV76400987','20','Tan','48475','33'),
('55749NFHDL3733YYR','18','Sandy Beach','25564','34'),
('444FJFHFMZXZCCVMJ','18','Red','100222','33'),
('5DDDFKFQWWEEW32P','18','Blue','89383','34'),
('2WWWSSDFSJFGK393U','18','Blue Streak','96956','2');
INSERT INTO Inventory (INVWholesale, INVRetail, VehID)
VALUES ('23500','26995','1'),
('34555','39995','2'),
('28000','32000','3'),
('28000','32000','4'),
('45250','51995','5'),
('44100','50555','6'),
('30000','35000','7'),
('49000','55555','8'),
('35000','39995','9'),
('32123','36250','10'),
('33000','37750','11'),
('29999','34555','12'),
('35000','38964','13'),
('50000','55250','14'),
('48000','53654','15'),
('48000','53654','16'),
('29650','33000','17'),
('47000','51000','18'),
('36985','40050','19'),
('30000','34000','20'),
('41000','41450','21'),
('51000','56000','22'),
('46520','51250','23'),
('55000','59995','24'),
('54000','58888','25');
INSERT INTO Invoice (InvoiceDate, InvoiceAmount, InventoryID, CustomerID,
EmployeeID)
VALUES ('2022-3-1','34887','2','91','7'),
('2022-3-2','27600','4','112','7'),
('2022-3-3','35000','9','133','7'),
('2022-3-4','32750','10','149','6'),
('2022-3-5','31014','17','169','5'),
('2022-4-1','31887','12','111','7'),
('2022-4-2','49600','14','119','5'),
('2022-4-3','49000','8','33','6'),
('2022-4-4','24750','1','10','5'),
('2022-4-5','30014','7','55','6');
INSERT INTO PayHistory (PHBeginDate, PHEndDate, PHRate, PHPayType, PHCommission,
EmployeeID, PositionID, DealershipID)
VALUES ('2022-03-01',NULL,'44','H',NULL,'1','2','7111'),
('2022-03-01',NULL,'45','H',NULL,'2','2','7111'),
('2022-03-01',NULL,'39','H',NULL,'3','2','5626'),
('2022-03-01',NULL,'39','H',NULL,'4','2','7111'),
('2022-03-01',NULL,'25','C','5','5','1','7111'),
('2022-03-01',NULL,'26.5','C','5','6','1','5626'),
('2022-02-01','2022-01-31','26','C','4.25','7','1','5626'),
('2022-03-01',NULL,'26.5','C','5','7','1','5626'),
('2022-03-01',NULL,'55000','S',NULL,'8','3','7111'),
('2022-03-01',NULL,'55000','S',NULL,'9','3','5626'),
('2022-02-01','2022-12-31','60000','S',NULL,'10','3','7111');
INSERT INTO ServiceTicket (VehID, CustID, STTimeIn, STTimeOut, STComments)
VALUES ('26','156','2022-03-01 07:30:00','2022-03-01 09:30:00',NULL),
('27','62','2022-03-01 08:30:00','2022-03-01 14:30:00',NULL),
('28','11','2022-03-03 09:30:00','2022-03-03 12:00:00',NULL),
('29','77','2022-03-03 13:30:00','2022-03-03 15:30:00',NULL),
('30','104','2022-03-02 09:30:00','2022-03-02 15:00:00',NULL),
('31','100','2022-03-04 08:30:00','2022-03-04 11:30:00',NULL),
('32','36','2022-03-03 11:30:00','2022-03-03 14:30:00',NULL),
('33','4','2022-03-08 13:30:00','2022-03-08 16:00:00',NULL),
('24','88','2022-03-19 08:30:00','2022-03-19 10:30:00',NULL),
('25','99','2022-03-10 09:30:00','2022-03-10 10:00:00',NULL);
INSERT INTO ServiceTicketDetails (STDQty, STDComments, STDWarrantyItem, STID,
EmployeeID, ServiceID)
VALUES ('1','10W40 Synthetic','0','10001','1','1'),
('1',NULL,'0','10001','1','6'),
('.25','Battery Cap Replace','1','10001','2','5'),
('1.25','Wheel Alignment','0','10002','6','5'),
('1','Passed','0','10002','1','3'),
('1','Passed','0','10002','2','4'),
('2','Recall Fixes','1','10003','2','5'),
('3','Recall Fixes','1','10004','2','5'),
('0.5','Changed Spark Plugs','0','10004','2','5'),
('1',NULL,'0','10004','1','7'),
('2.75','Carburetor Fix','0','10005','3','5'),
('1','10W40','0','10006','1','1'),
('1',NULL,'0','10006','2','7'),
('1',NULL,'0','10006','2','6'),
('1','Radiator Flush','0','10007','1','5'),
('0.25','Battery Check','1','10007','2','5'),
('1.75','Tire Balance','0','10008','3','5'),
('2','Recall Fixes','1','10009','3','5'),
('1','Passed','0','10010','1','3'),
('1','Failed','0','10010','1','4');
INSERT INTO PartsUsed (PUQty, PartID, STDID)
VALUES (1,5001,1),
(11,5001,5),
(8,5007,4),
(7,5004,2),
(4,5008,4),
(2,5008,3),
(3,5008,1);

#1A I'm insterting myself as a new employees and PayHistory
INSERT INTO Employee(EmpFirst, EmpLast, EmpAddress, EmpCity, EmpState, EmpZip, EmpPhone, EmpDOB)
VALUES('Trevor', 'Egbert', '1311 North 2275 West', 'Layton', 'UT', '84041', '8018820747', '1993-07-16');

INSERT INTO PayHistory(PHBeginDate, PHEndDate, PHRate, PHPaytype, PHCommission, EmployeeID, PositionID, DealershipID)
VALUES('2022-07-31', NULL, '80000', 'S', NULL, LAST_INSERT_ID(), '3', '1236');


#1B selecting from PayHistory
SELECT 
    *
FROM
    PayHistory;

#2A Deleting customer never had an Invoice or ServiceTicket
DELETE c . * FROM Customer c
        LEFT JOIN
    ServiceTicket st ON c.CustomerID = st.Custid
        LEFT JOIN
    Invoice i ON c.CustomerID = i.CustomerID 
WHERE
    STID IS NULL AND InvoiceID IS NULL;

#2B Select statement for Customer table

SELECT 
    *
FROM
    Customer;



#3A Updating unassigned services and decrease thier value by 10%
UPDATE Service s
        LEFT JOIN
    ServiceTicketDetails std ON std.ServiceID = s.ServiceID 
SET 
    s.ServiceRate = (FLOOR(ServiceRate - (ServiceRate * 0.1)))
WHERE
    std.STID IS NULL;

#3B Select statement for Service
SELECT 
    *
FROM
    Service;



#4A  Updating 22 vehicles InvRetial and decrease thier value by 3.95% 
UPDATE Inventory i
        RIGHT JOIN
    Vehicle v ON i.VehID = v.VehID 
SET 
    InvRetail = (InvRetail - (InvRetail * 0.0395))
WHERE
    VehMileage IS NULL AND VehYear = 22;

#4B Select statment showing the year, color, trim name, and new retail price for 22 year model cars
SELECT 
    VehYear, VehColor, TrimName, FORMAT(InvRetail, 2)
FROM
    Inventory i
        RIGHT JOIN
    Vehicle v ON i.VehID = v.VehID
        JOIN
    VehicleTrim t ON t.TrimID = v.TrimID
WHERE
    VehMileage IS NULL AND VehYear = 22;