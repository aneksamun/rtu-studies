<?php 

include_once( "../lib/smarty/Smarty.class.php" );

interface PageProcessor
{
    public function execute();
    
    public function setData( $key, $value );
    
    public function getEngine();
}

?>