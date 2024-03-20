DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS AuthUsers;
DROP TABLE IF EXISTS InfoUsers;

-- Users Table
CREATE TABLE Users(
	username VARCHAR(50) NOT NULL PRIMARY KEY
);

-- AuthUsers Table
CREATE TABLE AuthUsers(
	username VARCHAR(50) NOT NULL,
	userPass VARCHAR(50) NOT NULL,
	FOREIGN KEY (username) REFERENCES Users(username)
);

-- InfoUsers Table
CREATE TABLE InfoUsers(
    username VARCHAR(50) NOT NULL,
    fname VARCHAR(50) NOT NULL,
    lname VARCHAR(50) NOT NULL,
    userAddress VARCHAR(100) NOT NULL,
    phoneNum VARCHAR(11) NOT NULL,
    emailAdd VARCHAR (100) NOT NULL,
    FOREIGN KEY (username) REFERENCES Users(username)
);
