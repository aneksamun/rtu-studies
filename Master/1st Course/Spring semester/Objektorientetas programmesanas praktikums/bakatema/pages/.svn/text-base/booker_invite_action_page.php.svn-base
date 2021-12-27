<?php

include_once("content_page.php");
include_once("../dao/system_dao.php");
include_once( "../resources/menu_factory.php" );

class BookerInviteActionPage extends ContentPage
{
	private $mode;
	private $lecturers;
	private $file_content;
	private $status;

	/**
	 * Process user request.
	 * @return string
	 */
	private function processAction()
	{
		$nextPage = '';

		if (ServerUtils::checkRequestData('invite', ServerUtils::DATA_SOURCE_POST ))
		{
			if (ServerUtils::checkRequestData('identities', ServerUtils::DATA_SOURCE_POST))
			{
				// Getting the pending lecturers list.
				$identities = array();
				$identities = ServerUtils::getRequestData('identities', ServerUtils::DATA_SOURCE_POST);

				foreach ($identities as $i => $value)
				{
					$lecturerDetail = array();

					$lecturerDetail['id'] = $identities[$i];
					$lecturerDetail['email'] = SystemDAO::getUserEmail($identities[$i]);

					$this->lecturers[] = $lecturerDetail;
				}

				// Getting content of the pattern file.
				$this->file_content = $this->getInviteText();
				// Setting display mode.
				$this->mode = 'send_email';
			}
			else
			{
				$this->status = "Lūdzu, vispirms izvēlēties vismaz vienu vadītāju.";
			}

			// Setting next page.
			$nextPage = 'booker_invite_action';
		}

		if (ServerUtils::checkRequestData('send', ServerUtils::DATA_SOURCE_POST ))
		{
			// Getting recievers list & invite text.
			$recievers = array();
			$recievers = ServerUtils::getRequestData('lecturersIds', ServerUtils::DATA_SOURCE_POST);

			$inviteText = ServerUtils::getRequestData('invite', ServerUtils::DATA_SOURCE_POST);

			// Sending message.
			$suceess = $this->notify($recievers, "Tēmu izveidošanas aicinājums", $inviteText);
				
			$this->status = ($suceess) ? "Ziņojums ir veiksmīgi nosūtīts." : "Ziņojuma sūtīšanas kļūda: pārliecināties par e-pastu atbilstību.";
				
			// Setting up next page.
			$nextPage = 'booker_invite_action';
		}

		if (ServerUtils::checkRequestData('back', ServerUtils::DATA_SOURCE_POST ) )
		{
			ServerUtils::redirect(Config::getDefaultPage());
		}

		return $nextPage;
	}

	/**
	 * Involves text from the invite pattern.
	 * @return string
	 */
	private function getInviteText()
	{
		$file_content = '';
		$filename = Config::getIviteFilename();

		if (file_exists($filename))
		{
			$file_content = file_get_contents($filename);
		}

		return $file_content;
	}

	/**
	 * Sends thesis creation invite message to the lecturers.
	 * @param array $to
	 * @param string $subject
	 * @param string $body
	 */
	private function notify($to, $subject, $body)
	{
		return NotificationService::instance()->sendNotification(
		SessionUtils::getUserSystemId(),
		$to,
		$subject,
		$body );
	}

	/*
	 * @see ContentPage::execute()
	 */
	public function execute()
	{
		SessionUtils::checkAccess(UserGroup::Bookkeeper);

		$this->mode = '';
		$this->file_content = '';
		$this->status = '';
		$this->lecturers = array();

		$menu = MenuFactory::getMenu( MenuFactory::MENU_TYPE_BOOKER );
		$menu['booker_invite']->setSelected(true);

		$this->engine->assign('menu', $menu);

		$this->engine->assign('content', 'content_booker_invite_action');
		$this->engine->assign('formaction', ServerUtils::getCurrentUrl());
		$this->engine->assign('nextpage', $this->processAction());

		$this->engine->assign('lecturers', $this->lecturers);
		$this->engine->assign('file_content', $this->file_content);
		$this->engine->assign('mode', $this->mode);
		$this->engine->assign('status', $this->status);

		$this->engine->assign('pagetitle', '- Aicināt vadītājus');

		parent::execute();
	}
}

?>