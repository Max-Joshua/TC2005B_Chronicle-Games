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
-- Table structure for table `user_info`
--

DROP TABLE IF EXISTS `user_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_info` (
  `id_user_info` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `mail` varchar(45) NOT NULL,
  `age` tinyint NOT NULL,
  `country` varchar(45) NOT NULL,
  `id_statistics` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_user_info`),
  KEY `id_statistics_idx` (`id_statistics`),
  CONSTRAINT `id_statistics` FOREIGN KEY (`id_statistics`) REFERENCES `statistics` (`id_statistics`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_info`
--

LOCK TABLES `user_info` WRITE;
/*!40000 ALTER TABLE `user_info` DISABLE KEYS */;
INSERT INTO `user_info` VALUES (1,'Tucker','Tucker477@gmail.com',50,'Norfolk',NULL),(2,'Ralph','Ralph496@gmail.com',45,'Cambodia',NULL),(3,'Boston','Boston760@gmail.com',23,'Estonia',NULL),(4,'Rafael','Rafael756@gmail.com',67,'Belgium',NULL),(5,'Oswaldo','Oswaldo799@gmail.com',66,'Afghanistan',NULL),(6,'Cordell','Cordell628@gmail.com',38,'Northern',NULL),(7,'Jimmy','Jimmy300@gmail.com',48,'Liberia',NULL),(8,'Selena','Selena137@gmail.com',35,'Cayman',NULL),(9,'Ivy','Ivy876@gmail.com',57,'Angola',NULL),(10,'America','America35@gmail.com',31,'Heard',NULL),(11,'Scott','Scott814@gmail.com',29,'Northern',NULL),(12,'Ahmad','Ahmad791@gmail.com',39,'Pakistan',NULL),(13,'Urijah','Urijah858@gmail.com',42,'Mexico',NULL),(14,'Jamya','Jamya567@gmail.com',20,'Åland',NULL),(15,'Lorelei','Lorelei124@gmail.com',45,'Moldova,',NULL),(16,'Roland','Roland852@gmail.com',35,'Canada',NULL),(17,'Perla','Perla452@gmail.com',30,'French',NULL),(18,'Dominic','Dominic264@gmail.com',48,'Cuba',NULL),(19,'Freddy','Freddy31@gmail.com',45,'Dominican',NULL),(20,'Brenda','Brenda665@gmail.com',67,'Papua',NULL),(21,'Kimora','Kimora990@gmail.com',37,'Puerto',NULL),(22,'Elise','Elise186@gmail.com',47,'Norway',NULL),(23,'Julio','Julio981@gmail.com',68,'Gabon',NULL),(24,'Londyn','Londyn683@gmail.com',51,'Indonesia',NULL),(25,'Ryan','Ryan175@gmail.com',21,'Paraguay',NULL),(26,'Sonny','Sonny278@gmail.com',61,'Canada',NULL),(27,'Shaun','Shaun262@gmail.com',37,'Iran,',NULL),(28,'Taryn','Taryn415@gmail.com',54,'Bosnia',NULL),(29,'Jewel','Jewel103@gmail.com',25,'Morocco',NULL),(30,'Karissa','Karissa771@gmail.com',36,'Malaysia',NULL),(31,'Zaniyah','Zaniyah384@gmail.com',29,'Congo,',NULL),(32,'Jadiel','Jadiel54@gmail.com',59,'Marshall',NULL),(33,'Faith','Faith7@gmail.com',48,'Nicaragua',NULL),(34,'Katelynn','Katelynn414@gmail.com',23,'Costa',NULL),(35,'Jaylan','Jaylan434@gmail.com',64,'Saint',NULL),(36,'Dakota','Dakota361@gmail.com',62,'Fiji',NULL),(37,'Desmond','Desmond570@gmail.com',39,'Egypt',NULL),(38,'Ulises','Ulises738@gmail.com',26,'Bosnia',NULL),(39,'Charlie','Charlie592@gmail.com',33,'Norfolk',NULL),(40,'Cassius','Cassius518@gmail.com',47,'Palau',NULL),(41,'Duncan','Duncan950@gmail.com',34,'Madagascar',NULL),(42,'Tiffany','Tiffany545@gmail.com',49,'Eritrea',NULL),(43,'Nataly','Nataly96@gmail.com',44,'Jamaica',NULL),(44,'Jaelynn','Jaelynn853@gmail.com',23,'British',NULL),(45,'Aimee','Aimee173@gmail.com',39,'Faroe',NULL),(46,'Carl','Carl132@gmail.com',27,'Antigua',NULL),(47,'Quinton','Quinton72@gmail.com',64,'Bhutan',NULL),(48,'Harrison','Harrison580@gmail.com',54,'Reunion',NULL),(49,'Jamison','Jamison413@gmail.com',42,'Lithuania',NULL),(50,'Scarlett','Scarlett298@gmail.com',24,'Åland',NULL),(51,'Elijah','Elijah265@gmail.com',53,'Italy',NULL),(52,'Jaylynn','Jaylynn350@gmail.com',40,'Afghanistan',NULL),(53,'Marin','Marin565@gmail.com',45,'Peru',NULL),(54,'Leila','Leila837@gmail.com',69,'Martinique',NULL),(55,'Seth','Seth205@gmail.com',45,'Djibouti',NULL),(56,'Julia','Julia310@gmail.com',49,'Falkland',NULL),(57,'Karly','Karly214@gmail.com',63,'Falkland',NULL),(58,'Elianna','Elianna767@gmail.com',42,'Niger',NULL),(59,'Hassan','Hassan669@gmail.com',27,'China',NULL),(60,'Claudia','Claudia867@gmail.com',43,'Grenada',NULL),(61,'Shirley','Shirley895@gmail.com',68,'Burundi',NULL),(62,'Anika','Anika869@gmail.com',24,'New',NULL),(63,'Abram','Abram133@gmail.com',55,'Georgia',NULL),(64,'Harold','Harold273@gmail.com',44,'Malaysia',NULL),(65,'Simon','Simon185@gmail.com',50,'Kiribati',NULL),(66,'Taniya','Taniya403@gmail.com',31,'Faroe',NULL),(67,'Emma','Emma528@gmail.com',49,'Kazakhstan',NULL),(68,'Sean','Sean107@gmail.com',55,'Germany',NULL),(69,'Miley','Miley438@gmail.com',56,'Peru',NULL),(70,'Rose','Rose493@gmail.com',47,'Korea,',NULL),(71,'Guadalupe','Guadalupe671@gmail.com',60,'Macao',NULL),(72,'Jaylee','Jaylee711@gmail.com',68,'Niger',NULL),(73,'Zachariah','Zachariah692@gmail.com',48,'Antigua',NULL),(74,'Abel','Abel262@gmail.com',67,'Mexico',NULL),(75,'Orlando','Orlando483@gmail.com',59,'Cayman',NULL),(76,'Sterling','Sterling721@gmail.com',56,'Kuwait',NULL),(77,'Esther','Esther260@gmail.com',27,'Ecuador',NULL),(78,'Aaron','Aaron503@gmail.com',48,'Monaco',NULL),(79,'Salma','Salma878@gmail.com',64,'Saint',NULL),(80,'Emanuel','Emanuel640@gmail.com',66,'Eritrea',NULL),(81,'Ayden','Ayden584@gmail.com',43,'American',NULL),(82,'Cameron','Cameron243@gmail.com',50,'Kyrgyzstan',NULL),(83,'Jaxon','Jaxon790@gmail.com',55,'Saint',NULL),(84,'Chaya','Chaya247@gmail.com',35,'Afghanistan',NULL),(85,'Sofia','Sofia955@gmail.com',25,'Libyan',NULL),(86,'Lina','Lina12@gmail.com',35,'Greenland',NULL),(87,'Simone','Simone418@gmail.com',31,'El',NULL),(88,'Jaqueline','Jaqueline338@gmail.com',36,'Mali',NULL),(89,'Malik','Malik686@gmail.com',36,'Pakistan',NULL),(90,'Charity','Charity672@gmail.com',33,'Belize',NULL),(91,'Jazmyn','Jazmyn946@gmail.com',41,'Saint',NULL),(92,'Landyn','Landyn795@gmail.com',40,'Lithuania',NULL),(93,'Carina','Carina202@gmail.com',36,'Cook',NULL),(94,'Charlotte','Charlotte248@gmail.com',20,'Indonesia',NULL),(95,'Nina','Nina722@gmail.com',45,'Montserrat',NULL),(96,'Roman','Roman120@gmail.com',61,'Croatia',NULL),(97,'Marques','Marques689@gmail.com',20,'Antigua',NULL),(98,'Vivian','Vivian721@gmail.com',69,'Japan',NULL),(99,'Meghan','Meghan166@gmail.com',40,'Egypt',NULL),(100,'Lillian','Lillian533@gmail.com',40,'Belgium',NULL),(101,'Kaden','Kaden215@gmail.com',48,'Afghanistan',NULL),(102,'Jane','Jane696@gmail.com',54,'Puerto',NULL),(103,'Karli','Karli592@gmail.com',57,'Myanmar',NULL),(104,'Emely','Emely240@gmail.com',44,'Antarctica',NULL),(105,'Noel','Noel714@gmail.com',43,'Cambodia',NULL),(106,'Kristopher','Kristopher841@gmail.com',41,'Honduras',NULL),(107,'Zachariah','Zachariah539@gmail.com',43,'Australia',NULL),(108,'Dylan','Dylan330@gmail.com',56,'El',NULL),(109,'Kelvin','Kelvin657@gmail.com',59,'Isle',NULL),(110,'Alicia','Alicia770@gmail.com',51,'Mongolia',NULL),(111,'Mateo','Mateo271@gmail.com',32,'Burkina',NULL),(112,'Madeline','Madeline989@gmail.com',61,'Belarus',NULL),(113,'Garrett','Garrett538@gmail.com',26,'Mayotte',NULL),(114,'Deon','Deon208@gmail.com',29,'Indonesia',NULL),(115,'Johnathon','Johnathon411@gmail.com',66,'Guinea',NULL),(116,'Cedric','Cedric928@gmail.com',27,'Greece',NULL),(117,'Mckayla','Mckayla700@gmail.com',59,'Brunei',NULL),(118,'Nadia','Nadia537@gmail.com',25,'Dominica',NULL),(119,'Hannah','Hannah714@gmail.com',54,'Mauritania',NULL),(120,'Zackary','Zackary17@gmail.com',42,'Bermuda',NULL);
/*!40000 ALTER TABLE `user_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-04 13:32:10
