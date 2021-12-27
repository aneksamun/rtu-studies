<?php 

include_once( "content_page.php" );

class AboutPage extends ContentPage
{
    public function execute()
    {
        $menu = MenuFactory::getMenu( MenuFactory::getMenuTypeByUserGroup( SessionUtils::getUserGroup() ) );
        $menu['about']->setSelected( true );
        
        $this->engine->assign( 'menu', $menu );
        
        $this->engine->assign( 'content', 'content_about' );
        
        $this->engine->assign( 'pagetitle', '- Par sistēmu' );
        
        parent::execute();
    }
}

?>