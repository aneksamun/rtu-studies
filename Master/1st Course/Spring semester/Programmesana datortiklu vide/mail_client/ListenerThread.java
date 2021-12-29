package mailing.example;

import javax.mail.Address;
import javax.mail.Flags;
import javax.mail.Folder;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Store;
import javax.mail.Transport;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMessage.RecipientType;

public class ListenerThread implements Runnable {
	private final String inboxFolder = "INBOX";
	private final int checkInterval = 5000;
	
	private Store store;
	private Transport transport;
	private Thread thread;
	private Session session;
	private volatile boolean quit;

	public ListenerThread(Store store, Transport transport, Session session) {
		this.store = store;
		this.transport = transport;
		this.thread = new Thread(this);
		this.session = session;
		this.quit = false;
	}

	/**
	 * Starts mail listener thread.
	 **/
	public void start() {
		this.thread.start();
	}

	/**
	 * Stops mail listener thread. 
	 **/
	public void stop() {
		// Setting flag for quit. 
		this.quit = true;
		
		try {
			// Waiting for threads to finish. 
			this.thread.join();	
		} 
		catch (InterruptedException e) {
			System.out.println("Exception: ");
			System.out.println(e.getMessage());
		}
	}
	
	@Override
	public void run() {
		// Repeating listening.
		while (!quit) {	
			try {
				// Getting INBOX folder;
				Folder folder = store.getFolder(inboxFolder);

				if (folder == null || !folder.exists()) {
					System.out.println("Could find inbox folder.");
					return;
				}
				
				folder.open(Folder.READ_WRITE);

				// Getting existing messages.
				Message[] msgs = folder.getMessages();

				for (Message msg : msgs) {					
					// Getting all senders.
					Address[] senders = msg.getFrom();
					
					System.out.println("New message recieved!");
					System.out.println("Sender: " + senders.toString());
					System.out.println("Subject: " + msg.getSubject());
					
					MimeMessage responseMsg = new MimeMessage(session);

					// Formatting response message.
					responseMsg.setRecipients(RecipientType.TO, senders);
					responseMsg.setContent(FileHandler.processResponse(), "text/plain; charset=utf-8");
					responseMsg.setSubject("RE: " + msg.getSubject());
					
					// Sending reply.
					transport.sendMessage(responseMsg, senders);
					System.out.println("Message reply has been send.\n");
					
					// Deleting message.
					msg.setFlag(Flags.Flag.DELETED, true);
				}
				
				// Accept changes.
				folder.close(true);
				
				// Sleep for five seconds.
				Thread.sleep(checkInterval);
			} 
			catch (MessagingException e) {
				System.out.println("Exception: ");
				System.out.println(e.getMessage());
			} 
			catch (InterruptedException e) {
				System.out.println("Exception: ");
				System.out.println(e.getMessage());
			}
		}
	}
}
