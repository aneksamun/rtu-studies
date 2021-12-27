<?php 

include_once( "content_page.php" );
include_once( "../config.php" );
include_once( "../dao/theses_dao.php" );
include_once( "../dao/thesis_title_dao.php" );
include_once( "../resources/menu_factory.php" );

class CathHomePage extends ContentPage
{
	private function getBachApprovedTitles()
	{
		// TODO: implement paging support
		$theses = ThesesDAO::getThesesByCathApprover( SessionUtils::getUserSystemId(), 0, 100 );
		$result = array();
		
		foreach( $theses as $thesis )
		{
			$nativeTitle = ThesisTitleDAO::getActualTitleByThesisIs( $thesis->thesis_id, 'LV' );
			if ( $nativeTitle->isActive == true 
					// and last record is lecturer approved while bach an cath approval pending
					&& $nativeTitle->lecturerApproved == true  
					&& $nativeTitle->bachelorApproved == true
					&& $nativeTitle->cathedraApproved == false )
			{
				$thesisData 					= array();
				$thesisData['thesis_id'] 		= $thesis->thesis_id;
				$thesisData['title_id'] 		= $nativeTitle->titleId;
				$thesisData['native_title'] 	= $nativeTitle->title;
				$thesisData['revision_date'] 	= date( 'd-m-Y', $nativeTitle->revisionDate );
				$thesisData['revision'] 		= $nativeTitle->revisionNumber;
				$thesisData['applied_students'] = ThesesDAO::getAppliedStudents( $thesis->thesis_id, 0, 100 );
				$thesisData['lecturer_email']	= SystemDAO::getUserEmail( $thesis->lecturer_id );
				$thesisData['lecturer_name']	= SystemDAO::getUserFirstName( $thesis->lecturer_id )
						. ' ' . SystemDAO::getUserLastName( $thesis->lecturer_id );
				
				$thesisData['bach_lecturer_name'] = SystemDAO::getUserFirstName( $thesis->bachelor_approval_by )
						. ' ' . SystemDAO::getUserLastName( $thesis->bachelor_approval_by );
						
				$result[] = $thesisData;
			}
			
			$englishTitle = ThesisTitleDAO::getActualTitleByThesisIs( $thesis->thesis_id, 'EN' );
			if ( $englishTitle->isActive == true 
					// and last record is lecturer approved while bach an cath approval pending
					&& $englishTitle->lecturerApproved == true  
					&& $englishTitle->bachelorApproved == true
					&& $englishTitle->cathedraApproved == false )
			{
				$thesisData 					= array();
				$thesisData['thesis_id'] 		= $thesis->thesis_id;
				$thesisData['title_id'] 		= $englishTitle->titleId;
				$thesisData['native_title'] 	= $englishTitle->title;
				$thesisData['revision_date'] 	= date( 'd-m-Y', $englishTitle->revisionDate );
				$thesisData['revision'] 		= $englishTitle->revisionNumber;
				$thesisData['applied_students'] = ThesesDAO::getAppliedStudents( $thesis->thesis_id, 0, 100 );
				$thesisData['lecturer_email']	= SystemDAO::getUserEmail( $thesis->lecturer_id );
				$thesisData['lecturer_name']	= SystemDAO::getUserFirstName( $thesis->lecturer_id )
						. ' ' . SystemDAO::getUserLastName( $thesis->lecturer_id );
				
				$thesisData['bach_lecturer_name'] = SystemDAO::getUserFirstName( $thesis->bachelor_approval_by )
						. ' ' . SystemDAO::getUserLastName( $thesis->bachelor_approval_by );
						
				$result[] = $thesisData;
			}
		}
		return $result;
	}
	
	public function execute()
	{
		// security check 
		SessionUtils::checkAccess( UserGroup::Cathedra );
		
		$menu = MenuFactory::getMenu( MenuFactory::MENU_TYPE_CATHEDRA );
		$menu['cath']->setSelected( true );
		
		$this->engine->assign( 'menu', $menu );
		
		$this->engine->assign( 'content', 'content_cath_home' );
		$this->engine->assign( 'formaction', ServerUtils::getCurrentUrl() );
		$this->engine->assign( 'nextpage', 'cath_action' );
		
		$this->engine->assign( 'data_titles', $this->getBachApprovedTitles() );
		
		$this->engine->assign( 'pagetitle', '- Katedras vadītāja izvēlne' );
		
		parent::execute();
	}
}

?>