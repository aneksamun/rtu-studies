<?php 

include_once( "../resources/notification_service.php" );
include_once( "../resources/menu_factory.php" );
include_once( "../dao/student_dao.php" );
include_once( "../dao/thesis_title_dao.php" );
include_once( "../dao/theses_dao.php" );

class StudentActionPage extends ContentPage
{
	private $mode;
	private $nextpage;
	
	private function processAction()
	{
		if ( ServerUtils::checkRequestData( 'edit_title', ServerUtils::DATA_SOURCE_POST ) )
		{	// edit initiated
			$this->mode		= 'edit_title';
			$this->nextpage	= 'student_action'; // action should return to complete 
			$titleId 		= ServerUtils::getRequestData( 'edit_title', ServerUtils::DATA_SOURCE_POST );
			$title 			= ThesisTitleDAO::getTitleById( $titleId );
			 
			$this->engine->assign( 'title_id', $titleId );
			$this->engine->assign( 'old_title', $title->title );
			
			return 'Tēmas nosaukuma rediģēšana.';
		}
		if ( ServerUtils::checkRequestData( 'update_title', ServerUtils::DATA_SOURCE_POST ) )
		{	// update initiated
			$titleId 		= ServerUtils::getRequestData( 'update_title', ServerUtils::DATA_SOURCE_POST );
			$title 			= ThesisTitleDAO::getTitleById( $titleId );
			$newTitle		= ServerUtils::getRequestData( 'new_title', ServerUtils::DATA_SOURCE_POST );
			
			if ( empty( $newTitle ) )
			{
				return 'Kļūda: Jaunais nosaukums ir tukšs.';
			}
			if ( strcmp( $newTitle, $title->title ) == 0 )
			{
				return 'Kļūda: Tēmas nosaukumi sakrīt.';
			}
			$title->title 				= $newTitle;
			$title->revisionNumber		+= 1;
			$title->revisionDate		= time();
			// remove approvals
			$title->lecturerApproved	= false;
			$title->bachelorApproved	= false;
			$title->cathedraApproved	= false;
			// TODO: thesis revision logic is required here
			ThesisTitleDAO::update( $title );
			
			$this->notify( $titleId, 'Tēmas nosaukums tika mainīts', 'Tēmas nosaukums tika mainīts.' );
			return 'Tēmas nosaukuma rediģēšana veiksmīga.';
		}
		if ( ServerUtils::checkRequestData( 'info', ServerUtils::DATA_SOURCE_POST ) )
		{
			$thesisId = ServerUtils::getRequestData( 'info', ServerUtils::DATA_SOURCE_POST );
			
			$this->mode		= 'approve_data';
			$this->nextpage	= 'student_action'; // action should return to complete
			$this->content	= 'content_title_log';
			
			$logLV = ThesisTitleDAO::getRevisionLogByThesis( $thesisId, 'LV' );
			$logEN = ThesisTitleDAO::getRevisionLogByThesis( $thesisId, 'EN' );

			$this->engine->assign( 'data_log_en', $logEN );
			$this->engine->assign( 'data_log_lv', $logLV );
			
			return;
		}
		if ( ServerUtils::checkRequestData( 'back', ServerUtils::DATA_SOURCE_POST ) )
		{	// back button pressed, redirect to index
			ServerUtils::redirect( Config::getDefaultPage() );
		}
		if ( ServerUtils::checkRequestData( 'select_thesis', ServerUtils::DATA_SOURCE_POST ) )
		{	// thesis selection
			// TODO: ugly hack to redirect to hardcoded page
			ServerUtils::redirect( "/student.php" );
		}
		return 'Komandas izpildes kļūda!';
	}
	
	private function notify( $titleId, $subject, $body )
	{
		$studentThesis 	= ThesisTitleDAO::getStudentThesesByTitleId( $titleId );
		$student 		= StudentDAO::getStudentById( $studentThesis->student_id );
		$thesis 		= ThesesDAO::getThesisById( $studentThesis->thesis_id );
		
		$to 	= array();
		$to[] 	= $student->systemId;
		$to[] 	= $thesis->lecturer_id;
		
		return NotificationService::instance()->sendNotification(
				SessionUtils::getUserSystemId(),
				$to,
				$subject,
				$body );
	}
	
	public function execute()
	{
		// security check 
		SessionUtils::checkAccess( UserGroup::Student );
		// mode, content and mextpage are populated by internal logic
		$this->mode 	= '';
		$this->nextpage = 'student';
		$this->content 	= 'content_student_action';
		
		$menu = MenuFactory::getMenu( MenuFactory::MENU_TYPE_STUDENT );
		$menu['student']->setSelected( true );
		
		$this->engine->assign( 'menu', $menu );
		
		$this->engine->assign( 'formaction', ServerUtils::getCurrentUrl() );
		
		$this->engine->assign( 'status', 	$this->processAction() );
		$this->engine->assign( 'mode', 		$this->mode );
		$this->engine->assign( 'nextpage', 	$this->nextpage );
		$this->engine->assign( 'content', 	$this->content );
		
		$this->engine->assign( 'pagetitle', '- Studenta izvēlne' );
		
		parent::execute();
	}
}

?>