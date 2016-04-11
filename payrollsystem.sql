/*
Navicat MySQL Data Transfer

Source Server         : SGTSI
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : payrollsystem

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2016-04-01 17:39:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `audit_trails`
-- ----------------------------
DROP TABLE IF EXISTS `audit_trails`;
CREATE TABLE `audit_trails` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(50) DEFAULT NULL,
  `user_name` varchar(50) DEFAULT NULL,
  `date_time` varchar(50) DEFAULT NULL,
  `Activity` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of audit_trails
-- ----------------------------

-- ----------------------------
-- Table structure for `company_deductions`
-- ----------------------------
DROP TABLE IF EXISTS `company_deductions`;
CREATE TABLE `company_deductions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `comde_code` varchar(50) DEFAULT NULL,
  `comde_desc` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of company_deductions
-- ----------------------------
INSERT INTO `company_deductions` VALUES ('1', 'CD1', 'Car Parking', '1');
INSERT INTO `company_deductions` VALUES ('2', 'CD2', 'Motor Parking', '1');

-- ----------------------------
-- Table structure for `departments`
-- ----------------------------
DROP TABLE IF EXISTS `departments`;
CREATE TABLE `departments` (
  `name` varchar(50) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(200) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `parent_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO `departments` VALUES ('&amp;amp;nbsp;', '1', '&amp;amp;nbsp;', '0', null);
INSERT INTO `departments` VALUES ('MARCOM', '4', 'MARCOM', '0', null);
INSERT INTO `departments` VALUES ('FINCOMs', '5', 'FINCOM', '1', null);
INSERT INTO `departments` VALUES ('MARCOM', '6', 'MARCOM', '1', null);
INSERT INTO `departments` VALUES ('EXECOM', '7', 'EXECOM', '1', null);
INSERT INTO `departments` VALUES ('PRODCOM', '8', 'PRODCOM', '1', null);
INSERT INTO `departments` VALUES ('SECCOM', '9', 'SECCOM', '1', null);
INSERT INTO `departments` VALUES ('PLANTOPS', '10', 'PLANTOPS', '1', null);
INSERT INTO `departments` VALUES ('MANCOM', '11', 'MANCOM', '1', null);
INSERT INTO `departments` VALUES ('MANCOM2', '12', 'MANCOM2', '1', null);

-- ----------------------------
-- Table structure for `de_minimis_benefits`
-- ----------------------------
DROP TABLE IF EXISTS `de_minimis_benefits`;
CREATE TABLE `de_minimis_benefits` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dmb_code` varchar(50) DEFAULT NULL,
  `dmb_desc` varchar(50) DEFAULT NULL,
  `dmb_amount` varchar(50) DEFAULT NULL,
  `dmb_type` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of de_minimis_benefits
-- ----------------------------
INSERT INTO `de_minimis_benefits` VALUES ('1', 'FOODALL', 'Food Allowance', '1000', 'Monthly', '1');
INSERT INTO `de_minimis_benefits` VALUES ('2', 'TRANSPOALL', 'Transportation Allowance', '2000', 'HalfMonth', '1');
INSERT INTO `de_minimis_benefits` VALUES ('3', 'CLOTHINGALL', 'Clothing Allowance', '1500', 'Monthly', '1');

-- ----------------------------
-- Table structure for `dtrcompute`
-- ----------------------------
DROP TABLE IF EXISTS `dtrcompute`;
CREATE TABLE `dtrcompute` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` varchar(50) DEFAULT NULL,
  `dtrc_dailyrate` varchar(50) DEFAULT NULL,
  `dtrc_hourrate` varchar(50) DEFAULT NULL,
  `dtrc_nightdiffrate` varchar(50) DEFAULT NULL,
  `dtrc_date` varchar(50) DEFAULT NULL,
  `dtrc_timein` varchar(50) DEFAULT NULL,
  `dtrc_timeout` varchar(50) DEFAULT NULL,
  `overtime_hours` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `late_perc` varchar(50) DEFAULT NULL,
  `late_amt` varchar(50) DEFAULT NULL,
  `ut_perc` varchar(50) DEFAULT NULL,
  `ut_amt` varchar(50) DEFAULT NULL,
  `ot_rate` varchar(50) DEFAULT NULL,
  `ot_amt` varchar(50) DEFAULT NULL,
  `ot_sh_rate` varchar(50) DEFAULT NULL,
  `ot_sh_amt` varchar(50) DEFAULT NULL,
  `sh_rate` varchar(50) DEFAULT NULL,
  `sh_amount` varchar(50) DEFAULT NULL,
  `ot_lh_rate` varchar(50) DEFAULT NULL,
  `ot_lh_amt` varchar(50) DEFAULT NULL,
  `lh_rate` varchar(50) DEFAULT NULL,
  `lh_amt` varchar(50) DEFAULT NULL,
  `ot_sun_rate` varchar(50) DEFAULT NULL,
  `ot_sun_amt` varchar(50) DEFAULT NULL,
  `ot_excess_sun_rate` varchar(50) DEFAULT NULL,
  `ot_excess_sun_amt` varchar(50) DEFAULT NULL,
  `ot_lh_sun_rate` varchar(50) DEFAULT NULL,
  `ot_lh_sun_amt` varchar(50) DEFAULT NULL,
  `ot_lh_excess_sun_rate` varchar(50) DEFAULT NULL,
  `ot_lh_excess_sun_amt` varchar(50) DEFAULT NULL,
  `ot_nightdiff_rate` varchar(50) DEFAULT NULL,
  `ot_nightdiff_amt` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `payroll_code` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=226 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of dtrcompute
-- ----------------------------
INSERT INTO `dtrcompute` VALUES ('197', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-01', '08:30:00 AM', '05:00:00 PM', '2', 'Regular Day', '0.00', '0', '0', '0', '1.25', '287.36', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('198', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-02', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '1.3', '1195.4', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('199', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-03', '08:30:00 AM', '04:59:59 PM', '13', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '1.69', '2166.65', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('200', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-04', '08:30:00 AM', '08:40:00 AM', '0', 'Regular Day', '0.00', '0', '0.50', '57.47', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('201', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-05', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('202', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-06', '08:30:00 AM', '04:59:59 PM', '3', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '448.26', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('203', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-07', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('204', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-08', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('205', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-09', '08:00:00 AM', '04:59:59 PM', '0', 'Leave Without Pay', '0', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('206', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-10', '08:00:00 AM', '04:59:59 PM', '0', 'Leave', '0', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('207', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-11', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '1195.4', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('208', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-12', '08:00:00 AM', '05:30:00 PM', '14', 'Regular Day', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.69', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('209', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-13', '08:46:00 AM', '04:59:59 PM', '0', 'Leave', '0.50', '57.47', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '1195.4', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('210', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-14', 'hh:mm:ss tt', '07:00:00 AM', '5', 'Leave', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.1', '869.2', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('211', 'EMP-0004', '919.54', '114.94', '158.04', '2016-03-20', '08:30:00 AM', '05:30:00 PM', '11', 'Regular Day', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2.68', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('212', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-01', '08:30:00 AM', '05:00:00 PM', '2', 'Regular Day', '0.00', '0', '0', '0', '1.25', '359.2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('213', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-02', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '1.3', '1494.26', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('214', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-03', '08:30:00 AM', '04:59:59 PM', '10', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '1.69', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('215', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-04', '08:30:00 AM', '08:40:00 AM', '0', 'Regular Day', '0.00', '0', '0.50', '71.84', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('216', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-05', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('217', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-06', '08:30:00 AM', '04:59:59 PM', '1', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '186.78', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('218', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-07', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('219', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-08', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('220', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-09', '08:00:00 AM', '04:59:59 PM', '0', 'Leave Without Pay', '0', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('221', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-10', '08:00:00 AM', '04:59:59 PM', '0', 'Leave', '0', '0', '0', '0', '1.25', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('222', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-11', '08:30:00 AM', '04:59:59 PM', '0', 'Regular Day', '0.00', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '1494.26', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('223', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-12', '08:00:00 AM', '05:30:00 PM', '12', 'Regular Day', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.69', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('224', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-13', '08:46:00 AM', '04:59:59 PM', '0', 'Leave', '0.50', '71.84', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1.3', '1494.26', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');
INSERT INTO `dtrcompute` VALUES ('225', 'EMP-0001', '1149.43', '143.68', '197.56', '2016-03-14', 'hh:mm:ss tt', '07:00:00 AM', '2', 'Leave', '0', '0', '0', '0', '1.25', '359.2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', 'P2016030120160331');

-- ----------------------------
-- Table structure for `employee`
-- ----------------------------
DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `birthday` varchar(20) DEFAULT NULL,
  `mobile` varchar(50) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `nationality` varchar(50) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `job_title_id` int(11) DEFAULT NULL,
  `employment_status` varchar(50) DEFAULT NULL,
  `date_hired` varchar(50) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `job_status` varchar(50) DEFAULT NULL,
  `date_resigned` varchar(20) DEFAULT NULL,
  `basic_salary` varchar(50) DEFAULT NULL,
  `daily_rate` varchar(50) DEFAULT NULL,
  `hour_rate` varchar(50) DEFAULT NULL,
  `night_rate` varchar(50) DEFAULT NULL,
  `def_time_in` varchar(50) DEFAULT NULL,
  `def_time_out` varchar(50) DEFAULT NULL,
  `w_13monthpay` varchar(1) DEFAULT NULL,
  `tin_no` varchar(50) DEFAULT NULL,
  `sss_no` varchar(50) DEFAULT NULL,
  `pagibig_no` varchar(50) DEFAULT NULL,
  `philhealth_no` varchar(50) DEFAULT NULL,
  `tax_comp` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `def_shift_id` varchar(50) DEFAULT NULL,
  `emp_last_employer` varchar(50) DEFAULT NULL,
  `prev_employer_date_resigned` varchar(20) DEFAULT NULL,
  `acu_id` int(11) DEFAULT NULL,
  `shift_id` int(11) unsigned DEFAULT NULL,
  `w_sss` varchar(1) DEFAULT NULL,
  `w_hdmf` varchar(1) DEFAULT NULL,
  `w_philhealth` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee
-- ----------------------------
INSERT INTO `employee` VALUES ('1', 'EMP-0001', 'Molina', 'Elbert', 'Onaniana', '1992-06-02', '09288135993', '', 'elbert.molina@sparkglobaltech.com', 'Filipino', '8', '1', 'Regular', '2015-08-03', 'Blk 11 Lot 8 Del undo Village Caloocan City', 'Active', '', '25000', '1149.43', '143.68', '197.56', '08:30:00 AM', '05:30:00 PM', '1', '0283129384', '73712837', '8723712', '7321929', 'S', '1', '1', 'Pandayan Bookshop', '', '0', '0', '1', '1', '1');
INSERT INTO `employee` VALUES ('2', 'EMP-0004', 'Dela Cruz', 'Juan', 'Guevarra', '1999-06-21', '0999999999', '9362497', 'JuanGDelaCruz@gmail.com', 'Filipino', '5', '1', 'Probitionary', '2015-09-01', 'Caloocan', 'Active', '', '20000', '919.54', '114.94', '158.04', '08:30:00 AM', '05:30:00 PM', '0', '', '', '', '', 'S', '1', '1', 'PBS Inc.', '', '0', '0', '1', '1', '1');
INSERT INTO `employee` VALUES ('3', 'EMP-0002', 'Test', 'Test', 'Test', '1993-02-03', '09392193212', '9263942', 'test@test.ph', 'Filipino', '5', '6', 'Probitionary', '', 'Test', '', null, '20000', '919.54', '114.94', '158.04', '08:30:00 AM', '05:30:00 PM', '0', '', '', '', '', 'S', '1', null, 'PBS Inc.', null, null, '0', '0', '0', '0');
INSERT INTO `employee` VALUES ('4', 'EMP-0003', 'Test', 'Test', 'Test', '1993-02-03', '09392193212', '9263942', 'test@test.ph', 'Filipino', '5', '6', 'Probitionary', '', 'Test', '', null, '20000', '919.54', '114.94', '158.04', '08:30:00 AM', '05:30:00 PM', '0', '', '', '', '', 'S', '1', null, 'PBS Inc.', null, null, '0', '0', '0', '0');

-- ----------------------------
-- Table structure for `employee_company_deductions`
-- ----------------------------
DROP TABLE IF EXISTS `employee_company_deductions`;
CREATE TABLE `employee_company_deductions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` varchar(50) DEFAULT NULL,
  `comde_code` varchar(50) DEFAULT NULL,
  `emp_comde_amt` varchar(50) DEFAULT NULL,
  `emp_comde_start_date` varchar(20) DEFAULT NULL,
  `emp_comde_end_date` varchar(20) DEFAULT NULL,
  `emp_deduct_type` varchar(1) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `emp_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_company_deductions
-- ----------------------------
INSERT INTO `employee_company_deductions` VALUES ('0', null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `employee_de_minimis_benefits`
-- ----------------------------
DROP TABLE IF EXISTS `employee_de_minimis_benefits`;
CREATE TABLE `employee_de_minimis_benefits` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` varchar(50) DEFAULT NULL,
  `dmb_code` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `emp_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_de_minimis_benefits
-- ----------------------------
INSERT INTO `employee_de_minimis_benefits` VALUES ('25', 'EMP-0001', 'FOODALL', null, '1');
INSERT INTO `employee_de_minimis_benefits` VALUES ('26', 'EMP-0001', 'TRANSPOALL', null, '1');

-- ----------------------------
-- Table structure for `employee_leaves`
-- ----------------------------
DROP TABLE IF EXISTS `employee_leaves`;
CREATE TABLE `employee_leaves` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` int(11) DEFAULT NULL,
  `leave_id` int(11) DEFAULT NULL,
  `date_apply` varchar(20) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `leave_used` varchar(50) DEFAULT NULL,
  `emp_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_leaves
-- ----------------------------
INSERT INTO `employee_leaves` VALUES ('17', '0', '2', null, null, null, '1');

-- ----------------------------
-- Table structure for `employee_photo`
-- ----------------------------
DROP TABLE IF EXISTS `employee_photo`;
CREATE TABLE `employee_photo` (
  `id` int(11) NOT NULL,
  `emp_id` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `photo` blob,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_photo
-- ----------------------------

-- ----------------------------
-- Table structure for `employee_receivable_and_taxable_allowances`
-- ----------------------------
DROP TABLE IF EXISTS `employee_receivable_and_taxable_allowances`;
CREATE TABLE `employee_receivable_and_taxable_allowances` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` varchar(50) DEFAULT NULL,
  `rta_code` varchar(50) DEFAULT NULL,
  `is_deleted` int(11) DEFAULT NULL,
  `emp_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_receivable_and_taxable_allowances
-- ----------------------------
INSERT INTO `employee_receivable_and_taxable_allowances` VALUES ('34', 'EMP-0001', 'REC2', null, '1');
INSERT INTO `employee_receivable_and_taxable_allowances` VALUES ('35', 'EMP-0001', 'ALLOW', null, '1');
INSERT INTO `employee_receivable_and_taxable_allowances` VALUES ('36', 'EMP-0001', 'ALLOW4', null, '1');

-- ----------------------------
-- Table structure for `employee_shift`
-- ----------------------------
DROP TABLE IF EXISTS `employee_shift`;
CREATE TABLE `employee_shift` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_id` varchar(11) DEFAULT NULL,
  `shift_id` varchar(11) DEFAULT NULL,
  `date_from` varchar(20) DEFAULT NULL,
  `date_to` varchar(20) DEFAULT NULL,
  `date_applied` varchar(20) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_shift
-- ----------------------------
INSERT INTO `employee_shift` VALUES ('7', 'EMP-0004', '1', '2016-03-14', '2016-03-14', '2016-24-27', '0');
INSERT INTO `employee_shift` VALUES ('8', 'EMP-0004', '10', '2016-03-14', '2016-03-14', '2016-03-27', '1');

-- ----------------------------
-- Table structure for `employee_working_days`
-- ----------------------------
DROP TABLE IF EXISTS `employee_working_days`;
CREATE TABLE `employee_working_days` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` varchar(50) DEFAULT NULL,
  `monday` varchar(1) DEFAULT NULL,
  `tuesday` varchar(1) DEFAULT NULL,
  `wednesday` varchar(1) DEFAULT NULL,
  `thursday` varchar(1) DEFAULT NULL,
  `friday` varchar(1) DEFAULT NULL,
  `saturday` varchar(1) DEFAULT NULL,
  `sunday` varchar(1) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `date_stamp` varchar(20) DEFAULT NULL,
  `emp_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee_working_days
-- ----------------------------
INSERT INTO `employee_working_days` VALUES ('17', 'EMP-0001', '0', '0', '0', '0', '0', '0', '0', null, null, '1');
INSERT INTO `employee_working_days` VALUES ('18', 'EMP-0005', '0', '0', '0', '0', '0', '0', '0', null, null, '5');

-- ----------------------------
-- Table structure for `gd_hdmf`
-- ----------------------------
DROP TABLE IF EXISTS `gd_hdmf`;
CREATE TABLE `gd_hdmf` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hdmf_code` varchar(50) DEFAULT NULL,
  `hdmf_from_comp` varchar(50) DEFAULT NULL,
  `hdmf_to_comp` varchar(50) DEFAULT NULL,
  `hdmf_cont_option` varchar(1) DEFAULT NULL,
  `hdmf_ee` varchar(50) DEFAULT NULL,
  `hdmf_er` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of gd_hdmf
-- ----------------------------
INSERT INTO `gd_hdmf` VALUES ('1', 'HDMF1', '0', '1499.99', '0', '1', '1', '1');
INSERT INTO `gd_hdmf` VALUES ('2', 'HDMF2', '1500.00', '4999.99', '0', '2', '2', '1');
INSERT INTO `gd_hdmf` VALUES ('3', 'HDMF3', '5000.00', '999999.99', '1', '100', '100', '1');

-- ----------------------------
-- Table structure for `gd_philhealth`
-- ----------------------------
DROP TABLE IF EXISTS `gd_philhealth`;
CREATE TABLE `gd_philhealth` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ph_code` varchar(50) DEFAULT NULL,
  `ph_from_comp` varchar(50) DEFAULT NULL,
  `ph_to_comp` varchar(50) DEFAULT NULL,
  `ph_ee` varchar(50) DEFAULT NULL,
  `ph_er` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of gd_philhealth
-- ----------------------------
INSERT INTO `gd_philhealth` VALUES ('1', 'PH1', '10000', '10999.99', '250', '250', '1');
INSERT INTO `gd_philhealth` VALUES ('3', 'PH3', '22000', '22999.99', '275', '275', '1');
INSERT INTO `gd_philhealth` VALUES ('4', 'PH4', '20000', '20999.99', '250', '250', '1');
INSERT INTO `gd_philhealth` VALUES ('5', 'PH5', '0', '8999.99', '100', '100', '1');
INSERT INTO `gd_philhealth` VALUES ('6', 'ph6', '9000', '9999.99', '112.50', '112.50', '1');
INSERT INTO `gd_philhealth` VALUES ('7', 'ph7', '11000', '11999.99', '137.50', '137.50', '1');
INSERT INTO `gd_philhealth` VALUES ('8', 'ph8', '12000', '12999.99', '150', '150', '1');
INSERT INTO `gd_philhealth` VALUES ('9', 'ph9', '13000', '13999.99', '162.50', '162.50', '1');
INSERT INTO `gd_philhealth` VALUES ('10', 'ph10', '14000', '14999.99', '175', '175', '1');
INSERT INTO `gd_philhealth` VALUES ('11', 'ph11', '15000', '15999.99', '187', '187', '1');
INSERT INTO `gd_philhealth` VALUES ('12', 'ph12', '16000', '16999.99', '200', '200', '1');
INSERT INTO `gd_philhealth` VALUES ('13', 'ph13', '17000', '17999.99', '212.50', '212.50', '1');
INSERT INTO `gd_philhealth` VALUES ('14', 'ph14', '18000', '18999.99', '225', '225', '1');
INSERT INTO `gd_philhealth` VALUES ('15', 'ph15', '19000', '19999.99', '237.50', '237.50', '1');
INSERT INTO `gd_philhealth` VALUES ('16', 'ph16', '21000', '21999.99', '262.50', '262.50', '1');
INSERT INTO `gd_philhealth` VALUES ('17', 'ph17', '23000', '23999.99', '287.50', '287.50', '1');
INSERT INTO `gd_philhealth` VALUES ('18', 'ph18', '24000', '24999.99', '300', '300', '1');
INSERT INTO `gd_philhealth` VALUES ('19', 'ph19', '25000', '25999.99', '312.50', '312.50', '1');
INSERT INTO `gd_philhealth` VALUES ('20', 'ph20', '26000', '26999.99', '325', '325', '1');
INSERT INTO `gd_philhealth` VALUES ('21', 'ph21', '27000', '27999.99', '337.50', '337.50', '1');
INSERT INTO `gd_philhealth` VALUES ('22', 'ph22', '28000', '28999.99', '350', '350', '1');
INSERT INTO `gd_philhealth` VALUES ('23', 'ph23', '29000', '29999.99', '362.50', '362.50', '1');
INSERT INTO `gd_philhealth` VALUES ('24', 'ph24', '30000', '30999.99', '375', '375', '1');
INSERT INTO `gd_philhealth` VALUES ('25', 'ph25', '31000', '31999.99', '387.50', '387.50', '1');
INSERT INTO `gd_philhealth` VALUES ('26', 'ph26', '32000', '32999.99', '400', '400', '1');
INSERT INTO `gd_philhealth` VALUES ('27', 'ph27', '33000', '33999.99', '412.50', '412.50', '1');
INSERT INTO `gd_philhealth` VALUES ('28', 'ph28', '34000', '34999.99', '425', '425', '1');
INSERT INTO `gd_philhealth` VALUES ('29', 'ph29', '35000', '99999.99', '437.50', '437.50', '1');

-- ----------------------------
-- Table structure for `gd_sss`
-- ----------------------------
DROP TABLE IF EXISTS `gd_sss`;
CREATE TABLE `gd_sss` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sss_code` varchar(50) DEFAULT NULL,
  `sss_from_comp` varchar(50) DEFAULT NULL,
  `sss_to_comp` varchar(50) DEFAULT NULL,
  `sss_ee` varchar(50) DEFAULT NULL,
  `sss_er` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `sss_ec` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of gd_sss
-- ----------------------------
INSERT INTO `gd_sss` VALUES ('1', 'SSS1', '10250.00', '10749.99', '381.50', '773.50', '1', '10');
INSERT INTO `gd_sss` VALUES ('2', 'SSS2', '10750.00', '11249.99', '399.70', '810.30', '1', '10');
INSERT INTO `gd_sss` VALUES ('3', 'SSS3', '11250', '11749.99', '417.80', '847.20', '1', '10');
INSERT INTO `gd_sss` VALUES ('4', 'SSS4', '11750.00', '12249.99', '436', '884', '1', '10');
INSERT INTO `gd_sss` VALUES ('5', 'SSS5', '12250', '12749.99', '454.20', '920.80', '1', '10');
INSERT INTO `gd_sss` VALUES ('6', 'SSS6', '12750', '13249.99', '472.30', '957.70', '1', '10');
INSERT INTO `gd_sss` VALUES ('7', 'SSS7', '13250', '13749.99', '490.50', '994.50', '1', '10');
INSERT INTO `gd_sss` VALUES ('8', 'SSS8', '13750', '14249.99', '508.70', '1031.30', '1', '10');
INSERT INTO `gd_sss` VALUES ('9', 'SSS9', '14250.00', '14749.99', '526.80', '1068.20', '1', '10');
INSERT INTO `gd_sss` VALUES ('10', 'SSS10', '14750', '15249.99', '545', '1105', '1', '10');
INSERT INTO `gd_sss` VALUES ('13', 'SSS11', '15250', '15749.99', '563.20', '1141.80', '1', '10');
INSERT INTO `gd_sss` VALUES ('14', 'SS12', '15750', '999999', '581.30', '1178.70', '1', '10');

-- ----------------------------
-- Table structure for `holidays`
-- ----------------------------
DROP TABLE IF EXISTS `holidays`;
CREATE TABLE `holidays` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `holiday_name` varchar(50) DEFAULT NULL,
  `holiday_date` varchar(50) DEFAULT NULL,
  `holiday_day` varchar(50) DEFAULT NULL,
  `holiday_category` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `holiday_percentage` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of holidays
-- ----------------------------
INSERT INTO `holidays` VALUES ('5', 'Christmas Day', '2016-12-25', 'Sunday', 'Legal Holiday', '1', '0');
INSERT INTO `holidays` VALUES ('6', 'Sample Holiday', '2016-03-12', 'Monday', 'Legal Holiday', '1', '0');
INSERT INTO `holidays` VALUES ('7', 'Sample Holiday 1', '2016-03-03', 'Thursday', 'Special Holiday', '1', '0');
INSERT INTO `holidays` VALUES ('8', 'Sample Holiday 2', '2016-03-02', 'Wednesday', 'Special Holiday', '1', '0');
INSERT INTO `holidays` VALUES ('9', 'Sample  holiday 3', '2016-03-11', 'Friday', 'Legal Holiday', '1', '0');
INSERT INTO `holidays` VALUES ('10', 'Sample Holiday 4', '2016-03-20', 'Sunday', 'Legal Holiday', '1', '0');

-- ----------------------------
-- Table structure for `job_titles`
-- ----------------------------
DROP TABLE IF EXISTS `job_titles`;
CREATE TABLE `job_titles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `dept_id` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of job_titles
-- ----------------------------
INSERT INTO `job_titles` VALUES ('1', 'Software Engineer', 'Software Engineer', '1', '8');
INSERT INTO `job_titles` VALUES ('2', 'Software Engineer two', 'Software Engineer 2', '1', '8');
INSERT INTO `job_titles` VALUES ('3', 'Software Engineer 3', 'Software Engineer 3', '1', '8');
INSERT INTO `job_titles` VALUES ('4', 'Manager', 'Manager', '1', '6');
INSERT INTO `job_titles` VALUES ('5', 'sdfds', 'sdfsdfs', '0', '6');
INSERT INTO `job_titles` VALUES ('6', 'Manager two', 'Manager 2', '1', '5');
INSERT INTO `job_titles` VALUES ('7', 'sdfds', 'sdfsdfs', '1', '5');
INSERT INTO `job_titles` VALUES ('8', 'asd', 'asd', '1', null);

-- ----------------------------
-- Table structure for `late_undertime`
-- ----------------------------
DROP TABLE IF EXISTS `late_undertime`;
CREATE TABLE `late_undertime` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `lu_from` varchar(50) DEFAULT NULL,
  `lu_to` varchar(50) DEFAULT NULL,
  `lu_percentage` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `shift_id` varchar(50) DEFAULT NULL,
  `lu_type` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=98 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of late_undertime
-- ----------------------------
INSERT INTO `late_undertime` VALUES ('4', '08:30:00 AM', '08:45:00 AM', '0.00', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('5', '08:46:00 AM', '09:00:00 AM', '0.50', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('6', '09:01:00 AM', '09:15:00 AM', '0.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('7', '09:16:00 AM', '09:30:00 AM', '1.00', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('8', '09:31:00 AM', '09:45:00 AM', '1.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('9', '02:00:00 PM', '02:15:00 PM', '0.01', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('10', '02:16:00 PM', '02:30:00 PM', '0.50', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('11', '02:31:00 PM', '02:45:00 PM', '0.75', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('12', '02:46:00 PM', '03:00:00 PM', '1.00', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('13', '03:01:00 PM', '03:15:00 PM', '1.25', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('14', '03:16:00 PM', '03:30:00 PM', '1.50', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('15', '07:00:00 PM', '07:15:00 PM', '0.00', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('16', '07:16:00 PM', '07:30:00 PM', '0.50', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('17', '07:31:00 PM', '07:45:00 PM', '0.75', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('18', '07:46:00 PM', '08:00:00 PM', '1.00', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('19', '08:01:00 PM', '08:15:00 PM', '1.25', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('20', '08:16:00 PM', '08:30:00 PM', '1.50', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('21', '08:30:00 AM', '08:40:00 AM', '0.00', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('22', '08:41:00 AM', '09:00:00 AM', '0.50', '0', '1', 'L');
INSERT INTO `late_undertime` VALUES ('23', '09:01:00 AM', '09:15:00 AM', '0.75', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('24', '09:16:00 AM', '09:30:00 AM', '1.00', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('25', '09:31:00 AM', '09:45:00 AM', '1.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('26', '09:46:00 AM', '10:00:00 AM', '1.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('27', '10:00:00 PM', '10:15:00 PM', '0.00', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('28', '10:16:00 PM', '10:30:00 PM', '0.50', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('29', '10:31:00 PM', '10:45:00 PM', '0.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('30', '10:46:00 PM', '11:00:00 PM', '1.00', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('31', '11:01:00 PM', '11:15:00 PM', '1.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('32', '11:16:00 PM', '11:30:00 PM', '1.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('33', '02:00:00 PM', '02:15:00 PM', '0.00', '1', '9', 'L');
INSERT INTO `late_undertime` VALUES ('34', '04:31:00 PM', '05:00:00 PM', '0.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('35', '04:16:00 PM', '04:31:00 PM', '0.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('36', '04:31:00 PM', '05:00:00 PM', '0.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('37', '04:01:00 PM', '04:15:00 PM', '1', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('38', '03:46:00 PM', '04:00:00 PM', '1.25', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('39', '03:31:00 PM', '03:45:00 PM', '1.50', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('40', '03:16:00 PM', '03:30:00 PM', '1.75', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('41', '03:01:00 PM', '03:15:00 PM', '2', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('42', '03:46:00 PM', '04:00:00 PM', '1.25', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('43', '02:46:00 PM', '03:00:00 PM', '2.25', '1', '10', 'L');
INSERT INTO `late_undertime` VALUES ('44', '02:31:00 PM', '02:45:00 PM', '2.5', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('45', '02:16:00 PM', '02:30:00 PM', '2.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('46', '02:01:00 PM', '02:15:00 PM', '3', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('47', '01:46:00 PM', '02:00:00 PM', '3.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('48', '01:31:00 PM', '01:45:00 PM', '3.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('49', '01:16:00 PM', '01:30:00 PM', '3.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('50', '01:01:00 PM', '01:15:00 PM', '4', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('51', '12:46:00 PM', '01:00:00 PM', '4.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('52', '12:31:00 PM', '12:45:00 PM', '4.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('53', '12:16:00 PM', '12:30:00 PM', '4.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('54', '12:01:00 PM', '12:15:00 PM', '5.0', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('55', '11:46:00 AM', '12:00:00 PM', '5.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('56', '11:31:00 AM', '11:45:00 AM', '5.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('57', '11:16:00 AM', '11:30:00 AM', '5.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('58', '11:01:00 AM', '11:15:00 AM', '6', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('59', '10:46:00 AM', '11:00:00 AM', '6.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('60', '10:31:00 AM', '10:45:00 AM', '6.5', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('61', '10:16:00 AM', '10:30:00 AM', '6.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('62', '10:01:00 AM', '10:15:00 AM', '7', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('63', '09:46:00 AM', '10:00:00 AM', '7.25', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('64', '09:31:00 AM', '09:45:00 AM', '7.50', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('65', '09:16:00 AM', '09:30:00 AM', '7.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('66', '09:01:00 AM', '09:15:00 AM', '8', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('67', '10:01:00 AM', '10:15:00 AM', '1.75', '1', '1', 'U');
INSERT INTO `late_undertime` VALUES ('68', '10:16:00 AM', '10:30:00 AM', '2', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('69', '10:31:00 AM', '10:45:00 AM', '2.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('70', '10:46:00 AM', '11:00:00 AM', '2.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('71', '11:01:00 AM', '11:15:00 AM', '2.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('72', '11:16:00 AM', '11:30:00 AM', '3', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('73', '11:31:00 AM', '11:45:00 AM', '3.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('74', '11:46:00 AM', '12:00:00 PM', '3.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('75', '12:01:00 PM', '12:15:00 PM', '3.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('76', '12:16:00 PM', '12:30:00 PM', '4', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('77', '12:31:00 PM', '12:45:00 PM', '4.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('78', '12:46:00 PM', '01:00:00 PM', '4.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('79', '01:01:00 PM', '01:15:00 PM', '4.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('80', '01:16:00 PM', '01:30:00 PM', '5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('81', '01:31:00 PM', '01:45:00 PM', '5.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('82', '01:46:00 PM', '02:00:00 PM', '5.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('83', '02:01:00 PM', '02:15:00 PM', '5.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('84', '02:16:00 PM', '02:30:00 PM', '6', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('85', '02:31:00 PM', '02:45:00 PM', '6.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('86', '02:46:00 PM', '03:00:00 PM', '6.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('87', '03:01:00 PM', '03:15:00 PM', '6.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('88', '03:16:00 PM', '03:30:00 PM', '7', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('89', '03:31:00 PM', '03:45:00 PM', '7.25', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('90', '03:46:00 PM', '04:00:00 PM', '7.5', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('91', '04:01:00 PM', '04:15:00 PM', '7.75', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('93', '04:16:00 PM', '04:30:00 PM', '8', '1', '1', 'L');
INSERT INTO `late_undertime` VALUES ('97', '08:30:00 AM', '08:40:00 AM', '0.50', '1', '1', 'U');

-- ----------------------------
-- Table structure for `leaves`
-- ----------------------------
DROP TABLE IF EXISTS `leaves`;
CREATE TABLE `leaves` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `leave_desc` varchar(50) DEFAULT NULL,
  `leave_no_of_days` varchar(50) DEFAULT NULL,
  `leave_convertable` varchar(1) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  `w_pay` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of leaves
-- ----------------------------
INSERT INTO `leaves` VALUES ('1', 'VACATION LEAVE', '10', '0', '1', '1');
INSERT INTO `leaves` VALUES ('2', 'SICK LEAVE', '15', '0', '1', '1');
INSERT INTO `leaves` VALUES ('3', 'MATERNITY LEAVE', '92', '0', '1', '1');

-- ----------------------------
-- Table structure for `menu`
-- ----------------------------
DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu` (
  `id` int(11) NOT NULL,
  `menu_code` varchar(50) DEFAULT NULL,
  `menu_name` varchar(50) DEFAULT NULL,
  `menu_flag` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of menu
-- ----------------------------

-- ----------------------------
-- Table structure for `overtime`
-- ----------------------------
DROP TABLE IF EXISTS `overtime`;
CREATE TABLE `overtime` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `overtime_rate` varchar(50) DEFAULT NULL,
  `overtime_regular_sh` varchar(50) DEFAULT NULL,
  `overtime_excess_sh` varchar(50) DEFAULT NULL,
  `overtime_sh_and_ot` varchar(50) DEFAULT NULL,
  `overtime_regular_lh` varchar(50) DEFAULT NULL,
  `overtime_excess_lh` varchar(50) DEFAULT NULL,
  `overtime_lh_and_ot` varchar(50) DEFAULT NULL,
  `overtime_regular_sun` varchar(50) DEFAULT NULL,
  `overtime_excess_sun` varchar(50) DEFAULT NULL,
  `overtime_regular_lh_sun` varchar(50) DEFAULT NULL,
  `overtime_excess_lh_sun` varchar(50) DEFAULT NULL,
  `overtime_nightdiff` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of overtime
-- ----------------------------
INSERT INTO `overtime` VALUES ('1', '1.25', '1.30', '1.69', '1.95', '1.30', '2.60', '3.38', '1.30', '1.69', '1.60', '2.68', '1.10');

-- ----------------------------
-- Table structure for `payroll`
-- ----------------------------
DROP TABLE IF EXISTS `payroll`;
CREATE TABLE `payroll` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payroll_code` varchar(50) DEFAULT NULL,
  `date_gen` varchar(50) DEFAULT NULL,
  `date_from` varchar(50) DEFAULT NULL,
  `date_to` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll
-- ----------------------------
INSERT INTO `payroll` VALUES ('5', 'P2016030120160331', '2016-04-01', '2016-03-01', '2016-03-31', '0');

-- ----------------------------
-- Table structure for `payroll_adjustments`
-- ----------------------------
DROP TABLE IF EXISTS `payroll_adjustments`;
CREATE TABLE `payroll_adjustments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_created` varchar(50) DEFAULT NULL,
  `date_occur` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `remarks` varchar(200) DEFAULT NULL,
  `paid` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(50) DEFAULT NULL,
  `payroll_code` varchar(50) DEFAULT NULL,
  `emp_code` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll_adjustments
-- ----------------------------
INSERT INTO `payroll_adjustments` VALUES ('1', '2016-03-30', '2016-03-03', '1000', '', '1', '1', 'P2016030120160331', 'EMP-0001');
INSERT INTO `payroll_adjustments` VALUES ('3', '2016-03-30', '2016-03-06', '1500', '', '1', '1', 'P2016030120160331', 'EMP-0004');

-- ----------------------------
-- Table structure for `payroll_comde`
-- ----------------------------
DROP TABLE IF EXISTS `payroll_comde`;
CREATE TABLE `payroll_comde` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payroll_code` varchar(50) DEFAULT NULL,
  `emp_code` varchar(50) DEFAULT NULL,
  `comde_code` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll_comde
-- ----------------------------

-- ----------------------------
-- Table structure for `payroll_details`
-- ----------------------------
DROP TABLE IF EXISTS `payroll_details`;
CREATE TABLE `payroll_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payroll_code` varchar(50) DEFAULT NULL,
  `emp_code` varchar(50) DEFAULT NULL,
  `emp_tax_comp` varchar(50) DEFAULT NULL,
  `emp_basicpay` varchar(50) DEFAULT NULL,
  `emp_late` varchar(50) DEFAULT NULL,
  `emp_absent` varchar(50) DEFAULT NULL,
  `emp_ut` varchar(50) DEFAULT NULL,
  `emp_ot` varchar(50) DEFAULT NULL,
  `emp_taxallowance` varchar(50) DEFAULT NULL,
  `emp_receivable` varchar(50) DEFAULT NULL,
  `emp_deminimis` varchar(50) DEFAULT NULL,
  `emp_totaltaxearning` varchar(50) DEFAULT NULL,
  `emp_bonus` varchar(50) DEFAULT NULL,
  `emp_wtax` varchar(50) DEFAULT NULL,
  `emp_govdeduc` varchar(50) DEFAULT NULL,
  `emp_comdeduc` varchar(50) DEFAULT NULL,
  `emp_totaldeduction` varchar(50) DEFAULT NULL,
  `emp_netpay` varchar(50) DEFAULT NULL,
  `emp_payrolladjustment` varchar(50) DEFAULT NULL,
  `emp_payroll_year` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll_details
-- ----------------------------
INSERT INTO `payroll_details` VALUES ('9', 'P2016030120160331', 'EMP-0004', 'S', '20000', '57.47', '0', '57.47', '7070.31', '0', '0', '0', '27524.07', '', '6682.59', '931.3', '0', '7613.89', '21410.18', '1500', '2016', '1');
INSERT INTO `payroll_details` VALUES ('10', 'P2016030120160331', 'EMP-0001', 'S', '25000', '71.84', '0', '71.84', '5028.76', '500', '1000', '2000', '29391.28', '', '7280.1', '993.8', '0', '8273.9', '18617.38', '1000', '2016', '1');

-- ----------------------------
-- Table structure for `payroll_govde`
-- ----------------------------
DROP TABLE IF EXISTS `payroll_govde`;
CREATE TABLE `payroll_govde` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payroll_code` varchar(50) DEFAULT NULL,
  `emp_code` varchar(50) DEFAULT NULL,
  `govde_code` varchar(50) DEFAULT NULL,
  `govde_eeshare` varchar(50) DEFAULT NULL,
  `govde_ershare` varchar(50) DEFAULT NULL,
  `gov_desc` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll_govde
-- ----------------------------
INSERT INTO `payroll_govde` VALUES ('37', 'P2016030120160331', 'EMP-0004', 'SS12', '581.30', '1188.7', 'SSS');
INSERT INTO `payroll_govde` VALUES ('38', 'P2016030120160331', 'EMP-0004', 'PH4', '250', '250', 'PhilHealth');
INSERT INTO `payroll_govde` VALUES ('39', 'P2016030120160331', 'EMP-0004', 'HDMF3', '100', '100', 'HDMF');
INSERT INTO `payroll_govde` VALUES ('40', 'P2016030120160331', 'EMP-0001', 'SS12', '581.30', '1188.7', 'SSS');
INSERT INTO `payroll_govde` VALUES ('41', 'P2016030120160331', 'EMP-0001', 'ph19', '312.50', '312.50', 'PhilHealth');
INSERT INTO `payroll_govde` VALUES ('42', 'P2016030120160331', 'EMP-0001', 'HDMF3', '100', '100', 'HDMF');

-- ----------------------------
-- Table structure for `payroll_settings`
-- ----------------------------
DROP TABLE IF EXISTS `payroll_settings`;
CREATE TABLE `payroll_settings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `salary_setting` varchar(50) DEFAULT NULL,
  `overtime_rate` varchar(50) DEFAULT NULL,
  `night_diff_rate` varchar(50) DEFAULT NULL,
  `special_holiday_rate` varchar(50) DEFAULT NULL,
  `legal_holiday_rate` varchar(50) DEFAULT NULL,
  `gov_deduction_settings` varchar(50) DEFAULT NULL,
  `tax_deduction_settings` varchar(50) DEFAULT NULL,
  `13month_release_date` varchar(20) DEFAULT NULL,
  `comp_deduction_settings` varchar(50) DEFAULT NULL,
  `minimum_wage` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payroll_settings
-- ----------------------------
INSERT INTO `payroll_settings` VALUES ('1', '1', '3', '5', '6', '8', 'Monthly', 'HalfMonth', '2016-12-19', '7', '9');

-- ----------------------------
-- Table structure for `receivable_and_taxable_allowances`
-- ----------------------------
DROP TABLE IF EXISTS `receivable_and_taxable_allowances`;
CREATE TABLE `receivable_and_taxable_allowances` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rta_code` varchar(50) DEFAULT NULL,
  `rta_desc` varchar(50) DEFAULT NULL,
  `rta_amount` varchar(50) DEFAULT NULL,
  `rta_taxable` varchar(1) DEFAULT NULL,
  `rta_type` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of receivable_and_taxable_allowances
-- ----------------------------
INSERT INTO `receivable_and_taxable_allowances` VALUES ('1', 'REC', 'RECEIVABLE', '500', '0', 'Monthly', '1');
INSERT INTO `receivable_and_taxable_allowances` VALUES ('2', 'REC2', 'RECEIVABLES', '2000', '0', 'HalfMonth', '1');
INSERT INTO `receivable_and_taxable_allowances` VALUES ('3', 'ALLOW', 'ALLOWANCES', '200', '1', 'Monthly', '1');
INSERT INTO `receivable_and_taxable_allowances` VALUES ('4', 'ALLOW4', 'ALLOWANCES(Food)', '300', '1', 'Monthly', '1');

-- ----------------------------
-- Table structure for `shifts`
-- ----------------------------
DROP TABLE IF EXISTS `shifts`;
CREATE TABLE `shifts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `shift_name` varchar(50) DEFAULT NULL,
  `time_in` varchar(50) DEFAULT NULL,
  `time_out` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of shifts
-- ----------------------------
INSERT INTO `shifts` VALUES ('1', 'Day Shift', '08:30:00 AM', '5:30:00 PM', '1');
INSERT INTO `shifts` VALUES ('9', 'Mid Shift ', '02:00:00 PM', '11:00:00 PM', '1');
INSERT INTO `shifts` VALUES ('10', 'Night Shift', '10:00:00 PM', '07:00:00 AM', '1');
INSERT INTO `shifts` VALUES ('11', 'Eom shift', '10:00', '20:00', '1');

-- ----------------------------
-- Table structure for `system_settings`
-- ----------------------------
DROP TABLE IF EXISTS `system_settings`;
CREATE TABLE `system_settings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `company_name` varchar(50) DEFAULT NULL,
  `company_logo` blob,
  `company_address` varchar(100) DEFAULT NULL,
  `company_telephone` varchar(100) DEFAULT NULL,
  `default_shift` varchar(1) DEFAULT NULL,
  `grace_period` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of system_settings
-- ----------------------------
INSERT INTO `system_settings` VALUES ('1', 'Spark Global Tech', null, '2204A East Tower Phil Stock Exchange Center, Exchange Road, Ortigas Center, Pasig City', '09212316863', 'D', '15');

-- ----------------------------
-- Table structure for `taxes`
-- ----------------------------
DROP TABLE IF EXISTS `taxes`;
CREATE TABLE `taxes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tax_code` varchar(50) DEFAULT NULL,
  `tax_status` varchar(50) DEFAULT NULL,
  `tax_operand` varchar(50) DEFAULT NULL,
  `tax_amount_comp` varchar(50) DEFAULT NULL,
  `tax_ceiling` varchar(50) DEFAULT NULL,
  `tax_additional` varchar(50) DEFAULT NULL,
  `tax_rate` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of taxes
-- ----------------------------
INSERT INTO `taxes` VALUES ('1', 'TAX1', 'S', '<', '2083', '0', '0', '0', '1');
INSERT INTO `taxes` VALUES ('2', 'TAX2', 'S', '<', '2500', '2083', '0', '0.05', '1');
INSERT INTO `taxes` VALUES ('3', 'TAX3', 'S', '<', '3333', '2500', '20.83', '0.10', '1');
INSERT INTO `taxes` VALUES ('4', 'TAX4', 'S', '<', '5000', '3333', '104.17', '0.15', '1');
INSERT INTO `taxes` VALUES ('5', 'TAX5', 'S', '<', '7917', '5000', '354.17', '0.20', '1');
INSERT INTO `taxes` VALUES ('6', 'TAX6', 'S', '<', '12500', '7917', '937.5', '0.25', '1');
INSERT INTO `taxes` VALUES ('7', 'TAX7', 'S', '<', '22917', '12500', '2083.33', '0.30', '1');
INSERT INTO `taxes` VALUES ('8', 'TAX8', 'S', '<', '999999', '22917', '5208.33', '0.32', '1');
INSERT INTO `taxes` VALUES ('9', 'TAX9', 'ME1', '<', '3125', '0', '0', '0', '1');
INSERT INTO `taxes` VALUES ('10', 'TAX10', 'ME1', '<', '3542', '3125', '0', '0.05', '1');
INSERT INTO `taxes` VALUES ('11', 'TAX11', 'ME1', '<', '4375', '3542', '20.83', '0.10', '1');
INSERT INTO `taxes` VALUES ('12', 'TAX12', 'ME1', '<', '6042', '4375', '104.17', '0.15', '1');
INSERT INTO `taxes` VALUES ('13', 'TAX13', 'ME1', '<', '8958', '6042', '354.17', '0.20', '1');
INSERT INTO `taxes` VALUES ('14', 'TAX14', 'ME1', '<', '13542', '8958', '937.5', '0.25', '1');
INSERT INTO `taxes` VALUES ('15', 'TAX15', 'ME1', '<', '23958', '13542', '2083.33', '0.30', '1');
INSERT INTO `taxes` VALUES ('16', 'TAX16', 'ME1', '<', '999999', '23958', '5208.33', '0.32', '1');
INSERT INTO `taxes` VALUES ('17', 'TAX17', 'ME2', '<', '4167', '0', '0', '0', '1');
INSERT INTO `taxes` VALUES ('18', 'TAX18', 'ME2', '<', '4583', '4167', '0', '0.05', '1');
INSERT INTO `taxes` VALUES ('19', 'TAX19', 'ME2', '<', '5417', '4583', '20.83', '0.10', '1');
INSERT INTO `taxes` VALUES ('20', 'TAX20', 'ME2', '<', '7083', '5417', '104.17', '0.15', '1');
INSERT INTO `taxes` VALUES ('21', 'TAX21', 'ME2', '<', '10000', '7083', '354.17', '0.20', '1');
INSERT INTO `taxes` VALUES ('22', 'TAX22', 'ME2', '<', '14583', '10000', '937.5', '0.25', '1');
INSERT INTO `taxes` VALUES ('23', 'TAX23', 'ME2', '<', '25000', '14583', '2083.33', '0.30', '1');
INSERT INTO `taxes` VALUES ('24', 'TAX24', 'ME2', '<', '999999', '25000', '5208.33', '0.32', '1');
INSERT INTO `taxes` VALUES ('26', 'TAX25', 'ME3', '<', '5208', '0', '0', '0', '1');
INSERT INTO `taxes` VALUES ('27', 'TAX26', 'ME3', '<', '5625', '5208', '0', '0.05', '1');
INSERT INTO `taxes` VALUES ('28', 'TAX27', 'ME3', '<', '6458', '5625', '20.83', '0.10', '1');
INSERT INTO `taxes` VALUES ('29', 'TAX28', 'ME3', '<', '8125', '6458', '104.17', '0.15', '1');
INSERT INTO `taxes` VALUES ('30', 'TAX29', 'ME3', '<', '11042', '8125', '354.17', '0.20', '1');
INSERT INTO `taxes` VALUES ('31', 'TAX30', 'ME3', '<', '15625', '11042', '937.5', '0.25', '1');
INSERT INTO `taxes` VALUES ('32', 'TAX31', 'ME3', '<', '26042', '15625', '2083.33', '0.30', '1');
INSERT INTO `taxes` VALUES ('33', 'TAX32', 'ME3', '<', '999999', '26042', '5208.33', '0.32', '1');
INSERT INTO `taxes` VALUES ('34', 'TAX33', 'ME4', '<', '6250', '0', '0', '0', '1');
INSERT INTO `taxes` VALUES ('35', 'TAX34', 'ME4', '<', '6667', '6250', '0', '0.05', '1');
INSERT INTO `taxes` VALUES ('36', 'TAX35', 'ME4', '<', '7500', '6667', '20.83', '0.10', '1');
INSERT INTO `taxes` VALUES ('37', 'TAX36', 'ME4', '<', '9167', '7500', '104.17', '0.15', '1');
INSERT INTO `taxes` VALUES ('38', 'TAX37', 'ME4', '<', '12083', '9167', '354.17', '0.20', '1');
INSERT INTO `taxes` VALUES ('39', 'TAX38', 'ME4', '<', '16667', '12083', '937.5', '0.25', '1');
INSERT INTO `taxes` VALUES ('40', 'TAX39', 'ME4', '<', '27083', '16667', '2083.33', '0.30', '1');
INSERT INTO `taxes` VALUES ('41', 'TAX40', 'ME4', '<', '999999', '27083', '5208.33', '0.32', '1');

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `user_type` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1', 'admin', '596ead4d35b36afe6e2c35f053c9f80a                  ', 'admin', '1');

-- ----------------------------
-- Table structure for `user_access`
-- ----------------------------
DROP TABLE IF EXISTS `user_access`;
CREATE TABLE `user_access` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `user_type` int(11) DEFAULT NULL,
  `access_no` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user_access
-- ----------------------------

-- ----------------------------
-- Table structure for `user_types`
-- ----------------------------
DROP TABLE IF EXISTS `user_types`;
CREATE TABLE `user_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_type_name` varchar(50) DEFAULT NULL,
  `is_deleted` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user_types
-- ----------------------------

-- ----------------------------
-- View structure for `comde`
-- ----------------------------
DROP VIEW IF EXISTS `comde`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `comde` AS select `employee`.`code` AS `code`,`employee_company_deductions`.`emp_comde_amt` AS `emp_comde_amt`,`employee_company_deductions`.`emp_comde_start_date` AS `emp_comde_start_date`,`employee_company_deductions`.`emp_comde_end_date` AS `emp_comde_end_date`,`employee_company_deductions`.`emp_deduct_type` AS `emp_deduct_type`,`employee_company_deductions`.`is_deleted` AS `is_deleted`,`company_deductions`.`comde_code` AS `comde_code` from ((`employee` join `employee_company_deductions` on((`employee_company_deductions`.`emp_code` = `employee`.`code`))) join `company_deductions` on((`employee_company_deductions`.`comde_code` = `company_deductions`.`comde_code`)));

-- ----------------------------
-- View structure for `v_payroll`
-- ----------------------------
DROP VIEW IF EXISTS `v_payroll`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_payroll` AS select `dtrcompute`.`id` AS `id`,`dtrcompute`.`emp_code` AS `emp_code`,concat(`employee`.`first_name`,' ',`employee`.`middle_name`,' ',`employee`.`last_name`) AS `Name`,`dtrcompute`.`dtrc_dailyrate` AS `dtrc_dailyrate`,`dtrcompute`.`dtrc_hourrate` AS `dtrc_hourrate`,`dtrcompute`.`dtrc_nightdiffrate` AS `dtrc_nightdiffrate`,`employee`.`basic_salary` AS `basic_salary`,sum(`dtrcompute`.`late_amt`) AS `Late`,sum(`dtrcompute`.`ut_amt`) AS `Undertime`,sum(`dtrcompute`.`ot_amt`) AS `Overtime`,sum(`dtrcompute`.`ot_sh_amt`) AS `Overtime Special Holiday`,sum(`dtrcompute`.`sh_amount`) AS `Special Holiday`,sum(`dtrcompute`.`ot_lh_amt`) AS `Overtime Legal Holiday`,sum(`dtrcompute`.`lh_amt`) AS `Legal Holiday`,sum(`dtrcompute`.`ot_sun_amt`) AS `Overtime Sunday`,sum(`dtrcompute`.`ot_excess_sun_amt`) AS `Overtime Excess Sunday`,sum(`dtrcompute`.`ot_lh_sun_amt`) AS `Overtime Legal Holiday Sunday`,sum(`dtrcompute`.`ot_lh_excess_sun_amt`) AS `Overtime Excess Legal Holiday Sunday`,sum(`dtrcompute`.`ot_nightdiff_amt`) AS `Overtime Night Differential`,`dtrcompute`.`is_deleted` AS `is_deleted`,`dtrcompute`.`payroll_code` AS `payroll_code`,`employee`.`w_sss` AS `w_sss`,`employee`.`w_hdmf` AS `w_hdmf`,`employee`.`w_philhealth` AS `w_philhealth`,`employee`.`tax_comp` AS `tax_comp` from (`dtrcompute` join `employee` on((`dtrcompute`.`emp_code` = `employee`.`code`))) where (`dtrcompute`.`dtrc_date` between '2016-03-01' and '2016-03-20');
