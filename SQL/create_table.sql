DROP TABLE IF EXISTS Test;
CREATE TABLE Test(
   phlid  	VARCHAR(8),
   email		VARCHAR(70) NOT NULL,
   pswd		CHAR(32) NOT NULL,
   PRIMARY KEY (phlid)
  );