using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class SerialComm : MonoBehaviour
{
    public string port = "COM4"; //When using MacOS -> "/dev/cu.usbmodem1411"
    public int baudRate = 115200;
    SerialPort m_stream;
    Thread m_receiveDataThread;
    Thread m_sendDataThread;
    bool writeFlag = false;
    string m_returnData;
    string m_dataToSend = "";
    public string ReturnData { get { return m_returnData; } }

    public void Awake()
    {
        
        // base.Awake();
        string[] ports = SerialPort.GetPortNames();
        foreach (var item in ports)
        {
            Debug.Log(item);
        }
        m_stream = new SerialPort(port, baudRate);
        //m_stream.ReadTimeout = 100;
        m_stream.DtrEnable = true;
        InitComm();
    }

    private void Update()
    {
        if(m_returnData != null){
            // Debug.Log(m_returnData);
            //m_stream.Write("u");
            //serialComm.Write("u");
        }
    }

    public void InitComm()
    {
        // base.InitComm();
        m_receiveDataThread = new Thread(new ThreadStart(FetchData));
        m_receiveDataThread.Start();

        //m_sendDataThread = new Thread(new ThreadStart(FetchData));
        //m_sendDataThread.Start();
        //Write("u");
    }

    public void FetchData()
    {
        // base.FetchData();
        Debug.Log("Starting Serial COMM Thread!");
        m_stream.Open();
        Debug.Log("Serial port " + port + " Open!");
        while (true)
        {
            Debug.Log("x");
            if (!m_stream.IsOpen)
            {
                break;
            }
            Debug.Log("y");
            m_returnData = m_stream.ReadLine();
            //if (m_dataToSend != null){
            //if(writeFlag){
                m_stream.Write(m_dataToSend);
                writeFlag = false;
           // }
            //}   
            Debug.Log("z");
            if (m_returnData != null)
            {
                m_stream.BaseStream.Flush();
            }
        }
    }

    public void Write(string data){
        m_dataToSend = data;
        writeFlag = true;
    }



    //0.56,-0.346,0.90
    //["0.56", "-0.346", "0.90"]
    public string[] SplittedData()
    {
        string[] tokens = m_returnData.Split(',');
        return tokens;
    }

    public Vector3 AccelVector()
    {
        Vector3 accel = new Vector3();
        if(m_returnData != null){
            string[] tokens = m_returnData.Split(',');
            accel.x = float.Parse(tokens[0]);
            accel.y = float.Parse(tokens[1]);
            accel.z = float.Parse(tokens[2]);
        }
        return accel;
    }

    public string getChar(){
        string data;
        if(m_returnData != null){
            data = m_returnData;
        }
        return m_returnData;
    }

    public void OnCommTerminate()
    {
        // base.OnCommTerminate();
        m_stream.Close();
        Debug.Log("Serial port " + port + " closed!");
    }

    void OnApplicationQuit()
    {
        OnCommTerminate();
    }
}