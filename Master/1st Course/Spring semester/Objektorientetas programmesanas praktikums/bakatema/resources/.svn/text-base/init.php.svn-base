<?php

include_once( "../utils/session_utils.php" );

class Init
{
	private static $done = false;
	
	public static function prepareSession()
	{
		session_start();
	}
	
	public static function run()
	{  
		if ( !self::$done )
		{	// all the application init goes here
			self::prepareSession();
			
			// mandatory security check
			SessionUtils::checkSecure();
				
			// check if user is new to current system
			SessionUtils::checkUserRegistered();
		}
		$done = true;
	}
}

?>