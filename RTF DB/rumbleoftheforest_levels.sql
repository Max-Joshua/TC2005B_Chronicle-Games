DROP TABLE IF EXISTS `levels`;

CREATE TABLE `levels` (
  `id_level` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `id_user_level` INT UNSIGNED NOT NULL,
  
  PRIMARY KEY(`id_level`), 
  KEY `id_user_level_idx` (`id_user_level`),
  
  CONSTRAINT `id_user_level` FOREIGN KEY (`id_user_level`) REFERENCES `user_level` (`id_user_level`) ON DELETE RESTRICT ON UPDATE CASCADE
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;