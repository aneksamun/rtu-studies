<?php 

include_once( "content_page.php" );

class IndexPage extends ContentPage
{
    public function execute()
    {
        $this->engine->assign( 'content', 'content_index' );
        
        $this->engine->assign( 'pagetitle', '- Home' );
        
        parent::execute();
    }
}

?>