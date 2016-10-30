using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using System;

public class NetworkOld : MonoBehaviour {

    static SocketIOComponent socket;

    public GameObject playerPreFab;
    public GameObject map;

    private string[][] maplayout = new string[40][];

    Dictionary<string, GameObject> players;

    GameObject player;

    // Use this for initialization
    void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMove);

        maplayout[0] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w" };
        maplayout[1] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w" };
        maplayout[2] = new string[40] { "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhRc", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w" };
        maplayout[3] = new string[40] { "w", "bB", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", " ", "w", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", "bG", "w" };
        maplayout[4] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "dhGo", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "dhBc", "w", "w", "w", "w", " ", "w" };
        maplayout[5] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", "bB", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[6] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bY", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhGc", "w", "dhYo", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[7] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bR", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", " ", " ", " ", " ", " ", " ", " ", "dvRo", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[8] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bG", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhGc", "w", "w", "w", "w", " ", "w" };
        maplayout[9] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[10] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[11] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[12] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[13] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[14] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "bR", "w", "w", "w", "w", " ", "w" };
        maplayout[15] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[16] = new string[40] { "w", "bB", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "bG", "w", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", " ", "w" };
        maplayout[17] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w" };
        maplayout[18] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", " ", "w", "w", "w", "dhYc", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w" };
        maplayout[19] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", "bA", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w" };
        maplayout[20] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "dvBo", " ", " ", " ", " ", " ", " ", "dvGc", " ", " ", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", "w", "w", "dvPc", "w" };
        maplayout[21] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", "w", "w", " ", "w", "w", " ", "w" };
        maplayout[22] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "dhRo", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", "w", "w", " ", "w", "w", " ", "w" };
        maplayout[23] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", " ", "w", " ", "dvYc", "dvGc", "dvBc", " ", "w", "w", " ", "w" };
        maplayout[24] = new string[40] { "w", "bR", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "bY", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", " ", "w", " ", "w", "w", "w", " ", "w", "w", " ", "w" };
        maplayout[25] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", " ", " ", "bP", "w", " ", "dvRo", " ", "w", "w", " ", "w" };
        maplayout[26] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "bR", "w", "w", "w", "w", " ", "w" };
        maplayout[27] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", " ", "dvYo", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[28] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "bP", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[29] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[30] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[31] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bG", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhGc", "w", "w", "w", "w", " ", "w" };
        maplayout[32] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bR", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", " ", " ", " ", " ", " ", " ", " ", "dvRo", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[33] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "bY", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhGc", "w", "dhYo", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[34] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", "bB", "w", "w", "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", " ", "w" };
        maplayout[35] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "dhGo", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "dhBc", "w", "w", "w", "w", " ", "w" };
        maplayout[36] = new string[40] { "w", "bB", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", " ", " ", " ", "w", "w", "w", "w", "w", " ", " ", " ", " ", " ", " ", " ", "bG", "w" };
        maplayout[37] = new string[40] { "w", "w", "w", "w", "w", " ", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "dhRc", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w" };
        maplayout[38] = new string[40] { "w", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "w" };
        maplayout[39] = new string[40] { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w" };
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("Connected");
        socket.Emit("move");
        //var buildGameMap = map.GetComponent<BuildMap>();
        //buildGameMap.buildLevel(maplayout);
    }

    private void OnSpawned(SocketIOEvent e)
    {
        Debug.Log("spawned");
        player = Instantiate(playerPreFab);
        Vector3 newPosition = new Vector3((float)(-18.5), (float)(0.5), (float)(-18.5));
        player.transform.position = newPosition;
    }

    private void OnMove(SocketIOEvent e)
    {
        /*foreach (var player in players)
        {
            if (player.Key == e.data["id"].ToString())
            {*/
                var navigateToPos = player.GetComponent<NavigatePosition>();
                Vector3 currentPos = player.transform.position;
                var x = float.Parse(e.data["x"].ToString().Replace("\"", ""));
                var z = float.Parse(e.data["y"].ToString().Replace("\"", ""));
                //Vector3 endPos = new Vector3(x, (float)(0.25), z);
                Vector3 endPos = new Vector3((float)(18.5), (float)(0.25), (float)(-18.5));
                //navigateToPos.navigateTo(currentPos, endPos);
        //   }
        //}
    }
}
