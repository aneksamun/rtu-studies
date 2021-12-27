<?php

include_once( "../resources/init.php" );
include_once( "../utils/session_utils.php" );
include_once( "../utils/server_utils.php" );
include_once( "../config.php" );

// application init
Init::prepareSession();

if ( ServerUtils::checkRequestData( 'system_id', ServerUtils::DATA_SOURCE_POST ) )
{	// populate user data
	SessionUtils::setUserSystemId( 
			ServerUtils::getRequestData( 'system_id', ServerUtils::DATA_SOURCE_POST ) );	
	SessionUtils::setUserStudentId( 
			ServerUtils::getRequestData( 'student_id', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserFirstName(
			ServerUtils::getRequestData( 'first_name', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserLastName(
			ServerUtils::getRequestData( 'last_name', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserEmail(
			ServerUtils::getRequestData( 'email', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserGroup(
			ServerUtils::getRequestData( 'user_group', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserAcademicId(
			ServerUtils::getRequestData( 'academic_id', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserInstitutionId(
			ServerUtils::getRequestData( 'institution_id', ServerUtils::DATA_SOURCE_POST ) );
	SessionUtils::setUserAcademicDegree(
			ServerUtils::getRequestData( 'academic_degree', ServerUtils::DATA_SOURCE_POST ) );
	
	// redirect and stop current execution
	ServerUtils::redirect( Config::getDefaultPage() );
}

?>

<body>
	<form action="<?php echo ServerUtils::getCurrentUrl() ?>" method="post">
		<span>System ID:</span><input id="system_id" name="system_id" value="123"><br/>
		<span>Student ID:</span><input id="student_id" name="student_id" value="123AB4567"><br/>
		<span>Academic ID:</span><input id="academic_id" name="academic_id" value="12345"><br/>
		<span>Institution ID:</span><input id="institution_id" name="institution_id" value="321"><br/>
		<span>Academic degree:</span><input id="academic_degree" name="academic_degree" value="Asoc. Prof."><br/>
		<span>First Name:</span><input id="first_name" name="first_name" value="John"><br/>
		<span>Last Name:</span><input id="last_name" name="last_name" value="Doe"><br/>
		<span>Email:</span><input id="email" name="email" value="john@doe.com"><br/>
		<span>User group:</span><select id="user_group" name="user_group">
			<option value="1">Student</option>
			<option value="2">Lecturer</option>
			<option value="3">BachLecturer</option>
			<option value="4">Cathedra</option>
			<option value="5">Bookkeeper</option>
		</select>
		<button type="submit">Run</button>
	</form>
</body>