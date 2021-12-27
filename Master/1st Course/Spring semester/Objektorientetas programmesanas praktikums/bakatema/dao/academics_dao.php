<?php
include_once( "../resources/db_access.php" );
include_once( "../domain/academics_vo.php" );
include_once( "../utils/db_utils.php" );

// Academics DAO
class AcademicsDAO {

    public static function getById($def_id) 
    {
        $query = sprintf("SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id 
                WHERE a.academic_id = '%s'",  
                DbUtils::prepareString($def_id));
        $data = DbAccess::instance()->executeQuery($query);
        if(!$data->isEmpty())
        {
            $data->next();
            $record = $data->current();
            return new AcademicsVO( $record['system_id'], 
                    $record['first_name'],
                    $record['last_name'],
                    $record['email'],
                    $record['academic_id'],
                    $record['role'],
                    $record['institution_id'],
                    $record['academic_degree'] );
        }
        return null;
    }

    public static function getBySystemId($def_sys_id) 
    {
        $query = sprintf("SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id 
                WHERE a.system_id = %d",  
                $def_sys_id);	
        $data = DbAccess::instance()->executeQuery($query);
        if(!$data->isEmpty())
        {
            $data->next();
            $record = $data->current();
            return new AcademicsVO($record['system_id'], 
                    $record['first_name'],
                    $record['last_name'],
                    $record['email'],
                    $record['academic_id'],
                    $record['role'],
                    $record['institution_id'],
                    $record['academic_degree']);
        }
        return null;
    }

    public static function getByRole($def_role, $def_start, $def_limit) 
    {
        $query = sprintf("SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id 
                WHERE a.role = %d 
                order by a.role 
                limit %d, %d", 
                $def_role, 
                $def_start, 
                $def_limit);	
        $data = DbAccess::instance()->executeQuery($query);
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record )
            {
                $result[] =  new AcademicsVO($record['system_id'], 
                        $record['first_name'],
                        $record['last_name'],
                        $record['email'],
                        $record['academic_id'],
                        $record['role'],
                        $record['institution_id'],
                        $record['academic_degree']);
            }
        }
        return $result;
    }

    public static function getByInstitution($def_institution, $def_start, $def_limit) 
    {
        $query = sprintf("SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id  
                WHERE a.institution_id = %d 
                order by a.institution_id limit %d, %d", 
                $def_role, 
                $def_start, 
                $def_limit);	
        $data = DbAccess::instance()->executeQuery($query);
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record )
            {
                $result[] =  new AcademicsVO($record['system_id'], 
                        $record['first_name'],
                        $record['last_name'],
                        $record['email'],
                        $record['academic_id'],
                        $record['role'],
                        $record['institution_id'],
                        $record['academic_degree']);
            }
        }
        return $result;
    }

    public static function getAll($def_start, $def_limit) 
    {
        $query = sprintf("SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id 
                limit %d, %d", 
                $def_start, 
                $def_limit);	
        $data = DbAccess::instance()->executeQuery($query);
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record )
            {
                $result[] =  new AcademicsVO($record['system_id'], 
                        $record['first_name'],
                        $record['last_name'],
                        $record['email'],
                        $record['academic_id'],
                        $record['role'],
                        $record['institution_id'],
                        $record['academic_degree']);
            }
        }
        return $result;
    }


    public static function storeNew( $academicData )
    {
        $db = DbAccess::instance();
        $db->beginTransaction();
        
        $query = sprintf( "insert into system(system_id, first_name, last_name, email)
                values( %d, '%s', '%s', '%s' )",
                $academicData->system_id,
                DbUtils::prepareString( $academicData->first_name ),
                DbUtils::prepareString( $academicData->last_name ),
                DbUtils::prepareString( $academicData->email ) );
        // save the system record first
        if ( !$db->executeNonQuery( $query ) )
        {
            $db->endTransaction( DbAccess::TRANS_ROLLBACK );
            return false;
        }
        
        $query = sprintf( "INSERT INTO academics (academic_id, role, institution_id, system_id, academic_degree) 
                        VALUES('%s', %d, %d, %d, '%s')",
                DbUtils::prepareString($academicData->academic_id),
                $academicData->role,
                $academicData->institution_id,
                $academicData->system_id,
                DbUtils::prepareString($academicData->academic_degree) );
                
        // then try to save academic record
        if ( !$db->executeNonQuery( $query ) )
        {
            $db->endTransaction( DbAccess::TRANS_ROLLBACK );
            return false;
        }
        // commit once done
        $db->endTransaction( DbAccess::TRANS_COMMIT );
        return true;
    }

    public static function delete($academic_id) 
    {
        $query = mysql_query("DELETE FROM academics WHERE academic_id = '%s' ", DbUtils::prepareString($academic_id));
        $data = DbAccess::instance()->executeQuery($query);
    }

    public static function update($academic_id, $field, $value)
    {
        $query = sprintf("UPDATE academics SET %s = '%s' WHERE academic_id = %s",
        DbUtils::prepareString($field),
        DbUtils::prepareString($value),
        DbUtils::prepareString($academic_id));
        $data = DbAccess::instance()->executeQuery($query);
    }

    public static function getStaffByRole( $role, $page, $itemsPerPage )
    {
        if ( !is_numeric( $role ) )
        {
            throw new Exception( "Invalid user group id." );
        }
        
        $first = $page * $itemsPerPage;
        
        $query = sprintf( "SELECT s.system_id, s.first_name, s.last_name,
                  s.email, a.academic_id, a.role, a.institution_id,
                  a.academic_degree
                FROM academics a
                inner join system s on s.system_id = a.system_id 
                WHERE a.role = %d
                LIMIT %d, %d;",
                $role,  
                $first, 
                $itemsPerPage);
                
        $data = DbAccess::instance()->executeQuery( $query );
        $result = array();
                
        if ( !$data->isEmpty() )
        {
            foreach( $data as $key => $record )
            {
                $result[] =  new AcademicsVO($record['system_id'], 
                        $record['first_name'],
                        $record['last_name'],
                        $record['email'],
                        $record['academic_id'],
                        $record['role'],
                        $record['institution_id'],
                        $record['academic_degree']);
            }
        }
        
        return $result;
    }
}

?>
