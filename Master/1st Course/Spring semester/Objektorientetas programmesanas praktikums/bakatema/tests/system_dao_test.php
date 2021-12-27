<?php 

include_once( "../dao/system_dao.php" );

class SystemDAOTest
{
    public static function validateSystemIdTest()
    {
        assert( SystemDAO::validateSystemId( "String" ) == false );
        assert( SystemDAO::validateSystemId( -1 ) == false );
        assert( SystemDAO::validateSystemId( 1 ) == true );
    }
    
    private static function firesException( $function, $param )
    {
        $exceptionFired = false;
        try 
        {
            SystemDAO::$function( $param );	
        }
        catch ( Exception $e )
        {
            $exceptionFired = true;
        }
        return $exceptionFired;
    }
    
    public static function getUserFirstNameTest()
    {
        assert( self::firesException( "getUserFirstName", "String" ) );
        assert( self::firesException( "getUserFirstName", -1 ) );
        assert( !self::firesException( "getUserFirstName", 1 ) );
    }
    
    public static function getUserLastNameTest()
    {
        assert( self::firesException( "getUserLastName", "String" ) );
        assert( self::firesException( "getUserLastName", -1 ) );
        assert( !self::firesException( "getUserLastName", 1 ) );
    }
    
    public static function getUserEmailTest()
    {
        assert( self::firesException( "getUserEmail", "String" ) );
        assert( self::firesException( "getUserEmail", -1 ) );
        assert( !self::firesException( "getUserEmail", 1 ) );
    }
    
    public static function run()
    {
        echo ( "SystemDAOTest started<br/>" );
        
        self::validateSystemIdTest();
        self::getUserFirstNameTest();
        self::getUserLastNameTest();
        self::getUserEmailTest();
        
        echo ( "SystemDAOTest done<br/>" );
    }
}

?>