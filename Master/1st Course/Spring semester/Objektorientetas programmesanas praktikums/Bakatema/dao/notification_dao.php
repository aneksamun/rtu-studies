<?php

include_once( "../resources/db_access.php" );
include_once( "../domain/notification_vo.php" );
include_once( "../utils/db_utils.php" );

class NotificationDAO
{
    public static function getNotificationById($id)
    {
        $query = sprintf("SELECT * FROM bakatema.notifications 
                          WHERE notification_id='%d'", $id);
        
        $data = DbAccess::instance()->executeQuery($query);
        
        if(!$data->isEmpty())
        {
            $data->next();
            $record = $data->current();
            return new NotificationVO(
                $record['notification_id'], 
                $record['message_text'], 
                $record['recepients'], 
                $record['effective_date'], 
                $record['emitted_by'], 
                $record['is_sent']);
        }
        throw new Exception( "Invalid notification id." );
    }
    
    public static function getNotificationBySender($sender)
    {
        if (!is_numeric($sender))
        {
            throw new Exception("Invalid sender id.");
        }
        
        $query = sprintf("SELECT * FROM notifications WHERE emitted_by='%d'", $sender);
        
        $data = DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record)
            {
                $result[] = new NotificationVO(
                        $record['notification_id'], 
                        $record['message_text'], 
                        $record['recepients'], 
                        $record['effective_date'], 
                        $record['emitted_by'], 
                        $record['is_sent']);
            }
        }
        
        return $result;
    }
    
    public static function getNotificationByDate($dateTime)
    {
        $date = $dateTime->format('Y-m-d');
        
        $query = sprintf("SELECT notification_id, message_text, recepients, effective_date, emitted_by, is_sent 
                          FROM notifications WHERE DATE(effective_date) = DATE('%s')", $date);
        
        $data = DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record)
            {
                $result[] = new NotificationVO(
                        $record['notification_id'], 
                        $record['message_text'], 
                        $record['recepients'], 
                        $record['effective_date'], 
                        $record['emitted_by'], 
                        $record['is_sent']);
            }
        }
        
        return $result;
    }
    
    public static function getNotSentNotifications($page, $itemsPerPage)
    {
        if (!is_numeric($page) || $page < 0)
        {
            throw new Exception("Invalid page.");
        }
        
        if (!is_numeric($itemsPerPage) || $itemsPerPage < 1)
        {
            throw new Exception("Invalid items per page.");
        }
        
        $first = $page * $itemsPerPage;
        
        $query = sprintf("SELECT * FROM notifications 
                          WHERE is_sent = 0
                          LIMIT %d, %d;", $first, $itemsPerPage);
        
        $data = DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record)
            {
                $result[] = new NotificationVO(
                        $record['notification_id'], 
                        $record['message_text'], 
                        $record['recepients'], 
                        $record['effective_date'], 
                        $record['emitted_by'], 
                        $record['is_sent']);
            }
        }
        
        return $result;
    }
    
    public static function getNotifications($page, $itemsPerPage)
    {
        if (!is_numeric($page) || $page < 0)
        {
            throw new Exception("Invalid page.");
        }
        
        if (!is_numeric($itemsPerPage) || $itemsPerPage < 1)
        {
            throw new Exception("Invalid items per page.");
        }
        
        $first = $page * $itemsPerPage;
        
        $query = sprintf("SELECT * FROM notifications 
                          LIMIT %d, %d;", $first, $itemsPerPage);
        
        $data = DbAccess::instance()->executeQuery( $query );
        $result = array();
        
        if (!$data->isEmpty())
        {
            foreach($data as $key => $record)
            {
                $result[] = new NotificationVO(
                        $record['notification_id'], 
                        $record['message_text'], 
                        $record['recepients'], 
                        $record['effective_date'], 
                        $record['emitted_by'], 
                        $record['is_sent']);
            }
        }
        
        return $result;
    }
    
    public static function store( $notification )
    {
        $nid 	= self::getNextId();
        $query 	= sprintf("insert into notifications values(
                  %d, '%s', '%s', FROM_UNIXTIME(%d), %d, %d );", 
                $nid, 
                DbUtils::prepareString( $notification->messageText ),
                DbUtils::prepareString( $notification->recepients ), 
                $notification->effectiveDate,
                $notification->emittedBy,
                $notification->isSent ? 1 : 0 );
        
        if( !DbAccess::instance()->executeNonQuery( $query ) )
        {
            return -1;
        }
        return $nid;
    }
    
    public static function getNextId()
    {
        $query = "select
                  case when max(notification_id) is null then 1
                  else max(notification_id) + 1 end next_id from notifications";
        
        $data = DbAccess::instance()->executeQuery( $query );
        
        if ( $data->isEmpty() )
        {
            throw new Exception("Database logic error.");
        }
        $data->next();
        $record = $data->current();
        
        return $record['next_id'];
    }
}

?>