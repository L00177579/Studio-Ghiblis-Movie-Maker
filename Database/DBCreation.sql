-- Dumping database structure for studioghiblicourses
CREATE DATABASE IF NOT EXISTS `studioghiblicourses` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `studioghiblicourses`;

-- Dumping structure for table studioghiblicourses.courses
CREATE TABLE IF NOT EXISTS `courses` (
  `CourseId` int(11) NOT NULL AUTO_INCREMENT,
  `CourseName` text NOT NULL,
  `Running` tinyint(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`CourseId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping structure for table studioghiblicourses.students
CREATE TABLE IF NOT EXISTS `students` (
  `StudentId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` text NOT NULL,
  `LastName` text NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Email` text NOT NULL,
  `Courses` text NOT NULL,
  PRIMARY KEY (`StudentId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
