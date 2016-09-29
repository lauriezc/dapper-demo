/*
 Navicat MySQL Data Transfer

 Source Server         : local
 Source Server Version : 50711
 Source Host           : localhost
 Source Database       : dapper-test

 Target Server Version : 50711
 File Encoding         : utf-8

 Date: 09/29/2016 12:21:13 PM
*/

SET NAMES utf8;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
--  Table structure for `Test`
-- ----------------------------
DROP TABLE IF EXISTS `Test`;
CREATE TABLE `Test` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=134 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
--  Table structure for `datatype`
-- ----------------------------
DROP TABLE IF EXISTS `datatype`;
CREATE TABLE `datatype` (
  `bit` bit(1) NOT NULL,
  `tinyint` tinyint(4) NOT NULL AUTO_INCREMENT,
  `smallint` smallint(6) NOT NULL,
  `mediumint` mediumint(9) NOT NULL,
  `int` int(11) NOT NULL,
  `integer` int(11) NOT NULL,
  `bigint` bigint(20) NOT NULL,
  `real` double NOT NULL,
  `double` double NOT NULL,
  `float` float NOT NULL,
  `decimal` decimal(10,0) NOT NULL,
  `numeric` decimal(10,0) NOT NULL,
  `char` char(11) NOT NULL,
  `varchar` varchar(11) NOT NULL,
  `binary` binary(10) NOT NULL,
  `varbinary` varbinary(11) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `datetime` datetime NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `year` year(4) NOT NULL,
  `tinyblob` tinyblob NOT NULL,
  `blob` blob NOT NULL,
  `mediumblob` mediumblob NOT NULL,
  `longblob` longblob NOT NULL,
  `tinytext` tinytext NOT NULL,
  `text` text NOT NULL,
  `mediumtext` mediumtext NOT NULL,
  PRIMARY KEY (`tinyint`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  View structure for `all_test`
-- ----------------------------
DROP VIEW IF EXISTS `all_test`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `all_test` AS select `test`.`id` AS `id`,`test`.`name` AS `name`,`test`.`Time` AS `Time` from `test`;

-- ----------------------------
--  Procedure structure for `plus`
-- ----------------------------
DROP PROCEDURE IF EXISTS `plus`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `plus`(IN a int, IN b int, OUT c int)
select a+b
 ;;
delimiter ;

-- ----------------------------
--  Function structure for `f_plus`
-- ----------------------------
DROP FUNCTION IF EXISTS `f_plus`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `f_plus`(a int, b int) RETURNS int(11)
return a+b
 ;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
