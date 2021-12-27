<?php
error_reporting(E_ALL ^ E_NOTICE);
	include_once( "../dao/theses_dao.php" );
	include_once( "../dao/thesis_title_dao.php" );
	include_once( "../dao/system_dao.php" );
	include_once( "../dao/student_dao.php" );
	include_once( "../dao/academics_dao.php" );
	
	$system_id = SessionUtils::getUserSystemId();
	//$system_id = 1;
	//get academic 
	$academic = AcademicsDAO::getBySystemId($system_id);
	$lecturer_id = $academic->academic_id;
	$institution_id = $academic->institution_id;
	$itemsPerPage = 10;
	
if(!isset($_GET['page_nr']))
{ 
	$page_nr = 0;
}else{ 
	$page_nr = $_GET['page_nr'];
}



function getNames($student_id, $names)
{
	$data = StudentDAO::getStudentById($student_id);
	$firstName = $data->firstName;
	$lastName = $data->lastName;
	$names = $firstName." ".$lastName;
	return $names;
}



if(!isset($_POST['newThesis']) && !isset($_POST['edit_thesis']) && !isset($_GET['student_id']) && !isset($_GET['thesis_id']) && !isset($_GET['_thesis_id'])&&  !isset($_POST['denyChThesis']))
{
	echo '<div class="post">
	<h1 class="title"><a href="index.php?user=superviser">Tēmu saraksts</a></h1><br />';
	$thesis = ThesesDAO::getThesisByLecturer($lecturer_id, $page_nr, $itemsPerPage);
	if($thesis != null)
	{
		echo '<table border="1" width="800" cellspacing="0" cellspadding="0">';
		echo '<tr class="head"><td width="30">Nr.</td><td width="330">Nosaukums</td><td width="100">Statuss</td><td width="150">Opcijas</td><td>Students</td></tr>';
		
		///echo $thesis['thesis_id'];
		//echo count($thesis);
		
		for($i=0; $i<count($thesis); $i++)
		{
			$thesis_id = $thesis[$i]->thesis_id;
			$default_native_title_id = $thesis[$i]->default_native_title_id;
			echo '<tr><td>'.($i+1+$page_nr*$itemsPerPage).'.</td>';
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
			echo '<td>
			<a href="index.php?user=superviser&page_nr='.$page_nr.'&_thesis_id='.$thesis_id.'">
			'.$thesis_title.'</a></td><td>';
			for($n=0; $n<count($statuss); $n++)
			{
				if($statuss[$n] != 0){ echo "Apstiprināta"; }else{ echo "Nav apstiprināta";}
				//echo $statuss[$n];
				if($n!=count($statuss)-1){ echo '<br />';}
			}
			echo '</td>
			<td>
			<form action="index.php?user=superviser&page_nr='.$page_nr.'&thesis_id='.$thesis_id.'" method="POST">
			<input type="submit" class="edit" name="edit_thesis" value="" />&nbsp;
			<input type="submit" class="delete" name="delete_thesis" value=""  onclick="return confirm(\'Dzēst tēmu: '.$thesis_title.' ?\')" /></form></td>
			<td>';
			for($n=0; $n<count($student); $n++)
			{
				echo '<a href="index.php?user=superviser&page_nr='.$page_nr.'&student_id='.$id[$n].'">'.$student[$n].'</a>';
				if($n!=count($student)-1){ echo '<br />';}
			}
			echo '</td></tr>';
			unset($student); unset($id); unset($statuss);
		}
	echo '</table>';
	
	//paging
	$query = sprintf("SELECT * FROM theses WHERE lecturer_id='%d'", $lecturer_id);
	$data = DbAccess::instance()->executeQuery($query);
	if(!$data->isEmpty())
	{
		foreach($data as $key => $record )
		{
			$student_id = $record['thesis_id'];
			$student[] = $student_id;
		}
	}
	$items = count($student);
	$pages_count = ceil($items/$itemsPerPage);

	echo '<h3>';
	for($p=0; $p<$pages_count; $p++)
	{
		if($pages_count < 2) break;
		echo '<a href="index.php?user=superviser&page_nr='.$p.'"> '.($p+1).' </a>';
	}
	echo '</h3>';
	}else{ echo 'Tēmu saraksts ir tukšs!'; }
	echo '</div><form action="index.php?user=superviser&page_nr='.$page_nr.'&createnewthesis" method="POST">
		<input type="submit" name="newThesis" value="Jauna tēma" />&nbsp;
		<input type="submit" onclick="javascript: window.open(\'../utils/report.php\', \'ATSKAITE\', \'toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,resizable=no,width=900,height=700\'); return false" name="reports" value="Atskaites" />
		</form></br>';
	
}

/// Jaunas tēmas pievienošana sarakstam [FORMA]
if(isset($_POST['newThesis']))
{
	
	echo '<div class="post">
	<form name="frmCreateThesis" action="index.php?user=superviser" method="POST">
	<table border="1" width="800" cellspacing="0" cellspadding="0">';
	echo '<tr><td colspan="2"><h1 class="title"><a href="#">Jaunas tēmas pievienošana</a></h1></td></tr>';
	echo '<tr><td>Tēmas nosaukums (LV): </td><td><input type="text" name="LV_ThesisTitle" size="71" /></td></tr>
	<tr><td>Tēmas nosaukums (EN): </td><td><input type="text" name="EN_ThesisTitle" size="71" /></td></tr>
	<tr><td>Tēmas apraksts: </td><td><textarea rows="5" cols="70" name="ThesisInf"></textarea></td></tr>
	<tr><td colspan="2"><input type="submit" name="addThesis" value="Pievienot" onclick="return check(frmCreateThesis); return confirm(\'Saglabāt jaunu tēmu?\')" />
	<input type="button" name="btnBack" value="Atpakaļ" onclick="history.back()"/></td></tr>';
	echo '</table></form></div>';
}

if(isset($_POST['addThesis']))
{
	$LV_title = $_POST['LV_ThesisTitle'];
	$EN_title = $_POST['EN_ThesisTitle'];
	$inf = $_POST['ThesisInf'];
	$curr_year = date("Y");
	
	// tabula THESIS:
	$tb_theses = new ThesisVO(null, null, $lecturer_id, $curr_year, null, null, $institution_id, null);
	$t_id = ThesesDAO::storeNewThesis($tb_theses);

	$tb_titles = new ThesisTitleVO(null, 0, 0, 0, 1, $t_id, $LV_title, time(), 1, null, null, 'LV', $inf);
	//get lv title id
	$lvTitle_id = ThesisTitleDAO::store($tb_titles);

	$tb_titles = new ThesisTitleVO(null, 0, 0, 0, 1, $t_id, $EN_title, time(), 1, null, null, 'EN', $inf);
	//get en title id
	$enTitle_id = ThesisTitleDAO::store($tb_titles);

	// update thesis
	$thesis = new ThesisVO($t_id, $lvTitle_id, $lecturer_id, $curr_year, null, null, $institution_id, $enTitle_id);
	ThesesDAO::updateThesis($thesis);
	echo '<script language="javascript">alert("Jauna tēma ir saglabāta!")</script>';
	echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
}
echo '<script language="javascript">
	function check(F){
		if(F.LV_ThesisTitle.value =="")
		{ 
			alert("Ievadiet tēmas nosaukumu!"); 
			F.LV_ThesisTitle.focus();
			return false
		}
		else
		{  
			return confirm(\'Saglabāt jaunu tēmu?\')}
		}
</script>';

// END:: Jaunas tēmas pievienošana sarakstam 
// Tēmas dzešana
if(isset($_POST['delete_thesis']) && isset($_GET['thesis_id']))
{
	$thesis_id = $_GET['thesis_id'];
	$delete = true;
	//parbaudīt vai tēmai ir piesaistīts students
	$query = sprintf("SELECT st.student_id FROM student_theses st, theses t WHERE st.thesis_id = t.thesis_id AND st.thesis_id ='%d'", $thesis_id);
	$data = DbAccess::instance()->executeQuery($query);
	if(!$data->isEmpty())
	{
		$data->next();
		$record = $data->current();
		$student_id = $record['student_id'];
		$delete = false;
	}
	if(!$delete)
	{
		//get student data
		$student = StudentDAO::getStudentById($student_id);
		echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
		echo '<script type="text/javascript">alert("Šo tēmu jau izvēlējies '.$student->firstName.' '.$student->lastName.'!\nDzēst nevar!")</script>';
	}else
	{
		$thesis_data = ThesesDAO::getThesisById($thesis_id);
		$lv_title_id = $thesis_data->default_native_title_id;
		ThesisTitleDAO::delete($lv_title_id);
		if($thesis_data->default_english_title_id != 0)
		{
			$en_title_id = $thesis_data->default_english_title_id;
			ThesisTitleDAO::delete($en_title_id);
		}
		ThesesDAO::deleteThesis($thesis_id);
		echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
		echo '<script type="text/javascript">alert("Tēma ir dzēsta!")</script>';
	}
}
// Tēmas modeficēšana
if(isset($_POST['edit_thesis'])&& isset($_GET['thesis_id']))
{
	$thesis_id = $_GET['thesis_id'];
	$thesis_data = ThesesDAO::getThesisById($thesis_id);
	$lv_title_id = $thesis_data->default_native_title_id;
	$en_title_id = $thesis_data->default_english_title_id;
	$title  = ThesisTitleDAO::getTitleById($lv_title_id );
	$thesis_title = $title->title;
	$inf = $title->comment;
	if($thesis_data->default_english_title_id != 0)
	{
		$title  = ThesisTitleDAO::getTitleById($en_title_id);
		$en_thesis_title = $title->title;
	}
	$th_id = $thesis_data->thesis_id;
	echo '<div class="post">
	<form name="frmEditThesis" action="index.php?user=superviser&thesis_id='.$thesis_id.'" method="POST">
	<table border="1" width="800" cellspacing="0" cellspadding="0">';
	echo '<tr><td colspan="4"><h1 class="title"><a href="#">Tēmas datu rediģēšana</a></h1></td></tr>';
	
	echo '<tr><td colspan="3">Tēmas nosaukums (LV): <input type="text" name="LV_ThesisTitle" value="'.$thesis_title.'" size="71" />
	<input type="hidden" name="lvTitleId" value="'.$lv_title_id.'" /></td></tr>
	<tr><td colspan="3">Tēmas nosaukums (EN): <input type="text" name="EN_ThesisTitle" value="'.$en_thesis_title.'" size="71" />
	<input type="hidden" name="enTitleId" value="'.$en_title_id.'" /></td></tr>
	<tr><td colspan="3">Tēmas apraksts: <br/>
	<textarea rows="5" cols="70" name="ThesisInf">'.$inf.'
	</textarea>
	</td></tr>
	<tr><td colspan="2"></br>
	<tr><td colspan="2"><input type="submit" name="saveThesisData" value="Saglabāt" onclick="return check(frmEditThesis);return confirm(\'Saglabāt izmaiņas?\')" />
	<input type="button" name="btnBack" value="Atpakaļ" onclick="history.back()"/></td></tr>';
	echo '</table></form></div>';
	//parbaudīt vai tēmai ir piesaistīts students
	$query = sprintf("SELECT st.student_id FROM student_theses st, theses t WHERE st.thesis_id = t.thesis_id AND st.thesis_id ='%d'", $thesis_id);
	$data = DbAccess::instance()->executeQuery($query);
	if(!$data->isEmpty())
	{
		//echo 'dfdfdf';
		foreach($data as $key => $record )
		{
			$student_id = $record['student_id'];
			$student[] = getNames($student_id, $names);			
		}
		//get student data
		///$student = StudentDAO::getStudentById($student_id[$st]);
		echo '<script type="text/javascript">alert("Šo tēmu jau izvēlējies ';
		for($st = 0; $st<count($student); $st++)
		{
			//$student = StudentDAO::getStudentById($student_id[$st]);
			echo $student[$st];
			if($st!=(count($student))-1){ echo ', ';}
		}
		echo '!")</script>';
		unset($student);
	}
}
if(isset($_POST['saveThesisData']))
{
	$lv_id = $_POST['lvTitleId'];
	$en_id = $_POST['enTitleId'];
	$lv_title = $_POST['LV_ThesisTitle'];
	$en_title = $_POST['EN_ThesisTitle'];
	$inf = $_POST['ThesisInf'];
	//get title info
	$lv = ThesisTitleDAO::getTitleById($lv_id);
	$titlesLV = new ThesisTitleVO($lv->titleId, $lv->lecturerApproved, $lv->bachelorApproved, $lv->cathedraApproved, $lv->revisionNember, $lv->thesisId, $lv_title, $lv->revisionDate, $lv->isActive, $lv->refusalReason, $lv->refusedBy, $lv->language, $inf);
	ThesisTitleDAO::update($titlesLV);
	if($en_id !=0)
	{
		$en = ThesisTitleDAO::getTitleById($en_id);
		$titlesEN = new ThesisTitleVO($en->titleId, $en->lecturerApproved, $en->bachelorApproved, $en->cathedraApproved, $en->revisionNember, $en->thesisId, $en_title, $en->revisionDate, $en->isActive, $en->refusalReason, $en->refusedBy, $en->language, $inf);
		ThesisTitleDAO::update($titlesEN);
	}
	echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
	echo '<script language="javascript">alert("Dati saglabāti!")</script>';
}
// ------------ END:: Tēmas modificēšana

// Apskatities studentu
if(isset($_GET['student_id']))
{
	$student_id = $_GET['student_id'];
	$firstName = SystemDAO::getUserFirstName($student_id);
	$lastName = SystemDAO::getUserLastName($student_id);
	$e_mail = SystemDAO::getUserEmail($student_id);
	$thesis_data = ThesesDAO::getThesisByStudent($student_id);
	
	$title  = ThesisTitleDAO::getTitleById($thesis_data->default_native_title_id);
	$thesis_title = $title->title;
	//$lecturer_approved = $title->lecturerApproved;
	
	$inf = $title->comment;
	if($thesis_data->default_english_title_id != 0)
	{
		$title  = ThesisTitleDAO::getTitleById($thesis_data->default_english_title_id);
		$en_thesis_title = $title->title;
	}
	$th_id = $thesis_data->thesis_id;
	$st_thesis = ThesesDAO::getStudentThesisByStudentId($student_id);
	$statuss = $st_thesis->student_approved;
	// tēmas pieteikšanas datums:
	$student_thesis = ThesesDAO::getStudentThesisByStudentId($student_id);
	$apply_date = $student_thesis->apply_date;
	$lv_id = $student_thesis->native_title_id;
	$en_id = $student_thesis->english_title_id;
	$title = ThesisTitleDAO::getTitleById($lv_id);
	$lv_th_title = $title->title;
	if($en_id!=0)
	{
		$title = ThesisTitleDAO::getTitleById($en_id);
		$en_th_title = $title->title;
	}
	echo '<div class="post">
	<form action="index.php?user=superviser&studentID='.$student_id.'" method="POST">
	<table border="0" width="800" cellspacing="0" cellspadding="0">';
	echo '<tr><td colspan="3"><h1 class="title"><a href="#">Studenta dati</a></h1></td></tr>';
	echo '<tr><td colspan="2">Students: <input type="text" name="studentNames" value="'.$firstName.' '.$lastName.'" size="30" readonly="readonly" /><br/><br/></td>
	<td align="right">E-pasts: <input typr="text" name="e_mail" value="'.$e_mail.'" size="25" readonly="readonly" /><br/><br/></td></tr>';
	
	echo '<tr><td colspan="4">Pieteicas tēmai:</td></tr>
	<tr><td colspan="3">(LV):&nbsp;&nbsp;<input type="text" name="ThesisTitle" value="'.$thesis_title.'" size="71" readonly="readonly" />
	<input type="hidden" name="lvTitleId" value="'.$thesis_data->default_native_title_id.'" />
	<input type="hidden" name="thesis_id" value="'.$thesis_data->thesis_id.'" /></td></tr></td></tr>
	<tr><td colspan="3">(EN):&nbsp;<input type="text" name="ThesisTitle" value="'.$en_thesis_title.'" size="71" readonly="readonly" />
	<input type="hidden" name="enTitleId" value="'.$thesis_data->default_english_title_id.'" /><br /><br /></td></tr>
	<tr><td colspan="4">Tekoša tēma: </td></tr>
	<tr><td colspan="3">(LV):&nbsp;&nbsp;<input type="text" name="lvThesisTitle" value="'.$lv_th_title.'" size="71" readonly="readonly" /></td></tr>
	<tr><td colspan="3">(EN):&nbsp;<input type="text" name="enThesisTitle" value="'.$en_th_title.'" size="71" readonly="readonly" /><br /><br /></td></tr>
	<tr><td colspan="2">Tēmas apraksts: <br/>
	<textarea rows="5" cols="70" name="ThesisInf" readonly="readonly">'.$inf.'
	</textarea>
	</td></tr>
	<tr><td colspan="2"><td>
	Statuss: ';
	if($statuss ==0){ echo 'Nav apstiprināta';}else{ echo 'Apstiprināta';}
	echo '</td></tr>
	<tr><td colspan="2"></br>
	<input type="submit" name="denyChThesis" value="Atteikt izvēlēties tēmu" />
	<input type="submit" name="confirmThesis" value="Apstiprināt tēmu" onclick="return confirm(\'Apstiprināt tēmu?\')" />
	<input type="button" name="btnBack" value="Atpakaļ" onclick="history.back()"/>
	</td><td>Tēmas pieteikuma datums: '.$apply_date.'</td></tr>';
	echo '</table></form></div>';
}
// Tēmas izvēles atteikšana
if(isset($_POST['denyChThesis']))
{
	$thesis_id = $_POST['thesis_id'];
	$lvTitleId = $_POST['lvTitleId'];
	$student_id = $_GET['studentID'];
	//get lecturer data
	$lect = AcademicsDAO::getById($lecturer_id);
	$firstName = SystemDAO::getUserFirstName($lect->system_id);
	$lastName = SystemDAO::getUserLastName($lect->system_id);
	$lecturerNames = $firstName.' '.$lastName;
	//get student data
	$student = getNames($student_id, $names);
	//get Title data
	$title = ThesisTitleDAO::getTitleById($lvTitleId);
	echo $lecturer = getNames($lecturer_id, $names);
	echo '<div class="post">';
	echo '<form action="index.php?user=superviser&studentID='.$student_id.'" method="POST">
	<table border="1" width="800" cellspacing="0" cellspadding="0">';
	echo '<tr><td colspan="2"><h1 class="title"><a href="#">Tēmas izvēlēs atteikšana</a></h1></td></tr>';
	echo '<tr><td width="40">No ka: </td><td><input type="text" name="txtFrom" value="'.$lect->academic_degree.' '.$lecturerNames.'" /></td></tr>
	<tr><td width="40">Kam: </td><td><input type="text" name="txtTo" value="'.$student.'" /></td></tr>
	<tr><td colspan="2">Komentārs:<br />
	<textarea rows="5" cols="70" name="comment"></textarea>
	<input type="hidden" name="thesis_id" value="'.$thesis_id.'" /><br/></td></tr>
	<tr><td colspan="2"><input type="submit" name="confirmDenyThesis" value="Apstiprināt" onclick="return confirm(\'Atteikt studentam izvēlēties tēmu: '.$title->title.'?\')" />
	<input type="submit" name="btnTheses" value="Tēmu saraksts" /></td></tr>';
	echo '</table></form></div>';
}

if(isset($_POST['confirmDenyThesis']))
{
	$student_id = $_GET['studentID'];
	//paziņojuma sutīšana uz studenta e-pastu
	$comment = $_POST['comment'];
	
	//delete student_theses 
	ThesesDAO::deleteStudentThesis($student_id);
	echo '<script language="javascipt">alert("Studentam tika nosūtīts paziņojums par tēmas izvēles atteikumu!")</script>';
	echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
}
// Tēmas izvēles apstiprināšana
if(isset($_POST['confirmThesis']))
{
	$student_id = $_GET['studentID'];
	//get student_theses data
	$t = ThesesDAO::getStudentThesisByStudentId($student_id);
	$thesis_data = new StudentThesesVO ($student_id, $t->thesis_id, $t->apply_date, $t->native_title_id, $t->english_title_id, 1);
	ThesesDAO::updateStudentThesis($thesis_data);
	echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
}
/// Apskatities tēmu
if(isset($_GET['_thesis_id']))
{
	$thesis_id = $_GET['_thesis_id'];
	$thesis_data = ThesesDAO::getThesisById($thesis_id);
	$title  = ThesisTitleDAO::getTitleById($thesis_data->default_native_title_id);
	$thesis_title = $title->title;
	$inf = $title->comment;
	if($thesis_data->default_english_title_id != 0)
	{
		$title  = ThesisTitleDAO::getTitleById($thesis_data->default_english_title_id);
		$en_thesis_title = $title->title;
	}
	$th_id = $thesis_data->thesis_id;
	echo '<div class="post">
	<form action="index.php?user=superviser&page_nr='.$page_nr.'&thesis_id='.$thesis_id.'" method="POST">
	<table border="1" width="800" cellspacing="0" cellspadding="0">';
	echo '<tr><td colspan="4"><h1 class="title"><a href="#">Tēmas dati</a></h1></td></tr>';
	
	echo '<tr><td colspan="3">Tēmas nosaukums (LV): <input type="text" name="ThesisTitle" value="'.$thesis_title.'" size="71" readonly="readonly" /></td></tr>
	<tr><td colspan="3">Tēmas nosaukums (EN): <input type="text" name="ThesisTitle" value="'.$en_thesis_title.'" size="71" readonly="readonly" /></td></tr>
	<tr><td colspan="3">Tēmas apraksts: <br/>
	<textarea rows="5" cols="70" name="ThesisInf"  readonly="readonly">'.$inf.'
	</textarea>
	</td></tr>
	<tr><td colspan="2"></br>';
	echo '<input type="submit" name="edit_thesis" value="Rediģēt" /><input type="button" name="btnBack" value="Atpakaļ" onclick="history:back()"/></td></tr>';
	echo '</table></form></div>';
}
if(isset($_POST['btnTheses']))
{
	echo '<meta http-equiv="refresh" content="0; url=index.php?user=superviser">';
}	
?>