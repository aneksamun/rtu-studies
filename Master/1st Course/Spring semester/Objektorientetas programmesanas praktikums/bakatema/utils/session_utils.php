<?php 

include_once( "../dao/system_dao.php" );
include_once( "../dao/student_dao.php" );
include_once( "../dao/academics_dao.php" );
include_once( "server_utils.php" );
include_once( "../config.php" );

class SessionUtils
{
    const SESSION_SYSTEM_ID 		= "system_id";
    const SESSION_STUDENT_ID 		= "student_id";
    const SESSION_ACADEMIC_ID 		= "academic_id";
    const SESSION_FIRST_NAME 		= "first_name";
    const SESSION_LAST_NAME 		= "last_name";
    const SESSION_EMAIL 			= "email";
    const SESSION_USER_GROUP		= "user_group";
    const SESSION_INSTITUTION_ID	= "institution_id";
    const SESSION_ACADEMIC_DEGREE	= "academic_degree";
    
    public static function getUserSystemId()
    {
        return $_SESSION[SessionUtils::SESSION_SYSTEM_ID];
    }
    
    public static function getUserStudentId()
    {
        return $_SESSION[SessionUtils::SESSION_STUDENT_ID];
    }
    
    public static function getUserAcademicId()
    {
        return $_SESSION[SessionUtils::SESSION_ACADEMIC_ID];
    }
    
    public static function getUserInstitutionId()
    {
        return $_SESSION[SessionUtils::SESSION_INSTITUTION_ID];
    }
    
    public static function setUserSystemId( $id )
    {
        if ( !is_numeric( $id ) )
        {
            trigger_error( 'SystemId must be numeric.', E_USER_ERROR );
        }
        $_SESSION[SessionUtils::SESSION_SYSTEM_ID] = $id;
    }
    
    public static function setUserStudentId( $id )
    {
        if ( is_null( $id ) )
        {
            trigger_error( 'StudentId must be valid.', E_USER_ERROR );
        }
        $_SESSION[SessionUtils::SESSION_STUDENT_ID] = $id;
    }
    
    public static function setUserAcademicId( $id )
    {
        if ( !is_numeric( $id ) )
        {
            trigger_error( 'Academic must be numeric.', E_USER_ERROR );
        }
        $_SESSION[SessionUtils::SESSION_ACADEMIC_ID] = $id;
    }
    
    public static function setUserInstitutionId( $id )
    {
        if ( !is_numeric( $id ) )
        {
            trigger_error( 'Institution must be numeric.', E_USER_ERROR );
        }
        $_SESSION[SessionUtils::SESSION_INSTITUTION_ID] = $id;
    }
    
    public static function setUserFirstName( $firstName )
    {
        $_SESSION[SessionUtils::SESSION_FIRST_NAME] = ServerUtils::encodeString( $firstName );
    }
    
    public static function setUserLastName( $lastName )
    {
        $_SESSION[SessionUtils::SESSION_LAST_NAME] = ServerUtils::encodeString( $lastName );
    }
    
    public static function setUserEmail( $email )
    {
        $_SESSION[SessionUtils::SESSION_EMAIL] = ServerUtils::encodeString( $email );
    }
    
    public static function setUserAcademicDegree( $degree )
    {
        $_SESSION[SessionUtils::SESSION_ACADEMIC_DEGREE] = ServerUtils::encodeString( $degree );
    }
    
    public static function getUserFirstName()
    {
        return $_SESSION[SessionUtils::SESSION_FIRST_NAME];
    }
    
    public static function getUserLastName()
    {
        return $_SESSION[SessionUtils::SESSION_LAST_NAME];
    }
    
    public static function getUserEmail()
    {
        return $_SESSION[SessionUtils::SESSION_EMAIL];
    }
    
    public static function getUserAcademicDegree()
    {
        return $_SESSION[SessionUtils::SESSION_ACADEMIC_DEGREE];
    }
    
    public static function isAuthenticated()
    {
        return isset( $_SESSION[SessionUtils::SESSION_SYSTEM_ID] );
    }
    
    public static function checkSecure()
    {
        if ( !self::isAuthenticated() )
        {
            ServerUtils::redirect( Config::getRegistrationPage() );
        }
    }
    
    public static function checkUserRegistered()
    {
        $sid = self::getUserSystemId();
    
        if ( !SystemDAO::validateSystemId( $sid ) )
        {
            ServerUtils::redirect( Config::getSignupPage() );
        }
    }
    
    public static function setUserGroup( $group )
    {
        if ( !is_numeric( $group ) )
        {
            trigger_error( 'User group invalid.', E_USER_ERROR );
        }
        $_SESSION[SessionUtils::SESSION_USER_GROUP] = $group;
    }
    
    public static function getUserGroup()
    {
        return $_SESSION[SessionUtils::SESSION_USER_GROUP];
    }
    
    public static function getRoleHomePage()
    {
        switch( self::getUserGroup() )
        {
            case UserGroup::Student:		return Config::getHomePageStudent();
            case UserGroup::Lecturer:		return Config::getHomePageLecturer();
            case UserGroup::BachLecturer:	return Config::getHomePageBachLecturer();
            case UserGroup::Cathedra:		return Config::getHomePageCathedra();
            case UserGroup::Bookkeeper:		return Config::getInvitePageBookkeeper();
            default: 						return 'index';
        }
    }
    
    public static function checkAccess( $role )
    {
        if ( self::getUserGroup() != $role )
        {
            die( 'Unauthorized access attempt' );
        }
    }
    
    public static function tryStoreUser()
    {
        switch ( self::getUserGroup() )
        {
            case UserGroup::Student: 
                StudentDAO::storeStudent( new StudentVO( 
                        self::getUserStudentId() , 
                        self::getUserSystemId(), 
                        self::getUserFirstName(), 
                        self::getUserLastName(), 
                        self::getUserEmail() ) );
                break;
                
            case UserGroup::Lecturer:
            case UserGroup::Cathedra:
            case UserGroup::Bookkeeper:
            case UserGroup::BachLecturer:
                AcademicsDAO::storeNew( new AcademicsVO(
                        self::getUserSystemId(), 
                        self::getUserFirstName(),
                        self::getUserLastName(),
                        self::getUserEmail(),
                        self::getUserAcademicId(), 
                        self::getUserGroup(), 
                        self::getUserInstitutionId(), 
                        self::getUserAcademicDegree() ) );
                break;
                
            default: 
                trigger_error( 'User data corrupted.', E_USER_ERROR );
        }
    }
}

?>