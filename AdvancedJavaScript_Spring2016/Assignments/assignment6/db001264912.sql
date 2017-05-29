-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 12, 2016 at 07:32 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 5.6.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db001264912`
--
CREATE DATABASE IF NOT EXISTS `db001264912` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `db001264912`;

-- --------------------------------------------------------

--
-- Table structure for table `actors`
--

DROP TABLE IF EXISTS `actors`;
CREATE TABLE `actors` (
  `actorId` int(11) NOT NULL,
  `firstName` varchar(40) NOT NULL,
  `lastName` varchar(40) NOT NULL,
  `birthMonth` int(10) NOT NULL,
  `birthYear` int(10) NOT NULL,
  `birthday` int(10) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `action` varchar(10) NOT NULL,
  `comedy` varchar(10) NOT NULL,
  `drama` varchar(10) NOT NULL,
  `scienceFiction` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `actors`
--

INSERT INTO `actors` (`actorId`, `firstName`, `lastName`, `birthMonth`, `birthYear`, `birthday`, `gender`, `action`, `comedy`, `drama`, `scienceFiction`) VALUES
(1, 'Michael', 'Dobachesky', 11, 1991, 22, 'male', 'true', 'true', 'true', 'true'),
(2, 'Amy', 'Llaves', 10, 1993, 5, 'female', 'true', 'true', 'true', 'true'),
(4, 'zdfg', 'sdfg', 2, 2016, 4, 'male', 'true', 'true', 'true', 'true'),
(5, 'zdfg', 'sdfg', 2, 2016, 4, 'male', 'true', 'true', 'true', 'true'),
(6, 'asdf', 'asdf', 2, 2015, 3, 'male', 'true', 'true', 'true', 'true'),
(7, 'sdfg', 'asd', 3, 2016, 3, 'male', 'false', 'true', 'true', 'false'),
(8, 'sdfg', 'asd', 3, 2016, 0, 'female', 'false', 'true', 'true', 'false'),
(9, 'sdfg', 'asd', 3, 2016, 0, 'female', 'false', 'true', 'false', 'true');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `actors`
--
ALTER TABLE `actors`
  ADD PRIMARY KEY (`actorId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `actors`
--
ALTER TABLE `actors`
  MODIFY `actorId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
