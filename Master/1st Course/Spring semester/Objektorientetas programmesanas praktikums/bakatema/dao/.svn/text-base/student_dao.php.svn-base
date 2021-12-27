<?php

include_once( "../resources/db_access.php" );
include_once( "../domain/student_vo.php" );
include_once( "../utils/db_utils.php" );

// Student data access object
class StudentDAO
{
	public static function getStudentById( $id )
	{
		if (empty($id))
		{
			throw new Exception("Invalid student id.");
		}
		
		$query = sprintf( "SELECT st.student_id, sys.* FROM students st
				inner join system sys on st.system_id = sys.system_id
				where st.student_id = '%s' ",
				DbUtils::prepareString( $id ) );
		
		$data = DbAccess::instance()->executeQuery( $query );
		
		if ( !$data->isEmpty() )
		{
			$data->next();
			$record = $data->current();
			return new StudentVO( $record['student_id'], $record['system_id'], 
					$record['first_name'], $record['last_name'], $record['email'] );
		}
		throw new Exception("Invalid student id.");
	}
	
	public static function getStudentByEmail($email)
	{
		$query = sprintf("SELECT * FROM students st, system sys
						  WHERE st.system_id = sys.system_id 
						  AND sys.email LIKE '%s';", "%".$email."%");
				
		$data = DbAccess::instance()->executeQuery( $query );
		$result = array();
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new StudentVO( $record['student_id'], $record['system_id'], 
						$record['first_name'], $record['last_name'], $record['email'] );
			}
		}
		
		return $result;
	}
	
	public static function getStudents( $page, $itemsPerPage )
	{
		$result = array();
		$first 	= $page * $itemsPerPage;
		
		$query = sprintf( "SELECT st.student_id, sys.* FROM students st
				inner join system sys on st.system_id = sys.system_id
				limit %d, %d",
				$first,
				$itemsPerPage );
				
		$data = DbAccess::instance()->executeQuery( $query );
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new StudentVO( $record['student_id'], $record['system_id'], 
						$record['first_name'], $record['last_name'], $record['email'] );
			}
		}
		return $result;
	}
	
	public static function storeStudent( $student )
	{
		$db = DbAccess::instance();
		// TODO: add proper exception handling
		$db->beginTransaction();
		
		$query = sprintf( "insert into system(system_id, first_name, last_name, email)
				values( %d, '%s', '%s', '%s' )",
				$student->systemId,
				DbUtils::prepareString( $student->firstName ),
				DbUtils::prepareString( $student->lastName ),
				DbUtils::prepareString( $student->email ) );
		// save the system record first
		if ( !$db->executeNonQuery( $query ) )
		{
			$db->endTransaction( DbAccess::TRANS_ROLLBACK );
			return;
		}
		
		$query = sprintf( "insert into students(student_id, system_id)
				values( %d, %d )",
				$student->studentId,
				$student->systemId );
		// then try to save student record
		if ( !$db->executeNonQuery( $query ) )
		{
			$db->endTransaction( DbAccess::TRANS_ROLLBACK );
			return;
		}
		// commit once done
		$db->endTransaction( DbAccess::TRANS_COMMIT );
	}
	
	public static function updateStudent($student)
	{
		$db = DbAccess::instance();
		$db->beginTransaction();
		
		$query = sprintf("UPDATE system SET system_id = %d, first_name = '%s', last_name = '%s', email='%s'
				WHERE system_id = %d",
				$student->systemId,
				DbUtils::prepareString($student->firstName),
				DbUtils::prepareString($student->lastName),
				DbUtils::prepareString($student->email),
				$student->systemId);

		if (!$db->executeNonQuery($query))
		{
			$db->endTransaction( DbAccess::TRANS_ROLLBACK );
			return;
		}
		
		$query = sprintf("UPDATE students SET student_id = %d, system_id = %d WHERE system_id = %d;",
				$student->studentId,
				$student->systemId,
				$student->systemId);

		if (!$db->executeNonQuery($query))
		{
			$db->endTransaction(DbAccess::TRANS_ROLLBACK);
			return;
		}

		$db->endTransaction(DbAccess::TRANS_COMMIT);
	}
	
	public static function deleteStudentById($id)
	{
		if (!is_numeric($id))
		{
			throw new Exception("Invalid student id.");
		}
		
		$student = StudentDAO::getStudentById($id);
		
		if (is_null($student))
			return;
		
		StudentDAO::deleteStudent($student);
	}
	
	public static function deleteStudent($student)
	{
		$db = DbAccess::instance();
		$db->beginTransaction();
		
		$query = sprintf("delete from students where student_id = %d;", $student->studentId);
		
		if (!$db->executeNonQuery($query))
		{
			$db->endTransaction( DbAccess::TRANS_ROLLBACK );
			return;
		}
		
		$query = sprintf("delete from system where system_id = %d;", $student->systemId);
		
		if (!$db->executeNonQuery($query))
		{
			$db->endTransaction(DbAccess::TRANS_ROLLBACK);
			return;
		}

		$db->endTransaction(DbAccess::TRANS_COMMIT);
	}
	
	public static function getStudentByCriteria($criteria)
	{
		$result = array();

		// TODO: find solution how to apply one argument for multiple args.
		// %1$s don't works.
		
		$query = sprintf("SELECT st.*, sys.* FROM students st, system sys 
				WHERE st.system_id = sys.system_id 
				AND (st.student_id LIKE '%s'
				OR sys.system_id LIKE '%s'
				OR sys.first_name LIKE '%s' 
				OR sys.last_name LIKE '%s'
				OR sys.email LIKE '%s');",
				("%".$criteria."%"),
				("%".$criteria."%"),
				("%".$criteria."%"),
				("%".$criteria."%"),
				("%".$criteria."%")
		);
				
		$data = DbAccess::instance()->executeQuery( $query );
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new StudentVO( $record['student_id'], $record['system_id'], 
						$record['first_name'], $record['last_name'], $record['email'] );
			}
		}
		return $result;
	}
}

?>