package mailing.example;

import java.util.Properties;
import javax.mail.Session;
import javax.mail.Store;
import javax.mail.Transport;

public class Main {
    
    /**
     * @param args
     */
    public static void main(String[] args) {
        
        // Checking for arguments.
        if (args.length != 0 && args.length > 1) {
            System.out.println("Too many arguments are specified:");
            System.out.println("Syntax: java -jar MailClient.jar\nor");
            System.out.println("Syntax: java -jar MailClient.jar <file_path>");
            System.exit(1);
        }
        
        final String filePath = (args.length == 1) ? args[0] : "ResponseMsg.txt";
        
        // Checking for file existence.
        if (!FileHandler.isValidFilePath(filePath)) {
            System.out.println("Response message file couldn't be find.");
            System.out.println("Try to specify file path as argument:");
            System.out.println("Syntax: java -jar MailClient.jar <file_path>");
            System.exit(1);
        }
        
        // Getting starting with e-mail processing.
        
        final String popHost = "pop.gmail.com";
        final String smtpHost = "smtp.gmail.com";
        final int smtpPort = 465;
        final String user = "";
        final String password = "";
        
        System.out.println(".:Simple Java Gmail client:.\n");
        System.out.println("E-mail settings:");
        System.out.println("Username: " + user);
        System.out.println("Password: " + password + "\n");
        
        try {
            // Getting system properties for the session object.
            Properties props = System.getProperties();
            // Setting up SMTP server host.
            props.put("mail.smtps.host", smtpHost);
            
            // Creating mail session instance.
            Session session = Session.getInstance(props, null);
            //session.setDebug(true);
            
            // Getting message delivery object.
            Transport transport = session.getTransport("smtps");
            // Getting messages retrieving object. 
            Store store = session.getStore("pop3s");
            
            // Establishing connection with the server.  
            store.connect(popHost, user, password);
            transport.connect(smtpHost, smtpPort, user, password);
            
            if (store.isConnected()) {
                System.out.println("Connection to server is established.");
                System.out.println("Listening for a new message...\n");
                
                // Running listener threads.
                final ListenerThread listener = new ListenerThread(store, transport, session);
                listener.start();
                
                // Stopping listener on application exit.
                Runtime.getRuntime().addShutdownHook( new Thread() {
                    @Override
                    public void run() {
                        listener.stop();
                    }
                });
            }
        }
        catch(Exception ex) {
            System.out.println("Unexpected error is occurred:");
            System.out.println(ex.getMessage());
        }
    }
}
