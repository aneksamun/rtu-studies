<?php 

include_once( "session_utils.php" );

class PageUtils
{
    public static function setupPageHeader( $page )
    {
        $page->setData( 'username', SessionUtils::getUserFirstName() . ' ' .SessionUtils::getUserLastName() );
        $page->setData( 'usergroup', SessionUtils::getUserGroup() );
        $page->setData( 'userid', SessionUtils::getUserSystemId() );
        $page->setData( 'debug', Config::isDebug() );
    }
}

?>