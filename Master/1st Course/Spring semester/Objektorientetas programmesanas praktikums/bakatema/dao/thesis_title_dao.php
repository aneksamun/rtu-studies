<?php 

include_once( "../resources/db_access.php" );
include_once( "../domain/thesis_title_vo.php" );
include_once( "../utils/db_utils.php" );

// Thesis title data access object
class ThesisTitleDAO
{
    private static $langs = array( 'EN', 'LV' );
    
    public static function getTitleById( $id )
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid title id." );
        }
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, 
                  t.refusal_reason, t.refused_by, t.language, t.comment
                FROM titles t
                WHERE t.title_id = %d;",
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( !$data->isEmpty() )
        {
            $data->next();
            $record = $data->current();
            
            return new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                    $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                    $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                    $record['language'], $record['comment'] );
        }
        throw new Exception( "Invalid title id." );
    }
    
    public static function getRevisionLogByThesis( $thesisId, $lang )
    {
        if ( !in_array( $lang, self::$langs ) )
        {
            throw new Exception( "Invalid language." );
        }
        if ( !is_numeric( $thesisId ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, t.refusal_reason,
                  t.refused_by, t.language, t.comment
                FROM titles t
                WHERE t.thesis_id = %d and t.language = '%s'
                ORDER BY t.revision_number desc;",
                $thesisId,
                DbUtils::prepareString( $lang ) );
                
        $data 	= DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if ( !$data->isEmpty() )
        {
            foreach( $data as $key => $record )
            {
                $result[] = new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                        $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                        $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                        $record['language'], $record['comment'] );
            }
        }
        return $result;
    }
    
    public static function getRevisionLogByStudent( $studentId, $lang )
    {
        if ( !in_array( $lang, self::$langs ) )
        {
            throw new Exception( "Invalid language." );
        }
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, t.refusal_reason,
                  t.refused_by, t.language, t.comment
                FROM titles t
                inner join student_theses st on st.thesis_id = t.thesis_id
                WHERE st.student_id = '%s' and t.language = '%s'
                ORDER BY t.revision_number desc;",
                DbUtils::prepareString( $studentId ),
                DbUtils::prepareString( $lang ) );
                
        $data 	= DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if ( !$data->isEmpty() )
        {
            foreach( $data as $key => $record )
            {
                $result[] = new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                        $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                        $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                        $record['language'], $record['comment'] );
            }
        }
        return $result;
    }
    
    public static function getRefusedTitles( $thesisId, $page, $itemsPerPage )
    {
        if ( !is_numeric( $thesisId ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        if ( !is_numeric( $page ) || $page < 0 )
        {
            throw new Exception( "Invalid page." );
        }
        if ( !is_numeric( $itemsPerPage ) || $itemsPerPage < 1 )
        {
            throw new Exception( "Invalid items per page." );
        }
        $first = $page * $itemsPerPage;
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, t.refusal_reason,
                  t.refused_by, t.language, t.comment
                FROM titles t
                WHERE t.refusal_reason is not null and t.refused_by is not null
                and t.thesis_id = %d
                limit %d, %d;",
                $thesisId,
                $first,
                $itemsPerPage );
            
        $data 	= DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if ( !$data->isEmpty() )
        {
            foreach( $data as $key => $record )
            {
                $result[] = new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                        $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                        $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                        $record['language'], $record['comment'] );
            }
        }
        return $result;
    }
    
    public static function getRefusedByTitles( $thesisId, $refusedBy, $page, $itemsPerPage )
    {
        if ( !is_numeric( $thesisId ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        if ( !is_numeric( $page ) || $page < 0 )
        {
            throw new Exception( "Invalid page." );
        }
        if ( !is_numeric( $itemsPerPage ) || $itemsPerPage < 1 )
        {
            throw new Exception( "Invalid items per page." );
        }
        $first = $page * $itemsPerPage;
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, t.refusal_reason,
                  t.refused_by, t.language, t.comment
                FROM titles t
                WHERE t.refusal_reason is not null and t.refused_by is not null
                and t.thesis_id = %d and t.refused_by = '%s'
                limit %d, %d;",
                $thesisId,
                DbUtils::prepareString( $refusedBy ),
                $first,
                $itemsPerPage );
            
        $data 	= DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if ( !$data->isEmpty() )
        {
            foreach( $data as $key => $record )
            {
                $result[] = new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                        $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                        $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                        $record['language'], $record['comment'] );
            }
        }
        return $result;
    }
    
    public static function getActualTitleByThesisIs( $thesisId, $lang )
    {
        if ( !is_numeric( $thesisId ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        if ( !in_array( $lang, self::$langs ) )
        {
            throw new Exception( "Invalid language." );
        }
        switch ( $lang )
        {
            case 'LV' : $titleField = 'native_title_id'; break; 
            case 'EN' : $titleField = 'english_title_id'; break;
            default: 	throw new Exception( "Invalid language." );
        }
        $query = sprintf( "SELECT t.title_id, t.lecturer_approved, t.bachelor_approved, t.cathedra_approved,
                  t.revision_number, t.thesis_id, t.title, UNIX_TIMESTAMP( t.revision_date ) as revision_date, t.is_active, t.refusal_reason,
                  t.refused_by, t.language, t.comment 
                  FROM titles t
                inner join student_theses st on st.%s = t.title_id and st.thesis_id = %d
                order by t.revision_number desc
                limit 0, 1;",
                $titleField,
                $thesisId );

        $data = DbAccess::instance()->executeQuery( $query );
                
        if ( !$data->isEmpty() )
        {
            $data->next();
            $record = $data->current();
            
            return new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                    $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                    $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                    $record['language'], $record['comment'] );
        }
        throw new Exception( "No data available." );
    }
    
    public static function getStudentThesesByTitleId( $id )
    { 
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid title id." );
        }
        $query = sprintf( "SELECT st.student_id, st.thesis_id, st.apply_date, st.native_title_id, st.english_title_id, st.student_approved
                FROM student_theses st
                where st.native_title_id = %d or st.english_title_id = %d;",
                $id,
                $id );
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( !$data->isEmpty() )
        {
            $data->next();
            $record = $data->current();
            
            return new StudentThesesVO( $record['student_id'], $record['thesis_id'], $record['apply_date'], 
                    $record['native_title_id'], $record['english_title_id'], $record['student_approved'] );
        }
        throw new Exception( "No data available." );
    }
    
    public static function store( $title )
    {
        $nid = self::getNextId();
        $query = sprintf( "insert into titles( title_id, lecturer_approved, bachelor_approved, cathedra_approved,
                  revision_number, thesis_id, title, revision_date, is_active, refusal_reason,
                  refused_by, language, comment )
                values( %d, %d, %d, %d, %d, %d, '%s', FROM_UNIXTIME(%d), %d, '%s', '%s', '%s', '%s' );",
                $nid,
                $title->lecturerApproved,
                $title->bachelorApproved,
                $title->cathedraApproved,
                $title->revisionNumber,
                $title->thesisId,
                DbUtils::prepareString( $title->title ),
                $title->revisionDate,
                $title->isActive,
                DbUtils::prepareString( $title->refusalReason ),
                DbUtils::prepareString( $title->refusedBy ),
                DbUtils::prepareString( $title->language ),
                DbUtils::prepareString( $title->comment ) );
            
        if( !DbAccess::instance()->executeNonQuery( $query ) )
        {
            return -1;
        }
        return $nid;
    }
    
    public static function update( $title )
    {
        $query = sprintf( "update titles set lecturer_approved = %d, bachelor_approved = %d, cathedra_approved = %d,
                  revision_number = %d, thesis_id = %d, title = '%s', revision_date = FROM_UNIXTIME(%d),
                  is_active = %d, refusal_reason = '%s', refused_by = '%s', language = '%s', comment = '%s'
                where title_id = %d;",
                $title->lecturerApproved,
                $title->bachelorApproved,
                $title->cathedraApproved,
                $title->revisionNumber,
                $title->thesisId,
                DbUtils::prepareString( $title->title ),
                $title->revisionDate,
                $title->isActive,
                DbUtils::prepareString( $title->refusalReason ),
                DbUtils::prepareString( $title->refusedBy ),
                DbUtils::prepareString( $title->language ),
                DbUtils::prepareString( $title->comment ),
                $title->titleId );
            
        return DbAccess::instance()->executeNonQuery( $query );
    }
    
    public static function delete( $id )
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid title id." );
        }
        $query = sprintf( "delete from titles where title_id = %d;", $id );
        
        return DbAccess::instance()->executeNonQuery( $query );
    }
    
    public static function getNextId()
    {
        $query = "select
                  case when max(title_id) is null then 1
                  else max(title_id) + 1 end next_id from titles";
        
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( $data->isEmpty() )
        {
            throw new Exception("Database logic error.");
        }
        $data->next();
        $record = $data->current();
        
        return $record['next_id'];
    }
    
    public static function changeActiveTitle( $oldTitle, $newTitleId )
    {
        switch ( $oldTitle->language )
        {
            case 'LV' : $titleField = 'native_title_id'; break; 
            case 'EN' : $titleField = 'english_title_id'; break;
            default: 	throw new Exception( "Invalid language." );
        }
        $query = sprintf( "update student_theses
                set %s = %d
                where thesis_id = %d and %s = %d;",
                $titleField,
                $newTitleId,
                $oldTitle->thesisId,
                $titleField,
                $oldTitle->titleId );
                
        return DbAccess::instance()->executeNonQuery( $query );
    }
    
    public static function getNativeTitleByThesisId( $id )
    {		
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        
        $query = sprintf( "select * from titles
                           where thesis_id = %d 
                           and language = 'LV';", 
                        $id);
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( !$data->isEmpty() )
        {
            $data->next();
            $record = $data->current();
            
            return new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                    $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                    $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                    $record['language'], $record['comment'] );
        }
        
        throw new Exception( "Invalid thesis id." );
    }
    
    public static function getBroadTitleByThesisId($id)
    {
        if ( !is_numeric( $id ) )
        {
            throw new Exception( "Invalid thesis id." );
        }
        
        $query = sprintf( "select t.* from titles t
                           where t.thesis_id = %d
                           and t.language = 'EN';", 
                        $id);
                
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( !$data->isEmpty() )
        {
            $data->next();
            $record = $data->current();
            
            return new ThesisTitleVO( $record['title_id'], $record['lecturer_approved'], $record['bachelor_approved'], 
                    $record['cathedra_approved'], $record['revision_number'], $record['thesis_id'], $record['title'], 
                    $record['revision_date'], $record['is_active'], $record['refusal_reason'], $record['refused_by'], 
                    $record['language'], $record['comment'] );
        }
        
        throw new Exception( "Invalid thesis id." );
    }
}

?>