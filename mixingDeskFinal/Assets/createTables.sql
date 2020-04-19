DROP TABLE IF EXISTS companies;
DROP TABLE IF EXISTS flavourings;
DROP TABLE IF EXISTS recipes;
CREATE TABLE IF NOT EXISTS MyTable(Primary_Key INTEGER PRIMARY KEY,Text_Entry TEXT NULL); 
CREATE TABLE IF NOT EXISTS  companies(idNumbC INTEGER PRIMARY KEY, name TEXT NOT NULL UNIQUE);
CREATE TABLE IF NOT EXISTS  flavourings(idNumbF INTEGER PRIMARY KEY, name TEXT NOT NULL UNIQUE, versionNumber Number, inPersonalStash boolean NOT NULL, companyName_FK TEXT NOT NULL, FOREIGN KEY (companyName_FK) REFERENCES companies(idNumbC));


CREATE TABLE IF NOT EXISTS recipes
(idNumbR INTEGER PRIMARY KEY, 
name TEXT NOT NULL, 
creatorName TEXT,
notes TEXT,
postDate DATETIME NOT NULL,
rating NUMBER NOT NULL,
flav_1Percent NUMBER NOT NULL, 
flav_2Percent NUMBER, 
flav_3Percent NUMBER, 
flav_4Percent NUMBER,
flav_5Percent NUMBER, 
flav_6Percent NUMBER, 
flav_7Percent NUMBER,
flav_1_FK Number NOT NULL,
flav_2_FK Number,
flav_3_FK Number,
flav_4_FK Number,
flav_5_FK Number,
flav_6_FK Number,
flav_7_FK Number,
FOREIGN KEY (flav_1_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_2_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_3_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_4_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_5_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_6_FK) REFERENCES flavourings(idNumbC),
FOREIGN KEY (flav_7_FK) REFERENCES flavourings(idNumbC)


);