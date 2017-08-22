using OpenPop.Pop3;
using OpenPop.Mime;
using System.Collections.Generic;

namespace EmailClient.POP3
{
    class POPProtocol
    {
        public static List<Message> fetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);
                client.Authenticate(username, password);
                int messageCount = client.GetMessageCount();

                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                return allMessages;
            }
        }

        public static int getMessagesCount(string hostname, int port, bool useSsl, string username, string password)
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);
                client.Authenticate(username, password);
                int messageCount = client.GetMessageCount();

                return messageCount;
            }
        }
    }
}
