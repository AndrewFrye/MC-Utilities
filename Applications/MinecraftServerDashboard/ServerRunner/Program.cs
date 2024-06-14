using System.IO.Pipes;
using System.Text;

namespace ConsoleApp1ServerRunner;

class Program
{
    static void Main(string[] args)
    {
        int i;
        Thread?[] servers = new Thread[maxConnections];

        Console.WriteLine("\n*** Named pipe server stream with impersonation example ***\n");
        Console.WriteLine("Waiting for client connect...\n");
        for (i = 0; i < maxConnections; i++)
        {
            servers[i] = new Thread(ServerThread);
            servers[i]?.Start();
        }
        Thread.Sleep(250);
        while (i > 0)
        {
            for (int j = 0; j < maxConnections; j++)
            {
                if (servers[j] != null)
                {
                    if (servers[j]!.Join(250))
                    {
                        Console.WriteLine("Server thread[{0}] finished.", servers[j]!.ManagedThreadId);
                        servers[j] = null;
                        i--;    // decrement the thread watch count
                    }
                }
            }
        }
        Console.WriteLine("\nServer threads exhausted, exiting.");
    }

    private static int maxConnections = 4;
    private static void ServerThread(object? data)
    {
        NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.InOut, maxConnections);

        int threadId = Thread.CurrentThread.ManagedThreadId;

        // Wait for a client to connect
        pipeServer.WaitForConnection();

        Console.WriteLine("Client connected on thread[{0}].", threadId);
        try
        {
            Stream stream = pipeServer;
            stream.Write(Encoding.Default.GetBytes("Test Message From Server"));
        }
        // Catch the IOException that is raised if the pipe is broken
        // or disconnected.
        catch (IOException e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
        }
        pipeServer.Close();
    }
}
