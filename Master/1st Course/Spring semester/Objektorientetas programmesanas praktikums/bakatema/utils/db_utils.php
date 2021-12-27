<?php

class DbUtils
{
    public static function prepareString( $source )
    {
        return mysql_real_escape_string( $source );
    }
}

?>