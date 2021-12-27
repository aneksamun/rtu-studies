<?php 

include_once( "page_processor.php" );
include_once( "../utils/page_utils.php" );

class ContentPage implements PageProcessor
{
    protected $engine;
    
    public function __construct()
    {	
        $this->engine = new Smarty();
        $this->engine->setTemplateDir('../templates');
        $this->engine->setCompileDir('../templates/compiled');
    }
    
    public function execute()
    {
        PageUtils::setupPageHeader( $this );
        
        $this->engine->display('main_page.tpl');
    }
    
    public function setData( $key, $value )
    {
        $this->engine->assign( $key, $value );
    }
    
    public function getEngine()
    {
        return $this->engine;
    }
}

?>