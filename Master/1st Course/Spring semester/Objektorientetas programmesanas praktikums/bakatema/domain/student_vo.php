<?php

class StudentVO
{
    public $studentId;
    public $systemId;
    public $firstName;
    public $lastName;
    public $email;
    
    public function __construct( $studentId, $systemId, $firstName, $lastName, $email )
    {
        $this->studentId    = $studentId;
        $this->systemId     = $systemId;
        $this->firstName    = $firstName;
        $this->lastName     = $lastName;
        $this->email        = $email;
    }
}

?>