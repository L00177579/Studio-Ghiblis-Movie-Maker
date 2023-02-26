-- Dumping database structure for studioghiblicourses
CREATE DATABASE IF NOT EXISTS `studioghiblicourses` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `studioghiblicourses`;

-- Dumping structure for table studioghiblicourses.courses
CREATE TABLE IF NOT EXISTS `courses` (
  `CourseId` int(11) NOT NULL AUTO_INCREMENT,
  `CourseName` TEXT NOT NULL,
  `Running` BOOL NOT NULL DEFAULT 1,
  PRIMARY KEY (`CourseId`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping structure for table studioghiblicourses.students
CREATE TABLE IF NOT EXISTS `students` (
  `StudentId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` TEXT NOT NULL,
  `LastName` TEXT NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Email` TEXT NOT NULL,
  `Courses` TEXT NOT NULL,
  PRIMARY KEY (`StudentId`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping structure for table studioghiblicourses.users
CREATE TABLE IF NOT EXISTS `users` (
  `UserName` VARCHAR(100) NOT NULL,
  `Password` TEXT NOT NULL,
  `Salt` text NOT NULL,
  `Administrator` BOOL NOT NULL DEFAULT 0,
  PRIMARY KEY (`UserName`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
