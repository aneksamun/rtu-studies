<?php

class NotificationVO
{
    public $notificationId;
    public $messageText;
    public $recepients;
    public $effectiveDate;
    public $emittedBy;
    public $isSent;
    
    public function __construct($notificationId, $messageText, $recepients, $effectiveDate, $emittedBy, $isSent)
    {
        $this->notificationId = $notificationId;
        $this->messageText = $messageText;
        $this->recepients = $recepients;
        $this->effectiveDate = $effectiveDate;
        $this->emittedBy = $emittedBy;
        $this->isSent = $isSent;
    }
}

?>