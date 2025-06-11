CREATE DATABASE EventDb

USE EventDb

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) not null CHECK (LEN(UserName) >= 1 AND LEN(UserName) <= 50),
    Role VARCHAR(20) not null CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) not null CHECK (LEN(Password) >= 6 AND LEN(Password) <= 20)
);

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL CHECK (LEN(EventName) >= 1 AND LEN(EventName) <= 50),
    EventCategory VARCHAR(50) NOT NULL CHECK (LEN(EventCategory) >= 1 AND LEN(EventCategory) <= 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(500) NULL,
    Status VARCHAR(10) CHECK (Status IN ('Active', 'In-Active'))
);

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL CHECK (LEN(SpeakerName) >= 1 AND LEN(SpeakerName) <= 50)
);

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
    SessionTitle VARCHAR(50) NOT NULL CHECK (LEN(SessionTitle) >= 1 AND LEN(SessionTitle) <= 50),
    SpeakerId INT NOT NULL FOREIGN KEY REFERENCES SpeakersDetails(SpeakerId),
    Description VARCHAR(500) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(500)
)
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL FOREIGN KEY REFERENCES UserInfo(EmailId),
    EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
    SessionId INT NOT NULL FOREIGN KEY REFERENCES SessionInfo(SessionId),
    IsAttended BIT CHECK (IsAttended IN (0, 1))
);