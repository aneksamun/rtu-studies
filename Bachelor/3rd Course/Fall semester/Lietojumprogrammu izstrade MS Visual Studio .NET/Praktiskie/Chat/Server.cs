using System;
using System.Runtime.Remoting;

public class Server{
   public static void Main(string[] Args){
      RemotingConfiguration.Configure("Central.config");
      Console.WriteLine("The host application is currently running. Press Enter to exit.");
      Console.ReadLine();
   }
}