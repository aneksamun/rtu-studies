Copyright (c) 2005, Oracle Corporation.  All rights reserved. 


DESCRIPTION

The following examples use the Oracle Spatial Java Class Library to read and write 
Geographic Markup Language (GML).  The Java example under the READ_GML 
directory, named talk_GML.java, demonstrates how to open an Oracle database 
connection, read geometry information from a user-defined table (with at least one 
column of type SDO_GEOMETRY) and print out well defined GML for the geometries 
returned in a SQL result set.  The Java example under the WRITE_GML directory, named 
TestManyGeoms.java, demonstrates how to consume and transform a pre-defined GML 
document into an Oracle JGeometry type.  The Oracle Spatial Java Class Library and 
associated GML examples can be used to read/write geometries from/to Oracle8i, 
Oracle9i and Oracle10g databases.

   
NOTES

In order to use the Oracle Spatial Java Class Library to read and write Geographic 
Markup Language (GML) the following requirements must be met:

1)	Must have an Oracle8i, Oracle9i or Oracle10g database with Locator or Spatial 
	installed
	-To run talk_GML.java, SDO_GEOMETRY objects must be present.  
2)	Must have a user/password account for the database with connect and resource 
	privileges
3)	Must be using the following supplied Oracle10g JDBC and utility libraries (JARs):
	-ojdbc14.jar
	-xmlparserv2.jar
	-sdoapi.jar
4)	Must use the version of sdoutl.jar that comes with one of the following:
	-Oracle Database 10.1.0.4
	-Oracle Database 10.2.0.x
	-Oracle Spatial Java Class Library on OTN
2)	Must have installed the Sun JDK version 1.4.2_04 or higher
		
		
COMPILE AND RUN INSTRUCTIONS

1)	Open a command line session and at the prompt type> java -version
2)	If you receive an error or the Java version is lower than 1.4.2_04, you must either 
	update your PATH with the existing JDK or install a new JDK
3)	Unzip GML_Examples.zip to a new directory (i.e. d:\examples\spatial) 
4)	Change to the directory where you unzipped the examples (i.e. 
	D:\spatial\GML\READ_GML or D:\spatial\GML\WRITE_GML) 
5)	In the READ_GML directory, edit talk_GML.java.  Subsitute database connection and 
	query information with information local to your environment
6)	Edit the gml_compile_and_run.txt documents to reflect your Oracle10g database 
	environment (i.e. substitute [ORACLE_DB_HOME] for the path to your local database 
	environment such as D:\oracle\product\10.2.0\db_2)
6)	To compile, type the compile command at the prompt> javac -classpath.....
7)	To run, type the run command at the prompt> java -cp......
