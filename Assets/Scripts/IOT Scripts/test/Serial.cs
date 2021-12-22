using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class Serial : MonoBehaviour
{
    private SerialPort stream;
    [SerializeField] private string portCom;
    [SerializeField] private int serialBaud;
    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort(portCom, serialBaud);
        stream.ReadTimeout = 50;
        stream.Open();
    }


    public void WriteToArduino(string message)
    {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    public void OnDestroy()
    {
        stream.Close();
    }
}
