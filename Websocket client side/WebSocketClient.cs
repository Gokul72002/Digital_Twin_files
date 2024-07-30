using UnityEngine;
using TMPro;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#if UNITY_WEBGL && !UNITY_EDITOR
using NativeWebSocket;
#else
using System.Net.WebSockets;
#endif

public class WebSocketClient : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    private WebSocket socket;
#else
    private ClientWebSocket socket;
#endif

    public TextMeshProUGUI Temperature;
    public TextMeshProUGUI overaltemp;
    public TextMeshProUGUI Humidity;
    public ParticleColorChanger particleColorChanger;

    [Header("world canvas")]
    public TextMeshProUGUI Tempdata_World;
    public TextMeshProUGUI Humidity_data;


    [Serializable]
    public class SensorData
    {
        public string type;
        public string value;
        public string updated_at;
    }

    [Serializable]
    public class SensorDataArray
    {
        public SensorData[] data;
    }

    async void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        socket = new WebSocket("wss://api.cavinkare.in/socketweb/hello");
        socket.OnOpen += OnOpen;
        socket.OnMessage += OnMessage;
        socket.OnError += OnError;
        socket.OnClose += OnClose;
        await socket.Connect();
#else
        socket = new ClientWebSocket();
        Uri serverUri = new Uri("wss://api.cavinkare.in/socketweb/hello");
        await ConnectAsync(serverUri);
#endif
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    private void OnOpen()
    {
        Debug.Log("WebSocket connection established");
    }
 
    private void OnMessage(byte[] message)
    {
        string messageString = Encoding.UTF8.GetString(message);
        Debug.Log("Message from server: " + messageString);
 
        // Parse the JSON message
        ParseAndHandleMessage(messageString);
    }
 
    private void OnError(string message)
    {
        Debug.LogError("WebSocket error: " + message);
    }
 
    private void OnClose(WebSocketCloseCode closeCode)
    {
        Debug.Log("WebSocket connection closed with code: " + closeCode);
    }
#else
    private async Task ConnectAsync(Uri serverUri)
    {
        try
        {
            await socket.ConnectAsync(serverUri, CancellationToken.None);
            OnOpen();
            await ReceiveLoop();
        }
        catch (Exception e)
        {
            OnError(e.Message);
        }
    }

    private void OnOpen()
    {
        Debug.Log("WebSocket connection established");
    }

    private void OnMessage(string message)
    {
        Debug.Log("Message from server: " + message);

        // Parse the JSON message
        ParseAndHandleMessage(message);
    }

    private void OnError(string message)
    {
        Debug.LogWarning("WebSocket error: " + message);
    }

    private void OnClose()
    {
        Debug.Log("WebSocket connection closed");
    }
#endif

    private void ParseAndHandleMessage(string message)
    {
        try
        {
            // Wrap the JSON array in an object
            string wrappedMessage = "{\"data\":" + message + "}";

            // Parse the JSON data
            SensorDataArray sensorDataArray = JsonUtility.FromJson<SensorDataArray>(wrappedMessage);

            // Handle the data
            foreach (var sensorData in sensorDataArray.data)
            {
                Debug.Log($"Type: {sensorData.type}, Value: {sensorData.value}, Updated At: {sensorData.updated_at}");

                // Perform actions based on the type and value
                HandleSensorData(sensorData);
            }


        }
        catch (Exception e)
        {
            OnError("JSON parse error: " + e.Message);
        }
    }

    public void HandleSensorData(SensorData sensorData)
    {
        if (sensorData.type == "temprature")
        {
            // Handle temperature data
            float temperature = float.Parse(sensorData.value);
            Debug.Log("Temperature C: " + temperature);

            // Set temperature value to UI
            Temperature.text = $"{temperature}\n";
            overaltemp.text = $"{temperature}\n";

            Tempdata_World.text = $"{temperature}\n";

            // Pass the temperature value to the ParticleColorChanger script
            if (particleColorChanger != null)
            {
                particleColorChanger.SetTemperature(temperature);
            }
        }
        if (sensorData.type == "humidity")
        {
            // Handle humidity data
            float humidity = float.Parse(sensorData.value);
            Debug.Log("Humidity: " + humidity);

            // Set humidity value to UI
            Humidity.text = $"{humidity}\n";

            Humidity_data .text = $"{humidity}\n";
        }
    }


    private string CleanAndFormatMessage(string rawData)
    {
        // Remove unwanted characters
        string cleanedData = Regex.Replace(rawData, "[\\[\\]{}\"]", "");

        // Replace commas with new lines for better readability
        cleanedData = cleanedData.Replace(",", "\n");

        return cleanedData;
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    /*private void Update()
    {
        socket.DispatchMessageQueue();
    }*/
 
    private async void OnDestroy()
    {
        if (socket != null)
        {
            await socket.Close();
        }
    }
#else
    private async Task ReceiveLoop()
    {
        var buffer = new byte[1024 * 4];
        try
        {
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    OnClose();
                }
                else
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnMessage(message);
                }
            }
        }
        catch (Exception e)
        {
            OnError(e.Message);
        }
    }

    private void OnDestroy()
    {
        if (socket != null)
        {
            if (socket.State == WebSocketState.Open)
            {
                socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
            socket.Dispose();
        }
    }
#endif
}