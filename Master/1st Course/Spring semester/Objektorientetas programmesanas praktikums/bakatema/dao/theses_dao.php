<?php

include_once( "../resources/db_access.php" );
include_once( "../domain/thesis_vo.php" );
include_once( "../utils/db_utils.php" );

// Theses DAO
class ThesesDAO
{
	public static function getThesisById($thesis_id)
	{
		$query = sprintf("SELECT * FROM theses WHERE thesis_id='%s'", DbUtils::prepareString($thesis_id));
		$data = DbAccess::instance()->executeQuery($query);
		if(!$data->isEmpty())
		{
			$data->next();
			$record = $data->current();
			return new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
			);
		}
		return null;
	}
	public static function getThesisByStudent($student_id)
	{
		$query = sprintf( "SELECT st.*, th.* FROM student_theses st, theses th
			WHERE st.thesis_id = th.thesis_id AND student_id = '%s'",
			DbUtils::prepareString($student_id));	
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			$data->next();
			$record = $data->current();
			return new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
			);
		}
		return null;
	}
	
	public static function getThesisByLecturer($lecturer_id, $page, $itemsPerPage)
	{
		$first = $page*$itemsPerPage;
		$query = sprintf("SELECT * FROM theses WHERE lecturer_id='%s' limit %d, %d",
				DbUtils::prepareString($lecturer_id), $first, $itemsPerPage);
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			foreach($data as $key => $record )
			{
				$result[] =  new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	
	public static function getAllThesisByLecturer($lecturer_id)
	{
		$query = sprintf("SELECT * FROM theses WHERE lecturer_id='%s'",
				DbUtils::prepareString($lecturer_id));
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			foreach($data as $key => $record )
			{
				$result[] =  new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	
	public static function getThesisByInstitution($institution_id, $page, $itemsPerPage)
	{
		$first = $page*$itemsPerPage;
		$query = sprintf("SELECT * FROM theses WHERE institution_id = '%s' limit %d, %d",
			DbUtils::prepareString($institution_id), $first, $itemsPerPage);
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			foreach($data as $key => $record )
			{
				$result[] =  new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	public static function getThesisByYear($year, $page, $itemsPerPage)
	{
		$first = $page*$itemsPerPage;
		$query = sprintf("SELECT * FROM theses WHERE academic_year = '%s' limit %d, %d",
			DbUtils::prepareString($year), $first, $itemsPerPage);
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			foreach($data as $key => $record )
			{
				$result[] =  new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	public static function getAllTheses($page, $itemsPerPage)
	{
		$first = $page*$itemsPerPage;
		$query = sprintf("SELECT * FROM theses limit %d, %d", $first, $itemsPerPage);
		$data = DbAccess::instance()->executeQuery($query);
		if (!$data->isEmpty())
		{
			foreach($data as $key => $record )
			{
				$result[] =  new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	// store new Thesis
	public static function storeNewThesis($thesis)
	{
		$nid = self::getNextId();
		$query = sprintf("
		INSERT INTO theses (thesis_id, default_native_title_id, lecturer_id, bachelor_approval_by, cathedra_approval_by, academic_year, institution_id, default_english_title_id) 
			VALUES('%d', '%d', '%d', '%s', '%s','%d', '%d', '%d')",
			$nid,
			$thesis->default_native_title_id,
			$thesis->lecturer_id,
			DbUtils::prepareString($thesis->bachelor_approval_by),
			DbUtils::prepareString($thesis->cathedra_approval_by),
			$thesis->academic_year,
			$thesis->institution_id,
			$thesis->default_english_title_id);
		if( !DbAccess::instance()->executeNonQuery( $query ) )
		{
			return -1;
		}
		return $nid;
	}
	
	public static function getStudentThesisByStudentId($student_id)
	{
		$query = sprintf("SELECT st.student_id, st.thesis_id, st.apply_date, st.native_title_id, st.english_title_id, st.student_approved 
		FROM theses t, student_theses st WHERE t.thesis_id = st.thesis_id AND st.student_id='%s'", $student_id);
		$data = DbAccess::instance()->executeQuery($query);
		if(!$data->isEmpty())
		{
			$data->next();
			$record = $data->current();
			return new StudentThesesVO($record['student_id'], 
								$record['thesis_id'], 
								$record['apply_date'], 
								$record['native_title_id'], 
								$record['english_title_id'], 
								$record['student_approved']
			);
		}
		return null;
	}
	
	// store new to student table: student_theses
	public static function storeThesisToStudent($student_thesis)
	{
		$query = sprintf("
		INSERT INTO student_theses (student_id, thesis_id, apply_date, native_title_id, english_title_id, student_approved) 
			VALUES('%d', '%d', FROM_UNIXTIME(%d), '%d', '%d')",
			$student_thesis->student_id,
			$student_thesis->thesis_id,
			$student_thesis->apply_date,
			$student_thesis->native_title_id,
			$student_thesis->english_title_id,
			$student_thesis->student_approved);
		return DbAccess::instance()->executeNonQuery( $query );
	}
	/// delete Student (from student_theses)
	public static function deleteStudentThesis($student_id)
	{
		if(!is_numeric($student_id))
        {
            throw new Exception("Invalid student id.");
        }
        $query = sprintf("DELETE FROM student_theses WHERE student_id ='%d'", $student_id);
        return DbAccess::instance()->executeNonQuery($query);
	}
	//update table student_theses
	public static function updateStudentThesis($student_thesis)
	{
		$query = sprintf("UPDATE student_theses SET  thesis_id = '%d', apply_date = FROM_UNIXTIME(%d), native_title_id='%d', english_title_id='%d', student_approved='%d'
			WHERE student_id ='%d'",
			$student_thesis->thesis_id,
			$student_thesis->apply_date,
			$student_thesis->native_title_id,
			$student_thesis->english_title_id,
			$student_thesis->student_approved,
			$student_thesis->student_id);
		return DbAccess::instance()->executeNonQuery( $query );
	}
	//update table theses
	public static function updateThesis($thesis)
	{
		$query = sprintf("UPDATE theses SET  default_native_title_id = '%d', lecturer_id = '%d', bachelor_approval_by='%s', cathedra_approval_by='%s', academic_year='%d',
			institution_id='%d', default_english_title_id='%d' WHERE thesis_id ='%d'",
			$thesis->default_native_title_id,
			$thesis->lecturer_id,
			DbUtils::prepareString($thesis->bachelor_approval_by),
			DbUtils::prepareString($thesis->cathedra_approval_by),
			$thesis->academic_year,
			$thesis->institution_id,
			$thesis->default_english_title_id,
			$thesis->thesis_id);
		return DbAccess::instance()->executeNonQuery( $query );
	}
	//delete thesis (table thesis)
	public static function deleteThesis($thesis_id)
	{
		if(!is_numeric($thesis_id))
        {
            throw new Exception("Invalid thesis id.");
        }
        $query = sprintf("DELETE FROM theses WHERE thesis_id = '%d'", $thesis_id);
        return DbAccess::instance()->executeNonQuery($query);
	}
	public static function getThesesByBachApprover( $academicId, $page, $itemsPerPage )
	{
		if ( !is_numeric( $academicId ) )
		{
			throw new Exception( "Invalid academic id." );
		}
		$first = $page * $itemsPerPage;
		$query = sprintf( "SELECT * FROM theses t
				where t.bachelor_approval_by = %d limit %d, %d", 
				$academicId,
				$first, 
				$itemsPerPage );
		
		$data 	= DbAccess::instance()->executeQuery($query);
		$result = array();
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	
	public static function getThesesByCathApprover( $academicId, $page, $itemsPerPage )
	{
		if ( !is_numeric( $academicId ) )
		{
			throw new Exception( "Invalid academic id." );
		}
		$first = $page * $itemsPerPage;
		$query = sprintf( "SELECT * FROM theses t
				where t.cathedra_approval_by = %d limit %d, %d", 
				$academicId,
				$first, 
				$itemsPerPage );
		
		$data 	= DbAccess::instance()->executeQuery($query);
		$result = array();
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		return $result;
	}
	
	public static function getCatchedraApprovedTheses( $page, $itemsPerPage )
	{
		if ( !is_numeric( $page ) || $page < 0 )
		{
			throw new Exception( "Invalid page." );
		}
		
		if ( !is_numeric( $itemsPerPage ) || $itemsPerPage < 1 )
		{
			throw new Exception( "Invalid items per page." );
		}
		
		$first = $page * $itemsPerPage;
		
		$query = sprintf( "select th.* from theses th
						   where th.thesis_id in
								(select t.thesis_id from titles t
 								 where t.is_active = 1 and t.cathedra_approved = 1 
 							     group by t.thesis_id
 								 having count(t.thesis_id) = 2)
						   limit %d, %d;",
				$first,
				$itemsPerPage );
			
		$data 	= DbAccess::instance()->executeQuery( $query );
		$result = array();
		
		if ( !$data->isEmpty() )
		{
			foreach( $data as $key => $record )
			{
				$result[] = new ThesisVO($record['thesis_id'], 
								$record['default_native_title_id'], 
								$record['lecturer_id'], 
								$record['academic_year'], 
								$record['bachelor_approval_by'], 
								$record['cathedra_approval_by'], 
								$record['institution_id'],
								$record['default_english_title_id']
				);
			}
		}
		
		return $result;
	}
	
	public static function getStudentThesisByThesisId($thesisId)
	{
		$query = sprintf("select * from student_theses 
						  where thesis_id = %d;", 
						  $thesisId);
						  	
		$data = DbAccess::instance()->executeQuery($query);
		
		if (!$data->isEmpty())
		{
			$data->next();
			$record = $data->current();
			
			return new StudentThesesVO($record['student_id'], 
								$record['thesis_id'], 
								$record['apply_date'], 
								$record['native_title_id'], 
								$record['english_title_id'],
								""
			);
			
		}
		
		return null;
	}
	
	public static function getAppliedStudents( $thesisId, $page, $itemsPerPage )
	{
		if ( !is_numeric( $thesisId ) )
		{
			throw new Exception( "Invalid thesis id." );
		}
		$first = $page * $itemsPerPage;
		$query = sprintf( "SELECT sys.system_id, sys.first_name, sys.last_name, sys.email, s.student_id
				FROM student_theses st
				inner join students s on s.student_id = st.student_id
				inner join system sys on sys.system_id = s.system_id
				where st.thesis_id = %d limit %d, %d", 
				$thesisId,
				$first, 
				$itemsPerPage );
		
		$data 	= DbAccess::instance()->executeQuery($query);
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
	//get thesis id
	public static function getNextId()
	{
		$query = "select
  				case when max(thesis_id) is null then 1
  				else max(thesis_id) + 1 end next_id from theses";
		
		$data = DbAccess::instance()->executeQuery( $query );
		
		if ( $data->isEmpty() )
		{
			throw new Exception("Database logic error.");
		}
		$data->next();
		$record = $data->current();
		
		return $record['next_id'];
	}
}

?>