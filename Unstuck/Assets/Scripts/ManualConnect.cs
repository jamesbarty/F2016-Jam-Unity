using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ManualConnect : MonoBehaviour {


    public void Connect ()
    {
        SocketIO.SocketIOComponent io = GetComponent<SocketIO.SocketIOComponent>();
        /*Text iptext = GameObject.Find("IPText").GetComponent<Text>();
        string url = "wss://"+ iptext.text + "/socket.io/?EIO=4&transport=websocket";
        io.Init(url);*/
        io.Connect();
    }
}
