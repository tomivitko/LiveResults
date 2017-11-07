-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: live_results_db
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admins` (
  `id_admin` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `e-mail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_admin`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES (1,'Ivo','Ivić','admin','5f4dcc3b5aa765d61d8327deb882cf99','ivo@blabla.com'),(2,'tomi','vitko','tomi','pass','mail'),(4,'tomi','vitko','tomi2','pass','mail'),(5,'a','a','a','0cc175b9c0f1b6a831c399e269772661','a');
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competition`
--

DROP TABLE IF EXISTS `competition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competition` (
  `id_competition` int(11) NOT NULL AUTO_INCREMENT,
  `competition_name` varchar(45) DEFAULT NULL,
  `id_sport` int(11) NOT NULL,
  PRIMARY KEY (`id_competition`),
  KEY `sport` (`id_sport`),
  CONSTRAINT `sport_id_sport` FOREIGN KEY (`id_sport`) REFERENCES `sport` (`id_sport`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competition`
--

LOCK TABLES `competition` WRITE;
/*!40000 ALTER TABLE `competition` DISABLE KEYS */;
INSERT INTO `competition` VALUES (1,'HRVATSKA PRVA LIGA',1),(2,'ENGLESKA PREMIER LIGA',1),(3,'NJEMAČKA BUNDESLIGA',1),(4,'PRVA KOŠARKAŠKA LIGA',2);
/*!40000 ALTER TABLE `competition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `match`
--

DROP TABLE IF EXISTS `match`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `match` (
  `id_match` int(11) NOT NULL AUTO_INCREMENT,
  `id_home_team` int(11) DEFAULT NULL,
  `id_away_team` int(11) DEFAULT NULL,
  `match_start` datetime DEFAULT NULL,
  `id_competition` int(11) DEFAULT NULL,
  `result` varchar(45) DEFAULT '0:0',
  `id_match_status` int(11) DEFAULT '1',
  PRIMARY KEY (`id_match`),
  KEY `home_team` (`id_home_team`),
  KEY `away_team` (`id_away_team`),
  KEY `competition_id` (`id_competition`),
  KEY `match_status` (`id_match_status`),
  CONSTRAINT `away_team` FOREIGN KEY (`id_away_team`) REFERENCES `team` (`id_team`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `competition` FOREIGN KEY (`id_competition`) REFERENCES `competition` (`id_competition`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `home_team` FOREIGN KEY (`id_home_team`) REFERENCES `team` (`id_team`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `match_status` FOREIGN KEY (`id_match_status`) REFERENCES `match_status` (`id_match_status`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `match`
--

LOCK TABLES `match` WRITE;
/*!40000 ALTER TABLE `match` DISABLE KEYS */;
INSERT INTO `match` VALUES (1,1,2,'2017-02-04 15:00:00',1,'2:0',3),(2,3,4,'2017-02-04 15:00:00',1,'0:0',1),(9,8,7,'2017-02-04 18:00:00',4,'0:0',1),(10,10,11,'2017-02-04 14:00:00',2,'0:0',1),(12,5,6,'2017-02-04 18:00:00',1,'0:0',1),(13,12,13,'2017-02-04 18:00:00',3,'0:0',1),(14,2,9,'2017-02-04 18:00:00',3,'0:0',1),(15,2,4,'2017-02-04 18:00:00',3,'0:0',1);
/*!40000 ALTER TABLE `match` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `match_status`
--

DROP TABLE IF EXISTS `match_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `match_status` (
  `id_match_status` int(11) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_match_status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `match_status`
--

LOCK TABLES `match_status` WRITE;
/*!40000 ALTER TABLE `match_status` DISABLE KEYS */;
INSERT INTO `match_status` VALUES (1,'nije počelo'),(2,'u tijeku'),(3,'kraj');
/*!40000 ALTER TABLE `match_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sport`
--

DROP TABLE IF EXISTS `sport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sport` (
  `id_sport` int(11) NOT NULL AUTO_INCREMENT,
  `sport_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_sport`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sport`
--

LOCK TABLES `sport` WRITE;
/*!40000 ALTER TABLE `sport` DISABLE KEYS */;
INSERT INTO `sport` VALUES (1,'NOGOMET'),(2,'KOŠARKA'),(3,'RUKOMET'),(4,'TENIS');
/*!40000 ALTER TABLE `sport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `team`
--

DROP TABLE IF EXISTS `team`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `team` (
  `id_team` int(11) NOT NULL AUTO_INCREMENT,
  `team_name` varchar(45) DEFAULT NULL,
  `id_sport` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_team`),
  KEY `sport` (`id_sport`),
  CONSTRAINT `sport` FOREIGN KEY (`id_sport`) REFERENCES `sport` (`id_sport`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `team`
--

LOCK TABLES `team` WRITE;
/*!40000 ALTER TABLE `team` DISABLE KEYS */;
INSERT INTO `team` VALUES (1,'DINAMO ZAGREB',1),(2,'HAJDUK SPLIT',1),(3,'RIJEKA',1),(4,'SLAVEN BELUPO',1),(5,'CIBALIJA',1),(6,'ISTRA',1),(7,'CIBONA',2),(8,'CEDEVITA',2),(9,'Samobor',1),(10,'Manchester United',1),(11,'Liverpool',1),(12,'Bayern',1),(13,'Hoffenheim',1),(14,'zagreb',3),(15,'split',3);
/*!40000 ALTER TABLE `team` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-04 12:24:41
