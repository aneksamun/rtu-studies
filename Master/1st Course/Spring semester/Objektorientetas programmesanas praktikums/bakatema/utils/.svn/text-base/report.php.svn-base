<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Atskaite</title>
</head>
<body bgcolor="#ffffff">
<?php
error_reporting(E_ALL ^ E_NOTICE);
	include_once( "../dao/theses_dao.php" );
	include_once( "../dao/thesis_title_dao.php" );
	include_once( "../dao/system_dao.php" );
	include_once( "../dao/student_dao.php" );
	include_once( "../dao/academics_dao.php" );
	

	$system_id = 1;
	//get academic 
	$academic = AcademicsDAO::getBySystemId($system_id);
	$lecturer_id = $academic->academic_id;
	$institution_id = $academic->institution_id;
	
function getNames($student_id, $names)
{
	$data = StudentDAO::getStudentById($student_id);
	$firstName = $data->firstName;
	$lastName = $data->lastName;
	$mail = $data->email;
	$names = $firstName." ".$lastName." - ".$mail;
	return $names;
}	

	echo '
	<h1 class="title" style="font-family: Arial, Helvetica, sans-serif;font-size: 22px;color: #444444;">Tēmu saraksts</h1>
	<table border="1" width="800" cellspacing="0" cellspadding="0" style="font-family: Arial, Helvetica, sans-serif;font-size: 12px;color: #444444; border:1px solid #ddd;">';
	echo '<tr style="background-color:#ddd;font-weight:bold;border:none;"><td style="border:1px solid #ddd;">Nr.</td><td style="border:1px solid #ddd;">Tēmas nosaukums</td><td style="border:1px solid #ddd;">Statuss</td><td style="border:1px solid #ddd;">Students/i</td></tr>';
		$thesis = ThesesDAO::getAllThesisByLecturer($lecturer_id);
		
		///echo $thesis['thesis_id'];
		//echo count($thesis);
		$thesis_title='';
		$statuss='';
		$student_id='';

		for($i=0; $i<count($thesis); $i++)
		{
			$thesis_id = $thesis[$i]->thesis_id;
			$default_native_title_id = $thesis[$i]->default_native_title_id;
			echo '<tr><td style="border:1px solid #ddd;padding-left:3px;">'.($i+1).'.</td>';
			$title = ThesisTitleDAO::getTitleById($default_native_title_id);
			$thesis_title = $title->title;
			///$statuss = $title->lecturerApproved;
			//getStudentsbyThesisID
			$query = sprintf("SELECT st.student_id, st.student_approved FROM theses t, student_theses st WHERE t.thesis_id = st.thesis_id AND t.thesis_id='%s'", $thesis_id);
			$data = DbAccess::instance()->executeQuery($query);
					
					if(!$data->isEmpty())
					{
						foreach($data as $key => $record )
						{
							$student_id = $record['student_id'];
							$statuss[] = $record['student_approved'];
							$student[] = getNames($student_id, $names);
							
							$id[] = $student_id;
						}
					}
			
					// getStudent first and last names from system
					if($statuss != 0){ $status_msg ="Apstiprināta";}else{ $status_msg="Nav apstiprināta";}
					echo '<td style="border:1px solid #ddd;padding-left:3px;">'.$thesis_title.'</td><td style="border:1px solid #ddd;padding-left:3px;">';
					for($n=0; $n<count($statuss); $n++)
					{
						if($statuss[$n] != 0){ echo "Apstiprināta"; }else{ echo "Nav apstiprināta";}
						//echo $statuss[$n];
						if($n!=count($statuss)-1){ echo '<br />';}
					}
					echo'</td><td style="border:1px solid #ddd;padding-left:3px;">';

					for($n=0; $n<count($student); $n++)
					{
						if(count($student) != 0){ echo $student[$n]; }
						if($n!=count($student)-1){ echo '<br />';}
					}
					if (count($student)==0) echo '&nbsp;';
					echo '</td></tr>';

					unset($student); unset($id); unset($statuss);

			
		}
	echo '</table>';
?>
</body>
</html>