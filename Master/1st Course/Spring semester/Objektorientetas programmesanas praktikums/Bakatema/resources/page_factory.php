<?php 

include_once( "../pages/index_page.php" );
include_once( "../pages/about_page.php" );
include_once( "../pages/bach_lecturer_home_page.php" );
include_once( "../pages/bach_lecturer_action_page.php" );
include_once( "../pages/cath_home_page.php" );
include_once( "../pages/cath_action_page.php" );
include_once( "../pages/booker_invite_page.php" );
include_once( "../pages/booker_invite_action_page.php" );
include_once( "../pages/booker_order_page.php" );
include_once( "../pages/student_home_page.php" );
include_once( "../pages/student_action_page.php" );

class Pages
{
    const Index 				= 'index';
    const StudentHome 			= 'student';
    const StudentAction			= 'student_action';
    const LecturerHome  		= 'lect';
    const BachLecturerHome  	= 'bach';
    const BachLecturerAction  	= 'bach_action';
    const CathedraHome  		= 'cath';
    const CathedraAction  		= 'cath_action';
    const BookerInvite			= 'booker_invite';
    const BookerInviteAction	= 'booker_invite_action';
    const BookerOrder			= 'booker_order';
    const About					= 'about';
}

class PageFactory
{
    public static function createPage( $pageName )
    {
        switch( $pageName )
        {
            case Pages::Index:
                return new IndexPage();
            case Pages::StudentHome:
                return new StudentHomePage();
            case Pages::StudentAction:
                return new StudentActionPage();
            case Pages::LecturerHome:
                throw new Exception( "LecturerHome page not implemented." );
            case Pages::BachLecturerHome:
                return new BachLecturerHomePage();
            case Pages::BachLecturerAction:
                return new BachLecturerActionPage();
            case Pages::CathedraHome:
                return new CathHomePage();
            case Pages::CathedraAction:
                return new CathActionPage();
            case Pages::BookerInvite:
                return new BookerInvitePage();
            case Pages::BookerInviteAction:
                return new BookerInviteActionPage();
            case Pages::BookerOrder:
                return new BookerOrderPage();
            case Pages::About:
                return new AboutPage();
            default:
                throw new Exception( "Unknown page." );
        }
    } 
}

?>