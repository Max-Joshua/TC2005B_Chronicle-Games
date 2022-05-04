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
-- Temporary view structure for view `top_high_scores`
--

DROP TABLE IF EXISTS `top_high_scores`;
/*!50001 DROP VIEW IF EXISTS `top_high_scores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_high_scores` AS SELECT 
 1 AS `name`,
 1 AS `total_score`,
 1 AS `age`,
 1 AS `accuracy`,
 1 AS `game_time`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `top_ages`
--

DROP TABLE IF EXISTS `top_ages`;
/*!50001 DROP VIEW IF EXISTS `top_ages`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_ages` AS SELECT 
 1 AS `age`,
 1 AS `num_age`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `notes_stats`
--

DROP TABLE IF EXISTS `notes_stats`;
/*!50001 DROP VIEW IF EXISTS `notes_stats`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `notes_stats` AS SELECT 
 1 AS `name`,
 1 AS `total_notes`,
 1 AS `perfect_percentage`,
 1 AS `good_percentage`,
 1 AS `hit_percentage`,
 1 AS `missed_percentage`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `damage_compare`
--

DROP TABLE IF EXISTS `damage_compare`;
/*!50001 DROP VIEW IF EXISTS `damage_compare`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `damage_compare` AS SELECT 
 1 AS `name`,
 1 AS `damage_taken`,
 1 AS `damage_inflicted`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `top_high_scores`
--

/*!50001 DROP VIEW IF EXISTS `top_high_scores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_high_scores` AS select `ui`.`name` AS `name`,`s`.`total_score` AS `total_score`,`ui`.`age` AS `age`,`st`.`accuracy` AS `accuracy`,`st`.`game_time` AS `game_time` from ((`score` `s` join `user_info` `ui` on((`s`.`id_score` = `ui`.`id_user_info`))) join `statistics` `st` on((`st`.`id_statistics` = `s`.`id_score`))) order by `s`.`total_score` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `top_ages`
--

/*!50001 DROP VIEW IF EXISTS `top_ages`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_ages` AS select `user_info`.`age` AS `age`,count(`user_info`.`age`) AS `num_age` from `user_info` group by `user_info`.`age` order by `num_age` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `notes_stats`
--

/*!50001 DROP VIEW IF EXISTS `notes_stats`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `notes_stats` AS select `ui`.`name` AS `name`,(((coalesce(`sn`.`num_notes_perfect`) + coalesce(`sn`.`num_notes_good`)) + coalesce(`sn`.`num_notes_hit`)) + coalesce(`sn`.`num_notes_missed`)) AS `total_notes`,((coalesce(`sn`.`num_notes_perfect`) * 100) / (((coalesce(`sn`.`num_notes_perfect`) + coalesce(`sn`.`num_notes_good`)) + coalesce(`sn`.`num_notes_hit`)) + coalesce(`sn`.`num_notes_missed`))) AS `perfect_percentage`,((coalesce(`sn`.`num_notes_good`) * 100) / (((coalesce(`sn`.`num_notes_perfect`) + coalesce(`sn`.`num_notes_good`)) + coalesce(`sn`.`num_notes_hit`)) + coalesce(`sn`.`num_notes_missed`))) AS `good_percentage`,((coalesce(`sn`.`num_notes_hit`) * 100) / (((coalesce(`sn`.`num_notes_perfect`) + coalesce(`sn`.`num_notes_good`)) + coalesce(`sn`.`num_notes_hit`)) + coalesce(`sn`.`num_notes_missed`))) AS `hit_percentage`,((coalesce(`sn`.`num_notes_missed`) * 100) / (((coalesce(`sn`.`num_notes_perfect`) + coalesce(`sn`.`num_notes_good`)) + coalesce(`sn`.`num_notes_hit`)) + coalesce(`sn`.`num_notes_missed`))) AS `missed_percentage` from (`user_info` `ui` join `score_notes` `sn` on((`ui`.`id_user_info` = `sn`.`id_score_notes`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `damage_compare`
--

/*!50001 DROP VIEW IF EXISTS `damage_compare`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `damage_compare` AS select `ui`.`name` AS `name`,`sc`.`damage_taken` AS `damage_taken`,`sc`.`damage_inflicted` AS `damage_inflicted` from (`score` `sc` join `user_info` `ui` on((`ui`.`id_user_info` = `sc`.`id_score`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Dumping events for database 'rumbleoftheforest'
--

--
-- Dumping routines for database 'rumbleoftheforest'
--
/*!50003 DROP PROCEDURE IF EXISTS `get_mail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_mail`(in user varchar(45))
begin
	select mail
    from user_info
    where user = name;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `get_stats` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_stats`(in user varchar(45))
begin
	select 	total_score,
			deaths,
            accuracy
	from user_info ui
    inner join statistics st on ui.id_user_info = st.id_statistics
    inner join score sc on ui.id_user_info = sc.id_score
    where name = user;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-04 13:32:10
