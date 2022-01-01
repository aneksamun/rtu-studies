using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class ChatClient : MarshalByRefObject {

   private string username = null;

	public override object InitializeLifetimeService() {
      return null;
   }

   public ChatClient(string alias){
        
      this.username = alias;
    
   }

   public void Run(){
    
      RemotingConfiguration.Configure("Client.config");
      ChatCoordinator chatcenter = new ChatCoordinator();
      chatcenter.Submission += new SubmissionEventHandler(this.SubmissionReceiver);
      String keyState = "";
        
      while (true){
         Console.WriteLine("Press 0 (zero) and ENTER to Exit:\r\n");
         keyState = Console.ReadLine();

         if (String.Compare(keyState,"0", true) == 0)
            break;
         chatcenter.Submit(keyState, username);
      }
      chatcenter.Submission -= new SubmissionEventHandler(this.SubmissionReceiver);
   }

	public void SubmissionReceiver(object sender, SubmitEventArgs args){

	if (String.Compare(args.Contributor, username, true) == 0){
         Console.WriteLine("Your message was broadcast.");
      }
      else
         Console.WriteLine(args.Contributor 
            + " says: " + args.Contribution);
      }

   public static void Main(string[] Args){

      if (Args.Length != 1){
         Console.WriteLine("You need to type an alias.");
         return;
      }

      ChatClient client = new ChatClient(Args[0]);
         client.Run();
      }
}