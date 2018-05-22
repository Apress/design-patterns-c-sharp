using System;


namespace ChainOfResponsibilityPatternModified
{
    public enum MessagePriority
    {
        Normal,
        High
    }
    public class Message
    {
        public string Text;
        public MessagePriority Priority;
        public Message(string msg, MessagePriority p)
        {
            Text = msg;
            this.Priority = p;
        }
    }


    public interface IReceiver
    {
        bool HandleMessage(Message message);
    }
    public class IssueRaiser
    {
        public IReceiver setFirstReceiver;
        public IssueRaiser(IReceiver firstReceiver)
        {
            this.setFirstReceiver = firstReceiver;
        }
        public void RaiseMessage(Message message)
        {
            if (setFirstReceiver != null)
                setFirstReceiver.HandleMessage(message);
        }
    }
    public class FaxErrorHandler : IReceiver
    {
        private IReceiver nextReceiver;
        public FaxErrorHandler(IReceiver nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }
        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Fax"))
            {
                Console.WriteLine(" FaxErrorHandler processed {0} priority issue: {1}", message.Priority, message.Text);
                return true;
            }
            else
            {
                if (nextReceiver != null)
                    nextReceiver.HandleMessage(message);
            }
            return false;
        }
    }
    public class EmailErrorHandler : IReceiver
    {
        private IReceiver nextReceiver;
        public EmailErrorHandler(IReceiver nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }
        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Email"))
            {
                Console.WriteLine(" EmailErrorHandler processed {0} priority issue: {1}", message.Priority, message.Text);
                return true;
            }
            else
            {
                if (nextReceiver != null)
                    nextReceiver.HandleMessage(message);
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ***Chain of Responsibility Pattern Demo***\n");
            /* Making the chain:IssueRaiser->FaxErrorhandler->EmailErrorHandler */
            IReceiver faxHandler, emailHandler;            
            //End of chain
            emailHandler = new EmailErrorHandler(null);
            //fax handler is placed before email handler
            faxHandler = new FaxErrorHandler(emailHandler);

            //Starting point:IssueRaiser will raise issues and set the first handler
            IssueRaiser raiser = new IssueRaiser(faxHandler);

            Message m1 = new Message("Fax is reaching late to the destination.", MessagePriority.Normal);
            Message m2 = new Message("Emails are not raching to destinatinations.", MessagePriority.High);
            Message m3 = new Message("In Email, CC field is disabled always.", MessagePriority.Normal);
            Message m4 = new Message("Fax is not reaching destination.", MessagePriority.High);

            raiser.RaiseMessage(m1);
            raiser.RaiseMessage(m2);
            raiser.RaiseMessage(m3);
            raiser.RaiseMessage(m4);

            Console.ReadKey();
        }
    }
}
