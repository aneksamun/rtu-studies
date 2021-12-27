-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: bakatema
-- ------------------------------------------------------
-- Server version	5.5.11

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
-- Current Database: `bakatema`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `bakatema` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bakatema`;

--
-- Table structure for table `academics`
--

DROP TABLE IF EXISTS `academics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `academics` (
  `academic_id` int(11) NOT NULL DEFAULT '0' COMMENT 'Person�la identifikators',
  `role` int(11) DEFAULT NULL COMMENT 'Person�la loma: Vad�t�js, Bakalaurant�ras vad�t�js, Katedras vad�t�js, Lietvede',
  `institution_id` int(11) DEFAULT NULL COMMENT 'Strukt�rvien�bas identifikators',
  `system_id` int(11) DEFAULT NULL COMMENT 'Sist�mas lietot�ja identifikators',
  `academic_degree` varchar(100) DEFAULT NULL COMMENT 'Akad�misk� pak�pe',
  PRIMARY KEY (`academic_id`),
  UNIQUE KEY `idx_system_academics` (`system_id`),
  KEY `idx_institution_academics` (`institution_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='ORTUS vid� pieejamo person�la datu abstrakcija.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academics`
--

LOCK TABLES `academics` WRITE;
/*!40000 ALTER TABLE `academics` DISABLE KEYS */;
INSERT INTO `academics` VALUES (1,2,1,1,'prof'),(2,2,1,3,'prof'),(3,5,1,5,'lietvede');
/*!40000 ALTER TABLE `academics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `institutions`
--

DROP TABLE IF EXISTS `institutions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `institutions` (
  `institution_id` int(11) NOT NULL DEFAULT '0' COMMENT 'Strukt�rvien�bas identifikators',
  `title` text CHARACTER SET utf8 COMMENT 'Strukt�rvien�bas nosaukums',
  `clerk_id` int(11) DEFAULT NULL COMMENT 'Strukt�rvien�bai piesast�t�s lietvedes person�la identifikators.',
  PRIMARY KEY (`institution_id`),
  KEY `idx_institutions_clerks` (`clerk_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Strukt�rvien�bu tabula. Katrai strukt�rvien�bai var tikt pie';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `institutions`
--

LOCK TABLES `institutions` WRITE;
/*!40000 ALTER TABLE `institutions` DISABLE KEYS */;
INSERT INTO `institutions` VALUES (1,'Datorzinātņu institūts',3);
/*!40000 ALTER TABLE `institutions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notifications`
--

DROP TABLE IF EXISTS `notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notifications` (
  `notification_id` int(11) NOT NULL DEFAULT '0' COMMENT 'Zi�ojuma identifikators',
  `message_text` text COMMENT 'Zi�ojuma teksts. Teksta garums nav ierobe�ots.',
  `recepients` text COMMENT 'Zi�ojuma sa��m�ju e-pasta adreses (koma-separ�tas)',
  `effective_date` datetime DEFAULT NULL COMMENT 'Zi�ojuma izs�t��anas laiks',
  `emitted_by` int(11) DEFAULT NULL COMMENT 'Zi�ojuma ierosin�t�js (autors)',
  `is_sent` tinyint(1) DEFAULT NULL COMMENT 'Zi�ojuma aizs�ti�anas st�voklis',
  PRIMARY KEY (`notification_id`),
  KEY `idx_system_notifications` (`emitted_by`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Zi�ojumu tabula. Satur zi�ojumus un to st�vok�u inform�ciju.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notifications`
--

LOCK TABLES `notifications` WRITE;
/*!40000 ALTER TABLE `notifications` DISABLE KEYS */;
INSERT INTO `notifications` VALUES (1,'','1;2','2011-05-15 20:24:27',123,1),(2,'','1;2','2011-05-15 20:25:07',123,1),(3,'','1;2','2011-05-15 20:52:02',123,1),(4,'','2','2011-05-15 20:54:32',123,1),(5,'','1;2','2011-05-16 01:19:25',123,1),(6,'','1;2','2011-05-16 03:14:46',123,1),(7,'','1;2','2011-05-18 17:45:49',123,1),(8,'','1;2','2011-05-19 04:17:02',123,1);
/*!40000 ALTER TABLE `notifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_theses`
--

DROP TABLE IF EXISTS `student_theses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student_theses` (
  `student_id` char(9) NOT NULL DEFAULT '' COMMENT 'Studenta identifikators',
  `thesis_id` int(11) DEFAULT NULL COMMENT 'T�mas identifikators',
  `apply_date` date DEFAULT NULL COMMENT 'T�mas pieteikuma datums',
  `native_title_id` int(11) DEFAULT NULL COMMENT 'Akt�va nosaukuma dzimtaj� valod� identifikators',
  `english_title_id` int(11) DEFAULT NULL COMMENT 'Akt�v� nosaukuma ang�u valod� identifikators',
  PRIMARY KEY (`student_id`),
  KEY `idx_student_theses_thesis` (`thesis_id`),
  KEY `idx_student_theses_native_title` (`native_title_id`),
  KEY `idx_student_theses_english_title` (`english_title_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Studentu izv�l�to t�mu sates tabula. T�mas nosaukumam ir ies';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_theses`
--

LOCK TABLES `student_theses` WRITE;
/*!40000 ALTER TABLE `student_theses` DISABLE KEYS */;
INSERT INTO `student_theses` VALUES ('123AB1234',1,'2011-04-13',1,2),('2',2,'2011-04-14',3,4);
/*!40000 ALTER TABLE `student_theses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `student_id` char(9) NOT NULL DEFAULT '' COMMENT 'Studenta apliec�bas numurs',
  `system_id` int(11) DEFAULT NULL COMMENT 'ORTUS lietot�ja identifikators',
  PRIMARY KEY (`student_id`),
  KEY `idx_system_stuents` (`system_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='ORTUS vid� pieejam�s studentu inform�cijas abstrakcija. Stud';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES ('123AB1234',2),('2',4),('8',99),('0',123);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system`
--

DROP TABLE IF EXISTS `system`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `system` (
  `system_id` int(11) NOT NULL DEFAULT '0' COMMENT 'Sist�mas lietot�ja identifikators',
  `first_name` varchar(20) DEFAULT NULL COMMENT 'Lietot�ja v�rds',
  `last_name` varchar(30) DEFAULT NULL COMMENT 'Lietot�ja uzv�rds',
  `email` varchar(320) DEFAULT NULL COMMENT 'Lietot�ja e-pasta adrese',
  PRIMARY KEY (`system_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='ORTUS vides lietot�ja datu prezent�cija. API pamats.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system`
--

LOCK TABLES `system` WRITE;
/*!40000 ALTER TABLE `system` DISABLE KEYS */;
INSERT INTO `system` VALUES (5,'Madara','Lietvede','liet@liet.lv'),(1,'Jānis','Ozols','ozols@ozols.lv'),(2,'Mārtiņš','Bērziņš','sergejs.terentjevs@gmail.com'),(3,'Māris','Kļava','klava@klava.lv'),(4,'Aleksandrs','Smirnovs','smirn@smirn.lv'),(99,'first','last','some@mail.com'),(123,'Gryzly','Beaz',''),(0,'','','');
/*!40000 ALTER TABLE `system` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `templates`
--

DROP TABLE IF EXISTS `templates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `templates` (
  `template_type` enum('NOT_SET') NOT NULL DEFAULT 'NOT_SET' COMMENT '�ablona tips',
  `template_path` varchar(260) DEFAULT NULL COMMENT '�ablona faila pilnais ce��',
  PRIMARY KEY (`template_type`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='�ablona tabula. Satur faila ce�u katram �ablona tipam. ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `templates`
--

LOCK TABLES `templates` WRITE;
/*!40000 ALTER TABLE `templates` DISABLE KEYS */;
/*!40000 ALTER TABLE `templates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `theses`
--

DROP TABLE IF EXISTS `theses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `theses` (
  `thesis_id` int(11) NOT NULL DEFAULT '0' COMMENT 'T�mas identifikators',
  `default_native_title_id` int(11) DEFAULT NULL COMMENT 'S�kotn�j� t�mas nosaukuma dzimtaj� valod� identifikators',
  `lecturer_id` int(11) DEFAULT NULL COMMENT 'Vad�t�ja identifikators',
  `academic_year` smallint(6) DEFAULT NULL COMMENT 'Aktu�lais akad�miskais gads',
  `bachelor_approval_by` int(11) DEFAULT NULL COMMENT 'Persona, kas veic bakalaurant�ras vad�taja apstiprin�jumu',
  `cathedra_approval_by` int(11) DEFAULT NULL COMMENT 'Persona, kas veic katedras vad�taja apstiprin�jumu',
  `institution_id` int(11) DEFAULT NULL COMMENT 'Strukturvien�bas identifikators',
  `default_english_title_id` int(11) DEFAULT NULL COMMENT 'S�kotn�jais t�mas nosaukuma ang�u valod� identifikators ',
  PRIMARY KEY (`thesis_id`),
  KEY `idx_theses_institution` (`institution_id`),
  KEY `idx_theses_default_title_native` (`default_native_title_id`),
  KEY `idx_theses_default_title_english` (`default_english_title_id`),
  KEY `fk_theses_lecturer` (`lecturer_id`),
  KEY `fk_theses_bapproveby` (`bachelor_approval_by`),
  KEY `fk_theses_capproveby` (`cathedra_approval_by`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='T�mu tabula. Izveidojot t�mu, t�s nosaukumam s�kotn�ji ir j�';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `theses`
--

LOCK TABLES `theses` WRITE;
/*!40000 ALTER TABLE `theses` DISABLE KEYS */;
INSERT INTO `theses` VALUES (1,1,2,2011,123,123,1,2),(2,3,1,2011,123,123,1,4);
/*!40000 ALTER TABLE `theses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `title_id` int(11) NOT NULL DEFAULT '0' COMMENT 'T�mas nosaukuma identifikators',
  `lecturer_approved` tinyint(1) DEFAULT NULL COMMENT 'Vad�t�ja apstiprin�jums',
  `bachelor_approved` tinyint(1) DEFAULT NULL COMMENT 'Bakalauranturas vad�t�ja apstiprin�jums',
  `cathedra_approved` tinyint(1) DEFAULT NULL COMMENT 'Katedras vad�t�ja apstiprin�jums',
  `revision_number` int(11) DEFAULT NULL COMMENT 'Nosaukuma varianta k�rtas numurs',
  `thesis_id` int(11) DEFAULT NULL COMMENT 'T�mas indentifikators',
  `title` text CHARACTER SET utf8 COMMENT 'T�mas nosaukums',
  `revision_date` date DEFAULT NULL COMMENT 'T�mas nosaukuma pievieno�anas datums',
  `is_active` tinyint(1) DEFAULT NULL COMMENT 'Nor�da t�mas aktualit�ti',
  `refusal_reason` text CHARACTER SET utf8 COMMENT 'T�mas atteikuma iemesla izkl�sts',
  `refused_by` int(11) DEFAULT NULL COMMENT 'T�mas atteikuma ierosin�t�ja identifikators',
  `language` enum('LV','EN') CHARACTER SET utf8 DEFAULT NULL COMMENT 'T�mas nosaukuma valoda',
  `comment` text CHARACTER SET utf8 COMMENT 'T�mas izmai�as vai pieteik�anas koment�rs',
  PRIMARY KEY (`title_id`),
  KEY `idx_titles` (`refused_by`),
  KEY `idx_titles_0` (`thesis_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='T�mu nosaukumi. Katrai izv�l�tai t�mai var b�t tikai viens a';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,1,1,0,6,1,'Tēmas nosaukums 1','2011-05-04',0,'Tēma atteikta!',123,'LV',''),(2,1,1,1,7,1,'These 1','2011-04-11',1,NULL,NULL,'EN',NULL),(3,1,1,1,9,2,'Tēmas nosaukums 2','2011-04-06',1,NULL,NULL,'LV',NULL),(4,1,1,1,8,2,'These 2','2011-04-07',1,NULL,NULL,'EN',NULL),(66,0,0,0,1,1,'Cool title','2011-05-01',0,'serious reason',0,'LV','shit happens'),(67,0,1,0,1,1,'some title','2011-05-18',1,'serious reason',123,'LV','cool title'),(68,0,1,0,1,1,'some title','2011-05-18',1,'serious reason',123,'LV','cool title');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2011-06-09 20:57:36
