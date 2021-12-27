<?php
include_once( "../resources/db_access.php" );
include_once( "../resources/init.php" );
include_once( "../resources/page_factory.php" );
include_once( "../utils/session_utils.php" );

// application init
Init::run();

$page = ServerUtils::getRequestData( 'page', ServerUtils::DATA_SOURCE_GET_OR_POST );
if ( !isset( $page ) )
{
    $page = SessionUtils::getRoleHomePage();
}

if ( $page == 'lect' )
{
    $usergr = SessionUtils::getUserGroup();
    $usernm = SessionUtils::getUserFirstName();
    $userlm = SessionUtils::getUserLastName();
    $userfm = $usernm.' '.$userlm;
    $userid = SessionUtils::getUserSystemId();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

<title>Bakatema - Studenta izvēlne</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <div class="main">
        <div class="head">
            <span class="logname"><? echo"Labdien, $userfm ";?>
            </span>
        </div>
        <div class="header">
            <div class="logo">
                <h1>
                    <a href="#">BAKATEMA</a>
                </h1>
            </div>
            <p></p>
            <div class="clear"></div>

            <div class="menu">
                <ul>
                    <li class="current"><a href="index.php">Sākums</a></li>
                    <li><a href="?page=about">Par sistēmu</a></li>
                </ul>
            </div>
        </div>
        <div class="content">
            <div class="right">
                <div class="post">
<?php
    if ($page == 'lect') include "modules/superviser/superviser.php";
?>
                </div>
            </div>
            <div class="clear"></div>
        </div>

        <div class="footer">
            <p>Copyright by BAKATEMA @ 2011</p>
        </div>
    </div>
</body>
</html>
<?php
} 
else 
{
    $proc = PageFactory::createPage( $page );
    $proc->execute();
}
?>