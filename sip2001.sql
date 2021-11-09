-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 09, 2021 at 06:59 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sip2001`
--

-- --------------------------------------------------------

--
-- Table structure for table `dashboard`
--

CREATE TABLE `dashboard` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `subtitle` varchar(255) NOT NULL,
  `ket` text NOT NULL,
  `url` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dashboard`
--

INSERT INTO `dashboard` (`id`, `title`, `subtitle`, `ket`, `url`) VALUES
(1, 'Mahasiswa Page', 'Mahasiswa', 'Tambah data mahasiswa baru , edit dan juga hapus bisa dilakukan disini', 'mahasiswa-admin'),
(2, 'Home Page', 'Home', 'Edit halaman home bisa dilakukan disini ya.', 'home-page-config'),
(3, 'Photo Page', 'Photo', 'Tambah foto , edit dan juga hapus bisa dilakukan disini ya.', 'photo-admin'),
(4, 'Tools Page', 'Tools', 'Tambah tools baru , edit maupun hapus bisa dilakukan disini ya.', 'tools-admin');

-- --------------------------------------------------------

--
-- Table structure for table `homepage`
--

CREATE TABLE `homepage` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `subtitle` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `img` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `homepage`
--

INSERT INTO `homepage` (`id`, `title`, `subtitle`, `description`, `img`) VALUES
(1, 'SI-P2001 .', 'The best class, friendly and cool', 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint nulla beatae facere, perspiciatis perferendis dolore possimus, molestiae accusantium deserunt ab officiis iure aliquam temporibus. Magni placeat culpa, saepe cumque assumenda soluta adipisci consectetur debitis nesciunt distinctio veritatis nemo a esse?.', './assets/img/banner-web.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `id` int(11) NOT NULL,
  `npm` int(11) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `gender` int(1) NOT NULL,
  `tglLahir` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`id`, `npm`, `nama`, `gender`, `tglLahir`) VALUES
(1, 20120064, 'Hasiholan Matondang', 1, '2003-05-20'),
(2, 20120040, 'Aldi Chandra Maulana', 1, '2001-09-19'),
(3, 20120026, 'Bahagia Elfrando Nababan', 1, '1998-06-23'),
(4, 20120087, 'Dharma Bakti Situmorang', 1, '2002-01-17'),
(5, 20120033, 'Fredi Nandus Gea', 1, '2001-05-21'),
(6, 20120002, 'Danang Dwi Yulianto', 1, '2002-07-08'),
(7, 20120058, 'Salsabila Edrin', 2, '2001-03-08'),
(8, 20120059, 'Dinda Saputri Gea', 2, '2002-12-22'),
(9, 20120035, 'Nazrul Azizi', 1, '1999-10-18'),
(10, 20120024, 'Siti Nurhalizah', 2, '2002-09-29'),
(11, 20120069, 'Bella Putri Cahyani', 2, '2002-04-13'),
(12, 20120043, 'Theresya Yohana Jesica Nainggolan', 2, '2000-05-06'),
(13, 20120021, 'Jihadussabil', 1, '2002-11-05'),
(14, 20120017, 'Siti Khairunnisa', 2, '2001-01-02'),
(15, 20120031, 'Vriska Amanda', 2, '2002-08-27'),
(16, 20120073, 'Gunawan Siburian', 1, '1997-05-09'),
(17, 20120106, 'Delis Marnyu Telaumbanua', 1, '2001-03-06'),
(18, 20120020, 'Afriyani Nasution', 2, '2001-04-08'),
(19, 20120050, 'Dian Yunita Sihombing', 2, '2002-06-29'),
(20, 20120078, 'Sri Wahyuni Hutagalung', 2, '2001-06-15'),
(21, 20120080, 'Madikatul Sania', 2, '2002-04-14'),
(22, 20120089, 'Rupa Bertha L. Pakpahan', 2, '2001-10-24'),
(23, 20120015, 'Rosaima Situmorang', 2, '2002-03-27'),
(24, 20120048, 'Restu Sigit Prasetyo', 1, '2001-06-24'),
(25, 20120099, 'Khairunnisa', 2, '2002-10-12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dashboard`
--
ALTER TABLE `dashboard`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `homepage`
--
ALTER TABLE `homepage`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `npm` (`npm`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dashboard`
--
ALTER TABLE `dashboard`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `homepage`
--
ALTER TABLE `homepage`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
