<?php

include_once( "../config.php" );
include_once( "db_iterator.php" );

// singletone DB access class
class DbAccess
{
	private static $instance;

	private $db_connect_id;
	
	const TRANS_COMMIT 		= 0;
	const TRANS_ROLLBACK 	= 1;

	// Prevent users to clone the instance
	public function __clone()
	{
		trigger_error( 'Cloning not allowed.', E_USER_ERROR );
	}

	// Constructor
	private function __construct()
	{	// init
		mb_internal_encoding( "UTF-8" );
		$this->db_connect_id = mysql_connect( Config::getDbHost(), Config::getDbUser(), Config::getDbPass() ) or die( "Could not connect" );
		mysql_select_db(  Config::getDbSchema(), $this->db_connect_id );
		mysql_set_charset( 'utf8', $this->db_connect_id );
	}

	// The singleton method
	public static function instance()
	{
		if (!isset(self::$instance))
		{
			$c = __CLASS__;
			self::$instance = new $c;
		}

		return self::$instance;
	}

	// Execute query and provides result iterator
	public function executeQuery( $query = "", $fetchType = DbIterator::FETCH_ARRAY )
	{
		$result = @mysql_query( $query, $this->db_connect_id );

        if ( !$result ) 
        {
            throw new Exception( "Query Error: " . mysql_error() );
        }
      
        return new DbIterator( $result, $fetchType );
	}
	
	// Executes non-query 
	public function executeNonQuery( $query = "" )
	{
		$result = mysql_unbuffered_query( $query );
		
		if ( !is_bool( $result ) )
		{
			throw new Exception( "Invalid query type given." );
		}
		
		return $result;
	}
	
	// Begins transaction record
	public function beginTransaction()
	{
		mysql_query("START TRANSACTION");
	} 
	
	// Closes transaction record with specified action
	public function endTransaction( $action )
	{
		switch( $action )
		{
			case DbAccess::TRANS_COMMIT: 	mysql_query("COMMIT"); break;
			case DbAccess::TRANS_ROLLBACK: 	mysql_query("ROLLBACK"); break;
			default:
				throw new Exception( "Invalid action type specified." );
		}
	}
}
?>