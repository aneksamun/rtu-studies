<?php

/// AcademicsVO
class AcademicsVO
{
	public $system_id;
	public $first_name;
	public $last_name;
	public $email;
    public $academic_id;
    public $role;
    public $institution_id;
    public $academic_degree;
        
    public function __construct( $system_id, $first_name, $last_name, $email, $academic_id, $role, $institution_id, $academic_degree )
    {
    	$this->system_id		= $system_id;
    	$this->first_name		= $first_name;
    	$this->last_name		= $last_name;
    	$this->email			= $email;
    	$this->academic_id 		= $academic_id;
        $this->role 			= $role;
        $this->institution_id 	= $institution_id;
        $this->academic_degree 	= $academic_degree;
    }
}
?>