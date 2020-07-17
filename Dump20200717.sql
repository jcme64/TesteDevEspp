CREATE DATABASE  IF NOT EXISTS `exame` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `exame`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: exame
-- ------------------------------------------------------
-- Server version	8.0.21

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
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '77f6fef0-c7a7-11ea-bc47-10604b46bf78:1-68,
bf437de5-c7a7-11ea-ae6c-10604b46bf78:1-103';

--
-- Table structure for table `tb_clientes`
--

DROP TABLE IF EXISTS `tb_clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_clientes` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nm_cliente` varchar(250) DEFAULT NULL,
  `cpf_cnpj` varchar(14) DEFAULT NULL,
  `tp_cliente` char(1) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_clientes`
--

LOCK TABLES `tb_clientes` WRITE;
/*!40000 ALTER TABLE `tb_clientes` DISABLE KEYS */;
INSERT INTO `tb_clientes` VALUES (2,'Yago Fábio Farias','27849822382','F','jcme64@gmail.com'),(5,'Alessandra Sarah Ferreira','88484881962','F','jcme64@gmail.com');
/*!40000 ALTER TABLE `tb_clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_conta`
--

DROP TABLE IF EXISTS `tb_conta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_conta` (
  `id_conta` int NOT NULL AUTO_INCREMENT,
  `id_cliente` int DEFAULT NULL,
  `nm_conta` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`id_conta`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_conta`
--

LOCK TABLES `tb_conta` WRITE;
/*!40000 ALTER TABLE `tb_conta` DISABLE KEYS */;
INSERT INTO `tb_conta` VALUES (1,2,'00000001'),(2,2,'00000002');
/*!40000 ALTER TABLE `tb_conta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_lancamentos`
--

DROP TABLE IF EXISTS `tb_lancamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_lancamentos` (
  `id_lancamento` int NOT NULL AUTO_INCREMENT,
  `id_conta` int DEFAULT NULL,
  `dt_lancamento` datetime DEFAULT NULL,
  `vl_lancamento` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_lancamento`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_lancamentos`
--

LOCK TABLES `tb_lancamentos` WRITE;
/*!40000 ALTER TABLE `tb_lancamentos` DISABLE KEYS */;
INSERT INTO `tb_lancamentos` VALUES (1,1,'2020-07-17 15:04:56',100.00),(2,1,'2020-07-17 16:04:56',-500.00),(3,1,'2020-07-16 10:04:56',610.50),(4,1,'2020-07-16 11:04:56',-10.50),(5,1,'2020-07-16 16:04:56',-10.50),(6,1,'2020-07-17 16:17:27',0.21),(7,1,'2020-07-16 16:04:56',-10.50),(8,1,'2020-07-17 16:20:20',-0.21),(9,1,'2020-07-16 16:04:56',-10.50),(10,1,'2020-07-17 16:29:48',-0.21),(11,1,'2020-07-16 16:24:56',-45.50),(12,1,'2020-07-17 16:29:53',-0.91),(13,1,'2020-07-16 16:24:56',-45.50),(14,1,'2020-07-17 16:32:42',-0.91),(15,1,'2020-07-16 16:34:56',-55.55),(16,1,'2020-07-17 16:36:03',-1.11),(17,1,'2020-07-16 16:34:56',-100.55),(18,1,'2020-07-17 16:38:22',-2.01),(19,1,'2020-07-16 16:34:56',-100.55),(20,1,'2020-07-17 16:40:56',-2.01),(21,1,'2020-07-16 16:39:56',-190.55),(22,1,'2020-07-17 16:44:15',-3.81),(23,1,'2020-07-16 16:39:56',-190.55),(24,1,'2020-07-17 16:46:07',-3.81),(25,1,'2020-07-16 16:39:56',-190.55),(26,1,'2020-07-17 16:57:16',-3.81),(27,1,'2020-07-16 16:39:56',-190.55),(28,1,'2020-07-17 17:02:46',-3.81),(29,1,'2020-07-16 16:39:56',-190.55),(30,1,'2020-07-17 17:05:18',-3.81),(31,1,'2020-07-16 16:39:56',-190.55),(32,1,'2020-07-17 17:11:45',-3.81),(33,1,'2020-07-16 16:39:56',-190.55),(34,1,'2020-07-17 17:14:54',-3.81),(35,1,'2020-07-16 16:39:56',-190.55),(36,1,'2020-07-17 17:21:02',-3.81),(37,1,'2020-07-16 16:39:56',-190.55),(38,1,'2020-07-17 17:22:43',-3.81);
/*!40000 ALTER TABLE `tb_lancamentos` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-07-17 17:32:35
