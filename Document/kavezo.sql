CREATE DATABASE IF NOT EXISTS kavezo
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

USE kavezo;

-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 01. 19:50
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kavezo`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `dolgozok`
--

CREATE TABLE `dolgozok` (
  `DolgozoId` int(11) NOT NULL,
  `Nev` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `dolgozok`
--

INSERT INTO `dolgozok` (`DolgozoId`, `Nev`) VALUES
(1, 'Kiss Anna'),
(2, 'Nagy Péter'),
(3, 'Tóth Eszter'),
(4, 'Horváth László'),
(5, 'Szabó Júlia'),
(6, 'Kovács Bálint'),
(7, 'Nagy Dóra'),
(8, 'Szabó Máté'),
(9, 'Tóth Petra'),
(10, 'Varga Ádám'),
(11, 'Horváth Nóra'),
(12, 'Kiss Levente'),
(13, 'Farkas Luca'),
(14, 'Balogh Zsófia'),
(15, 'Papp Gergő');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendelestetelek`
--

CREATE TABLE `rendelestetelek` (
  `TetelId` int(11) NOT NULL,
  `DolgozoId` int(11) NOT NULL,
  `TermekId` int(11) NOT NULL,
  `Mennyiseg` int(11) NOT NULL DEFAULT 1,
  `RendelesDatum` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendelestetelek`
--

INSERT INTO `rendelestetelek` (`TetelId`, `DolgozoId`, `TermekId`, `Mennyiseg`, `RendelesDatum`) VALUES
(1, 6, 6, 1, '2026-01-24 20:15:07'),
(2, 9, 1, 2, '2026-01-25 20:15:07'),
(3, 6, 2, 2, '2026-01-26 20:15:07'),
(4, 13, 2, 2, '2026-01-27 20:15:07'),
(5, 7, 2, 1, '2026-01-26 20:15:07'),
(6, 8, 5, 1, '2026-01-19 20:15:07'),
(7, 12, 4, 4, '2026-01-22 20:15:07'),
(8, 5, 2, 3, '2026-01-16 20:15:07'),
(9, 14, 6, 2, '2026-01-19 20:15:07'),
(10, 2, 5, 1, '2026-01-22 20:15:07'),
(11, 10, 2, 4, '2026-01-28 20:15:07'),
(12, 7, 2, 1, '2026-01-24 20:15:07'),
(13, 6, 4, 2, '2026-01-29 20:15:07'),
(14, 7, 3, 1, '2026-01-19 20:15:07'),
(15, 14, 2, 3, '2026-01-29 20:15:07'),
(16, 15, 3, 1, '2026-01-20 20:15:07'),
(17, 12, 4, 1, '2026-01-27 20:15:07'),
(18, 15, 2, 1, '2026-01-24 20:15:07'),
(19, 10, 3, 1, '2026-01-28 20:15:07'),
(20, 6, 3, 2, '2026-01-21 20:15:07'),
(21, 11, 5, 1, '2026-01-26 20:15:07'),
(22, 8, 4, 1, '2026-01-19 20:15:07'),
(23, 12, 1, 4, '2026-01-22 20:15:07'),
(24, 1, 1, 4, '2026-01-20 20:15:07'),
(25, 7, 1, 3, '2026-01-19 20:15:07'),
(26, 13, 5, 3, '2026-01-27 20:15:07'),
(27, 15, 1, 1, '2026-01-17 20:15:07'),
(28, 12, 1, 1, '2026-01-28 20:15:07'),
(29, 14, 1, 4, '2026-01-28 20:15:07'),
(30, 9, 3, 4, '2026-01-18 20:15:07'),
(31, 10, 6, 1, '2026-01-20 20:15:07'),
(32, 5, 5, 3, '2026-01-21 20:15:07'),
(33, 4, 2, 2, '2026-01-22 20:15:07'),
(34, 12, 6, 4, '2026-01-29 20:15:07'),
(35, 13, 1, 4, '2026-01-22 20:15:07'),
(36, 13, 1, 1, '2026-01-25 20:15:07'),
(37, 12, 1, 4, '2026-01-17 20:15:07'),
(38, 5, 5, 2, '2026-01-21 20:15:07'),
(39, 11, 4, 2, '2026-01-17 20:15:07'),
(40, 11, 2, 1, '2026-01-23 20:15:07'),
(64, 3, 3, 3, '2026-01-29 20:32:24');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termekek`
--

CREATE TABLE `termekek` (
  `TermekId` int(11) NOT NULL,
  `Nev` varchar(100) NOT NULL,
  `Ar` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`TermekId`, `Nev`, `Ar`) VALUES
(1, 'Fekete kávé', 600.00),
(2, 'Cappuccino', 750.00),
(3, 'Latte', 800.00),
(4, 'Csokis süti', 850.00),
(5, 'Sajttorta', 950.00),
(6, 'Kakaós csiga', 650.00),
(7, 'Americano', 700.00),
(8, 'Ristretto', 650.00),
(9, 'Flat White', 950.00),
(10, 'Mocha', 990.00),
(11, 'Macchiato', 780.00),
(12, 'Espresso doppio', 850.00),
(13, 'Jegeskávé', 1050.00),
(14, 'Chai latte', 1100.00),
(15, 'Matcha latte', 1250.00),
(16, 'Forró csoki', 900.00),
(17, 'Limonádé', 850.00),
(18, 'Ásványvíz', 450.00),
(19, 'Croissant', 690.00),
(20, 'Muffin csoki', 750.00),
(21, 'Muffin áfonya', 750.00),
(22, 'Sajttorta szelet', 1050.00),
(23, 'Brownie', 890.00),
(24, 'Keksz', 450.00),
(25, 'Szendvics sonkás', 1290.00),
(26, 'Szendvics vegetáriánus', 1190.00);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `dolgozok`
--
ALTER TABLE `dolgozok`
  ADD PRIMARY KEY (`DolgozoId`);

--
-- A tábla indexei `rendelestetelek`
--
ALTER TABLE `rendelestetelek`
  ADD PRIMARY KEY (`TetelId`),
  ADD KEY `DolgozoId` (`DolgozoId`),
  ADD KEY `TermekId` (`TermekId`);

--
-- A tábla indexei `termekek`
--
ALTER TABLE `termekek`
  ADD PRIMARY KEY (`TermekId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `dolgozok`
--
ALTER TABLE `dolgozok`
  MODIFY `DolgozoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT a táblához `rendelestetelek`
--
ALTER TABLE `rendelestetelek`
  MODIFY `TetelId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT a táblához `termekek`
--
ALTER TABLE `termekek`
  MODIFY `TermekId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `rendelestetelek`
--
ALTER TABLE `rendelestetelek`
  ADD CONSTRAINT `rendelestetelek_ibfk_1` FOREIGN KEY (`DolgozoId`) REFERENCES `dolgozok` (`DolgozoId`),
  ADD CONSTRAINT `rendelestetelek_ibfk_2` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`TermekId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
