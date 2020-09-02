# trustedi10-mvc-assessment-asad

#SQL Script 

create database recDB
GO

use recDB
GO

CREATE TABLE recTable (
 occurance varchar(10) DEFAULT NULL,
 recDT varchar(25) DEFAULT NULL,
 recValue varchar(100) DEFAULT NULL,
 recName varchar(100) DEFAULT NULL,
 recEvent varchar(45) DEFAULT NULL
)

GO

INSERT INTO recTable 
VALUES ('45','2020-01-30 09:17:00','100','SpO2','Vital Sign'),
('45','2020-01-30 09:17:00','66','Height','Vital Sign'),
('45','2020-01-30 09:17:00','4192','Weight','Vital Sign'),
('45','2020-01-30 09:17:00','158/85','BP','Vital Sign'),
('45','2020-01-30 09:17:00','97.5','Temp','Vital Sign'),
('45','2020-01-30 09:17:00','1','Temp src','Vital Sign'),
('45','2020-01-30 09:17:00','70','Pulse','Vital Sign'),
('45','2020-01-30 09:17:00','18','Resp','Vital Sign'),
('46','2020-01-30 09:50:00','Yes','IV Start Kit used?','Peripheral IV'),
('46','2020-01-30 09:50:00','ED Department','LDA Placed?','Peripheral IV'),
('46','2020-01-30 09:50:00','20 G','Size','Peripheral IV'),
('46','2020-01-30 09:50:00','Antecubital','Location','Peripheral IV'),
('46','2020-01-30 09:50:00','Nurse A','Inserted by','Peripheral IV'),
('46','2020-01-30 09:50:00','1','Insertion attempts','Peripheral IV');

GO

CREATE PROCEDURE SP_getRecDetails
AS
BEGIN


SELECT DISTINCT CONVERT(VARCHAR(30), rt2.recDT) + ' - ' + CONVERT(VARCHAR(30), rt2.recEvent) + ' [ '
    + STUFF( ( SELECT ', ' + CONVERT(VARCHAR(30), recName) + ': ' + CONVERT(VARCHAR(30), recValue)
            FROM recTable rt1 WHERE rt1.recDT = rt2.recDT
			FOR XML PATH(''), TYPE).value('.', 'varchar(max)'), 1,1,'') + ' ] ' as result
FROM recTable rt2;


END
