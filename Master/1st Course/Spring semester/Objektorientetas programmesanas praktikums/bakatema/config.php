<?php
class Config
{
    private static $debug		= true;
    
    private static $dbHost 		= "localhost";
    private static $dbUser 		= "root";
    private static $dbPass 		= "p4ssw0rd";
    private static $dbSchema 	= "bakatema"; 
    
    private static $pageDefault 	= "/index.php";
    private static $pageRegister 	= "/startup.php"; // TODO: redirect to ortus login
    private static $pageSignUp		= "/signup.php";
    
    // default pages
    private static $pageHomeStudent			= "student";
    private static $pageHomeLecturer		= "lect";
    private static $pageHomeBachLecturer	= "bach";
    private static $pageHomeCathedra		= "cath";
    private static $pageInviteBooker		= "booker_invite";
    private static $pageOrderBooker			= "booker_order";

    // students quote for the lecturers 
    private static $studentsQuote			= 4;
    private static $invitePattern			= "./patterns/invite_text.txt";
    
    private static $mailSmtpHost = '127.0.0.1';
    private static $mailSmtpPort = 26;
    private static $mailSmtpUser = 'user@localhost';
    private static $mailSmtpPass = 'p4ssw0rd';
    
    public static function getDbUser() { return self::$dbUser; }
    public static function getDbPass() { return self::$dbPass; }
    public static function getDbHost() { return self::$dbHost; }
    public static function getDbSchema() { return self::$dbSchema; }
    
    public static function getStudentsQuote() { return self::$studentsQuote; }
    public static function getIviteFilename() { return self::$invitePattern; }
    
    public static function getDefaultPage() { return self::$pageDefault; }
    public static function getRegistrationPage() { return self::$pageRegister; }
    public static function getSignupPage() { return self::$pageSignUp; }
    
    public static function getHomePageStudent() { return self::$pageHomeStudent; }
    public static function getHomePageLecturer() { return self::$pageHomeLecturer; }
    public static function getHomePageBachLecturer() { return self::$pageHomeBachLecturer; }
    public static function getHomePageCathedra() { return self::$pageHomeCathedra; }
    public static function getInvitePageBookkeeper() { return self::$pageInviteBooker; }
    public static function getOrderPageBookkeeper() { return self::$pageOrderBooker; }
    
    public static function isDebug() { return self::$debug; }
    
    public static function getMailSmtpHost() { return self::$mailSmtpHost; }
    public static function getMailSmtpPort() { return self::$mailSmtpPort; }
    public static function getMailSmtpUser() { return self::$mailSmtpUser; }
    public static function getMailSmtpPass() { return self::$mailSmtpPass; }
}
?>