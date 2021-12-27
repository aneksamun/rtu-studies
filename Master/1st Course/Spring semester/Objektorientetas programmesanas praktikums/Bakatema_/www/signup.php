<?php 

include_once( "../resources/init.php" );
include_once( "../utils/session_utils.php" );
include_once( "../utils/server_utils.php" );
include_once( "../domain/student_vo.php" );
include_once( "../dao/student_dao.php" );

// application init
Init::prepareSession();

if ( ServerUtils::checkRequestData( 'post-back', ServerUtils::DATA_SOURCE_POST ) )
{	// action confirmed, adding user
    SessionUtils::tryStoreUser();
    ServerUtils::redirect( Config::getDefaultPage() );
}

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
                    <br/>
                    <form action="<?php echo ServerUtils::getCurrentUrl() ?>" method="post">
                        <input type="hidden" name="post-back" id="post-back"/>
                        <h1 class="title">Laipni lūdzam BAKATEMA sistemā!</h1>
                        <br/>
                        <h4>Lai apstiprinātu Jusu vēlmi izmantot sistēmu un sniegt tai 
                            Jusu datus, nospiediet "Turpināt".</h4>
                        <button type="submit">Turpināt</button>
                    </form>
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