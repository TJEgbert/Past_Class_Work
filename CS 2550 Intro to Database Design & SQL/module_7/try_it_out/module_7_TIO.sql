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