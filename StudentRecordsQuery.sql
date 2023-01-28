CREATE TABLE `students` (
	`studentid` INT NOT NULL,
	`name` TEXT(40) NOT NULL,
	`dob` DATE NOT NULL,
	`email` TEXT(50) NOT NULL,
	`phone` VARCHAR(15),
	`courses` TEXT(100) NOT NULL,
	`comments` TEXT(500),
	PRIMARY KEY (`studentid`)
);

CREATE TABLE `courses` (
	`courseid` INT(20) NOT NULL,
	`coursename` TEXT(60) NOT NULL,
	PRIMARY KEY (`courseid`)
)