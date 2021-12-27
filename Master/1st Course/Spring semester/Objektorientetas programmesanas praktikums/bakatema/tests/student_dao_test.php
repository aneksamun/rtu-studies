<?php

include_once( "../dao/student_dao.php" );

class StudentDAOTest
{
	public static function getStudentByEmailTest()
	{
		$students = StudentDAO::getStudentByEmail("berzs");
		StudentDAOTest::printRecords($students);
	}
	
	public static function updateStudentTest()
	{
		$student = StudentDAO::getStudentById(0);
		
		foreach ($student as $key => $value) {
			print "$key: $value\n";
		}
		
		$student->firstName = "none";
		$student->lastName = "none";
		$student->email = "none@none.lv";
		
		StudentDAO::updateStudent($student);
	}
	
	public static function deleteStudentTest()
	{
		StudentDAO::deleteStudentById(4);
	}
	
	public static function getStudentByCriteriaTest() 
	{
		$students = StudentDAO::getStudentByCriteria("berz");
		StudentDAOTest::printRecords($students);
	}
	
	private static function printRecords($records)
	{
		for($i = 0; $i < count($records); $i++) {
			foreach ($records[$i] as $key => $value) {
				print "$key: $value\n";
			}
		}	
	}
}

?>