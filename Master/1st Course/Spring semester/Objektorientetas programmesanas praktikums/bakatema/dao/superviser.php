<?php
function getStudTheses(){
    $query =  mysql_query("
        SELECT SYS.first_name, SYS.last_name, SYS.email, TS.title 
        FROM student_theses ST, theses T, titles TS, students S,
        academics A, system SYS
        WHERE SYS.system_id=S.system_id AND S.student_id=ST.student_id AND
        ST.thesis_id=T.thesis_id AND ST.thesis_id=TS.thesis_id AND
        T.lecturer_id=A.academic_id AND A.academic_id='1'
        ");
    $query = mysql_fetch_array($query);
    return $query;
}

?>