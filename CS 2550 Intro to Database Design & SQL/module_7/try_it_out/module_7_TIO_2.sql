DROP DATABASE IF exists Baseball;
CREATE DATABASE IF NOT EXISTS Baseball;
USE Baseball;


CREATE TABLE Team (
    TeamID SMALLINT,
    TeamName VARCHAR(50) NOT NULL,
    TeamCity VARCHAR(50),
    TeamManager VARCHAR(50) NOT NULL,
    PRIMARY KEY (TeamID)
);

CREATE TABLE Player (
    PlayerID SMALLINT,
    PlayerName VARCHAR(30) NOT NULL,
    PlayerDOB DATE,
    PRIMARY KEY (PlayerID)
);

CREATE TABLE PlayerHistory (
    PlayerHistoryID SMALLINT,
    TeamID SMALLINT,
    PlayerID SMALLINT,
    PlayerBatingAverage DECIMAL(6 , 2 ),
    PlayerStartDate DATE,
    PlayerEndDate DATE,
    PlayerPosition VARCHAR(10),
    PRIMARY KEY (PlayerHistoryID),
    FOREIGN KEY (TeamID)
        REFERENCES Team (TeamID),
    FOREIGN KEY (PlayerID)
        REFERENCES Player (PlayerID)
);

CREATE TABLE Coach (
    CoachID SMALLINT,
    CoachName VARCHAR(30),
    CoachPhoneNumber VARCHAR(20),
    CoachSalary DECIMAL(8 , 2 ),
    TeamID SMALLINT,
    PRIMARY KEY (CoachID),
    FOREIGN KEY (TeamID)
        REFERENCES Team (TeamID)
);

CREATE TABLE UnitsOfWork (
    UnitsNumber SMALLINT,
    NumberOfYears TINYINT,
    ExperienceType VARCHAR(30),
    CoachID SMALLINT,
    PRIMARY KEY (UnitsNumber),
    FOREIGN KEY (CoachID)
        REFERENCES Coach (CoachID)
);


CREATE TABLE Bat (
    BatSerialNumber SMALLINT,
    BatManufacturer VARCHAR(50),
    TeamID SMALLINT,
    PRIMARY KEY (BatSerialNumber),
    FOREIGN KEY (TeamID)
        REFERENCES Team (TeamID)
);

INSERT INTO Team(TeamID, TeamName, TeamCity, TeamManager)
VALUES(1, 'Robins', 'Round Rock', 'Jim Bob'),
	  (2, 'Ducks', 'Dallas', 'Fred Smith'),
      (3, 'Magpies', 'Mesa', 'Ann Brown'),
      (4, 'Long Horns', 'Louisville', 'Alice Brierfield');
      
INSERT INTO Player(PlayerID, PlayerName, PlayerDOB)
VALUES(1, 'Sam Smith', '2010-01-03'),
	  (2, 'Peter Parker', '2010-02-07'),
      (3, 'Clark Kent', '2009-08-07'),
      (4, 'Bruce Waune', '2009-07-06'),
      (5, 'Steve Rogers', '2010-11-11'),
      (6, 'Al Simmons', '2011-06-05');
      
INSERT INTO Coach(CoachID, CoachName, CoachPhoneNumber, CoachSalary, TeamID)
VALUES(1, 'Sidney ValdWell', '801-123-4567', 45000.00, 1),
	  (2, 'Ardelia Horn', '801-987-6541', 50000.00, 2),
      (3, 'Hollis Pace', '801-876-5309', 40000.00, 3),
      (4, 'Dottie Murphy', '801-465-3135', 35000.00, 3);
      
INSERT INTO UnitsOfWork(UnitsNumber, NumberOfYears, ExperienceType, CoachID)
VALUES(10, 3, 'Bowling Coach', 1),
	  (12, 4, 'Figure Skating Coach', 2),
      (13, 2, 'Baseball Coach', 3);
      
INSERT INTO PlayerHistory(PlayerHistoryID, TeamID, PlayerID, PlayerBatingAverage, PlayerStartDate, PlayerEndDate, PlayerPosition)
VALUES(110, 1, 1, 70.82, '2019-01-01', NULL, '3B'),
	  (111, 1, 2, 100.01, '2019-01-01', NULL, 'C'),
      (112, 1, 3, 90.07, '2019-01-01', NULL, 'RF'),
      (113, 2, 4, 50.80, '2019-05-05', NULL, 'P'),
      (114, 2, 5, 152.50, '2019-05-05', NULL, '2B'),
      (115, 2, 6, 100.00, '2019-05-05', NULL, 'SS');
      
      
# Try-it-out 7-2-3

UPDATE PlayerHistory 
SET 
    PlayerEndDate = '2020-07-07'
WHERE
    PlayerID IN (2 , 4, 6);
    
    
    

UPDATE Team t
        LEFT JOIN
    PlayerHistory p ON t.TeamID = p.TeamID 
SET 
    TeamManager = 'Vacant'
WHERE
    PlayerID IS NULL;




UPDATE Coach c
        LEFT JOIN
    UnitsOfWork u ON c.CoachID = u.CoachID 
SET 
    CoachSalary = (ROUND(CoachSalary * 0.0255))
WHERE
    UnitsNumber IS NOT NULL;




DELETE u FROM UnitsOfWork u
        JOIN
    Coach c ON c.CoachID = u.CoachID
        JOIN
    Team t ON t.TeamID = c.TeamID 
WHERE
    t.TeamCity NOT LIKE 'R%'
    AND t.teamcity NOT LIKE 'S%'
    AND t.TeamCity NOT LIKE 'T%';



DELETE FROM Playerhistory ORDER BY PlayerBatingAverage ASC LIMIT 2;

SELECT 
    *
FROM
    Team;

SELECT 
    *
FROM
    Coach;

SELECT 
    *
FROM
    Player;

SELECT 
    *
FROM
    PlayerHistory;

SELECT 
    *
FROM
    UnitsOfWork;
