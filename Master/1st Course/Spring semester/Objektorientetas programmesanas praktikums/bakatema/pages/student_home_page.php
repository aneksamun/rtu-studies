<?php 

include_once( "content_page.php" );
include_once( "../config.php" );
include_once( "../dao/theses_dao.php" );
include_once( "../dao/thesis_title_dao.php" );
include_once( "../resources/menu_factory.php" );

class StudentHomePage extends ContentPage
{
    private function getThesisInfo()
    {
        $thesis = ThesesDAO::getThesisByStudent( SessionUtils::getUserStudentId() );
        $result = array();
        
        if ( isset( $thesis ) )
        {
            $nativeTitle                = ThesisTitleDAO::getActualTitleByThesisIs( $thesis->thesis_id, 'LV' );
            $englishTitle               = ThesisTitleDAO::getActualTitleByThesisIs( $thesis->thesis_id, 'EN' );
            $result['thesis_id']        = $thesis->thesis_id;
            $result['title_id_n']       = $nativeTitle->titleId;
            $result['title_id_e']       = $englishTitle->titleId;
            $result['native_title']     = $nativeTitle->title;
            $result['revision_date_n']  = date( 'd-m-Y', $nativeTitle->revisionDate );
            $result['revision_n']       = $nativeTitle->revisionNumber;
            $result['lect_approved_n']  = $nativeTitle->lecturerApproved;
            $result['bach_approved_n']  = $nativeTitle->bachelorApproved;
            $result['cath_approved_n']  = $nativeTitle->cathedraApproved;
            $result['english_title']    = $englishTitle->title;
            $result['revision_date_e']  = date( 'd-m-Y', $englishTitle->revisionDate );
            $result['revision_e']       = $englishTitle->revisionNumber;
            $result['lect_approved_e']  = $englishTitle->lecturerApproved;
            $result['bach_approved_e']  = $englishTitle->bachelorApproved;
            $result['cath_approved_e']  = $englishTitle->cathedraApproved;
            $result['lecturer_email']   = SystemDAO::getUserEmail( $thesis->lecturer_id );
            $result['lecturer_name']    = SystemDAO::getUserFirstName( $thesis->lecturer_id )
                    . ' ' . SystemDAO::getUserLastName( $thesis->lecturer_id );
            $result['bach_name']        = SystemDAO::getUserFirstName( $thesis->bachelor_approval_by )
                    . ' ' . SystemDAO::getUserLastName( $thesis->bachelor_approval_by );
            $result['cath_name']        = SystemDAO::getUserFirstName( $thesis->cathedra_approval_by )
                    . ' ' . SystemDAO::getUserLastName( $thesis->cathedra_approval_by );
        }
        return $result;
    }
    
    public function execute()
    {
        // security check 
        SessionUtils::checkAccess( UserGroup::Student );
        
        $menu = MenuFactory::getMenu( MenuFactory::MENU_TYPE_STUDENT );
        $menu['student']->setSelected( true );
        
        $this->engine->assign( 'menu', $menu );
        
        $this->engine->assign( 'content', 'content_student_home' );
        $this->engine->assign( 'formaction', ServerUtils::getCurrentUrl() );
        $this->engine->assign( 'nextpage', 'student_action' );
        
        $this->engine->assign( 'data_thesis', $this->getThesisInfo() );
        
        $this->engine->assign( 'pagetitle', '- Studenta izvēlne' );
        
        parent::execute();
    }
}

?>