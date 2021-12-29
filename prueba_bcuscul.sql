/*
Navicat MySQL Data Transfer

Source Server         : BD_Locales
Source Server Version : 50621
Source Host           : localhost:3306
Source Database       : prueba

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2021-12-29 16:10:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `empleados`
-- ----------------------------
DROP TABLE IF EXISTS `empleados`;
CREATE TABLE `empleados` (
  `dpi` bigint(20) NOT NULL,
  `nombreCompleto` varchar(128) DEFAULT NULL,
  `cantidadHijos` int(11) DEFAULT NULL,
  `SalarioBase` decimal(10,0) DEFAULT NULL,
  `SalarioLiquido` decimal(10,0) DEFAULT NULL,
  `UsuarioCreacion` varchar(128) DEFAULT NULL,
  `fechaCreacion` datetime DEFAULT NULL,
  PRIMARY KEY (`dpi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of empleados
-- ----------------------------
INSERT INTO `empleados` VALUES ('156798770101', 'Cfuentes', '2', '4500', '4754', 'Administrador', '2021-12-29 15:50:15');
INSERT INTO `empleados` VALUES ('2323899000101', 'Noe', '2', '5000', '5225', 'Administrador', '2021-12-29 12:00:56');
INSERT INTO `empleados` VALUES ('5790679000101', 'Emily', '2', '3880', '4170', 'Administrador', '2021-12-29 15:50:36');
INSERT INTO `empleados` VALUES ('7897675550101', 'Marce', '1', '20000', '19217', 'Administrador', '2021-12-29 13:38:36');
INSERT INTO `empleados` VALUES ('7897908770101', 'Javi', '2', '15000', '14642', 'Administrador', '2021-12-29 12:05:14');

-- ----------------------------
-- Table structure for `usuarios`
-- ----------------------------
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(128) DEFAULT NULL,
  `email` varchar(64) DEFAULT NULL,
  `fechaNacimiento` date DEFAULT NULL,
  `passw` varchar(128) DEFAULT NULL,
  `tokenR` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of usuarios
-- ----------------------------
INSERT INTO `usuarios` VALUES ('1', 'Administrador', 'billycuscul@gmail.com', '1993-02-22', 'marce', '');
INSERT INTO `usuarios` VALUES ('2', 'Cuscul', 'cuscul@gmail.com', '2000-01-01', 'cuscul', null);
INSERT INTO `usuarios` VALUES ('3', 'cfuentes', 'cfuentes@incomel.com.gt', '2000-01-01', 'cfuentes', null);
