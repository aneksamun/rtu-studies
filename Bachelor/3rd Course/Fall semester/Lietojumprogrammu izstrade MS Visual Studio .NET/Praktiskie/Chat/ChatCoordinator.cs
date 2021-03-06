using System;
using System.Runtime.Remoting;
using System.Collections;

// Define the class that contains the information for a Submission event.
[Serializable]
public class SubmitEventArgs : EventArgs{

   private string _string = null;
   private string _alias = null;

   public SubmitEventArgs(string contribution, string contributor){
      this._string = contribution;
      this._alias = contributor;
   }

   public string Contribution{
      get{
         return _string;
      }
   }

   public string Contributor{
      get { 
         return _alias; 
      }    
   }
}

// The delegate declares the structure of the method that the event will call when it occurs. 
// Clients implement a method with this structure, create a delegate that wraps it, and then
// pass that delegate to the event. The runtime implements events as a pair of methods,
// add_Submission and remove_Submission, and both take an instance of this type of delegate 
// (which really means a reference to the method on the client that the event will call).
public delegate void SubmissionEventHandler(object sender, SubmitEventArgs submitArgs);

// Define the service.
public class ChatCoordinator : MarshalByRefObject{

   public ChatCoordinator(){
    
   Console.WriteLine("ChatCoordinator created. Instance: " + this.GetHashCode().ToString());
    
   }

   // This is to insure that when created as a Singleton, the first instance never dies,
   // regardless of the time between chat users.
   public override object InitializeLifetimeService(){
      return null;
   }

   // The client will subscribe and unsubscribe to this event.
   public event SubmissionEventHandler Submission;

   // Method called remotely by any client. This simple chat server merely forwards 
   // all messages to any clients that are listening to the Submission event, including
   // whoever made the contribution.
   public void Submit(string contribution, string contributor){
      Console.WriteLine("{0} sent: {1}.", contributor, contribution);

      // Package String in SubmitEventArgs, which will be sent as an argument
      // to all event "sinks", or listeners.
      SubmitEventArgs e = new SubmitEventArgs(contribution, contributor);

      if (Submission != null){
         Console.WriteLine("Broadcasting...");
         // Raise Event. This calls the remote listening method on all clients of this object.
         Submission(this, e);
      }
   }
}