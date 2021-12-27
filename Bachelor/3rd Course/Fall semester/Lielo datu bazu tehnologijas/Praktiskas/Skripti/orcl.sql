 CREATE TABLESPACE PRIVATESPACE
 datafile 'C:\oracle\product\10.1.0\oradata\orcl\private.dbf'
 SIZE 8M AUTOEXTEND ON NEXT 4M MAXSIZE 50M
 /
 
 SELECT username, default_tablespace
 FROM dba_users
 WHERE username = 'NEO'
 /
 
ALTER USER neo DEFAULT TABLESPACE PRIVATESPACE
/

GRANT ALL PRIVILEGES TO neo
/

CREATE TABLE AVIOREISS
(
	Reisa_Num NUMBER CONSTRAINT A_Invalid_PK PRIMARY KEY,
	Lidmasina VARCHAR(15) CONSTRAINT A_Empty_Airplane NOT NULL,
	Vietu_SK NUMBER(3) CONSTRAINT A_Empty_PlaceQ NOT NULL,
	Valsts VARCHAR(15) CONSTRAINT A_Empty_State NOT NULL,
	Pienaksanas_punkts VARCHAR2(20) CONSTRAINT A_Empty_FlyingPoint NOT NULL,
	Ierasanas_laiks DATE CONSTRAINT A_Interval_ArrivalTime CHECK(Ierasanas_laiks BETWEEN to_date('01.01.2008','dd.mm.yyyy') and to_date('31.12.2030','dd.mm.yyyy')),
	Atiesanas_lidosta VARCHAR2(20) DEFAULT 'Riga',
	Aizlidosanas_laiks DATE CONSTRAINT A_Interval_FlyAwayTime CHECK(Aizlidosanas_laiks BETWEEN to_date('01.01.2008','dd.mm.yyyy') and to_date('31.12.2030','dd.mm.yyyy'))
)
/

BEGIN
	INSERT INTO AVIOREISS(Reisa_Num, Lidmasina, Vietu_SK, Valsts, Pienaksanas_punkts, 
		Ierasanas_laiks, Atiesanas_lidosta, Aizlidosanas_laiks)
	VALUES (Reisu_Num.NEXTVAL, 'Boeing707-120B', 100, 'Krievija', 'Maskava', 
		to_date('10.10.2008 15:43:55','dd.mm.yyyy hh24:mi:ss'), 'Riga', 
		to_date('10.10.2008 10:45:00','dd.mm.yyyy hh24:mi:ss'));
	INSERT INTO AVIOREISS(Reisa_Num, Lidmasina, Vietu_SK, Valsts, Pienaksanas_punkts, 
		Ierasanas_laiks, Aizlidosanas_laiks)
	VALUES (Reisu_Num.NEXTVAL, 'Boeing707-320B', 100, 'Anglija', 'Londona', 
		to_date('15.10.2008 11:15:30','dd.mm.yyyy hh24:mi:ss'), 
		to_date('15.10.2008 7:45:00','dd.mm.yyyy hh24:mi:ss'));
	INSERT INTO AVIOREISS(Reisa_Num, Lidmasina, Vietu_SK, Valsts, Pienaksanas_punkts, 
		Ierasanas_laiks, Aizlidosanas_laiks)
	VALUES (Reisu_Num.NEXTVAL, 'Boeing737', 110, 'Afrika', 'Kaira', 
		to_date('17.10.2008 17:00:11','dd.mm.yyyy hh24:mi:ss'), 
		to_date('17.10.2008 10:00:00','dd.mm.yyyy hh24:mi:ss'));
	INSERT INTO AVIOREISS(Reisa_Num, Lidmasina, Vietu_SK, Valsts, Pienaksanas_punkts, 
		Ierasanas_laiks, Aizlidosanas_laiks)
	VALUES (Reisu_Num.NEXTVAL, 'Boeing727', 105, 'Kina', 'Pekina', 
		to_date('19.10.2008 15:00:11','dd.mm.yyyy hh24:mi:ss'), 
		to_date('19.10.2008 20:05:37','dd.mm.yyyy hh24:mi:ss'));
END;
/

CREATE SEQUENCE Reisu_Num
	MINVALUE 1 -- start value
	MAXVALUE 99999 -- MaxValue
	START WITH 1 --start value
	INCREMENT BY 1 -- increment by 1 {2,3, u.t.t}
	NOCYCLE --IF reach max value, then don't start with one to max again
	CACHE 9 -- keep in memory nine values
/

SELECT ReissNum.NEXTVAL FROM dual; -- know next value
	   ReissNum.CURRVAL

CREATE TABLE KLIENTS
(
	Klienta_Num NUMBER CONSTRAINT K_Invalid_PK PRIMARY KEY,
	Vards VARCHAR2(20) CONSTRAINT K_Empty_Name NOT NULL,
	Uzvards VARCHAR2(20) CONSTRAINT K_Empty_Surname NOT NULL),
	Valsts VARCHAR2(2) DEFAULT 'LV',
	Pilseta VARCHAR2(15) DEFAULT 'Riga',
	Adrese VARCHAR2(25) DEFAULT NULL,
	Telefons NUMBER(8) DEFAULT NULL,
	Rekina_num NUMBER CONSTRAINT K_Invalid_CostNum CHECK(Rekina_num >= 0)
)
/

CREATE SEQUENCE Klientu_Num
	MINVALUE 1 -- start value
	MAXVALUE 99999 -- MaxValue
	START WITH 1 --start value
	INCREMENT BY 1 -- increment by 1 {2,3, u.t.t}
	NOCYCLE --IF reach max value, then don't start with one to max again
	CACHE 9 -- keep in memory nine values
/

BEGIN
	INSERT INTO Klients(Klienta_Num, Vards, Uzvards, Valsts, Pilseta, Adrese,Telefons,Rekina_num)
	VALUES (Klientu_Num.NEXTVAL,'Vija', 'Roze', 'LV', 'Riga', 'Brivibas 55', 27745233, 123);
	INSERT INTO Klients(Klienta_Num, Vards, Uzvards, Adrese, Telefons, Rekina_num)
	VALUES (Klientu_Num.NEXTVAL,'Dmitrijs', 'Dimidovs','Meza 5', 24367779, 133);
	INSERT INTO Klients(Klienta_Num, Vards, Uzvards, Adrese, Telefons, Rekina_num)
	VALUES (Klientu_Num.NEXTVAL,'Aleksejs', 'Saveljevs','Valdemara 36', 24364577, 134);
	INSERT INTO Klients(Klienta_Num, Vards, Uzvards, Adrese, Telefons, Rekina_num)
	VALUES (Klientu_Num.NEXTVAL,'Andrejs', 'Vasiljevs','Raina 4', 24363339, 135);
	INSERT INTO Klients(Klienta_Num, Vards, Uzvards, Adrese, Telefons, Rekina_num)
	VALUES (Klientu_Num.NEXTVAL,'Sergejs', 'Jakovlevs','Deglavas 10', 24311137, 137);
END;

CREATE TABLE VIETA
(
	ID NUMBER CONSTRAINT V_Invalid_PK PRIMARY KEY,
	Vietas_Num NUMBER(3) CONSTRAINT V_Empty_PlaceNum NOT NULL,
	Rindas_Num NUMBER(3) CONSTRAINT V_Empty_LineNum NOT NULL,
	Maksa NUMBER(5,2) DEFAULT 90.00 CONSTRAINT V_Invalid_Payment CHECK(Maksa > 0),
	Avio_Nr NUMBER,
	CONSTRAINT V_REISS_FK
		FOREIGN KEY (Avio_Nr)
		REFERENCES AVIOREISS(Reisa_Num)
		ON DELETE CASCADE,
	Klient_Nr Number,
	CONSTRAINT V_Klients_FK
		FOREIGN KEY (Klient_Nr)
		REFERENCES KlIENTS(Klienta_Num)
		ON DELETE CASCADE			   
)
/

BEGIN
	INSERT INTO Vieta(ID, Vietas_Num, Rindas_Num, Maksa, Avio_Nr, Klient_Nr)
	VALUES (1, 1, 1, 130.25, 1, 1);
	INSERT INTO Vieta(ID, Vietas_Num, Rindas_Num, Avio_Nr, Klient_Nr)
	VALUES (2, 1, 1, 2, 2);
	INSERT INTO Vieta(ID, Vietas_Num, Rindas_Num, Maksa, Avio_Nr, Klient_Nr)
	VALUES (3, 1, 1, 300.47, 3, 3);
	INSERT INTO Vieta(ID, Vietas_Num, Rindas_Num, Maksa, Avio_Nr, Klient_Nr)
	VALUES (4, 1, 1, 390.77, 4, 4);
	INSERT INTO Vieta(ID, Vietas_Num, Rindas_Num, Maksa, Avio_Nr, Klient_Nr)
	VALUES (5, 2, 1, 130.25, 1, 5);
END;	

SELECT k.Vards, k.Uzvards, v.Maksa
FROM klients k, vieta v
WHERE k.Klienta_Num = v.Klient_Nr AND 
      v.Maksa > (SELECT SUM(Maksa)/COUNT(ID) AS A 
				 FROM Vieta);
				 
SELECT A.Lidmasina, COUNT(V.Avio_Nr)
FROM Avioreiss A, Vieta V
WHERE A.Reisa_Num = V.Avio_Nr
GROUP BY A.Lidmasina
HAVING COUNT(V.Avio_Nr) > 1;

sho user; 

COLUMN Klienta_Num FORMAT 999
COLUMN Vards FORMAT A8
COLUMN Uzvards FORMAT A9
COLUMN Valsts FORMAT A6
COLUMN Pilseta FORMAT A7
COLUMN Adrese FORMAT A12
COLUMN Telefons FORMAT 99999999
COLUMN Rekina_Num HEADING 'Rek.#'
COLUMN Rekina_Num FORMAT 99999

COLUMN Reisa_Num HEADING 'NUM'
COLUMN Reisa_Num FORMAT 99
COLUMN Lidmasina FORMAT A14
COLUMN Vietu_SK HEADING 'Sk'
COLUMN Vietu_SK FORMAT 999
COLUMN Valsts FORMAT A8
COLUMN Pienaksanas_punkts HEADING 'Nosezas'
COLUMN Pienaksanas_punkts FORMAT A7
COLUMN Atiesanas_lidosta HEADING 'Atiet'
COLUMN Atiesanas_lidosta FORMAT A5

SELECT Reisa_Num, Lidmasina, Vietu_SK, Valsts,
	Pienaksanas_punkts, Atiesanas_lidosta, 
	to_char(Ierasanas_laiks, 'dd.mm.yy hh24:mi') As Ierodas,
	to_char(Aizlidosanas_laiks, 'dd.mm.yy hh24:mi') As Aizlido
FROM Avioreiss;

COLUMN table_name FORMAT A11
COLUMN column_name FORMAT A18
COLUMN data_type FORMAT A8
COLUMN data_length FORMAT 9999

SELECT table_name, column_name, data_type, data_length
FROM user_tab_columns
ORDER BY table_name
/
 
SELECT table_name, constraint_name
FROM user_constraints
WHERE table_name = 'AVIOREISS'
--WHERE table_name IN ('VIETA', 'KLIENTS', 'AVIOREISS')
ORDER BY constraint_name;
 
SELECT sequence_name
FROM user_sequences;
 
CREATE OR REPLACE VIEW Klientu_skats(Vards, Uzvards, Rekina_num, Rekins, Reiss)
AS SELECT Klients.Vards, Klients.Uzvards, Klients.Rekina_Num, Vieta.Maksa, Avioreiss.Reisa_Num
   FROM (Vieta FULL JOIN Klients
   ON Vieta.klient_nr = Klients.Klienta_num) 
   INNER JOIN Avioreiss
   ON Vieta.Avio_Nr = Avioreiss.Reisa_num
   WHERE Avioreiss.Aizlidosanas_laiks >= (SELECT to_date(sysdate,'dd.mm.yyyy') FROM dual)
WITH READ ONLY
/

COLUMN Vards FORMAT A8
COLUMN Uzvards FORMAT A9
COLUMN Rekina_Num HEADING 'Rek#'
COLUMN Rekina_Num FORMAT 9999
COLUMN Rekins FORMAT 999.99
COLUMN REISS FORMAT 99999

SELECT * FROM Klientu_skats
/

CREATE OR REPLACE VIEW REZERVETAS_VIETAS AS 
	SELECT K.Klienta_Num, K.Vards, K.Uzvards, K.Rekina_Num,
		   V.ID, V.Vietas_Num, V.Rindas_Num, V.Maksa, V.Avio_Nr, 
	       V.Klient_Nr 
	FROM Vieta V, Klients K
	WHERE V.Klient_Nr = K.Klienta_Num
WITH CHECK OPTION
/

SELECT * FROM KLIENTU_SKATS;

SELECT view_name, text_length FROM user_views;

SELECT text, text_length
FROM user_views
WHERE view_name IN ('KLIENTU_SKATS','PARSKATS')
/ 

CREATE OR REPLACE VIEW PIETIEKUMA_SKATS(Num, Vieta, Rinda, Maksa, Reiss, Klient_Num)
AS SELECT * FROM Vieta
WITH CHECK OPTION 
/

BEGIN
	INSERT INTO PIETIEKUMA_SKATS(Num, Vieta, Rinda, Maksa, Reiss, Klient_Num)
	VALUES (6, 2, 1, 300.47, 3, 1);
	INSERT INTO PIETIEKUMA_SKATS(Num, Vieta, Rinda, Maksa, Reiss, Klient_Num)
	VALUES (7, 2, 1, 390.77, 4, 2);
	INSERT INTO PIETIEKUMA_SKATS(Num, Vieta, Rinda, Maksa, Reiss, Klient_Num)
	VALUES (8, 3, 1, 390.77, 4, 3);
END;

SELECT COUNT(*) AS PIETEIKUMI, SUM(MAKSA) AS IENAKUMI
FROM PIETIEKUMA_SKATS;

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE CLUSTER KLASTER
(Klaster_num NUMBER)
TABLESPACE Privatespace
SIZE 512
STORAGE (INITIAL 100K next 50K)
/

CREATE INDEX idx_klaster ON CLUSTER klaster;

CREATE TABLE Avioreiss_1
	CLUSTER klaster (Reisa_Num)
	AS SELECT * FROM Avioreiss
/
	
CREATE TABLE Klients_1
	CLUSTER klaster (Klienta_Num)
	AS SELECT * FROM Klients
/
	
CREATE TABLE Vieta_1
	CLUSTER klaster (ID)
	AS SELECT * FROM Vieta
/
 
 ALTER TABLE Avioreiss_1
 MODIFY Ierasanas_laiks DATE DEFAULT SYSDATE;
 
 ALTER TABLE Avioreiss_1
 MODIFY Aizlidosanas_laiks DATE DEFAULT SYSDATE;
 
 ALTER TABLE Avioreiss_1
 ADD CONSTRAINT A1_Interval_ArrivalTime CHECK(Ierasanas_laiks BETWEEN 
 to_date('01.01.2008','dd.mm.yyyy') and to_date('01.01.2030','dd.mm.yyyy'));
 
 ALTER TABLE Avioreiss_1
 ADD CONSTRAINT A1_Interval_FlyAwayTime CHECK(Aizlidosanas_laiks BETWEEN 
 to_date('01.01.2008','dd.mm.yyyy') and to_date('01.01.2030','dd.mm.yyyy'));
 
 ALTER TABLE Avioreiss_1
 MODIFY Atiesanas_lidosta VARCHAR2(20) DEFAULT 'Riga';
 
 ALTER TABLE KLIENTS_1
 MODIFY Pilseta VARCHAR2(15) DEFAULT 'Riga';
 
 ALTER TABLE KLIENTS_1
 MODIFY Valsts VARCHAR2(2) DEFAULT 'LV';
 
 ALTER TABLE KLIENTS_1
 MODIFY Adrese VARCHAR2(25) DEFAULT NULL;
 
 ALTER TABLE KLIENTS_1
 MODIFY Telefons NUMBER(8) DEFAULT NULL;
 
 ALTER TABLE KLIENTS_1
 ADD CONSTRAINT K1_Invalid_CostNum CHECK(Rekina_num >= 0);

 ALTER TABLE VIETA_1
 MODIFY Maksa NUMBER(5,2) DEFAULT 90.00;
 
 ALTER TABLE VIETA_1
 ADD CONSTRAINT V1_Invalid_Payment CHECK(Maksa > 0);
 
 
SELECT K.Vards, K.Uzvards, V.Rindas_Num, V.Maksa
FROM Vieta_1 V, Klients_1 K
WHERE V.Klient_Nr = K.Klienta_Num;

select vieta_1.vietas_num, avioreiss_1.vietu_sk
from vieta_1 full join avioreiss_1
on vieta_1.Avio_Nr = avioreiss_1.reisa_num; 

 SELECT table_name, constraint_name name
 FROM user_constraints
 WHERE table_name IN ('VIETA_1', 'KLIENTS_1', 'AVIOREISS_1')
 ORDER BY table_name;

SELECT cluster_name, tablespace_name, key_size, hashkeys, single_table
FROM user_clusters;

COLUMN table_name FORMAT A11
COLUMN cluster_name FORMAT A11
COLUMN tablespace_name FORMAT A15

SELECT table_name, cluster_name, tablespace_name
FROM user_tables
/

COLUMN Vards FORMAT A8
COLUMN Uzvards FORMAT A9
COLUMN Maksa FORMAT 999.99
COLUMN Valsts FORMAT A8
COLUMN Pienaksanas_punkts HEADING 'Nosezas'
COLUMN Pienaksanas_punkts FORMAT A7

SELECT K.Vards, K.Uzvards, V.Vietas_Num, V.Maksa, 
       A.Valsts, A.Pienaksanas_punkts
FROM Vieta_1 V, Klients_1 K, Avioreiss_1 A
WHERE V.Klient_Nr = K.Klienta_Num AND
	  V.Avio_Nr = A.Reisa_Num
/

-------------------------------------------------------------------------------------------------------------------
 
SELECT a.Aizlidosanas_laiks AS DATUMS,a.Valsts AS KURORTS, 
	COUNT(k.Klienta_num) AS KL_KOPA, SUM(v.Maksa) AS IENAKUMI
FROM Vieta_1 v, Klients_1 k, Avioreiss_1 a
WHERE k.Klienta_Num = v.Klient_Nr AND
	a.Reisa_Num = v.Avio_Nr
GROUP BY CUBE(a.Aizlidosanas_laiks, a.Valsts)
ORDER BY a.Aizlidosanas_laiks
/

SELECT DECODE(GROUPING(a.Aizlidosanas_laiks), 1, 'Kopa', a.Aizlidosanas_laiks) AS DATUMS,
	DECODE(GROUPING(a.Valsts), 1, 'Kopa', a.Valsts) AS KURORTS,
	COUNT(k.Klienta_num) AS KL_KOPA, SUM(v.Maksa) AS IENAKUMI
FROM Vieta_1 v, Klients_1 k, Avioreiss_1 a
WHERE k.Klienta_Num = v.Klient_Nr AND
	a.Reisa_Num = v.Avio_Nr
GROUP BY CUBE(a.Aizlidosanas_laiks, a.Valsts)
ORDER BY a.Aizlidosanas_laiks
/

CREATE TABLE TEACHER
(
	TchPK INTEGER CONSTRAINT tch_pk PRIMARY KEY,
	Name VARCHAR(30) NOT NULL,
	Post VARCHAR(20) CONSTRAINT tch_ch_pst CHECK
					 (Post IN ('profesors', 'docents', 'pasniedzejs', 'asistents')),
	Chief INTEGER DEFAULT NULL CONSTRAINT tch_fk_tch REFERENCES TEACHER(TchPK)
)

BEGIN
	INSERT INTO TEACHER(TchPK, Name, Post)
	VALUES (6, 'Lauskis', 'profesors');
	INSERT INTO TEACHER(TchPK, Name, Post, Chief)
	VALUES (4, 'Basko', 'docents', 6);
	INSERT INTO TEACHER(TchPK, Name, Post, Chief)
	VALUES (2, 'Martinova', 'pasniedzejs', 4);
	INSERT INTO TEACHER(TchPK, Name, Post, Chief)
	VALUES (1, 'Davidovs', 'asistents', 2);
	INSERT INTO TEACHER(TchPK, Name, Post, Chief)
	VALUES (3, 'Jakina', 'pasniedzejs', 4);
	INSERT INTO TEACHER(TchPK, Name, Post, Chief)
	VALUES (5, 'Sparans', 'docents', 6);
END;

COLUMN Name HEADING 'Uzvards'
COLUMN Name FORMAT A9
COLUMN Post HEADING 'AMATS'
COLUMN Post FORMAT A14
COLUMN TchPk HEADING 'CHILD'
COLUMN TchPK FORMAT 999999
COLUMN Chief HEADING 'PARENT'
COLUMN Chief FORMAT 99999

SELECT Name, Post, TchPK, Chief
FROM TEACHER
START WITH Chief IS NULL
CONNECT BY PRIOR TchPK = Chief
/

SELECT LPAD(' ', 2*(LEVEL - 1)) || Name
FROM TEACHER
START WITH Chief IS NULL
CONNECT BY PRIOR TchPK = Chief
/

SELECT LPAD(' ', 2*(LEVEL - 1)) || Name AS UZVARDS
FROM TEACHER
START WITH NAME = 'Basko'
CONNECT BY PRIOR TchPK = Chief
/

SELECT a.Aizlidosanas_laiks AS DATUMS, k.Uzvards, 
	v.Maksa AS Maksa, SUM(v.Maksa) 
	OVER(PARTITION BY a.Aizlidosanas_laiks) AS KOPA
FROM Vieta_1 v, Avioreiss_1 a, Klients_1 k
WHERE v.Avio_Nr = a.Reisa_Num AND
	k.Klienta_Num = v.Klient_Nr;

SELECT Avio_Nr AS Avioreiss,
	Vietas_Num AS V_NUMURS, 
	COUNT(Vietas_Num)
	OVER(PARTITION BY Avio_Nr) AS KOPA_REZERVETAS 
FROM Vieta_1;
ORDER BY Reisa_Num;
 