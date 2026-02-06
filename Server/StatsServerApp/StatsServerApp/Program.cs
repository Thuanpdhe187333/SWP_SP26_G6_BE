using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using StatsDataServer.Dtos;

TcpListener listener = new TcpListener(IPAddress.Any, 9000);
listener.Start();

Console.WriteLine("Server started...");
Console.WriteLine("Waiting for client...");

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    Console.WriteLine("Client connected");
    Task.Run(() => HandleClient(client));
}

static void HandleClient(TcpClient client)
{
    using NetworkStream stream = client.GetStream();

    try
    {
        using var ms = new System.IO.MemoryStream();
        byte[] buffer = new byte[4096];
        int bytesRead;

        // Read until there's no more data (client closed or no data available)
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, bytesRead);
            if (!stream.DataAvailable) break;
        }

        if (ms.Length == 0) return;

        string json = Encoding.UTF8.GetString(ms.ToArray());
        Console.WriteLine("Received:");
        Console.WriteLine(json);

        var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var request = System.Text.Json.JsonSerializer.Deserialize<ClientMessage>(json, options)
                      ?? throw new Exception("Invalid request");

        object payload = request.Category switch
        {
            "Customer" => HandleCustomer(request.Action),
            "Product" => HandleProduct(request.Action),
            "Employee" => HandleEmployee(request.Action),
            _ => throw new Exception("Invalid Category")
        };

        var response = new ServerMessage
        {
            Success = true,
            Payload = payload,
            Error = null
        };

        SendResponse(stream, response);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception handling client: " + ex);
        SendResponse(stream, new ServerMessage
        {
            Success = false,
            Payload = Array.Empty<object>(),
            Error = ex.Message
        });
    }
    finally
    {
        client.Close();
        Console.WriteLine("Client closed");
    }
}

#region HANDLERS

static object HandleCustomer(string action) => action switch
{
    "ByYear" => new[]
    {
        new { Label = "2023", Value = 120000 },
        new { Label = "2024", Value = 150000 }
    },
    "ByMonth" => new[]
    {
        new { Label = "01", Value = 10000 },
        new { Label = "02", Value = 18000 }
    },
    "ByDay" => new[]
    {
        new { Label = "2024-01-01", Value = 5000 },
        new { Label = "2024-01-02", Value = 7000 }
    },
    _ => throw new Exception("Invalid Action")
};

static object HandleProduct(string action) => new[]
{
    new { Label = "Chai", Value = 50000 },
    new { Label = "Chang", Value = 72000 }
};

static object HandleEmployee(string action) => new[]
{
    new { Label = "Nancy Davolio", Value = 110000 },
    new { Label = "Andrew Fuller", Value = 95000 }
};

#endregion

static void SendResponse(NetworkStream stream, ServerMessage response)
{
    string json = JsonSerializer.Serialize(response);
    byte[] data = Encoding.UTF8.GetBytes(json);

    stream.Write(data, 0, data.Length);
    stream.Flush(); // 🔥 RẤT QUAN TRỌNG
}
