<?php

include_once( "../tests/system_dao_test.php" );
include_once( "../tests/thesis_title_dao_test.php" );

echo( "Starting basic tests<br/>" );

SystemDAOTest::run();
ThesisTitleDAOTest::run();

echo( "Tests completed<br/>" );

?>