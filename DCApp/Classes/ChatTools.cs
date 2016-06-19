using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace DomainCommander
{
    class ChatTools
    {
        TcpClient IRCConnection = null;
        NetworkStream ns = null;
        StreamReader sr = null;
        StreamWriter sw = null;

        public void IrcClient(String server, int port, String nick, String name, String channel, String password)
        {


            try

            {

                IRCConnection = new TcpClient(server, port);

                IRCConnection.ReceiveBufferSize = 1024;

            }

            catch

            {

                Console.WriteLine("Communication Error!");

            }

            try

            {

                ns = IRCConnection.GetStream();

                sr = new StreamReader(ns);

                sw = new StreamWriter(ns) { NewLine = "\r\n", AutoFlush = true };

 
                sendData("PASS", password);

                sendData("NICK", nick);

                sendData("USER", nick + " idsolutions-inc.com " + " idsolutions-inc.com" + " :" + name);

                sendData("JOIN", channel);

 
                IRCWork();

            }

            catch

            {

                Console.WriteLine("Communitaction Error!");

            }

            finally

            {

                if (sr != null)

                    sr.Close();

                if (sw != null)

                    sw.Close();

                if (ns != null)

                    ns.Close();

                if (IRCConnection != null)

                    IRCConnection.Close();

            }

        }

        public void sendData(string cmd, string param)
        {

            if (param == null)
            {

                sw.WriteLine(cmd);

                sw.Flush();

                Console.WriteLine(cmd);

            }

            else
            {

                sw.WriteLine(cmd + " " + param);

                sw.Flush();

                Console.WriteLine(cmd + " " + param);

            }

        }

        public void IRCWork()
        {

            string[] ex;

            string data;

            bool shouldRun = true;

            while (shouldRun)

            {

                data = sr.ReadLine();

                Console.WriteLine(data);

                char[] charSeparator = new char[] { ' ' };

                ex = data.Split(charSeparator, 5);

 
                if (ex[0] == "PING")

                {

                    sendData("PONG", ex[1]);

                }

 
                if (ex.Length > 4) //is the command received long enough to be a bot command?

                {

                    string command = ex[3]; //grab the command sent

 
                    switch (command)

                    {

                        case ":!join":

                            sendData("JOIN", ex[4]); //if the command is !join send the "JOIN" command to the server with the parameters sent by the user

                            break;

                        case ":!say":

                            sendData("PRIVMSG", ex[2] + " " + ex[4]); //if the command is !say, send a message to the chan (ex[2]) followed by the actual message (ex[4])

                            break;

                        case ":!quit":

                            sendData("QUIT", ex[4]); //if the command is quit, send the QUIT command to the server with a quit message

                            shouldRun = false;

                            break;

                    }

                }

 
                if (ex.Length > 3)

                {

                    string command = ex[3];

 
                    switch (command)

                    {

                        case ":!part":

                            sendData("PART", ex[2]);

                            break;

                    }

                }

            }

        }

    }

}
