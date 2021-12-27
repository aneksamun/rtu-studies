<?php 

include_once( "../config.php" );
include_once( "../lib/phpmailer/class.phpmailer.php" );
include_once( "../dao/notification_dao.php" );

class EmailAddress
{
    public $name;
    public $email;
    
    public function __construct( $name, $email )
    {
        $this->email 	= $email;
        $this->name 	= $name;
    }
}

class NotificationService
{
    private static $instance;

    private $mail;
    
    // Constructor
    private function __construct()
    {	// init
        $this->mail = new PHPMailer();
        // telling the class to use SMTP
        $this->mail->IsSMTP(); 	
        // enable SMTP authentication
        $this->mail->SMTPAuth      = true;                  
        // SMTP connection will not close after each email sent
        $this->mail->SMTPKeepAlive = true;                  
        $this->mail->Host          = Config::getMailSmtpHost();
        $this->mail->Port          = Config::getMailSmtpPort();
        $this->mail->Username      = Config::getMailSmtpUser();
        $this->mail->Password      = Config::getMailSmtpPass();
    }
    
    public function sendNotification( $senderId, $recepients, $subject, $body )
    {
        $this->mail->ClearAllRecipients();
        $this->mail->ClearCustomHeaders();
        
        $sender = new EmailAddress( SystemDAO::getUserFirstName( $senderId ) . ' ' . SystemDAO::getUserLastName( $senderId ) , 
                SystemDAO::getUserEmail( $senderId ) );
        
        $this->mail->SetFrom( $sender->email, $sender->name );
        foreach( $recepients as $rid )
        {
            $recepient = new EmailAddress( SystemDAO::getUserFirstName( $rid ) . ' ' . SystemDAO::getUserLastName( $rid ) , 
                    SystemDAO::getUserEmail( $rid ) );
            $this->mail->AddAddress( $recepient->email, $recepient->name );
        }
        $this->mail->Subject 	= $subject;
        $this->mail->Body 		= $body;
        
        $success = true;
        // do not send emails on debug
        if ( !Config::isDebug() )
        {
            $success = $this->mail->Send();
            if( !$success ) 
            {
                trigger_error( "Mailer Error: " . $this->mail->ErrorInfo, E_USER_WARNING );
            } 	
        }
        $strRecepients 	= implode( ";", $recepients );
        $notification 	= new NotificationVO( -1, $body, $strRecepients, time(), $senderId, $success );
        
        NotificationDAO::store( $notification );
        
        return $success;
    }

    // The singleton method
    public static function instance()
    {
        if (!isset(self::$instance))
        {
            $c = __CLASS__;
            self::$instance = new $c;
        }

        return self::$instance;
    }
}

?>