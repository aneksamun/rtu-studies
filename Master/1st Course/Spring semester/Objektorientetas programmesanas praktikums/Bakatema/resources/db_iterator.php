<?php

// DB result iterator
class DbIterator implements Iterator
{
    // Result fetching modes
    const FETCH_ARRAY   = 0;
    const FETCH_OBJECTS = 1;
    const FETCH_ASSOC   = 2;

    private $data;
    private $type;
    private $dataCount  = 0;
    private $row        = false;
    private $index      = 0;

    public function __construct( $data, $fetchType = DbIterator::FETCH_ARRAY )
    {
        $this->data         = $data;
        $this->dataCount    = mysql_num_rows( $data );
        $this->type         = $fetchType;
    }
    
    public function __destruct()
    {
        if ( is_resource( $this->data ) ) 
        {
            mysql_free_result( $this->data );   
        }
    }
    
    private function fetch()
    {
        if ( $this->dataCount > 0 ) 
        {
            switch ( $this->type ) 
            {
                case DbIterator::FETCH_OBJECTS: 
                    $func = 'mysql_fetch_object';
                    break;
                case DbIterator::FETCH_ASSOC: 
                    $func = 'mysql_fetch_assoc';
                    break;
                case DbIterator::FETCH_ARRAY: 
                default: 
                    $func = 'mysql_fetch_array';
            }
            
            $this->row = $func( $this->data );
            $this->index++;
        }
    }
    
    public function isEmpty()
    {
        return $this->dataCount == 0;
    }
    
    public function rewind() 
    {
        if ( $this->dataCount > 0 ) 
        {
            mysql_data_seek( $this->data, 0 );
            $this->index = -1;  // fetch() will increment to 0
            $this->fetch();
        }
    }
    
    function current() 
    {
        return $this->row;
    }
    
    function key() 
    {
        return $this->index;
    }
    
    function next() 
    {
        $this->fetch();
    }
    
    function valid() 
    {
       return !($this->row === false);
    }
}
?>