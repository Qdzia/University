-- MySQL dump 10.13  Distrib 5.5.21, for Win32 (x86)
--
-- Host: localhost    Database: znajomi
-- ------------------------------------------------------
-- Server version	5.5.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `osoby`
--

DROP TABLE IF EXISTS `osoby`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `osoby` (
  `id_o` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `imie` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `nazwisko` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `miasto` varchar(30) COLLATE utf8_unicode_ci DEFAULT 'Gliwice',
  PRIMARY KEY (`id_o`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoby`
--

LOCK TABLES `osoby` WRITE;
/*!40000 ALTER TABLE `osoby` DISABLE KEYS */;
INSERT INTO `osoby` VALUES (1,'Adam','Ptak','Gliwice'),(2,'Mariusz','Lis','Gliwice');
/*!40000 ALTER TABLE `osoby` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefony`
--

DROP TABLE IF EXISTS `telefony`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefony` (
  `id_t` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `numer` char(9) COLLATE utf8_unicode_ci NOT NULL,
  `typ` enum('stacjonarny','komorkowy') COLLATE utf8_unicode_ci NOT NULL DEFAULT 'komorkowy',
  `operator` enum('era','play','heyah','tp') COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id_t`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefony`
--

LOCK TABLES `telefony` WRITE;
/*!40000 ALTER TABLE `telefony` DISABLE KEYS */;
/*!40000 ALTER TABLE `telefony` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teos`
--

DROP TABLE IF EXISTS `teos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teos` (
  `id` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `id_o` tinyint(3) unsigned NOT NULL,
  `id_t` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_o` (`id_o`),
  KEY `id_t` (`id_t`),
  CONSTRAINT `teos_ibfk_1` FOREIGN KEY (`id_o`) REFERENCES `osoby` (`id_o`),
  CONSTRAINT `teos_ibfk_2` FOREIGN KEY (`id_t`) REFERENCES `telefony` (`id_t`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teos`
--

LOCK TABLES `teos` WRITE;
/*!40000 ALTER TABLE `teos` DISABLE KEYS */;
/*!40000 ALTER TABLE `teos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-03 16:53:46
