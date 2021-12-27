<?php 

include_once( "../resources/notification_service.php" );
include_once( "../resources/menu_factory.php" );
include_once( "../dao/student_dao.php" );
include_once( "../dao/thesis_title_dao.php" );
include_once( "../dao/theses_dao.php" );

class CathActionPage extends ContentPage
{
    private $mode;
    private $nextpage;
    private $content;
    
    private function processAction()
    {
        if ( ServerUtils::checkRequestData( 'start_approve', ServerUtils::DATA_SOURCE_POST ) )
        {
            $this->mode		= 'approve_data';
            $this->nextpage	= 'cath_action'; // action should return to complete 
            $titleId 		= ServerUtils::getRequestData( 'start_approve', ServerUtils::DATA_SOURCE_POST );
            $title 			= ThesisTitleDAO::getTitleById( $titleId );
            
            $this->engine->assign( 'title_id', $titleId );
            $this->engine->assign( 'title', $title );
            
            return 'Tēmas apstiprināšana.';
        }
        if ( ServerUtils::checkRequestData( 'start_refuse', ServerUtils::DATA_SOURCE_POST ) )
        {
            $this->mode		= 'refuse_data';
            $this->nextpage	= 'cath_action'; // action should return to complete 
            $titleId 		= ServerUtils::getRequestData( 'start_refuse', ServerUtils::DATA_SOURCE_POST );
            $title 			= ThesisTitleDAO::getTitleById( $titleId );
            
            $this->engine->assign( 'title_id', $titleId );
            $this->engine->assign( 'title', $title );
            
            return 'Tēmas atteikšana.';
        }
        if ( ServerUtils::checkRequestData( 'approve', ServerUtils::DATA_SOURCE_POST ) )
        {	// title accepted
            $titleId 	= ServerUtils::getRequestData( 'approve', ServerUtils::DATA_SOURCE_POST );
            $title 		= ThesisTitleDAO::getTitleById( $titleId );
            $newTitle	= clone $title;
            // add new log record
            $newTitle->cathedraApproved = true;
            $newTitle->revisionNumber	+= 1;
            $newTitle->revisionDate		= time();
            $newTitle->comment			= '';
            $newTitle->refusalReason	= '';
            if ( ServerUtils::checkRequestData( 'approval_coment', ServerUtils::DATA_SOURCE_POST ) )
            {
                $newTitle->comment = ServerUtils::getRequestData( 'approval_coment', ServerUtils::DATA_SOURCE_POST );
            }
            $newTitleId = ThesisTitleDAO::store( $newTitle );
            if ( $newTitleId > 0 )
            {	// swap records
                ThesisTitleDAO::changeActiveTitle( $title, $newTitleId );
                // deactivate previous title record
                $title->isActive = false;
                ThesisTitleDAO::update( $title );
                $this->notify( $newTitleId, 'Tēmas apstiprinājums', 'Tēma tika apstiprināta:' . $newTitle->comment );
                return 'Tēma tika apstiprināta. Tēmas vadītājs, bakalaurantūtas vadītājs un piesaistītie studenti saņems e-pasta notifikāciju.';
            }
        }
        if ( ServerUtils::checkRequestData( 'refuse', ServerUtils::DATA_SOURCE_POST ) )
        {	// title refused
            $titleId 	= ServerUtils::getRequestData( 'refuse', ServerUtils::DATA_SOURCE_POST );
            $title 		= ThesisTitleDAO::getTitleById( $titleId );
            $newTitle	= clone $title;
            // add new log record
            $newTitle->refusedBy 		= SessionUtils::getUserSystemId();
            $newTitle->isActive			= false;
            $newTitle->revisionNumber	+= 1;
            $newTitle->revisionDate		= time();
            $newTitle->comment			= '';
            $newTitle->refusalReason	= '';
            if ( ServerUtils::checkRequestData( 'refusal_reason', ServerUtils::DATA_SOURCE_POST ) )
            {
                $newTitle->refusalReason = ServerUtils::getRequestData( 'refusal_reason', ServerUtils::DATA_SOURCE_POST );
            }
            $newTitleId = ThesisTitleDAO::store( $newTitle );
            if ( $newTitleId > 0 )
            {	// swap records
                ThesisTitleDAO::changeActiveTitle( $title, $newTitleId );
                // deactivate previous title record
                $title->isActive = false;
                ThesisTitleDAO::update( $title );
                $this->notify( $newTitleId, 'Tēmas atteikums', 'Tēma tika atteikta:' . $newTitle->refusalReason );
                return 'Tēma tika atteikta. Tēmas vadītājs, bakalaurantūtas vadītājs un piesaistītie studenti saņems e-pasta notifikāciju.';
            }
        }
        if ( ServerUtils::checkRequestData( 'info', ServerUtils::DATA_SOURCE_POST ) )
        {
            $titleId 	= ServerUtils::getRequestData( 'info', ServerUtils::DATA_SOURCE_POST );
            $title 		= ThesisTitleDAO::getTitleById( $titleId );
            
            $this->mode		= 'approve_data';
            $this->nextpage	= 'cath_action'; // action should return to complete
            $this->content	= 'content_title_log';
            
            $logLV = ThesisTitleDAO::getRevisionLogByThesis( $title->thesisId, 'LV' );
            $logEN = ThesisTitleDAO::getRevisionLogByThesis( $title->thesisId, 'EN' );

            $this->engine->assign( 'data_log_en', $logEN );
            $this->engine->assign( 'data_log_lv', $logLV );
            
            return;
        }
        if ( ServerUtils::checkRequestData( 'back', ServerUtils::DATA_SOURCE_POST ) )
        {	// back button pressed, redirect to index
            ServerUtils::redirect( Config::getDefaultPage() );
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
        $to[] 	= $thesis->bachelor_approval_by;
        
        return NotificationService::instance()->sendNotification(
                SessionUtils::getUserSystemId(),
                $to,
                $subject,
                $body );
    }
    
    public function execute()
    {
        // security check 
        SessionUtils::checkAccess( UserGroup::Cathedra );
        // mode, content and mextpage are populated by internal logic
        $this->mode 	= '';
        $this->nextpage = 'cath';
        $this->content 	= 'content_cath_action';
        
        $menu = MenuFactory::getMenu( MenuFactory::MENU_TYPE_CATHEDRA );
        $menu['cath']->setSelected( true );
        
        $this->engine->assign( 'menu', $menu );
    
        $this->engine->assign( 'formaction', ServerUtils::getCurrentUrl() );
        
        $this->engine->assign( 'status', 	$this->processAction() );
        $this->engine->assign( 'mode', 		$this->mode );
        $this->engine->assign( 'nextpage', 	$this->nextpage );
        $this->engine->assign( 'content', 	$this->content );
        
        $this->engine->assign( 'pagetitle', '- Katedras vadītāja izvēlne' );
        
        parent::execute();
    }
}

?>