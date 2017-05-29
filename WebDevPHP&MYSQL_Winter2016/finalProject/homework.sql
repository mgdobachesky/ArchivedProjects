-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 09, 2016 at 04:32 AM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 5.6.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `homework`
--
CREATE DATABASE IF NOT EXISTS `homework` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `homework`;

-- --------------------------------------------------------

--
-- Table structure for table `assignment`
--

DROP TABLE IF EXISTS `assignment`;
CREATE TABLE `assignment` (
  `id` int(11) NOT NULL,
  `assignmentname` text,
  `assignmentdate` date NOT NULL,
  `studentid` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `assignment`
--

INSERT INTO `assignment` (`id`, `assignmentname`, `assignmentdate`, `studentid`) VALUES
(1, 'Program a pizza order form', '2012-04-16', 1),
(2, 'Write a persuasive speech', '2012-04-22', 1),
(3, 'Build a website using php', '2012-04-01', 2),
(4, 'Write a system analysis diagram', '2012-04-08', 2);

-- --------------------------------------------------------

--
-- Table structure for table `assignmentcourse`
--

DROP TABLE IF EXISTS `assignmentcourse`;
CREATE TABLE `assignmentcourse` (
  `assignmentid` int(11) NOT NULL,
  `courseid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `assignmentcourse`
--

INSERT INTO `assignmentcourse` (`assignmentid`, `courseid`) VALUES
(1, 2),
(2, 1),
(3, 4),
(4, 3);

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`id`, `name`) VALUES
(1, 'EN211'),
(2, 'SE245'),
(3, 'SE252'),
(4, 'SE266');

-- --------------------------------------------------------

--
-- Table structure for table `privilege`
--

DROP TABLE IF EXISTS `privilege`;
CREATE TABLE `privilege` (
  `studentid` int(11) NOT NULL,
  `privilegeid` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `privilege`
--

INSERT INTO `privilege` (`studentid`, `privilegeid`) VALUES
(1, 'Account Administrator'),
(1, 'Content Editor'),
(1, 'Site Administrator'),
(2, 'Account Administrator'),
(2, 'Content Editor'),
(2, 'Site Administrator'),
(3, 'Account Administrator'),
(3, 'Content Editor'),
(3, 'Site Administrator');

-- --------------------------------------------------------

--
-- Table structure for table `privilegedetails`
--

DROP TABLE IF EXISTS `privilegedetails`;
CREATE TABLE `privilegedetails` (
  `id` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `privilegedetails`
--

INSERT INTO `privilegedetails` (`id`, `description`) VALUES
('Account Administrator', 'Add, remove, and edit students'),
('Content Editor', 'Add, remove, and edit assignments'),
('Site Administrator', 'Add, remove, and edit categories');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE `student` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `password` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`id`, `name`, `email`, `password`) VALUES
(1, 'Mike Dobachesky', 'mgdobachesky@email.neit.edu', '71307933fa630a00d0dfa3f1c32b05ce'),
(2, 'Another Student', 'anotherstudent@email.neit.edu', '71307933fa630a00d0dfa3f1c32b05ce'),
(3, 'clark', 'clark', 'acacc2c8d5818930ff766b8fd13a72dc');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assignment`
--
ALTER TABLE `assignment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `assignmentcourse`
--
ALTER TABLE `assignmentcourse`
  ADD PRIMARY KEY (`assignmentid`,`courseid`);

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `privilege`
--
ALTER TABLE `privilege`
  ADD PRIMARY KEY (`studentid`,`privilegeid`);

--
-- Indexes for table `privilegedetails`
--
ALTER TABLE `privilegedetails`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `assignment`
--
ALTER TABLE `assignment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
