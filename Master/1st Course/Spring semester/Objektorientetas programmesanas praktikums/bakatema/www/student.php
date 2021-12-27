<?php
	include_once( "../resources/db_access.php" );
	include_once( "../resources/init.php" );
	include_once( "../resources/page_factory.php" );
	include_once( "../utils/session_utils.php" );
	
	// application init
	Init::run();

	$usergr = SessionUtils::getUserGroup();
	$usernm = SessionUtils::getUserFirstName();
	$userlm = SessionUtils::getUserLastName();
	$userfm = $usernm.' '.$userlm;
	$userid = SessionUtils::getUserSystemId();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

<title>Bakatema - Studenta izvēlne</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>
	<div class="main">
		<div class="head">
			<span class="logname"><? echo"Labdien, $userfm ";?>
			</span>
		</div>
		<div class="header">
			<div class="logo">
				<h1>
					<a href="#">BAKATEMA</a>
				</h1>
			</div>
			<p></p>
			<div class="clear"></div>

			<div class="menu">
				<ul>
					<li class="current"><a href="index.php">Sākums</a></li>
					<li><a href="?page=about">Par sistēmu</a></li>
				</ul>
			</div>
		</div>
		<div class="content">
			<div class="right">
				<div class="post">
<?php
	if (isset($_POST['system_id'])) {$system_id = $_POST['system_id'];} else {$system_id = 2;}
	if (!isset($system_id)) {exit("Lietotajs nav identificets");}
	if (isset($_POST['thesis_id'])) {$thesis_id = $_POST['thesis_id'];}
	if (isset($_POST['lecturer_id'])) {$lecturer_id = $_POST['lecturer_id'];}	
	$itemsPerPage = 10;
	$page = 0;
	$year = 2011;
	$selfLink = $_SERVER['PHP_SELF'];
	if (!isset($_POST['studentActivePage'])) {
		$lietotajamIrTema = mysql_query("select s_th.* 
										from student_theses s_th, students s
										where s.system_id = $system_id
										and s_th.student_id = s.student_id
										");
		if ($lietotajamIrTemaRow= mysql_fetch_array($lietotajamIrTema)) {$studentActivePage = 4;
		} else {$studentActivePage = 1;}
	} else
	{
		$studentActivePage = $_POST['studentActivePage'];
	}

if (!isset($system_id)) exit("Lietotajs nav identificets");

// smenitj  URL!!!
// smenitj  URL!!!
// smenitj  URL!!!
	$view_icon_url="images/viewIcon.png";
	
//$studentActivePage = 6 begin
if ($studentActivePage == 6) {
	$student_email = $_POST[student_email];
	$lecturer_email = $_POST[lecturer_email];
	$iemesls=$_POST['Iemesls'];
	
	// kogda vstavljajetsa soobwenie- ne 15--> ludwe sdelatj autoincrement v DB!!!
	// kogda vstavljajetsa soobwenie- ne 15--> ludwe sdelatj autoincrement v DB!!!
	// kogda vstavljajetsa soobwenie- ne 15--> ludwe sdelatj autoincrement v DB!!!
	$notification_insert = mysql_query("insert into notifications 
									   values(1, '$iemesls', '$lecturer_email', CURDATE(), $system_id ,0)");
	if (!$notification_insert) {echo "Ziņojuma sūtīšanas kļūda<br>";}
	$getStudentIdQuery = mysql_query("select student_id from students where system_id = $system_id");
	if ($StudentIdArray = mysql_fetch_array($getStudentIdQuery)){
		$Student_id = $StudentIdArray[student_id];
		$deleteTheseFromStudentQuery = mysql_query("delete from student_theses 
												   where student_id = $Student_id");
		if (!$deleteTheseFromStudentQuery) {echo "Tēmas atteikuma kļūda! Atteikums nav īstenots.";}
	} else {echo "Studenta identificēšanas kļūda! Atteikums nav īstenots.";}
	// perehod v na4alo: $studentActivePage=1;
	$studentActivePage=1;
}
//$studentActivePage = 6 end

//$studentActivePage = 1 begin
if ($studentActivePage == 1) {
	echo "<h1 class='title'>Tēmu saraksts</h1><br>";	
	showThesesList($page, $itemsPerPage, $year, $lecturer_id, $system_id, $view_icon_url, $selfLink);
}

	
function showThesesList($page, $itemsPerPage, $year, $lecturer_id, $system_id, $view_icon_url, $selfLink){
	echo "<form action=\"$selfLink\" method='post' name='Pieteiksanas_forma' target='_self'>
		<input name='studenta_id' id='studenta_id' type='hidden' value='$system_id' />
	<i>Vadītājs: </i><select name='lecturer_id' onChange='submit()'> -
	<option value = ''> </option>
	<option value = ''> Visi ... </option>";
	
	$pasniedzeju_saraksts =  mysql_query("select s.first_name, s.last_name, th.lecturer_id
									 from system s, theses th, academics a
									 where th.lecturer_id = a.academic_id
									 and a.system_id = s.system_id
									 group by s.last_name");
	
	while ($prow = mysql_fetch_array($pasniedzeju_saraksts)){
	echo "<option value = '$prow[lecturer_id]'> $prow[first_name] $prow[last_name] </option>";}
		echo "</select>
		</form>";

	if ((isset($lecturer_id)) && (!empty($lecturer_id))){
	$query = mysql_query("select th.*, t.title, a.academic_id, s.first_name, s.last_name
										 from system s, theses th, academics a, titles t
										 where a.system_id = s.system_id 
										 and th.lecturer_id = a.academic_id
										 and th.lecturer_id = $lecturer_id
										 and t.title_id = th.default_native_title_id
										 and th.academic_year = $year
										 order by th.lecturer_id");
	}
	else {
	$query = mysql_query("select th.*, t.title, a.academic_id, s.first_name, s.last_name
										 from system s, theses th, academics a, titles t
										 where a.system_id = s.system_id 
										 and th.lecturer_id = a.academic_id
										 and t.title_id = th.default_native_title_id
										 and th.academic_year = $year
										 order by th.lecturer_id");
	}
	
	echo "<table  border='1' width='800' cellspacing='0' cellspadding='0'> <tr class='head'><td><i>Tēmas nosaukums</i></td><td><i>Vadītājs</i></td><td><i>Apskatīt</i></td></tr>";

	
	while ($thesis = mysql_fetch_array($query)){
		echo "<tr valign='center'>
			<td>$thesis[title]</td>
			<td>$thesis[first_name] $thesis[last_name]</td>
			<td align = 'center'>
			<form action=\"$selfLink\" method='post' name='TemasApskate' target='_self' style = 'padding-bottom: 0px; margin : 0px;'/>	
			<input name='thesis_id' type='hidden' value='$thesis[thesis_id]' >
			<input name='studentActivePage' type='hidden' value='2' />
			<input name='system_id' type='hidden' value='$system_id' />			
			<input name='ApskatesSubmit' type='image' value=$thesis[thesis_id] src=$view_icon_url align='middle' hspace='1' vspace='1' border='1' alt = 'Submit' />
			</form>	
			</td>
		</tr>";
		
	}
	echo "</table>";
	
}
//$studentActivePage = 1 end;

//$studentActivePage = 2 begin
if ($studentActivePage == 2) {
	echo "<h1 class='title'>Tēmas apskate</h1><br>";	
	showThesisData($itemsPerPage, $page, $system_id, $thesis_id, $selfLink);
}

function showThesisData($itemsPerPage, $page, $system_id, $thesis_id, $selfLink){
	$query = mysql_query("select t.title, s.first_name, s.last_name, t.comment
			  from theses th, titles t, academics a, system s
			  where th.default_native_title_id = t.title_id
			  and th.thesis_id =  $thesis_id
			  and th.lecturer_id = a.academic_id
			  and a.system_id = s.system_id");
	$dati=mysql_fetch_array($query);

	$temasNosaukums = $dati[title];
	$darbaVaditajs = $dati[first_name]." ".$dati[last_name];
	$temasApraksts = $dati[comment];
	$maxWidth=300;
	echo "<table  border='1' width='800' cellspacing='0' cellspadding='0'>
	<tr> <td>Tēmas nosaukums:</td> <td colspan='2'>$temasNosaukums</td> </tr>
	<tr> <td>Darba vadītājs:</td> <td colspan='2'>$darbaVaditajs</td> </tr>
	<tr> <td>Tēmas apraksts:</td> <td width = '$maxWidth' style='word-wrap: break-word;' colspan='2'>$temasApraksts</td> </tr>
	<tr> <td> &nbsp </td> <td align='right'>  
		<form action='$selfLink' method='post' name='Pieteiksanas' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>
			<input name='temasNosaukums' type='hidden' value='$temasNosaukums' >
			<input name='darbaVaditajs' type='hidden' value='$darbaVaditajs' >			
			<input name='thesis_id' type='hidden' value='$thesis_id' >
			<input name='studentActivePage' type='hidden' value='3' />
			<input name='system_id' type='hidden' value='$system_id' />			
			<input name='pieteiktiesSubmit' type='submit' value='Pieteikties' />	
	</form> </td>
	<td align='left'>
	<form action='$selfLink' method='post' name='PieteiksanasAtpakal' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>	
			<input name='system_id' type='hidden' value='$system_id' />			
			<input name='pieteiktiesAtpakaļ' type='submit' value='Atpakaļ' />	
	</form>	
	</td> 
	</tr>	
	</table>";
}
//$studentActivePage = 2 end;

//$studentActivePage = 3 begin
if ($studentActivePage == 3) {
	echo "<h1 class='title'>Pazīņojums</h1><br>";	
	 $nos = $_POST[temasNosaukums];
	 $vad = $_POST[darbaVaditajs];
	 makePieteiksanas($nos, $vad, $thesis_id, $system_id, $selfLink);
}

function makePieteiksanas($temasNosaukums, $darbaVaditajs, $thesis_id, $system_id, $selfLink){
		$query = mysql_query("select s.student_id from students s where s.system_id = $system_id");
	$res = mysql_fetch_array($query); 
	$student_id = $res[student_id];
	$query = mysql_query("select  th.default_native_title_id, th.default_english_title_id
						 from theses th where th.thesis_id = $thesis_id");
	$res = mysql_fetch_array($query); 
	$native_title_id = $res[default_native_title_id];	
	$english_title_id = $res[default_english_title_id];
	$query = mysql_query("insert into student_theses 
						 values ($student_id, $thesis_id, CURDATE(), $native_title_id, $english_title_id)");
	echo "<table   border='1' width='800' cellspacing='0' cellspadding='0'>";
	if (!$query) {
		echo "<tr> <td> Kluda! Tema netika pievienota. </td></tr>";
	} else
	{
		echo "<tr> <td align='center'>Jus pieteicaties temai</td></tr>
		<tr> <td align='center'>Temas nosaukums: $temasNosaukums</td></tr>
		<tr> <td align='center'>Darba vaditajs: $darbaVaditajs</td></tr>
		";
	}
	echo "<tr> <td align = 'right'>
	<form action='$selfLink' method='post' name='okForma' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>	
			<input name='system_id' type='hidden' value='$system_id' />			
			<input name='OK' type='submit' value='Labi'/>	
	</form>	</td></tr>";
	echo "</table>";
	
}
//$studentActivePage = 3 end

//$studentActivePage = 4 begin
if ($studentActivePage == 4) {
	showStudentThesisData($system_id, $selfLink);
}

function showStudentThesisData($system_id, $selfLink){
	 
	$query = mysql_query("select t.title, s.first_name, s.last_name, s.email, t.is_active, t.comment
						 from titles t, student_theses s_th, theses th, academics a, system s, students st
						 where st.system_id = $system_id
						 and st.student_id = s_th.student_id
						 and s_th.thesis_id = th.thesis_id
						 and s_th.native_title_id = t.title_id
						 and t.thesis_id = th.thesis_id
						 and th.lecturer_id = a.academic_id
						 and a.system_id = s.system_id
						 ");
	$dati=mysql_fetch_array($query);

	$temasNosaukums = $dati[title];
	$darbaVaditajs = $dati[first_name]." ".$dati[last_name];
	$temasApraksts = $dati[comment];
	$isActive = $dati[is_active];
	$kontaktaEmail = $dati[email];
	$maxWidth=300;
	
	
	echo "<table   border='1' width='800' cellspacing='0' cellspadding='0'>
	<tr> <td>Tēmas nosaukums:</td> <td colspan='2'>$temasNosaukums</td> </tr>
	<tr> <td>Darba vadītājs:</td> <td colspan='2'>$darbaVaditajs</td> </tr>
	<tr> <td>Tēmas apraksts:</td> <td width = '$maxWidth' style='word-wrap: break-word;' colspan='2'>$temasApraksts</td> </tr>

	
	<tr>
	<td align='left'>
	<form action='$selfLink' method='post' name='Atteiksana' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>	
			<input name='system_id' type='hidden' value='$system_id' />	
			<input name='studentActivePage' type='hidden' value='5' />	
			<input name='Atteikties' type='submit' value='Atteikties' />	
	</form>
	</td> 
	
	<td colspan='2' align='right' valign='bottom'> <i><font size='2' color='#0000FF'>Darba vadītāja e-pasts: $kontaktaEmail</font></i></td>
	</tr>
	</table>";

}
//$studentActivePage = 4 end

//$studentActivePage = 5 start
if ($studentActivePage == 5) {
	echo "<h1 class='title'>Atteikuma logs</h1><br>";	
	showNotificationForm( $system_id);
}

function showNotificationForm( $system_id){
	$query=mysql_query("select s.first_name, s.last_name, s.email
					   from system s
					   where s.system_id = $system_id");
	$studenta_dati = mysql_fetch_array($query);
	$query=mysql_query("select s.first_name, s.last_name, s.email
					   from system s, academics a, theses th, students st, student_theses s_th
					   where st.system_id = $system_id
					   and st.student_id = s_th.student_id
					   and s_th.thesis_id = th.thesis_id
					   and th.lecturer_id = a.academic_id
					   and a.system_id = s. system_id
					   ");
	$vaditaja_dati = mysql_fetch_array($query);
	$noKa = $studenta_dati[first_name]." ".$studenta_dati[last_name];
	$kam = $vaditaja_dati[first_name]." ".$vaditaja_dati[last_name];
	$student_email = $studenta_dati[email];
	$lecturer_email = $vaditaja_dati[email];
	echo "<table   border='1' width='800' cellspacing='0' cellspadding='0'>
	<tr>
		<td>No kā:</td><td colspan='3' align='left'> $noKa </td>
	</tr>
	<tr>
		<td>Kam:</td><td colspan='3' align='left'> $kam </td>
	</tr>
	<tr><td colspan='4'> Iemesls: </td></tr>
	<tr><td colspan='4'> 
	<form action='$selfLink' method='post' name='AtteikumaForma' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>	
		<textarea name='Iemesls' cols='40' rows='10'></textarea>	
	</td></tr>
	<tr><td colspan='3' align='right'> 
			<input name='student_email' type='hidden' value='$student_email' />	
			<input name='lecturer_email' type='hidden' value='$lecturer_email' />	
			<input name='system_id' type='hidden' value='$system_id' />	
			<input name='studentActivePage' type='hidden' value='6' />	
			<input name='Apstiprinat' type='submit' value='Apstiprināt'/>	
	</form>
	</td><td align='left'>
	<form action='$selfLink' method='post' name='AtcelsanasForma' target='_self' style = 'padding-bottom: 0px; margin : 0px;'>	
			<input name='system_id' type='hidden' value='$system_id' />	

			<input name='Atcelt' type='submit' value='Atcelt'/>	
	</form>
	</td></tr>		
	</table>";
	
}
//$studentActivePage = 5 end
?>
				</div>
			</div>
			<div class="clear"></div>
		</div>

		<div class="footer">
			<p>Copyright by BAKATEMA @ 2011</p>
		</div>
	</div>
</body>
</html>