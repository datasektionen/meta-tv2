-- Groups
CREATE TABLE Groups (
	groupId SERIAL PRIMARY KEY,
	title VARCHAR(50) NOT NULL,
	priority BOOLEAN NOT NULL,
	hidden BOOLEAN NOT NULL,
	createdBy VARCHAR(15),
	startDate timestamp without time zone NOT NULL,
	endDate timestamp without time zone,
	archive BOOLEAN NOT NULL,
	archiveDate timestamp without time zone
);

-- Slides
CREATE TABLE Slides (
	slideId SERIAL PRIMARY KEY,
	groupId INTEGER NOT NULL,
	groupIndex INTEGER NOT NULL,
	archive BOOLEAN NOT NULL,
	archiveDate timestamp without time zone,
	CONSTRAINT fk_groupId
		FOREIGN KEY (groupId)
			REFERENCES Groups(groupId)
);

-- Posts
CREATE TABLE Posts(
	postId SERIAL PRIMARY KEY,
	filePath VARCHAR(50) NOT NULL,
	pathType VARCHAR(50) NOT NULL,
	tvIndex INTEGER NOT NULL,
	slideId INTEGER NOT NULL,
	CONSTRAINT fk_slideId
		FOREIGN KEY (slideId)
			REFERENCES Slides(slideId)
);

-- Changes
CREATE TABLE Changes (
	changeId SERIAL PRIMARY KEY,
	groupId INTEGER NOT NULL,
	changedBy VARCHAR(15) NOT NULL,
	changeType VARCHAR(50) NOT NULL,
	changedSlideId INTEGER NOT NULL,
	changeDate timestamp without time zone NOT NULL,
	CONSTRAINT fk_groupId
		FOREIGN KEY (groupId)
			REFERENCES Groups(groupId)
);

-- Blacklist
CREATE TABLE Blacklist (
	alias VARCHAR(15) PRIMARY KEY
);

-- DROP TABLE Posts; DROP TABLE Slides; DROP TABLE Changes; DROP TABLE Groups; DROP TABLE Blacklist