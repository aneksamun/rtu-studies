-------------------------------------------------------------------------- OBJECT TABLES--------------------------------------------------------------------------

CREATE OR REPLACE TYPE Prece As OBJECT
(
	PreceID NUMBER,
	Nosaukums VARCHAR(25),
	Cena NUMBER(6,2),
	PVN NUMBER(3),
	Atlaide NUMBER(2),
	PiegID NUMBER,
	Maksa NUMBER(6,2),
	MEMBER PROCEDURE Gala_Cena
)
/

CREATE TABLE Preces OF Prece;

BEGIN
	INSERT INTO Preces VALUES 
	(Prece(1, 'Pildspalva', 0.25, 20, 10, 1, Null));
	INSERT INTO Preces VALUES 
	(Prece(2, 'Zimulis', 0.25, 10, 5, 1, Null));
	INSERT INTO Preces VALUES 
	(Prece(3, 'Rakstampapirs', 0.45, 20, 10, 1, Null));
	INSERT INTO Preces VALUES 
	(Prece(4, 'Planotajs', 0.65, 20, 10, 2, Null));
	INSERT INTO Preces VALUES 
	(Prece(5, 'Skavas', 0.15, 20, 10, 2, Null));
END;

COLUMN VALUE(P).PreceID HEADING 'ID'
COLUMN VALUE(P).PreceID FORMAT 99
COLUMN VALUE(P).Nosaukums HEADING 'Nosaukums'
COLUMN VALUE(P).Nosaukums FORMAT A13
COLUMN VALUE(P).Cena HEADING 'Cena'
COLUMN VALUE(P).Cena FORMAT 0.99
COLUMN VALUE(P).PVN HEADING 'PVN'
COLUMN VALUE(P).PVN FORMAT 99
COLUMN VALUE(P).Atlaide HEADING 'Atlaide'
COLUMN VALUE(p).Atlaide FORMAT 99
COLUMN VALUE(P).PiegID HEADING 'Pieg.'
COLUMN VALUE(p).PiegID FORMAT 9
COLUMN VALUE(P).Maksa HEADING 'Gala cena'

SELECT VALUE(P).PreceID, VALUE(P).Nosaukums, VALUE(P).Cena,VALUE(P).PVN, 
	VALUE(P).Atlaide, VALUE(P).PiegID, VALUE(P).Maksa
FROM Preces P;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE TYPE Pasutijums AS OBJECT
(
	PasutID NUMBER,
	DarbID NUMBER,
	PreceID NUMBER,
	PasutDatums DATE,
	Skaits NUMBER(3),
	Status NUMBER(1),
	ORDER MEMBER FUNCTION Kartot_Datum(p Pasutijums) RETURN INTEGER
)
/

CREATE TABLE Pasutijumi OF Pasutijums;

BEGIN
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(1, 2, 3, to_date('11.12.2008','dd.mm.yyyy'), 1, 1));
	INSERT INTO Pasutijumi VALUES 
	(pasutijums(2, 1, 2, to_date('11.12.2008','dd.mm.yyyy'), 3, 1));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(3, 3, 3, to_date('11.12.2008','dd.mm.yyyy'), 1, 1));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(4, 4, 1, to_date('12.12.2008','dd.mm.yyyy'), 3, 1));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(5, 5, 1, to_date('12.12.2008','dd.mm.yyyy'), 2, 1));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(6, 3, 4, to_date('13.12.2008','dd.mm.yyyy'), 1, 0));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(7, 1, 1, to_date('14.12.2008','dd.mm.yyyy'), 2, 0));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(8, 2, 5, to_date('14.12.2008','dd.mm.yyyy'), 2, 0));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(9, 5, 2, to_date('14.12.2008','dd.mm.yyyy'), 2, 0));
	INSERT INTO Pasutijumi VALUES 
	(Pasutijums(10, 3, 2, to_date('15.12.2008','dd.mm.yyyy'), 1, 0));
END;

SELECT VALUE(P) FROM Pasutijumi P;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE TYPE Piegadatajs AS OBJECT
(
	PiegID NUMBER,
	Nosaukums VARCHAR2(15)
)
/

CREATE TABLE Piegadataji OF Piegadatajs;

BEGIN
	INSERT INTO Piegadataji VALUES 
	(Piegadatajs(1, 'Elco'));
	INSERT INTO Piegadataji VALUES 
	(Piegadatajs(2, 'Lanateks'));
END;

SELECT * FROM Piegadataji;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE TYPE Darbinieks AS OBJECT
(
	DarbID NUMBER,
	Vards VARCHAR2(15),
	Uzvards VARCHAR2(15),
	Amats VARCHAR2(20),
	Tel_Num NUMBER(8),
	Alga NUMBER(6,2),
	Premija NUMBER(5,2),
	MAP MEMBER FUNCTION Samaksa RETURN REAL 
)
/

CREATE TABLE Darbinieki OF Darbinieks; 

BEGIN
	INSERT INTO Darbinieki VALUES 
	(Darbinieks(1, 'Ieva', 'Zole', 'Testetaja', 28335323, 350.89, 30.00));
	INSERT INTO Darbinieki VALUES 
	(Darbinieks(2, 'Girts', 'Osis', 'Programmetajs', 28775823, 550.89, 55.00));
	INSERT INTO Darbinieki VALUES 
	(Darbinieks(3, 'Janis', 'Lacis', 'Administrators', 29995823, 500.99, 49.99));
	INSERT INTO Darbinieki VALUES 
	(Darbinieks(4, 'Vilis', 'Spogis', 'Tehnikis', 27330023, 450.89, 40.00));
	INSERT INTO Darbinieki VALUES 
	(Darbinieks(5, 'Laima', 'Apse', 'Programmetaja', 28775823, 550.89, 55.00));
END;

COLUMN DarbID HEADING 'ID'
COLUMN DarbID FORMAT 99
COLUMN Vards FORMAT A5
COLUMN Uzvards FORMAT A7
COLUMN Amats FORMAT A15
COLUMN Tel_Num FORMAT 99999999
COLUMN Alga FORMAT 999.99
COLUMN Premija FORMAT 99.99

SELECT DarbID, Vards, Uzvards, Amats, Tel_Num,
		Alga, Premija
FROM Darbinieki;

CREATE OR REPLACE TYPE BODY Darbinieks AS
	MAP MEMBER FUNCTION Samaksa RETURN REAL IS
		BEGIN
			RETURN (SELF.Alga+SELF.Premija);
		END Samaksa;
END;


SELECT VALUE(D).Vards, VALUE(D).Uzvards, VALUE(D).Amats,				
	VALUE(D).Alga, VALUE(D).Premija 
FROM Darbinieki D ORDER BY VALUE(D) DESC; 

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

COLUMN VALUE(P).Nosaukums HEADING 'Prece'
COLUMN VALUE(P).Nosaukums FORMAT A13
COLUMN VALUE(P).Cena HEADING 'Cena'
COLUMN VALUE(P).Cena FORMAT 0.99
COLUMN COUNT(VALUE(PP).PreceID) HEADING 'x pasut.'
COLUMN COUNT(VALUE(PP).PreceID) HEADING FORMAT 99
COLUMN SUM(VALUE(PP).Skaits) HEADING 'Kop. sk.'
COLUMN SUM(VALUE(PP).Skaits) HEADING FORMAT 99
COLUMN IZMAKSAS HEADING 'Izmaksas'
COLUMN IZMAKSAS FORMAT 0.99

SELECT VALUE(P).Nosaukums, VALUE(P).Cena, COUNT(VALUE(PP).PreceID), 
		SUM(VALUE(PP).Skaits), SUM(VALUE(PP).Skaits * VALUE(P).Cena) AS IZMAKSAS
FROM Preces P, Pasutijumi PP
WHERE VALUE(P).PreceID = VALUE(PP).PreceID AND
		PP.Status = 0
GROUP BY VALUE(P).Nosaukums, VALUE(P).Cena;

COLUMN Nosaukums HEADING 'Prece'
COLUMN Nosaukums FORMAT A13

SELECT D.Vards, D.Uzvards, P.Nosaukums, 
		PP.PasutDatums, PP.Skaits
FROM Darbinieki D, Pasutijumi PP, Preces P
WHERE D.DarbID = PP.DarbID AND PP.PreceID = P.PreceID
		AND PP.Status = 0
ORDER BY PP.PasutDatums;

SELECT VALUE(P).Nosaukums, VALUE(P).Cena
FROM Preces P
WHERE VALUE(P).Cena < SOME(SELECT PP.Cena
							FROM Preces PP
							WHERE PP.Cena > 0.45); 
							
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

DECLARE
	p_Cena Preces.Cena%Type;
	P_PVN Preces.PVN%Type;
	p_Prece Preces.Nosaukums%Type;
	p_Uzcenojums Preces.Cena%Type;
	p_Rezultats Preces.Cena%Type;
BEGIN
	SELECT MAX(VALUE(P).Cena) INTO p_Cena
	FROM Preces P, Piegadataji PP
	WHERE VALUE(P).PiegID = VALUE(PP).PiegID
	AND PP.Nosaukums = 'Lanateks';
	-----------------------------------------------------------
	SELECT VALUE(P).PVN, VALUE(P).Nosaukums INTO p_PVN, p_Prece
	FROM Preces P, Piegadataji PP
	WHERE VALUE(P).PiegID = VALUE(PP).PiegID
	AND VALUE(PP).Nosaukums = 'Lanateks'
	AND VALUE(P).Cena = p_Cena;
	------------------------------------------------------------
	p_Uzcenojums := (p_Cena * p_PVN)/100;
	p_Rezultats := p_Cena + p_Uzcenojums;
	--------------------------------------------------------------
	DBMS_OUTPUT.PUT_LINE('--------------------------------------------------');
	DBMS_OUTPUT.PUT_LINE('Lanateks dargaka prece: ' || p_Prece);
	DBMS_OUTPUT.PUT_LINE('Preces sakotneja cena: ' || to_Char(p_Cena, '0.99'));
	DBMS_OUTPUT.PUT_LINE('Lanateks uzcenojums precei: ' || to_Char(p_Uzcenojums, '0.99'));
	DBMS_OUTPUT.PUT_LINE('Preces cena ar uzcenojumu: '|| to_Char(p_Rezultats, '0.99'));
END;

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE Pasut_Kopskats(p_Datums IN CHAR) IS
	p_Daudzums Pasutijumi.Skaits%Type;
	p_Skaits Pasutijumi.PreceID%Type;
BEGIN
	SELECT COUNT(P.PreceID), SUM(P.Skaits) INTO p_Skaits, p_Daudzums
	FROM Pasutijumi P
	WHERE P.PasutDatums = (to_date(p_Datums, 'dd.mm.yyyy'));
	DBMS_OUTPUT.PUT_LINE('---------------------');
	DBMS_OUTPUT.PUT_LINE('Datums: '|| p_Datums);
	DBMS_OUTPUT.PUT_LINE('Kopejo pasutito precu skaits: '||p_Skaits);
	DBMS_OUTPUT.PUT_LINE('Kopejo pasutito precu daudzums: '|| p_Daudzums);	
EXCEPTION
	WHEN OTHERS THEN
		DBMS_OUTPUT.PUT_LINE('Ludzu, uzradiet datumu formata dd.mm.yyyy!');	
END;
/

BEGIN
	Pasut_Kopskats('12.12.2008');
END;
/

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE Ienak_izsk IS
	Darb Darbinieki%RowType;
	IEN Darbinieki.Alga%Type;
	VID_IEN Darbinieki.Alga%Type;
	i NUMBER;
	CURSOR C1 IS
	SELECT VALUE(D)
	FROM Darbinieki D;
BEGIN
	DBMS_OUTPUT.PUT_LINE('-------------------------------------');
	i := 0;
	VID_IEN := 0;
	OPEN C1;
	IF C1%ISOPEN THEN
		LOOP
			FETCH C1 INTO Darb;
			EXIT WHEN C1%NOTFOUND;
			IEN := Darb.Alga + Darb.Premija;
			VID_IEN := VID_IEN + IEN;
			i := i + 1;
			DBMS_OUTPUT.PUT_LINE(Darb.Vards||' '||Darb.Uzvards||' ienakums: '|| IEN);
		END LOOP;
	DBMS_OUTPUT.PUT_LINE('-------------------------------------');
	DBMS_OUTPUT.PUT_LINE('Videjais darbinieku ienakums: ' || VID_IEN/i);
	END IF;
	CLOSE C1;
END;
/

BEGIN
	Ienak_izsk;
END;
/

CREATE OR REPLACE PROCEDURE IEN_IZK1 IS
	Type ms_Vards IS TABLE OF Darbinieki.Vards%Type
	INDEX BY BINARY_INTEGER;
	p_Vards ms_Vards;
	Type ms_Alga IS TABLE OF Darbinieki.Alga%Type
	INDEX BY BINARY_INTEGER;
	p_Alga ms_Alga;
	Darb Darbinieki%ROWTYPE; 
	CURSOR SlrCsr IS
	SELECT VALUE(D)
	FROM Darbinieki D;
	i NUMBER;
BEGIN
	DBMS_OUTPUT.PUT_LINE('-------------------------------------');
	i := 0;
	OPEN SlrCsr;
	IF SlrCsr%ISOPEN THEN
		LOOP
			FETCH SlrCsr INTO Darb;
			EXIT WHEN SlrCsr%NOTFOUND;
			IF Darb.Alga >= 400 THEN
				p_Vards(i) := Darb.Vards;
				p_Alga(i) := Darb.Alga;
				DBMS_OUTPUT.PUT_LINE(to_char(i)||' '||p_Vards(i)||' '||p_Alga(i));
				i := i + 1;
			END IF;
		END LOOP;
	END IF;
	CLOSE SlrCsr;
END;
/

BEGIN
	IEN_IZK1;
END;
/

--------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE TYPE Pasutijumu_Tab AS TABLE OF Pasutijums;

CREATE OR REPLACE FUNCTION Pasut_Preces(Stat NUMBER) RETURN Pasutijumu_Tab PIPELINED AS
BEGIN
	FOR i IN (SELECT * FROM Pasutijumi WHERE Status = Stat)
		LOOP
			PIPE ROW(Pasutijums(i.PasutID,
								i.DarbID,
								i.PreceID,
								i.PasutDatums,
								i.Skaits,
								i.Status));
		END LOOP;
	RETURN;
END Pasut_Preces;
/

SELECT * FROM TABLE(Pasut_Preces(1));

--------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE PACKAGE InfPasutijumi AS
		FUNCTION Pasut_Preces(Stat NUMBER) RETURN Pasutijumu_Tab PIPELINED;
		PROCEDURE Pasut_Kopskats(p_Datums IN CHAR);
END InfPasutijumi;

CREATE OR REPLACE PACKAGE BODY InfPasutijumi AS
---------------------------------------
FUNCTION Pasut_Preces(Stat NUMBER) RETURN Pasutijumu_Tab PIPELINED AS
BEGIN
	FOR i IN (SELECT * FROM Pasutijumi WHERE Status = Stat)
		LOOP
			PIPE ROW(Pasutijums(i.PasutID,
								i.DarbID,
								i.PreceID,
								i.PasutDatums,
								i.Skaits,
								i.Status));
		END LOOP;
	RETURN;
END Pasut_Preces;
---------------------------------------
PROCEDURE Pasut_Kopskats(p_Datums IN CHAR) IS
		p_Daudzums Pasutijumi.Skaits%Type;
		p_Skaits Pasutijumi.PreceID%Type;
BEGIN
		SELECT COUNT(P.PreceID), SUM(P.Skaits) INTO p_Skaits, p_Daudzums
		FROM Pasutijumi P
		WHERE P.PasutDatums = (to_date(p_Datums, 'dd.mm.yyyy'));
		DBMS_OUTPUT.PUT_LINE('---------------------');
		DBMS_OUTPUT.PUT_LINE('Datums: '|| p_Datums);
		DBMS_OUTPUT.PUT_LINE('Kopejo pasutito precu skaits: '||p_Skaits);
		DBMS_OUTPUT.PUT_LINE('Kopejo pasutito precu daudzums: '|| p_Daudzums);	
EXCEPTION
		WHEN OTHERS THEN
			DBMS_OUTPUT.PUT_LINE('Ludzu, uzradiet datumu formata dd.mm.yyyy!');	
END Pasut_Kopskats;
---------------------------------------
END InfPasutijumi;
/

BEGIN
	InfPasutijumi.Pasut_Kopskats('12.12.2008');
END;
/
	
SELECT * FROM (TABLE(InfPasutijumi.Pasut_Preces(0)));		

------------------------------------------

CREATE OR REPLACE VIEW Darb_Skats OF Darbinieks WITH OBJECT ID (DarbID) AS
SELECT * FROM Darbinieki; 	

CREATE OR REPLACE TYPE BODY Darbinieks AS
	MAP MEMBER FUNCTION Samaksa RETURN REAL IS
		BEGIN
			RETURN (SELF.Alga+SELF.Premija);
		END Samaksa;
END;

SELECT VALUE(A) 
FROM Darb_Skats A
ORDER BY VALUE(A);	

COLUMN VARDS FORMAT A5
COLUMN UZVARDS FORMAT A7
COLUMN AMATS FORMAT A15
COLUMN ALGA FORMAT 999.99
COLUMN PREMIJA FORMAT 99.99

SELECT VALUE(D).Vards AS VARDS, VALUE(D).Uzvards AS UZVARDS, VALUE(D).Amats AS AMATS, 
		VALUE(D).Alga AS ALGA, VALUE(D).Premija AS PREMIJA
FROM Darb_Skats D
ORDER BY VALUE(D) DESC;

------------------------------------------

CREATE OR REPLACE VIEW Pasut_Skats OF Pasutijums WITH OBJECT ID (PasutID) AS
SELECT * FROM Pasutijumi;

CREATE OR REPLACE TYPE BODY Pasutijums AS
ORDER MEMBER FUNCTION Kartot_Datum(p Pasutijums) RETURN INTEGER AS
BEGIN
	IF PasutDatums < p.PasutDatums THEN RETURN -1;
		ELSE IF PasutDatums > p.PasutDatums THEN RETURN 1;
			ELSE RETURN 0;
		END IF;
	END IF;
	END Kartot_Datum;
END;

SELECT VALUE(P) 
FROM Pasut_Skats P
ORDER BY VALUE(P) DESC;

COLUMN ID FORMAT 99
COLUMN DAUDZUMS FORMAT 99
COLUMN PASUTDATUMS FORMAT A11

SELECT VALUE(P).PasutID AS ID, VALUE(P).Skaits AS DAUDZUMS, 
			VALUE(P).PasutDatums AS PASUTDATUMS 
FROM Pasut_Skats P
ORDER BY VALUE(P);

----------------------------------------------

CREATE OR REPLACE VIEW Preces_Skats OF Prece WITH OBJECT ID (PreceID) AS
SELECT * FROM Preces;

CREATE OR REPLACE TYPE BODY Prece AS
	MEMBER PROCEDURE Gala_Cena IS
	BEGIN
		SELF.Maksa := (SELF.Cena + (SELF.Cena * SELF.PVN/100) - (SELF.Cena * SELF.Atlaide/100));
	END Gala_Cena;
END;

DECLARE
	Pr Preces%ROWTYPE;
	m_Prece Prece;
	CURSOR PrCsr IS
	SELECT VALUE(P)
	FROM Preces P;
BEGIN
	OPEN PrCsr;
	IF PrCsr%ISOPEN THEN
		LOOP
			FETCH PrCsr INTO Pr;
			EXIT WHEN PrCsr%NOTFOUND;
			SELECT VALUE(P) INTO m_Prece FROM Preces P WHERE P.PreceID = Pr.PreceID; 
			m_Prece.Gala_Cena();
			DELETE FROM Preces P WHERE P.PreceID = Pr.PreceID;
			INSERT INTO Preces VALUES (m_Prece);
		END LOOP;	
	END IF;
	CLOSE PrCsr;
END;

COLUMN Nosaukums FORMAT A13
COLUMN Cena FORMAT 0.99
COLUMN PVN FORMAT 99
COLUMN Atlaide FORMAT 99
COLUMN Maksa FORMAT 0.99

SELECT Nosaukums, Cena, PVN, Atlaide, Maksa FROM Preces_Skats;

----------------------------------------------------------

CREATE TABLE PriceLog (
			Pr NUMBER,
			OrderDate Date,
			LogDate Date,
			OldState NUMBER(1),
			NewState NUMBER(1));
			
CREATE TRIGGER LogPriceUpdate
	AFTER UPDATE OF Status ON Pasutijumi
	FOR EACH ROW
BEGIN
	INSERT INTO PriceLog(Pr, OrderDate, LogDate, OldState, NewState)
	VALUES (:OLD.PasutID, :OLD.PasutDatums, SysDate, :OLD.Status, :NEW.Status);
END;
/

UPDATE Pasutijumi SET Status = 1
WHERE PasutID = 6;

SELECT * FROM PriceLog;
 
----------------------------------------------------------

CREATE OR REPLACE TYPE Darbinieks2 AS OBJECT
(
			DarbID NUMBER,
			Vards VARCHAR2(15),
			Uzvards VARCHAR2(15),
			Alga NUMBER(6,2)
)
/

CREATE OR REPLACE TYPE Pasutijums2 AS OBJECT
(
	PasutID NUMBER,
	Prece VARCHAR(25),
	Cena NUMBER(6,2),
	PVN NUMBER(3),
	Atlaide NUMBER(2),
	PasutDatums DATE,
	Skaits NUMBER(3)
)
/

CREATE TABLE Pasutijumi2 OF Pasutijums2;

BEGIN
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(1, 'Pildspalva', 0.25, 20, 10, to_date('14.12.2008','dd.mm.yyyy'), 3));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(2, 'Zimulis', 0.25, 10, 5, to_date('14.12.2008','dd.mm.yyyy'), 3));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(3, 'Rakstampapirs', 0.45, 20, 10, to_date('14.12.2008','dd.mm.yyyy'), 1));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(4, 'Planotajs', 0.65, 20, 10, to_date('15.12.2008','dd.mm.yyyy'), 1));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(5, 'Skavas', 0.15, 20, 10, to_date('15.12.2008','dd.mm.yyyy'), 2));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(6, 'Kalkulators', 0.98, 10, 5, to_date('15.12.2008','dd.mm.yyyy'), 1));
	INSERT INTO Pasutijumi2 VALUES 
	(Pasutijums2(7, 'Spraudes', 0.10, 8, 2, to_date('17.12.2008','dd.mm.yyyy'), 8));
END;

CREATE OR REPLACE TYPE Ref_Pasutijumi AS TABLE OF REF Pasutijums2;

CREATE TABLE Darbinieki2
(
		Darbinieks_t Darbinieks2,
		Pasutijumi_t Ref_Pasutijumi
)
NESTED TABLE Pasutijumi_t STORE AS ptr_Pasutijumi
/

DECLARE
			ats1 ref Pasutijums2;
			ats2 ref Pasutijums2;
			ats3 ref Pasutijums2;
			ats4 ref Pasutijums2;
			ats5 ref Pasutijums2;
			ats6 ref Pasutijums2;
			ats7 ref Pasutijums2;
BEGIN
			SELECT REF(P) INTO ats1
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Pildspalva';
			SELECT REF(P) INTO ats2
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Zimulis';
			SELECT REF(P) INTO ats3
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Rakstampapirs';
			SELECT REF(P) INTO ats4
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Planotajs';
			SELECT REF(P) INTO ats5
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Skavas';
			SELECT REF(P) INTO ats6
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Kalkulators';
			SELECT REF(P) INTO ats7
			FROM Pasutijumi2 P
			WHERE P.Prece = 'Spraudes';
			
			INSERT INTO Darbinieki2
			VALUES(Darbinieks2(1, 'Ieva', 'Zole', 350.89), Ref_Pasutijumi(ats1, ats2));
			INSERT INTO Darbinieki2
			VALUES(Darbinieks2(2, 'Girts', 'Osis', 550.89), Ref_Pasutijumi(ats3));
			INSERT INTO Darbinieki2
			VALUES(Darbinieks2(3, 'Janis', 'Lacis', 500.99), Ref_Pasutijumi(ats4, ats5));
			INSERT INTO Darbinieki2
			VALUES(Darbinieks2(4, 'Vilis', 'Spogis',  450.89), Ref_Pasutijumi(ats6, ats4));
			INSERT INTO Darbinieki2
			VALUES(Darbinieks2(5, 'Laima', 'Apse',  550.89), Ref_Pasutijumi(ats7));
END;

SELECT * FROM Darbinieki2 D
WHERE D.Darbinieks_t.DarbID = 1
OR
D.Darbinieks_t.DarbID = 2;

SELECT D.Darbinieks_t.Vards, D.Darbinieks_t.Uzvards, 
VALUE(P).Prece, VALUE(P).Skaits
FROM Darbinieki2 D, TABLE(D.Pasutijumi_t) P
WHERE VALUE(P).PasutDAtums = to_date('17.12.2008','dd.mm.yyyy');

CREATE OR REPLACE PROCEDURE ATSKAITE IS
	CURSOR cur IS
	SELECT D.Darbinieks_t.Vards, DEREF(VALUE(P))
	FROM Darbinieki2 D, TABLE(D.Pasutijumi_t) P;

	p_Vards Darbinieki2.Darbinieks_t.Vards%TYPE;
	p_Pasut Pasutijums2;
	Izmaksas REAL; 

BEGIN
	DBMS_OUTPUT.PUT_LINE('-------------------------------------');
	OPEN cur;
	IF cur%ISOPEN THEN
		LOOP
			FETCH cur INTO p_Vards, p_Pasut;
			EXIT WHEN cur%NOTFOUND;
			Izmaksas := (p_Pasut.Cena + (p_Pasut.Cena * p_Pasut.PVN/100) - 
						(p_Pasut.Cena * p_Pasut.Atlaide/100));
			DBMS_OUTPUT.PUT_LINE(p_Pasut.PasutDatums||', '||p_Vards||', '
								||to_Char(Izmaksas * p_Pasut.Skaits, '0.99')||', '||p_Pasut.Prece);
		END LOOP;
	END IF;
	CLOSE cur;
END;

BEGIN
	ATSKAITE;
END;