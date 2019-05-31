DROP DATABASE IF EXISTS eecs113_final_db;
CREATE DATABASE eecs113_final_db;
USE eecs113_final_db;

CREATE TABLE Test(
   phlid  	VARCHAR(8),
   email		VARCHAR(70) NOT NULL,
   pswd		CHAR(32) NOT NULL,
   PRIMARY KEY (phlid)
  );