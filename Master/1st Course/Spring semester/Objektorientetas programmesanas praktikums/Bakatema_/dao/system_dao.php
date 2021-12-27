<?php

include_once( "../resources/db_access.php" );

// User group enum
class UserGroup
{
    const Student       = 1;
    const Lecturer      = 2;
    const BachLecturer  = 3;
    const Cathedra      = 4;
    const Bookkeeper    = 5;
}

// System data access object
class SystemDAO
{
    public static function validateSystemId( $id )
    {
        if ( !is_numeric( $id ) )
        {
            return false;
        }
        $query = sprintf( "SELECT * FROM system s
                where s.system_id = %d",
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( !$data->isEmpty() )
        {
            return true;
        }
        return false;
    }
    
    public static function getUserFirstName( $id )
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid system id." );
        }
        $query = sprintf( "SELECT s.first_name FROM system s
                where s.system_id = %d",
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( $data->isEmpty() )
        {
            throw new Exception( "Invalid system id." );
        }
        $data->next();
        $record = $data->current();
        
        return $record['first_name'];
    }
    
    public static function getUserLastName( $id )
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid system id." );
        }
        $query = sprintf( "SELECT s.last_name FROM system s
                where s.system_id = %d",
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( $data->isEmpty() )
        {
            throw new Exception( "Invalid system id." );
        }
        $data->next();
        $record = $data->current();
        
        return $record['last_name'];
    }
    
    public static function getUserEmail( $id )
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid system id." );
        }
        $query = sprintf( "SELECT s.email FROM system s
                where s.system_id = %d",
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( $data->isEmpty() )
        {
            throw new Exception( "Invalid system id." );
        }
        $data->next();
        $record = $data->current();
        
        return $record['email'];
    }
    
    public static function getUserGroup( $id )
    {
        throw new Exception( "Not implemented." );
    }
}

?>