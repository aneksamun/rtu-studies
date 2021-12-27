<?php 

include_once( "../dao/thesis_title_dao.php" );

class ThesisTitleDAOTest
{	
	public static function storeTest()
	{		
		$title = new ThesisTitleVO( 456, false, true, false, 1, 1, 'some title', time(), 
				true, 'serious reason', 123, 'LV', 'cool title' );
				
		ThesisTitleDAO::store( $title );
		
		$loadedTitle = ThesisTitleDAO::getTitleById( $title->titleId );
		assert( $title->titleId == $loadedTitle->titleId );
		assert( $title->lecturerApproved == $loadedTitle->lecturerApproved );
		assert( $title->bachelorApproved == $loadedTitle->bachelorApproved );
		assert( $title->cathedraApproved == $loadedTitle->cathedraApproved );
		assert( $title->revisionNember == $loadedTitle->revisionNember );
		assert( $title->thesisId == $loadedTitle->thesisId );
		assert( $title->title == $loadedTitle->title );
		assert( date( "Ymd", $title->revisionDate ) == date( "Ymd", $loadedTitle->revisionDate ) );
		assert( $title->isActive == $loadedTitle->isActive );
		assert( $title->language == $loadedTitle->language );
		assert( $title->refusalReason == $loadedTitle->refusalReason );
		assert( $title->refusedBy == $loadedTitle->refusedBy );
		assert( $title->comment == $loadedTitle->comment );
	}
	
	public static function updateTest()
	{
		$title = ThesisTitleDAO::getTitleById( 456 );
		
		$title->title 			= 'changed title';
		$title->revisionDate 	= time();
		$title->refusalReason 	= 'new reason'; 
		
		ThesisTitleDAO::update( $title );
		
		$loadedTitle = ThesisTitleDAO::getTitleById( $title->titleId );
		
		assert( $title->title == $loadedTitle->title );
		assert( date( "Ymd", $title->revisionDate ) == date( "Ymd", $loadedTitle->revisionDate ) );
		assert( $title->refusalReason == $loadedTitle->refusalReason );
	}
	
	public static function getRefusedTitlesTest()
	{
		$title = ThesisTitleDAO::getTitleById( 456 );
		
		$title->thesisId 	= 123;
		$title->refusedBy 	= 321;
		
		$refusedTitles = ThesisTitleDAO::getRefusedByTitles( 123, 321, 0, 100 );
		assert( $title->title == $refusedTitles[0]->title );
		
		$anotherRefusedTitles = ThesisTitleDAO::getRefusedTitles( 123, 0, 100 );
		assert( $title->title == $anotherRefusedTitles[0]->title );
	}
	
	public static function getRevisionLogTest()
	{
		$title = ThesisTitleDAO::getTitleById( 456 );
		
		$title->thesisId = 987;
		$title->language = 'LV'; 
		
		ThesisTitleDAO::update( $title );
		
		$log = ThesisTitleDAO::getRevisionLogByThesis( 987, 'LV' );
		assert( $title->title == $log[0]->title );
	}
	
	public static function deleteTest()
	{
		assert( ThesisTitleDAO::delete( 456 ) );	
	}
	
	public static function run()
	{
		echo ( "ThesisTitleDAOTest started<br/>" );

		self::storeTest();
		self::updateTest();
		self::deleteTest();
		
		echo ( "ThesisTitleDAOTest done<br/>" );
	}
}

?>