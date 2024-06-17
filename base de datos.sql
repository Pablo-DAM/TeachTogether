-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: teachtogether
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `autoevaluaciones`
--

DROP TABLE IF EXISTS `autoevaluaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autoevaluaciones` (
  `id_autoevaluacion` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(100) NOT NULL,
  `id_profesor_creador` int NOT NULL,
  `id_modulo` int NOT NULL,
  PRIMARY KEY (`id_autoevaluacion`),
  KEY `fk_profesor_creador_autoevaluacion_idx` (`id_profesor_creador`),
  KEY `fk_autoevaluacion_modulo_idx` (`id_modulo`),
  CONSTRAINT `fk_autoevaluacion_modulo` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_profesor_creador_autoevaluacion` FOREIGN KEY (`id_profesor_creador`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autoevaluaciones`
--

LOCK TABLES `autoevaluaciones` WRITE;
/*!40000 ALTER TABLE `autoevaluaciones` DISABLE KEYS */;
INSERT INTO `autoevaluaciones` VALUES (31,'Tema 2',64,24),(32,'Tema 1',64,26),(34,'Tema 3 DI',66,27),(35,'Tema 2 DI',66,27);
/*!40000 ALTER TABLE `autoevaluaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autoevaluaciones_usuarios`
--

DROP TABLE IF EXISTS `autoevaluaciones_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autoevaluaciones_usuarios` (
  `id_autoevaluacion` int NOT NULL,
  `id_alumno` int NOT NULL,
  `fecha_realizacion` date DEFAULT NULL,
  PRIMARY KEY (`id_autoevaluacion`,`id_alumno`),
  KEY `fk_alumno_realizador_idx` (`id_alumno`),
  CONSTRAINT `fk_alumno_realizador` FOREIGN KEY (`id_alumno`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE,
  CONSTRAINT `fk_autoevaluacion_id` FOREIGN KEY (`id_autoevaluacion`) REFERENCES `autoevaluaciones` (`id_autoevaluacion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autoevaluaciones_usuarios`
--

LOCK TABLES `autoevaluaciones_usuarios` WRITE;
/*!40000 ALTER TABLE `autoevaluaciones_usuarios` DISABLE KEYS */;
INSERT INTO `autoevaluaciones_usuarios` VALUES (32,70,'2024-06-13'),(34,70,'2024-06-14'),(34,71,NULL),(34,72,'2024-06-14'),(34,73,NULL);
/*!40000 ALTER TABLE `autoevaluaciones_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `encuestas`
--

DROP TABLE IF EXISTS `encuestas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `encuestas` (
  `id_encuesta` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(200) NOT NULL,
  `id_profesor_realizador` int NOT NULL,
  `id_modulo` int NOT NULL,
  PRIMARY KEY (`id_encuesta`),
  KEY `fk_profesor_realizador_idx` (`id_profesor_realizador`),
  KEY `fk_encuets_modulo_idx` (`id_modulo`),
  CONSTRAINT `fk_encuets_modulo` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`),
  CONSTRAINT `fk_profesor_realizador` FOREIGN KEY (`id_profesor_realizador`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `encuestas`
--

LOCK TABLES `encuestas` WRITE;
/*!40000 ALTER TABLE `encuestas` DISABLE KEYS */;
/*!40000 ALTER TABLE `encuestas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensajes`
--

DROP TABLE IF EXISTS `mensajes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mensajes` (
  `id_mensaje` int NOT NULL AUTO_INCREMENT,
  `id_creador` int NOT NULL,
  `texto` longtext,
  `fecha_creaccion` datetime NOT NULL,
  `id_receptor` int NOT NULL,
  PRIMARY KEY (`id_mensaje`),
  KEY `fk_creador_idx` (`id_creador`),
  KEY `fk_receptor_idx` (`id_receptor`),
  CONSTRAINT `fk_creador` FOREIGN KEY (`id_creador`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_receptor` FOREIGN KEY (`id_receptor`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mensajes`
--

LOCK TABLES `mensajes` WRITE;
/*!40000 ALTER TABLE `mensajes` DISABLE KEYS */;
INSERT INTO `mensajes` VALUES (88,64,'No más preguntas, ¡pesao!','2024-06-13 19:59:35',70),(90,64,'Bienvenido al curos de AD','2024-06-13 20:04:56',70),(93,70,'Gracias','2024-06-13 20:14:59',64),(94,66,'Aprobaste el exámen de DI','2024-06-14 18:13:40',71),(95,66,'Hoy no habrá clase por la huelga.','2024-06-14 18:14:26',71),(96,71,'Vale, gracias.','2024-06-14 18:15:43',66),(98,64,'Hola','2024-06-14 21:03:02',65);
/*!40000 ALTER TABLE `mensajes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulos`
--

DROP TABLE IF EXISTS `modulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modulos` (
  `id_modulo` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(70) NOT NULL,
  `horario` varchar(70) DEFAULT NULL,
  `horas` int DEFAULT NULL,
  `id_profesor` int NOT NULL,
  `codigo` varchar(45) NOT NULL,
  `dias` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id_modulo`),
  KEY `FK_profesor_idx` (`id_profesor`),
  CONSTRAINT `FK_profesor` FOREIGN KEY (`id_profesor`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulos`
--

LOCK TABLES `modulos` WRITE;
/*!40000 ALTER TABLE `modulos` DISABLE KEYS */;
INSERT INTO `modulos` VALUES (24,'Acceso a Datos','Lunes: 16:00-18:00, Martes: 15:00-17:00, Jueves: 17:00-18:00',420,64,'a','Lunes, Martes, Jueves'),(26,'Bases de Datos','Lunes: 12:00-19:00',200,64,'b','Lunes'),(27,'Desarrollo de Interfaces','Martes de 14:00 a 17:00. Jueves de 15:00 a 18:00',250,66,'a','Martes, Jueves'),(28,'Realidad Virtual','Lunes de 15:00 a 18:00',100,66,'a','Lunes');
/*!40000 ALTER TABLE `modulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opciones_pregunta_encuesta`
--

DROP TABLE IF EXISTS `opciones_pregunta_encuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opciones_pregunta_encuesta` (
  `id_opcion` int NOT NULL AUTO_INCREMENT,
  `texto_opcion` varchar(150) NOT NULL,
  `id_pregunta_encuesta` int NOT NULL,
  PRIMARY KEY (`id_opcion`),
  KEY `fk_pregunta_encuesta_idx` (`id_pregunta_encuesta`),
  CONSTRAINT `fk_pregunta_encuesta` FOREIGN KEY (`id_pregunta_encuesta`) REFERENCES `preguntas_encuesta` (`id_pregunta`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opciones_pregunta_encuesta`
--

LOCK TABLES `opciones_pregunta_encuesta` WRITE;
/*!40000 ALTER TABLE `opciones_pregunta_encuesta` DISABLE KEYS */;
/*!40000 ALTER TABLE `opciones_pregunta_encuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfiles`
--

DROP TABLE IF EXISTS `perfiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfiles` (
  `id_perfil` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(70) NOT NULL,
  `apellidos` varchar(120) NOT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_perfil`),
  UNIQUE KEY `id_usuario_UNIQUE` (`id_usuario`),
  UNIQUE KEY `id_usuario` (`id_usuario`),
  KEY `fk_usuario_idx` (`id_usuario`),
  CONSTRAINT `fk_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfiles`
--

LOCK TABLES `perfiles` WRITE;
/*!40000 ALTER TABLE `perfiles` DISABLE KEYS */;
INSERT INTO `perfiles` VALUES (38,'Luis','Herrero Cos','1992-02-13',64),(39,'Gonzalo','Gutiérres Somavilla','1960-04-13',65),(40,'Ricardo Luis','Gutierrez Hernandez','2001-06-14',66),(41,'Alberto Felipe','Álvarez Diago','1984-06-13',67),(42,'Maria Pilar ','Ruiz','2001-06-13',68),(43,'Felipe','MorenoDíaz','1989-06-13',69),(44,'Pablo','Sainz Luque','1900-06-18',70),(45,'Diego','Fernandez Fernandez','2012-06-14',71),(46,'Vladyslav','Golovatyi Tsymbal','1998-06-14',72),(47,'Ignacio','Saez Gonzalez','1994-06-14',73),(48,'Pablo','Paz del Valle','2002-06-14',74),(49,'Alejandro','Penil Haya','1998-06-14',75),(50,'Isaac','Cabria Diez','1998-06-14',76),(51,'Veronica','Alvarez Lavin','2007-04-12',77),(52,'Diego','Corominas Gomez','2008-06-14',78);
/*!40000 ALTER TABLE `perfiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preguntas_autoevaluacion`
--

DROP TABLE IF EXISTS `preguntas_autoevaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `preguntas_autoevaluacion` (
  `id_pregunta` int NOT NULL AUTO_INCREMENT,
  `id_autoevaluacion` int NOT NULL,
  `enunciado_pregunta` varchar(200) NOT NULL,
  PRIMARY KEY (`id_pregunta`),
  KEY `fk_autoevaluacion_idx` (`id_autoevaluacion`),
  CONSTRAINT `fk_autoevaluacion` FOREIGN KEY (`id_autoevaluacion`) REFERENCES `autoevaluaciones` (`id_autoevaluacion`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preguntas_autoevaluacion`
--

LOCK TABLES `preguntas_autoevaluacion` WRITE;
/*!40000 ALTER TABLE `preguntas_autoevaluacion` DISABLE KEYS */;
INSERT INTO `preguntas_autoevaluacion` VALUES (33,32,'¿Qué ha sido lo que más te ha gustado del tema 1?'),(36,34,'¿Qué os ha parecido WinForms?'),(37,34,'¿Preferís WPF o Winforms?');
/*!40000 ALTER TABLE `preguntas_autoevaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preguntas_encuesta`
--

DROP TABLE IF EXISTS `preguntas_encuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `preguntas_encuesta` (
  `id_pregunta` int NOT NULL AUTO_INCREMENT,
  `texto_pregunta` varchar(200) NOT NULL,
  `id_encuesta` int NOT NULL,
  PRIMARY KEY (`id_pregunta`),
  KEY `fk_encuesta_id_idx` (`id_encuesta`),
  CONSTRAINT `fk_encuesta_id` FOREIGN KEY (`id_encuesta`) REFERENCES `encuestas` (`id_encuesta`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preguntas_encuesta`
--

LOCK TABLES `preguntas_encuesta` WRITE;
/*!40000 ALTER TABLE `preguntas_encuesta` DISABLE KEYS */;
/*!40000 ALTER TABLE `preguntas_encuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respuestas_opcion_pregunta_encuesta`
--

DROP TABLE IF EXISTS `respuestas_opcion_pregunta_encuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `respuestas_opcion_pregunta_encuesta` (
  `id_respuesta` int NOT NULL AUTO_INCREMENT,
  `texto_opcional_respuesta` mediumtext,
  `id_opcion` int NOT NULL,
  `id_alumno` int NOT NULL,
  PRIMARY KEY (`id_respuesta`),
  KEY `fk_opcion_idx` (`id_opcion`),
  KEY `fk_respuestaEncuesta_alumno_idx` (`id_alumno`),
  CONSTRAINT `fk_opcion` FOREIGN KEY (`id_opcion`) REFERENCES `opciones_pregunta_encuesta` (`id_opcion`),
  CONSTRAINT `fk_respuestaEncuesta_alumno` FOREIGN KEY (`id_alumno`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respuestas_opcion_pregunta_encuesta`
--

LOCK TABLES `respuestas_opcion_pregunta_encuesta` WRITE;
/*!40000 ALTER TABLE `respuestas_opcion_pregunta_encuesta` DISABLE KEYS */;
/*!40000 ALTER TABLE `respuestas_opcion_pregunta_encuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respuestas_pregunta_autoevaluacion`
--

DROP TABLE IF EXISTS `respuestas_pregunta_autoevaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `respuestas_pregunta_autoevaluacion` (
  `id_respuesta` int NOT NULL AUTO_INCREMENT,
  `texto_respuesta` mediumtext,
  `id_pregunta` int NOT NULL,
  `id_alumno` int NOT NULL,
  PRIMARY KEY (`id_respuesta`),
  KEY `fk_pregunta_idx` (`id_pregunta`),
  KEY `fk_respuesta_alumno_idx` (`id_alumno`),
  CONSTRAINT `fk_pregunta` FOREIGN KEY (`id_pregunta`) REFERENCES `preguntas_autoevaluacion` (`id_pregunta`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_respuesta_alumno` FOREIGN KEY (`id_alumno`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respuestas_pregunta_autoevaluacion`
--

LOCK TABLES `respuestas_pregunta_autoevaluacion` WRITE;
/*!40000 ALTER TABLE `respuestas_pregunta_autoevaluacion` DISABLE KEYS */;
INSERT INTO `respuestas_pregunta_autoevaluacion` VALUES (33,'El IDE Eclipse',33,70),(36,'Me ha gustado y me sera de utilidad en el futuro.',36,70),(37,'Winforms',37,70),(38,'Genial',36,72),(39,'Winforms',37,72);
/*!40000 ALTER TABLE `respuestas_pregunta_autoevaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `rol` enum('profesor','alumno') NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `password` varchar(600) NOT NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (64,'profesor','Luishe-1','$2a$10$H83pvt8oK8Xi6bBbxnrhhOqiLSuzA1Mfx9qyCDqcUU2vlEyJdF9.2'),(65,'profesor','Gonza-1','$2a$10$hWfbFDSHgieFnKtF6Fbsy.dfQG7muE8ap4B3IMgn0YDYlohDlWfr.'),(66,'profesor','Ricardolu-1','$2a$10$FDsNS2K81l4cajeeYAckoOCbCRsKLq1koW90G05dzlvNUke2Qy2D6'),(67,'profesor','Albefe-1','$2a$10$6MmdzAUUajRmPkamkA9tneNfCq6aUTpiFF83BDXuZrTSvpaAq/TNi'),(68,'profesor','Maripi-1','$2a$10$DuEmc0qjkmhMvERdUCJpf.LcU.4/aV2Vv1ezaUAEBMzFOlAI8ztAu'),(69,'profesor','Fepimo-1','$2a$10$4e9vSe7GPoxGgs6OGUVYue.8C/TiVGP9vo4ZlDOs9UR7QrT2g7VJS'),(70,'alumno','Pablo-1','$2a$10$K8mUnt4lGvLR/asdROSHjeZF1oR.GRCX3hKXMjktaySQpR/cVSina'),(71,'alumno','Diegofe-1','$2a$10$HUiqwts4vqF8/lLnzUgLue.NAELW1Smdj2oMjVaOx.2a8dM0NX1X6'),(72,'alumno','Vladys-1','$2a$10$IesUwtcTq.yqI4KxWK7bbuiWxTkD9kba3CCnjmwPpY1r03k0TVcFC'),(73,'alumno','Ignacio-1','$2a$10$CaoIpcPU4VK4pTr3MEpH5O3yy2AZ5ERhXd14/j10ji.Lvwf4o17ny'),(74,'alumno','PabloHijo','$2a$10$uVBMH9He4uyWpFlodNlvH.r6mXogd4PczGqt3evILlPf78pGMWQ1C'),(75,'alumno','Alejandro-1','$2a$10$47hQEi4u5bTcrK4v7hFK9.nPTcmBj.ee6azNSlBrUIN2pX.nI3tTC'),(76,'alumno','Isaac-1','$2a$10$GaOv41SR//sg2NeA59DJx.hBGClETLrgC9PuTohXHFbo3OLbryL8q'),(77,'alumno','Veronica-1','$2a$10$820K3BTgRp39.DMpy.oJWOQh75aAlmx6GCfcKGEmK6Xyt0ZuMDJBO'),(78,'alumno','Diego-1','$2a$10$3ovezekP8USOkxs1R0WCWumoEgfkSv7UbQbLgiv.uablHvixCiy26');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_encuestas`
--

DROP TABLE IF EXISTS `usuarios_encuestas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_encuestas` (
  `id_usuario` int NOT NULL,
  `id_encuesta` int NOT NULL,
  `fecha_realizacion` date DEFAULT NULL,
  PRIMARY KEY (`id_usuario`,`id_encuesta`),
  KEY `fk_encuesta_idx` (`id_encuesta`),
  CONSTRAINT `fk_alumno_hacedor` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_encuesta` FOREIGN KEY (`id_encuesta`) REFERENCES `encuestas` (`id_encuesta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_encuestas`
--

LOCK TABLES `usuarios_encuestas` WRITE;
/*!40000 ALTER TABLE `usuarios_encuestas` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarios_encuestas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_modulos`
--

DROP TABLE IF EXISTS `usuarios_modulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_modulos` (
  `id_alumno` int NOT NULL,
  `id_modulo` int NOT NULL,
  PRIMARY KEY (`id_alumno`,`id_modulo`),
  KEY `fk_modulos_idx` (`id_modulo`),
  CONSTRAINT `fk_alumnos` FOREIGN KEY (`id_alumno`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_modulos` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_modulos`
--

LOCK TABLES `usuarios_modulos` WRITE;
/*!40000 ALTER TABLE `usuarios_modulos` DISABLE KEYS */;
INSERT INTO `usuarios_modulos` VALUES (70,26),(70,27),(71,27),(72,27),(73,27);
/*!40000 ALTER TABLE `usuarios_modulos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-16 16:23:36
