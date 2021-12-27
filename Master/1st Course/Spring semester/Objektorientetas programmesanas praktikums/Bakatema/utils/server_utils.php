<?php
 
class ServerUtils
{
    const DATA_SOURCE_POST 			= 0;
    const DATA_SOURCE_GET 			= 1;
    const DATA_SOURCE_GET_OR_POST 	= 2;
    
    public static function redirect( $url )
    {
        header( "Location: " . dirname( $_SERVER['PHP_SELF'] ) 
                . self::encodeString( $url ) );
        die();
    }
    
    public static function encodeString( $source )
    {
        return htmlspecialchars( $source );
    }
    
    public static function checkRequestData( $key, $type = DATA_SOURCE_POST )
    {
        switch( $type )
        {
            case ServerUtils::DATA_SOURCE_POST: return isset( $_POST[$key] );
            case ServerUtils::DATA_SOURCE_GET:	return isset( $_GET[$key] );
            default:
                throw new Exception( "Invalid source type specified." );
        }
    }
    
    public static function getRequestData( $key, $type = DATA_SOURCE_POST )
    {
        switch( $type )
        {
            case ServerUtils::DATA_SOURCE_POST: return isset( $_POST[$key] ) ? $_POST[$key] : NULL;
            case ServerUtils::DATA_SOURCE_GET:	return isset( $_GET[$key] ) ? $_GET[$key] : NULL;
            
            case ServerUtils::DATA_SOURCE_GET_OR_POST:
                return isset( $_POST[$key] ) ? $_POST[$key] : ( isset( $_GET[$key] ) ? $_GET[$key] : NULL );
            default:
                throw new Exception( "Invalid source type specified." );
        }
    }
    
    public static function setRequestData( $key, $value, $type = DATA_SOURCE_POST )
    {
        switch( $type )
        {
            case ServerUtils::DATA_SOURCE_POST: $_POST[$key] 	= $value; return;
            case ServerUtils::DATA_SOURCE_GET:	$_GET[$key] 	= $value; return;
            default:
                throw new Exception( "Invalid source type specified." );
        }
    }
    
    public static function getCurrentUrl()
    {
        return $_SERVER['PHP_SELF'];
    }
}

?>
