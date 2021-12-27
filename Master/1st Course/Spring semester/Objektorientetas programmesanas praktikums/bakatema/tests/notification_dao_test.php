<?php

include_once( "../dao/notification_dao.php" );

class NotificationDAOTest
{
	public static function getNotificationsByIDTest()
	{
		$notification = NotificationDAO::getNotificationById(1);
		
		foreach ($notification as $key => $value) {
			print "$key: $value\n";
		}
	}
	
	public static function getNotificationsBySenderTest()
	{
		$notifications = NotificationDAO::getNotificationBySender(1);
		NotificationDAOTest::printRecords($notifications);
	}
	
	public static function getNotificationsByDateTest()
	{
		$dateTime = new DateTime("now", new DateTimeZone('Europe/Helsinki'));
		
		$dateTimeZone = new DateTimeZone('GMT');
		$dateTime->setTimezone($dateTimeZone);
		
		$notifications = NotificationDAO::getNotificationByDate($dateTime);
		NotificationDAOTest::printRecords($notifications);
	}
	
	public static function getNotSentNotificationsTest()
	{
		$notifications = NotificationDAO::getNotSentNotifications(1, 1);
		NotificationDAOTest::printRecords($notifications);
	}
	
	public static function getNotifications()
	{
		$notifications = NotificationDAO::getNotifications(1, 2);
		NotificationDAOTest::printRecords($notifications);
	}
	
	private static function printRecords($records)
	{
		for($i = 0; $i < count($records); $i++) {
			foreach ($records[$i] as $key => $value) {
				print "$key: $value\n";
			}
		}	
	}	
}

?>