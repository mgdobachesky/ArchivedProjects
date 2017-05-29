-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 13, 2016 at 06:05 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 5.6.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `music`
--
CREATE DATABASE IF NOT EXISTS `music` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `music`;

-- --------------------------------------------------------

--
-- Table structure for table `ccdata`
--

DROP TABLE IF EXISTS `ccdata`;
CREATE TABLE `ccdata` (
  `id` int(11) NOT NULL,
  `ccNum` varchar(16) NOT NULL,
  `ccName` varchar(38) NOT NULL,
  `ccExpMo` int(2) NOT NULL,
  `ccExpYr` int(4) NOT NULL,
  `ccCCV` int(4) NOT NULL,
  `ccType` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ccdata`
--

INSERT INTO `ccdata` (`id`, `ccNum`, `ccName`, `ccExpMo`, `ccExpYr`, `ccCCV`, `ccType`) VALUES
(1, '349393847583746', 'AM', 4, 2020, 123, 'AM'),
(2, '36838392837467', 'CB', 2, 2022, 124, 'CB'),
(3, '38382938374627', 'DC', 4, 2016, 125, 'DC'),
(4, '6011837482938478', 'DI', 4, 2018, 126, 'DI'),
(5, '201483748392837', 'EN', 3, 2021, 127, 'EN'),
(6, '3088387328928374', 'JC', 5, 2022, 128, 'JC'),
(7, '5583928374837289', 'MC', 5, 2021, 129, 'MC'),
(8, '4837483928374', 'VA', 4, 2023, 130, 'VA');

-- --------------------------------------------------------

--
-- Table structure for table `songs`
--

DROP TABLE IF EXISTS `songs`;
CREATE TABLE `songs` (
  `id` int(11) NOT NULL,
  `name` varchar(25) NOT NULL,
  `artist` varchar(25) NOT NULL,
  `running_time` mediumint(9) NOT NULL,
  `lyrics` text NOT NULL,
  `rating` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `songs`
--

INSERT INTO `songs` (`id`, `name`, `artist`, `running_time`, `lyrics`, `rating`) VALUES
(1, 'Right Where It Belongs', 'Nine Inch Nails', 311, 'See the animal in his cage that you\r\nbuilt\r\nAre you sure what side you''re on?\r\nBetter not look him too closely in the eye\r\nAre you sure what side of the glass you are on?\r\nSee the safety of the life you have built\r\nEverything where it belongs\r\nFeel the hollowness inside of your heart\r\nAnd it''s all\r\nRight where it belongs\r\n\r\nWhat if everything around you\r\nIsn''t quite as it seems?\r\nWhat if all the world you think you know\r\nIs an elaborate dream?\r\nAnd if you look at your reflection\r\nIs it all you want it to be?\r\nWhat if you could look right through the cracks?\r\nWould you find yourself\r\nFind yourself afraid to see?\r\n\r\nWhat if all the world''s inside of your head\r\nJust creations of your own?\r\nYour devils and your gods\r\nAll the living and the dead\r\nAnd you''re really all alone?\r\nYou can live in this illusion\r\nYou can choose to believe\r\nYou keep looking but you can''t find the woods\r\nWhile you''re hiding in the trees\r\n\r\nWhat if everything around you\r\nIsn''t quite as it seems?\r\nWhat if all the world you used to know\r\nIs an elaborate dream?\r\nAnd if you look at your reflection\r\nIs it all you want it to be?\r\nWhat if you could look right through the cracks\r\nWould you find yourself\r\nFind yourself afraid to see?', 9.5),
(2, 'Figure 8', 'Ellie Goulding', 244, 'Breathe your smoke into my lungs,\r\nIn the back of a car with you I stare into the sun,\r\nStill not too old to die young,\r\nBut lovers hold on to everything,\r\nAnd lovers hold on to anything\r\n\r\nI chase your love around a figure 8,\r\nI need you more than I can take,\r\nYou promise forever and a day,\r\nAnd then you take it all away,\r\nAnd then you take it all away\r\n\r\nPlace a kiss on my cheekbone,\r\nWhen you vanish me, I''m buried in the snow,\r\nBut something tells me I''m not alone,\r\nBut lovers hold on to everything,\r\nAnd lovers hold on to anything\r\n\r\nI chase your love around a figure 8,\r\nI need you more than I can take,\r\nYou promise forever and a day,\r\nAnd then you take it all away,\r\nAnd then you take it all away\r\n\r\nSo lovers hold on to everything,\r\nAnd lovers hold on to anything,\r\nSo lovers hold on to everything,\r\nAnd lovers hold on to anything\r\n\r\nI chase your love around a figure 8,\r\nI need you more than I can take,\r\nYou promise forever and a day,\r\nAnd then you take it all away,\r\n\r\nI chase your love around a figure 8,\r\nI need you more than I can take,\r\nYou promise forever and a day,\r\nAnd then you take it all away,\r\nAnd then you take it all away', 8.5);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(15) NOT NULL,
  `username` varchar(15) NOT NULL,
  `pwd` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `pwd`) VALUES
(1, 'Michael', 'Mike', 'password'),
(2, 'Jill', 'Llaves', 'password');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ccdata`
--
ALTER TABLE `ccdata`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `songs`
--
ALTER TABLE `songs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `artist` (`artist`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ccdata`
--
ALTER TABLE `ccdata`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `songs`
--
ALTER TABLE `songs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
