<?php

include_once("content_page.php");
include_once("../config.php");
include_once("../dao/system_dao.php");
include_once("../dao/academics_dao.php");

class BookerInvitePage extends ContentPage
{
    /**
     * Gets lecturers list.
     * @return Ambigous <multitype:, number>
     */
    private function getLecturers()
    {
        $lecturers = AcademicsDAO::getStaffByRole( UserGroup::Lecturer, 0, 100 );
        $result = array();

        foreach ($lecturers as $lecturer)
        {
            $firstname = SystemDAO::getUserFirstName($lecturer->academic_id);
            $lastname = SystemDAO::getUserLastName($lecturer->academic_id);

            $lecturerData = array();
            $lecturerData['id'] = $lecturer->academic_id;
            $lecturerData['name'] = $firstname." ".$lastname;
            $lecturerData['qoute'] = Config::getStudentsQuote();
                
            $result[] = $lecturerData;
        }
        
        return $result;
    }
    
    
    /*
     * @see ContentPage::execute()
     */
    public function execute()
    {
        SessionUtils::checkAccess(UserGroup::Bookkeeper);
        
        $menu = MenuFactory::getMenu(MenuFactory::MENU_TYPE_BOOKER);
        $menu['booker_invite']->setSelected(true);
        
        $this->engine->assign('menu', $menu);
        
        $this->engine->assign('content', 'content_booker_invite');
        $this->engine->assign('formaction', ServerUtils::getCurrentUrl());
        
        $this->engine->assign('data_lecturers', $this->getLecturers());
        $this->engine->assign('nextpage', 'booker_invite_action');
        
        $this->engine->assign('pagetitle', '- Aicināt vadītājus');
        
        parent::execute();
    }
}

?>