<?php 

include_once( "../dao/system_dao.php" );

class MenuEntry
{
	public $title;
	public $page;
	public $params;
	public $selected;
	
	public function __construct( $title, $page, $params )
	{
		$this->title 	= $title;
		$this->page		= $page;
		$this->params	= $params;
		$this->selected	= false;
	}
	
	public function setSelected( $selected )
	{
		if ( !is_bool( $selected ) )
		{
			throw new Exception( "Invalid parameter." );
		}
		$this->selected = $selected;
	}
}

class MenuFactory
{
	public static $studentMenu;
	public static $bachMenu;
	public static $cathMenu;
	public static $bookMenu;
	
	const MENU_TYPE_STUDENT 	= 0;
	const MENU_TYPE_BACHELOR 	= 1;
	const MENU_TYPE_CATHEDRA 	= 2;
	const MENU_TYPE_BOOKER		= 3;
	
	public static function getMenu( $type )
	{
		switch( $type )
		{
			case self::MENU_TYPE_STUDENT: 	return self::$studentMenu;
			case self::MENU_TYPE_BACHELOR: 	return self::$bachMenu;
			case self::MENU_TYPE_CATHEDRA: 	return self::$cathMenu;
			case self::MENU_TYPE_BOOKER:	return self::$bookMenu;
			default: 						throw new Exception( 'Invalid menu type' );
		}
	}
	
	public static function getMenuTypeByUserGroup( $role )
	{
		switch ( $role )
		{
			case UserGroup::BachLecturer: 	return self::MENU_TYPE_BACHELOR;
			case UserGroup::Cathedra: 		return self::MENU_TYPE_CATHEDRA;
			case UserGroup::Bookkeeper: 	return self::MENU_TYPE_BOOKER;
			case UserGroup::Student: 		return self::MENU_TYPE_STUDENT;
			default: 						throw new Exception( 'Menu type unavailable!' ); 
		}
	}
}

MenuFactory::$studentMenu = array( 
	'student' => new MenuEntry( 'Studentiem', 'student', '' ),
	'about' => new MenuEntry( 'Par sistēmu', 'about', '' )
);

MenuFactory::$bachMenu = array(
	'bach' => new MenuEntry( 'Galvenā', 'bach', '' ),
	'about' => new MenuEntry( 'Par sistēmu', 'about', '' )
);

MenuFactory::$cathMenu = array(
	'cath' => new MenuEntry( 'Galvenā', 'cath', '' ),
	'about' => new MenuEntry( 'Par sistēmu', 'about', '' )
);

MenuFactory::$bookMenu = array(
	'booker_invite' => new MenuEntry( 'Aicināt vadītājus', 'booker_invite', '' ),
	'booker_order' => new MenuEntry( 'Veidot rīkojumu un uzdevumus', 'booker_order', '' ),
	'about' => new MenuEntry( 'Par sistēmu', 'about', '' )
);

?>