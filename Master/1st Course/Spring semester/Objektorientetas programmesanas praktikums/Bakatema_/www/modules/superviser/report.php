<?php
error_reporting(E_ALL ^ E_NOTICE);
include_once( "../../../dao/theses_dao.php" );
    
/* ----------------------------------------------------------
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
$system_id = 1;

//get academic 
$academic = AcademicsDAO::getBySystemId($system_id);
$lecturer_id = 1;//$academic->academic_id;
$institution_id = 1;//$academic->institution_id;
    
function getNames($student_id, $names)
{
    $data = StudentDAO::getStudentById($student_id);
    $firstName = $data->firstName;
    $lastName = $data->lastName;
    $names = $firstName." ".$lastName;
    return $names;
}	

echo '
<table border="1" width="800" cellspacing="0" cellspadding="0">';
echo '<tr class="head"><td>Nr.</td><td>Nosaukums</td><td>Statuss</td><td>Students</td></tr>';
    $thesis = ThesesDAO::getAllThesisByLecturer($lecturer_id);
    
    ///echo $thesis['thesis_id'];
    //echo count($thesis);
    $thesis_title='';
    $statuss='';
    $student_id='';
    for($i=0; $i<count($thesis); $i++)
    {
        foreach ($thesis[$i] as $key => $value){
            if($key == 'thesis_id'){ $thesis_id = $value;}
            if($key == 'default_native_title_id')
            {
                echo '<tr><td>'.($i+1+$page*$itemsPerPage).'.</td>';
                //echo $value; 
                $title = ThesisTitleDAO::getTitleById($value);
                foreach ($title as $key => $value)
                {
                    if($key == 'title'){ $thesis_title = $value;}
                    if($key == 'lecturerApproved'){ $statuss = $value;}
                }
                //getStudentsbyThesisID
                $query = sprintf("SELECT st.student_id FROM theses t, student_theses st WHERE t.thesis_id = st.thesis_id AND t.thesis_id='%s'", $thesis_id);
                $data = DbAccess::instance()->executeQuery($query);
                
                if(!$data->isEmpty())
                {
                    foreach($data as $key => $record )
                    {
                        $student_id = $record['student_id'];
                        $student[] = getNames($student_id, $names);
                        $id[] = $student_id;
                        
                    }
                }//else{ $student ='';}
        
                // getStudent first and last names from system
                if($statuss != 0){ $status_msg ="Apstiprināta";}else{ $status_msg="Nav apstiprināta";}
                echo '<td>
                <a href="index.php?page=superviser&page_nr='.$page.'&_thesis_id='.$thesis_id.'">
                '.$thesis_title.'</a><td>'.$status_msg.'</td>';
                for($n=0; $n<count($student); $n++)
                {
                    echo $student[$n].'<br />';
                }
                echo '</td></tr>';
            }
            unset($student); unset($id);
        }
    }
echo '</table>';
?>