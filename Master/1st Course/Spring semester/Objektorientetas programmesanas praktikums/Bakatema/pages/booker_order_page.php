<?php

include_once("content_page.php");
include_once("../dao/theses_dao.php");
include_once("../dao/thesis_title_dao.php");
include_once("../resources/menu_factory.php");

class BookerOrderPage extends ContentPage
{
    private function getCompletelyApprovedTheses()
    {
        $theses = ThesesDAO::getCatchedraApprovedTheses(0, 10);
        $result = array();

        foreach ($theses as $thesis)
        {
            $item = array();

            $native = ThesisTitleDAO::getNativeTitleByThesisId($thesis->thesis_id);
            $broad = ThesisTitleDAO::getBroadTitleByThesisId($thesis->thesis_id);
            
            $item["native_title"] = $native->title;
            $item["broad_title"] = $broad->title; 
            
            $firstname = SystemDAO::getUserFirstName($thesis->lecturer_id);
            $lastname = SystemDAO::getUserLastName($thesis->lecturer_id);
                
            $item["lecturer"] = $firstname." ".$lastname;

            $studentThesis = ThesesDAO::getStudentThesisByThesisId($thesis->thesis_id);
                
            $forename = (!is_null($studentThesis)) ? SystemDAO::getUserFirstName($studentThesis->student_id) : ' ';
            $surname = (!is_null($studentThesis)) ? SystemDAO::getUserLastName($studentThesis->student_id) : ' ';
                
            $item["student"] = $forename." ".$surname;
            
            $result[] = $item;
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
        $menu['booker_order']->setSelected(true);

        $this->engine->assign('menu', $menu);

        $this->engine->assign('content', 'content_booker_order');
        $this->engine->assign('formaction', ServerUtils::getCurrentUrl());
        
        $this->engine->assign('approvedTitles', $this->getCompletelyApprovedTheses());

        $this->engine->assign('nextpage', 'booker_order_page');

        $this->engine->assign('pagetitle', '- Veidot rīkojumus');

        parent::execute();
    }
}

?>