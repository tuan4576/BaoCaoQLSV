-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 02, 2024 at 06:44 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `qlsinhvien`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `student_code` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `photo` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `role_id` int NOT NULL,
  `birth_year` int DEFAULT NULL,
  `major` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `class` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `batch` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `gender` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `student_code`, `name`, `email`, `password`, `photo`, `role_id`, `birth_year`, `major`, `class`, `batch`, `gender`, `created_at`, `updated_at`) VALUES
(2, '2122110122', 'admin', 'admin@example.com', '123', 'photo.jpg', 1, NULL, NULL, NULL, NULL, NULL, '2024-10-26 04:54:46', '2024-10-26 15:07:34'),
(3, '2122110123', 'bảo', 'user3@gmail.com', '123', 'anh-ngau-cute-1.jpg', 0, 2005, 'Ngôn ngữ anh ', 'D', 'K45', 'Nam', '2024-10-26 06:04:40', '2024-11-02 06:25:04'),
(4, '2122110124', 'khánh', 'user1@gmail.com', '123', 'anh-avatar-cute-62.jpg', 0, 2006, 'Ngôn ngữ anh ', 'E', 'K46', 'Nữ', '2024-10-26 11:16:56', '2024-11-02 05:41:03'),
(12, '2122110125', 'hoài', 'tuan2@gmail.com', '123', 'anh-avatar-cute-43.jpg', 0, 2000, 'Cơ khí ', 'E', 'K46', 'Nữ', '2024-10-27 01:32:52', '2024-11-02 05:41:23'),
(14, '2122110126', 'tuấn', 'tuan@gmail.com', '123', 'anh-avatar-cute-53.jpg', 0, 2000, 'Ngôn ngữ anh ', 'B', 'K46', 'Nữ', '2024-10-28 07:58:35', '2024-11-02 05:43:08'),
(18, '2122110127', 'an', 'tuanb@gmail.com', '123', 'anh-avatar-cute-78.jpg', 0, 2000, 'Quản trị khách sạn ', 'B', 'K47', 'Nữ', '2024-10-28 08:05:43', '2024-11-02 05:40:49');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
