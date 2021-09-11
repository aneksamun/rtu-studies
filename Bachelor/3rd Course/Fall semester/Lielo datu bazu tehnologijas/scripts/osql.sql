-------------------------------------------------------------------------- OBJECT TABLE-------------------------------------------------------------------------- 

CREATE OR REPLACE TYPE KLIENTS_T AS OBJECT
(
	Vards VARCHAR2(15),
	Uzvards VARCHAR2(15),
	E_pasts VARCHAR2(15),
	Tel_Num NUMBER(8),
	Valsts VARCHAR2(2),
	Pilseta VARCHAR2(15),
	Adrese VARCHAR2(30)
)
/

CREATE TABLE Klienti OF Klients_t;

BEGIN
	INSERT INTO Klienti VALUES 
	(Klients_t('Aleksejs', 'Ivanovs', 'Alex@inbox.lv', 28676523, 'LV', 'Riga', 'Matisa 33'));
	INSERT INTO Klienti VALUES 
	(Klients_t('Galina', 'Makarova', NULL, 28676824, 'LV', 'Salaspils', 'Rigas 5'));
	INSERT INTO Klienti VALUES 
	(Klients_t('Vladimirs', 'Nikulins', NULL, 26776899, 'LV', 'Riga', 'Marijas 15'));
	INSERT INTO Klienti VALUES 
	(Klients_t('Janis', 'Roze', 'Janis@latnet.lv', 29775678, 'LV', 'Ogre', 'Lacplesa 7'));
END;

COLUMN object_name FORMAT A11
COLUMN object_type FORMAT A11

SELECT object_name, object_type
FROM user_objects 
WHERE object_name IN ('KLIENTI', 'KLIENTS_T');

COLUMN type_name HEADING 'TIPA NOS'
COLUMN type_name FORMAT A9
COLUMN typecode HEADING 'TIPS'
COLUMN typecode FORMAT A9
COLUMN attributes HEADING 'ATRIBUTI'
COLUMN attributes FORMAT 9
COLUMN methods HEADING 'METODES'
COLUMN methods FORMAT 9

SELECT type_name, typecode, attributes, methods
FROM user_types;

COLUMN column_name HEADING 'KOLONNA'
COLUMN column_name FORMAT A9
COLUMN data_type HEADING 'DATU TIPS'
COLUMN data_type FORMAT A10
COLUMN data_length HEADING 'GARUMS'
COLUMN data_length FORMAT 99

SELECT column_name, data_type, data_length
FROM user_tab_columns
WHERE table_name = 'KLIENTI'
ORDER BY column_name
/

COLUMN VARDS FORMAT A9
COLUMN UZVARDS FORMAT A9
COLUMN VALSTS FORMAT A6
COLUMN TEL_NUM FORMAT 99999999
COLUMN PILSETA FORMAT A9
COLUMN ADRESE FORMAT A10

SELECT * FROM Klienti
ORDER BY Vards;
   
SELECT VALUE(K) AS OBJEKTS FROM Klienti K
--WHERE K.E_pasts IS NULL
ORDER BY Vards; 

SELECT VALUE(K).PILSETA AS PILSETA, 
	LPAD(COUNT(VALUE(K)), 6, '=    ') AS SKAITS
FROM Klienti K
GROUP BY VALUE(K).Pilseta
ORDER BY VALUE(K).Pilseta;

SELECT K.PILSETA, LPAD(COUNT(*), 6, '=    ') AS SKAITS
FROM Klienti K
GROUP BY K.Pilseta
ORDER BY K.Pilseta; 

------------------------------------------------------------- TABLE WITH OBJECT COLUMNS----------------------------------------------------------

CREATE OR REPLACE TYPE Kreditkarte AS OBJECT
(
	TIPS VARCHAR(20),
	NUMURS VARCHAR2(10)
)
/

CREATE TABLE Pakalpojums
(
	Id NUMBER(4) PRIMARY KEY,
	Vieds VARCHAR2(20),
	Maksa NUMBER (5,2),
	Klients Klients_t,
	Norekins Kreditkarte
)

BEGIN
	INSERT INTO Pakalpojums VALUES(1, 'Transporta', 35.99, 
	(Klients_t('Jurijs', 'Basko', NULL, NULL, 'LV', 'Riga', 'Raina 7')), 
	(Kreditkarte('Visa', '4356-67737')));
	INSERT INTO Pakalpojums VALUES(2, 'Tehniskais', 20.88,
	(Klients_t('Evita', 'Caica', NULL, NULL, 'LV', 'Ogre', 'Rigas 5')), 
	(Kreditkarte('MasterCard', '2345-67733')));
END;

COLUMN ID HEADING 'ID|'
COLUMN ID FORMAT 9
COLUMN Vieds HEADING 'Pakalpojums|'
COLUMN Vieds FORMAT A12
COLUMN Maksa HEADING 'Maksa|'
COLUMN Maksa FORMAT 99.99
COLUMN Veids FORMAT A12
COLUMN Klients HEADING 'Klients: Vards, uzvards, e-pasts,|tel_num, valsts, pilseta, adrese'
COLUMN Klients FORMAT A34 
COLUMN Norekins HEADING 'Norekina veids|'
COLUMN Norekins FORMAT A20
	
SELECT * FROM Pakalpojums;

COLUMN column_name HEADING 'KOLONNA'
COLUMN column_name FORMAT A9
COLUMN data_type HEADING 'DATU TIPS'
COLUMN data_type FORMAT A11
COLUMN data_length HEADING 'GARUMS'
COLUMN data_length FORMAT 99

SELECT column_name, data_type, data_length
FROM user_tab_columns
WHERE table_name = 'PAKALPOJUMS'
ORDER BY data_type

COLUMN type_name HEADING 'TIPA NOS'
COLUMN type_name FORMAT A9
COLUMN typecode HEADING 'TIPS'
COLUMN typecode FORMAT A9
COLUMN attributes HEADING 'ATRIBUTI'
COLUMN attributes FORMAT 9
COLUMN methods HEADING 'METODES'
COLUMN methods FORMAT 9

SELECT type_name, typecode, attributes, methods
FROM user_types;

COLUMN name FORMAT A11
COLUMN type FORMAT A4
COLUMN text FORMAT A26

SELECT name, type, text
FROM user_source;

COLUMN ID HEADING 'ID|'
COLUMN ID FORMAT 9
COLUMN Vieds HEADING 'Pakalpojums|'
COLUMN Vieds FORMAT A12
COLUMN Maksa HEADING 'Maksa|'
COLUMN Maksa FORMAT 99.99
COLUMN Veids FORMAT A12
COLUMN Klients HEADING 'Klients: Vards, uzvards, e-pasts,|tel_num, valsts, pilseta, adrese'
COLUMN Klients FORMAT A34 
COLUMN Norekins HEADING 'Norekina veids|'
COLUMN Norekins FORMAT A20

SELECT * FROM Pakalpojums P
WHERE UPPER(P.Klients.Pilseta) LIKE 'O%' 
	AND P.Maksa < (SELECT SUM(Maksa)/COUNT(Id) FROM Pakalpojums);
	
SELECT Klients FROM Pakalpojums
WHERE Vieds <> 'Tehniskais';

SELECT P.Klients.Vards AS Vards, P.Klients.Uzvards AS Uzvards, P.Maksa, 
	P.Norekins.tips AS Kreditkarte, P.Norekins.Numurs AS NUMURS
FROM Pakalpojums P
WHERE P.Norekins.Numurs LIKE '2_4%';

---------------------------------------------------------------------------------- TABLE WITH COMPLEX OBJECTS -----------------------------------------------------------------------

CREATE OR REPLACE TYPE Kreditkarte_t AS OBJECT
(
	Kartes Kreditkarte,
	Likme NUMBER(4),
	Limits NUMBER(3)
)
/

CREATE TABLE Banku_pakalpojumi
(
	ID NUMBER(4) PRIMARY KEY,
	Bankas VARCHAR2(20),
	Kreditkartes Kreditkarte_t	
)
/

BEGIN
	INSERT INTO Banku_pakalpojumi VALUES(1, 'Parex', 
	(Kreditkarte_t(Kreditkarte('Visa Classic', '7444-12345'), 20, 3)));
	INSERT INTO Banku_pakalpojumi VALUES(2, 'Nordea',
	(Kreditkarte_t(Kreditkarte('MasterCard Gold', '3554-90675'), 0, 3))); 
	INSERT INTO Banku_pakalpojumi VALUES(3, 'Aizkraukles',
	(Kreditkarte_t(Kreditkarte('MasterCard Gold', '3554-90867'), 21, 4))); 
END;

COLUMN column_name HEADING 'KOLONNA'
COLUMN column_name FORMAT A12
COLUMN data_type HEADING 'DATU TIPS'
COLUMN data_type FORMAT A14
COLUMN data_length HEADING 'GARUMS'
COLUMN data_length FORMAT 99

SELECT column_name, data_type, data_length
FROM user_tab_columns
WHERE table_name = 'BANKU_PAKALPOJUMI'
ORDER BY data_type;

COLUMN type_name HEADING 'TIPA NOSAUKUMS'
COLUMN type_name FORMAT A14
COLUMN typecode HEADING 'TIPS'
COLUMN typecode FORMAT A9
COLUMN attributes HEADING 'ATRIBUTI'
COLUMN attributes FORMAT 9
COLUMN methods HEADING 'METODES'
COLUMN methods FORMAT 9
COLUMN final HEADING 'GALIGS?'
COLUMN final FORMAT A7
COLUMN instantiable HEADING 'EKSEMPLARI?'
COLUMN instantiable FORMAT A11

SELECT type_name, typecode, attributes, methods, 
	final, instantiable
FROM user_types;

COLUMN ID FORMAT 9
COLUMN Bankas FORMAT A11
COLUMN Kreditkartes HEADING 'KREDITKARTES: TIPS, NUMURS, LIKME(%), LIMITS(ALGU IZMERA)'
COLUMN Kreditkartes FORMAT A65 
	
SELECT * FROM Banku_pakalpojumi;

SELECT * FROM Banku_pakalpojumi B
WHERE UPPER(B.Kreditkartes.Kartes.Tips) LIKE '%MASTERCARD%' 
	AND B.Kreditkartes.Likme BETWEEN 0 AND 10;
		
SELECT Kreditkartes FROM Banku_pakalpojumi
WHERE UPPER(Bankas) IN ('PAREX', 'SEB', 'HANSA'); 

SELECT B.Kreditkartes.Kartes FROM Banku_pakalpojumi B
WHERE B.Kreditkartes.Limits < (SELECT MAX(B.Kreditkartes.Limits) 
	FROM Banku_pakalpojumi B) AND B.Kreditkartes.Likme > 
	(SELECT MIN(B.Kreditkartes.Likme) FROM Banku_pakalpojumi B);

SELECT B.Kreditkartes.Kartes.Tips AS Tips, 
	B.Kreditkartes.Likme AS LIKME_PROCENTOS 
FROM Banku_pakalpojumi B; 

------------------------------------------------------------- TABLE WITH COLECTION ----------------------------------------------------------

CREATE TYPE Klienti_t AS TABLE OF Klients_t;

CREATE TABLE Frizetavas
(
	ID NUMBER(4) PRIMARY KEY,
	Nosaukums VARCHAR2(15),
	Klienti Klienti_t
)
NESTED TABLE Klienti STORE AS Klientu_kolekcija
/

BEGIN
	INSERT INTO Frizetavas VALUES(1, 'Kamene', 
	Klienti_t(Klients_t('Olegs', 'Ivanovs', NULL, NULL, 'LV', 'Riga', NULL),
			  Klients_t('Zita', 'Lace', NULL, 24566788, 'LV', 'Riga', NULL),
			  Klients_t('Girts', 'Naglis', NULL, NULL, 'LV', 'Ogre', 'Stacijas 5'),
			  Klients_t('Anna', 'Dadze', NULL, 23445699, 'LV', 'Salaspils', 'Ogu 3')
	));
	INSERT INTO Frizetavas VALUES(2, 'Zemene', 
	Klienti_t(Klients_t('Natalija', 'Some', 'Nataly@one.lv', 26773699, 'LV', 'Riga', 'Dagdas 8'),
			  Klients_t('Mihails', 'Gorins', 'Miha@one.lv', 24566788, 'LV', 'Preili', NULL),
			  Klients_t('Girts', 'Seglins', NULL, NULL, 'LV', 'Salaspils', 'Dzirnavu 3'),
			  Klients_t('Dace', 'Burtina', 'Dace@inbox.lv', NULL, 'LV', 'Ogre', 'Parka 1')
	));
	INSERT INTO Frizetavas VALUES(3, 'Kolibri', 
	Klienti_t(Klients_t('Valdis', 'Puce', 'Valdis@one.lv', 22345643, 'LV', 'Riga', 'Dagdas 8'),
			  Klients_t('Ieva', 'Radzina', 'Ieva@inbox.lv', 27789239, 'LV', 'Ogre', 'Darza 5'),
			  Klients_t('Janis', 'Bruvers', NULL, NULL, 'LV', 'Riga', 'Raina 9')
	));
END;
/

COLUMN column_name HEADING 'KOLONNA'
COLUMN column_name FORMAT A12
COLUMN data_type HEADING 'DATU TIPS'
COLUMN data_type FORMAT A14
COLUMN data_length HEADING 'GARUMS'
COLUMN data_length FORMAT 99

SELECT column_name, data_type, data_length
FROM user_tab_columns
WHERE table_name = 'FRIZETAVAS'
ORDER BY data_type;

COLUMN type_name HEADING 'TIPA NOSAUKUMS'
COLUMN type_name FORMAT A14
COLUMN typecode HEADING 'TIPS'
COLUMN typecode FORMAT A10
COLUMN attributes HEADING 'ATRIBUTI'
COLUMN attributes FORMAT 9

SELECT type_name, typecode, attributes, type_oid  
FROM user_types;

COLUMN ID FORMAT 9
COLUMN NOSAUKUMS HEADING 'FRIZETAVA'
COLUMN Nosaukums FORMAT A9
COLUMN Klienti HEADING 'KLIENTS: VARDS, UZVARDS, E-PASTS, TEL, VALSTS, PILSETA, ADRESE'
COLUMN Klienti FORMAT A65 

SELECT * FROM Frizetavas;

SELECT Klienti FROM Frizetavas
WHERE LOWER(Nosaukums) = 'kolibri';

SELECT VALUE(K) AS KLIENTS FROM Frizetavas F, TABLE(F.Klienti) K
WHERE K.E_pasts LIKE '%inbox.lv' AND K.Tel_num IS NOT NULL;

SELECT VALUE(K).Vards AS VARDS, K.Uzvards, 
	VALUE(K).Pilseta AS PILSETA, 
	COALESCE(K.Adrese, 'NAV PIEREGISTRETA') AS ADRESE 
FROM Frizetavas F, TABLE(F.Klienti) K
WHERE UPPER(F.Nosaukums) = 'KAMENE'
ORDER BY K.Adrese;

COLUMN table_name FORMAT A17
COLUMN table_type_owner FORMAT A16
COLUMN table_type_name FORMAT A15
COLUMN parent_table_column FORMAT A19
 
SELECT table_name, table_type_owner, table_type_name,
	parent_table_column
FROM user_nested_tables
WHERE table_name = 'KLIENTU_KOLEKCIJA';

----------------------------------------------------- OSQL  -----------------------------------------------------------

SELECT F.Nosaukums AS FRIZETAVA, VALUE(K).Pilseta AS PILSETA, 
	COUNT(VALUE(K)) AS KLIENTI 
FROM Frizetavas F, TABLE(F.Klienti) K
GROUP BY VALUE(K).Pilseta, F.Nosaukums
ORDER BY F.Nosaukums;

SELECT VALUE(K).Uzvards AS UZVARDS, VALUE(K).Vards AS VARDS, 
	VALUE(K).E_pasts AS "E-PASTS"
FROM Frizetavas F, TABLE(F.Klienti) K
WHERE K.E_pasts IS NOT NULL
GROUP BY (K.Pilseta), VALUE(K).Vards, VALUE(K).Uzvards, 
	VALUE(K).E_pasts
HAVING UPPER(K.Pilseta) IN ('RIGA', 'SALASPILS');

SELECT F.Vards, F.Adrese
FROM TABLE(SELECT Klienti 
           FROM Frizetavas WHERE UPPER(Nosaukums) = 'ZEMENE')  F
WHERE F.Adrese LIKE '%a%a%';

SELECT Nosaukums, F.Adrese
FROM TABLE(SELECT Klienti 
           FROM Frizetavas WHERE UPPER(Nosaukums) = 'ZEMENE')  F
WHERE (F.Adrese || F.Vards) LIKE '%a%a%';

SELECT K.Uzvards
FROM Frizetavas F, TABLE(F.Klienti) K
WHERE K.Pilseta = (SELECT K.Pilseta FROM Frizetavas F, TABLE(F.Klienti) K
				   WHERE UPPER(K.UZVARDS) = 'DADZE') 
	  AND UPPER(K.Uzvards) <> 'DADZE'; 

ALTER TABLE Frizetavas
	ADD (Klienti2 Klienti_t)
    NESTED TABLE Klienti2 STORE AS Klientu_kolekcija2;
	
UPDATE Frizetavas F
  SET Klienti2 = 
    (SELECT F1.Klienti
     FROM Frizetavas F1
     WHERE F1.id = F.id);
			
SELECT F.Nosaukums AS FIRMA, 
	CARDINALITY(F.Klienti) AS KLIENTI,
	CARDINALITY(F.Klienti2) AS KLIENTI2
FROM Frizetavas F;

SELECT Klienti MULTISET EXCEPT Klienti2 AS KOLEKCIJA
FROM frizetavas;

SELECT Klienti MULTISET INTERSECT Klienti2 AS KOLEKCIJA
FROM frizetavas;  

-------------------------------------------------- 1 : N --------------------------------------------------------

CREATE TYPE Ats_klienti AS TABLE OF REF Klients_t;

CREATE TABLE Kompanijas
(
	ID NUMBER(4) PRIMARY KEY,
	Nosaukums VARCHAR2(20),
	Klienti Ats_klienti
)
NESTED TABLE Klienti STORE AS Klienti_ptr
/

DECLARE
		ats1 REF Klients_t;
		ats2 REF Klients_t;
		ats3 REF Klients_t;
		ats4 REF Klients_t;
BEGIN
		SELECT REF(K) INTO ats1
		FROM Klienti K
		WHERE VALUE(K).Vards = 'Aleksejs';
		SELECT REF(K) INTO ats2
		FROM Klienti K
		WHERE VALUE(K).Vards = 'Galina';
		SELECT REF(K) INTO ats3
		FROM Klienti K
		WHERE VALUE(K).Vards = 'Janis';
		SELECT REF(K) INTO ats4
		FROM Klienti K
		WHERE VALUE(K).Vards = 'Vladimirs';
		
		INSERT INTO Kompanijas VALUES
		(1, 'Exigen', Ats_klienti(ats1, ats4, ats3));
		INSERT INTO Kompanijas VALUES
		(2, 'IT Alise', Ats_klienti(ats1, ats2, ats3));
		INSERT INTO Kompanijas VALUES
		(3, 'Eddi', Ats_klienti(ats4, ats2));
		INSERT INTO Kompanijas VALUES
		(4, 'Lattelecom', Ats_klienti(ats2));
END;

SELECT DISTINCT VALUE(KK) AS ATSAUCES 
FROM Kompanijas K, TABLE(K.Klienti) KK;

SELECT Nosaukums AS FIRMAS, DEREF(VALUE(KK)).Vards AS VARDS,
	DEREF(VALUE(KK)).Uzvards AS UZVARDS
FROM Kompanijas K, TABLE(K.Klienti) KK;

----------------------------------------------------------- INFERITANCE --------------------------------------------------------------

CREATE TYPE Literatura_t AS OBJECT
(
	Nosaukums VARCHAR2(30),
	Gads NUMBER(4),
	Cena NUMBER(5,2)
)
NOT FINAL;
/

CREATE TYPE Gramata UNDER Literatura_t
(
	Autors VARCHAR2(30),
	Izdevnieciba VARCHAR2(15),
	Sejums NUMBER,
	Tips VARCHAR2(15)	
);
/

CREATE TYPE Avize UNDER Literatura_t
(
	Redakcija VARCHAR2(20),
	Numurs NUMBER
);
/

CREATE TABLE Literatura OF Literatura_t;

BEGIN
	INSERT INTO Literatura VALUES(Literatura_t('SQL for dummies', 2006, 4.55));
	INSERT INTO Literatura VALUES(Gramata('Alise brinumzeme', 1868, 5.79, 'L. Kerols', 'ABC', 5, 'Pasaka'));
	INSERT INTO Literatura VALUES(Gramata('Sarkangalvite', 1970, 5.99, 'K. Skalbe', 'ABC', 3, 'Pasaka'));
	INSERT INTO Literatura VALUES(Gramata('Kars un miers', 1869, 10.99, 'L. Tolstojs', 'ABC', 6, 'Romans'));
	INSERT INTO Literatura VALUES(Avize('Dienas Avize', 2008, 0.49, 'Diena', 7));
	INSERT INTO Literatura VALUES(Avize('Latvijas Avize', 2008 , 0.45, 'Latvijas avize', 9));
END;
/
	
SELECT VALUE(G) AS LITERATURA 
FROM Literatura G
ORDER BY VALUE(G).Gads;