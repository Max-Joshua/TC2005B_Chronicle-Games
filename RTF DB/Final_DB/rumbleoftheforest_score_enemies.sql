CREATE DATABASE  IF NOT EXISTS `rumbleoftheforest` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `rumbleoftheforest`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: rumbleoftheforest
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `score_enemies`
--

DROP TABLE IF EXISTS `score_enemies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `score_enemies` (
  `id_score_enemies` int unsigned NOT NULL AUTO_INCREMENT,
  `num_of_enemies` int NOT NULL,
  `id_enemies` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_score_enemies`),
  KEY `id_enemies` (`id_enemies`),
  CONSTRAINT `id_enemies` FOREIGN KEY (`id_enemies`) REFERENCES `enemies` (`id_enemies`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_enemies`
--

LOCK TABLES `score_enemies` WRITE;
/*!40000 ALTER TABLE `score_enemies` DISABLE KEYS */;
INSERT INTO `score_enemies` VALUES (1,748,NULL),(2,131,NULL),(3,467,NULL),(4,782,NULL),(5,679,NULL),(6,740,NULL),(7,81,NULL),(8,397,NULL),(9,880,NULL),(10,356,NULL),(11,894,NULL),(12,589,NULL),(13,598,NULL),(14,702,NULL),(15,597,NULL),(16,361,NULL),(17,92,NULL),(18,35,NULL),(19,999,NULL),(20,220,NULL),(21,25,NULL),(22,181,NULL),(23,188,NULL),(24,64,NULL),(25,105,NULL),(26,999,NULL),(27,179,NULL),(28,456,NULL),(29,925,NULL),(30,202,NULL),(31,609,NULL),(32,127,NULL),(33,371,NULL),(34,956,NULL),(35,993,NULL),(36,589,NULL),(37,237,NULL),(38,166,NULL),(39,308,NULL),(40,536,NULL),(41,338,NULL),(42,507,NULL),(43,885,NULL),(44,875,NULL),(45,164,NULL),(46,293,NULL),(47,22,NULL),(48,56,NULL),(49,599,NULL),(50,38,NULL),(51,327,NULL),(52,242,NULL),(53,819,NULL),(54,624,NULL),(55,348,NULL),(56,912,NULL),(57,863,NULL),(58,830,NULL),(59,180,NULL),(60,309,NULL),(61,696,NULL),(62,992,NULL),(63,611,NULL),(64,753,NULL),(65,562,NULL),(66,185,NULL),(67,671,NULL),(68,719,NULL),(69,144,NULL),(70,489,NULL),(71,304,NULL),(72,682,NULL),(73,88,NULL),(74,370,NULL),(75,971,NULL),(76,664,NULL),(77,185,NULL),(78,679,NULL),(79,219,NULL),(80,45,NULL),(81,614,NULL),(82,60,NULL),(83,307,NULL),(84,379,NULL),(85,319,NULL),(86,336,NULL),(87,565,NULL),(88,440,NULL),(89,123,NULL),(90,13,NULL),(91,20,NULL),(92,531,NULL),(93,664,NULL),(94,164,NULL),(95,322,NULL),(96,193,NULL),(97,363,NULL),(98,900,NULL),(99,513,NULL),(100,427,NULL),(101,729,NULL),(102,212,NULL),(103,149,NULL),(104,284,NULL),(105,875,NULL),(106,153,NULL),(107,80,NULL),(108,81,NULL),(109,264,NULL),(110,413,NULL),(111,716,NULL),(112,170,NULL),(113,64,NULL),(114,373,NULL),(115,250,NULL),(116,598,NULL),(117,110,NULL),(118,892,NULL),(119,485,NULL),(120,981,NULL);
/*!40000 ALTER TABLE `score_enemies` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-04 13:45:16
