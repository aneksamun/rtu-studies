<?php 

// Thesis title VO
class ThesisTitleVO
{
    public $titleId;
    public $lecturerApproved;
    public $bachelorApproved;
    public $cathedraApproved;
    public $revisionNumber;
    public $thesisId;
    public $title;
    public $revisionDate;
    public $isActive;
    public $refusalReason;
    public $refusedBy;
    public $language;
    public $comment;
    
    public function __construct( $titleId, $lecturerApproved, $bachelorApproved, $cathedraApproved, 
            $revisionNumber, $thesisId, $title, $revisionDate, $isActive, $refusalReason, $refusedBy,
            $language, $comment )
    {
        $this->titleId				= $titleId;
        $this->lecturerApproved		= $lecturerApproved;
        $this->bachelorApproved		= $bachelorApproved;
        $this->cathedraApproved		= $cathedraApproved;
        $this->revisionNumber		= $revisionNumber;
        $this->thesisId				= $thesisId;
        $this->title				= $title;
        $this->revisionDate			= $revisionDate;
        $this->isActive				= $isActive;
        $this->refusalReason		= $refusalReason;
        $this->refusedBy			= $refusedBy;
        $this->language				= $language;
        $this->comment				= $comment;
    }
}

?>