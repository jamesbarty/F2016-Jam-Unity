using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using SocketIO;
using System.Collections.Generic;

public class Network : MonoBehaviour {

    bool connected = false;

    public GameObject map;
    public GameObject OpenGamesPanel;
    public GameObject LobbyPanel;
    public GameObject LoginPanel;
    public GameObject GameLobbyPanel;
    public GameObject NameTextPanel;
    public GameObject GameOverPanel;
    public Text gameResultText;
    public Text iptext;

    private int playerId;

    static SocketIOComponent socket;

    static BuildMap mapBuilder;

	// Use this for initialization
	void Start () {
        socket = GetComponent<SocketIOComponent>();
        mapBuilder = map.GetComponent<BuildMap>();
        socket.On("open", OnConnected);
	}

	void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
        if (!connected)
        {
            firstConnect();
        }
        connected = true;
    }

    public void firstConnect()
    {
        // Tell the game our name
        JSONObject name = new JSONObject();
        name.AddField("name", iptext.text);
        socket.Emit("name", name);

        socket.On("lobbyUpdate", LobbyUpdateHandler);
        socket.On("gameLobbyUpdate", GameLobbyHandler);
        socket.On("initGame", InitHandler);
    }

    public void GameLobbyHandler(SocketIOEvent e)
    {
        Debug.Log("Handling game lobby update");
        Debug.Log(e.data.ToString());
        if (LobbyPanel.activeSelf)
        {
            LobbyPanel.SetActive(false);
            GameLobbyPanel.SetActive(true);
        }
        foreach (Transform child in NameTextPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Debug.Log(e.data["teamOne"]);
        Debug.Log("begin");
        if (e.data["teamOne"].ToString() != "[]") {
            int i = 0;
            while (e.data["teamOne"][i] && e.data["teamOne"][i].ToString() != "")
            {
                Debug.Log("sdgjjahdfough");
                string name = e.data["teamOne"][i]["name"].ToString().Trim('\"');
                Debug.Log(name);
                GameObject g = (GameObject)Instantiate(Resources.Load("NameText"));
                Text t = g.GetComponent<Text>();
                t.text = name;
                RectTransform r = g.GetComponent<RectTransform>();
                r.SetParent(NameTextPanel.GetComponent<RectTransform>(), false);
                r.anchoredPosition = new Vector2(40, -15 - 30 * i);
                i += 1;
            }
        }
        
        Debug.Log("mid");
        if (e.data["teamTwo"].ToString() != "[]") {
            int i = 0;
            while (e.data["teamTwo"][i] && e.data["teamTwo"][i].ToString() != "")
            {
                Debug.Log("asdfkhwo");
                string name = e.data["teamTwo"][i]["name"].ToString().Trim('\"');
                Debug.Log(name);
                GameObject g = (GameObject)Instantiate(Resources.Load("NameText"));
                Text t = g.GetComponent<Text>();
                t.text = name;
                RectTransform r = g.GetComponent<RectTransform>();
                r.SetParent(NameTextPanel.GetComponent<RectTransform>(), false);
                r.anchoredPosition = new Vector2(135, -15 - 30 * i);
                i += 1;
            }
        }
        Debug.Log("end");
    }

    public void LobbyUpdateHandler(SocketIOEvent e)
    {
        Debug.Log("Handling Lobby Update");
        Debug.Log(e.data.ToString());
        if (LoginPanel.activeSelf)
        {
            LoginPanel.SetActive(false);
            LobbyPanel.SetActive(true);
        }
        else if (GameLobbyPanel.activeSelf)
        {
            GameLobbyPanel.SetActive(false);
            LobbyPanel.SetActive(true);
        }
        else if (GameOverPanel.activeSelf)
        {
            GameOverPanel.SetActive(false);
            LobbyPanel.SetActive(true);
        }

        foreach (Transform child in OpenGamesPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        string gamesOpen = e.data["gamesOpen"].ToString();
        if (e.data["gamesOpen"].ToString() != "[]")
        {
            int i = 0;
            while (e.data["gamesOpen"][i].ToString() != "")
            {
                int gameID = Int32.Parse(e.data["gamesOpen"][i]["id"].ToString());
                int numPlayers = Int32.Parse(e.data["gamesOpen"][i]["numPlayers"].ToString());
                GameObject openGame = (GameObject)Instantiate(Resources.Load("OpenGame"));
                RectTransform r = openGame.GetComponent<RectTransform>();
                r.SetParent(OpenGamesPanel.transform, false);
                r.anchoredPosition = new Vector2(0, -15 - 30 * i);

                Debug.Log(numPlayers.ToString() + "/4 Players");
                Text t = openGame.GetComponentInChildren<Text>();
                t.text = numPlayers.ToString() + "/4 Players";

                Button b = openGame.GetComponentInChildren<Button>();
                b.onClick.AddListener(() => { JoinGame(gameID); });
                i += 1;
            }
        }
    }

    public void CreateGame()
    {
        socket.Emit("createGame");
    }

    public void LeaveGame()
    {
        socket.Emit("leaveGame");
    }

    public void StartGame()
    {
        socket.Emit("startGame");
    }

    public void JoinGame(int num)
    {
        JSONObject idData = new JSONObject();
        idData.AddField("gameNum", num);
        socket.Emit("joinGame", idData);
    }

    public void SwitchTeam(int num)
    {
        JSONObject teamData = new JSONObject();
        teamData.AddField("teamNum", num);
        socket.Emit("switchTeam", teamData);
    }

    public void InitHandler(SocketIOEvent e)
    {
        if (GameLobbyPanel.activeSelf)
        {
            GameLobbyPanel.SetActive(false);
        }
        int r = 0;
        while (e.data["mapData"][r])
        {
            int c = 0;
            while (e.data["mapData"][r][c])
            {
                mapBuilder.buildLevel(c, r, e.data["mapData"][r][c].ToString());
                c++;
            }
            r++;
        }
        Debug.Log(e.data["playerData"]);
        int i = 0;
        while(e.data["playerData"][i])
        {
            int x = int.Parse(e.data["playerData"][i]["spawn"]["x"].ToString());
            int y = int.Parse(e.data["playerData"][i]["spawn"]["y"].ToString());
            int id = int.Parse(e.data["playerData"][i]["id"].ToString());
            int me = int.Parse(e.data["playerData"][i]["me"].ToString());
            mapBuilder.createPlayer(x, y, id, me);
            if (me == 1)
            {
                playerId = id;
            }
            i++;
        }

        socket.On("moveTo", OnMove);
        socket.On("doorToggle", OnDoorToggle);
        socket.On("gameOver", OnGameOver);
        socket.On("playerKilled", OnPlayerKilled);
    }

    private void OnPlayerKilled(SocketIOEvent e)
    {
        Debug.Log("Killing player");
        Debug.Log(e.data);

        int id = int.Parse(e.data["id"].ToString());
        int x = int.Parse(e.data["spawnCoords"]["x"].ToString());
        int y = int.Parse(e.data["spawnCoords"]["y"].ToString());

        mapBuilder.teleportPlayer(id, x, y);
    }

    private void OnDoorToggle(SocketIOEvent e)
    {
        Debug.Log("Toggling door");
        Debug.Log(e.data);

        bool open = Convert.ToBoolean(e.data["state"].ToString());
        int x = int.Parse(e.data["coords"]["x"].ToString());
        int y = int.Parse(e.data["coords"]["y"].ToString());

        mapBuilder.toggleDoor(x, y, open);
    }

    private void OnGameOver(SocketIOEvent e)
    {
        Debug.Log("Game Over!");
        bool won = Convert.ToBoolean(int.Parse(e.data["won"].ToString()));
        Debug.Log("You won:" + won.ToString());

        foreach (Transform child in map.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameOverPanel.SetActive(true);
        if (!won)
        {
            gameResultText.text = "You Lose :(";
        }

        socket.Off("moveTo", OnMove);
        socket.Off("doorToggle", OnDoorToggle);
        socket.Off("gameOver", OnGameOver);
    }

    private void OnMove(SocketIOEvent e)
    {
        Debug.Log(e.data);
        int id = int.Parse(e.data["id"].ToString());

        int xCord = int.Parse(e.data["coords"]["x"].ToString());
        int zCord = int.Parse(e.data["coords"]["y"].ToString());
        float duration = float.Parse(e.data["duration"].ToString());
        mapBuilder.movePlayer(id, xCord, zCord, duration);
        
    }

    public void Connect()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Debug.Log("w Down");
            JSONObject json = new JSONObject();
            json.AddField("key", 'w');
            socket.Emit("keydown", json);
        }
        else if (Input.GetKeyDown("a"))
        {
            Debug.Log("a Down");
            JSONObject json = new JSONObject();
            json.AddField("key", 'a');
            socket.Emit("keydown", json);
        }
        else if (Input.GetKeyDown("s"))
        {
            Debug.Log("s Down");
            JSONObject json = new JSONObject();
            json.AddField("key", 's');
            socket.Emit("keydown", json);
        }
        else if (Input.GetKeyDown("d"))
        {
            Debug.Log("d Down");
            JSONObject json = new JSONObject();
            json.AddField("key", 'd');
            socket.Emit("keydown", json);
        }

        if (Input.GetKeyUp("w"))
        {
            Debug.Log("w Up");
            JSONObject json = new JSONObject();
            json.AddField("key", 'w');
            socket.Emit("keyup", json);
        }
        if (Input.GetKeyUp("a"))
        {
            Debug.Log("a Up");
            JSONObject json = new JSONObject();
            json.AddField("key", 'a');
            socket.Emit("keyup", json);
        }
        if (Input.GetKeyUp("s"))
        {
            Debug.Log("s Up");
            JSONObject json = new JSONObject();
            json.AddField("key", 's');
            socket.Emit("keyup", json);
        }
        if (Input.GetKeyUp("d"))
        {
            Debug.Log("d Up");
            JSONObject json = new JSONObject();
            json.AddField("key", 'd');
            socket.Emit("keyup", json);
        }

        /*if (Input.GetKeyUp("c"))
        {
            Debug.Log("released c");
            socket.Emit("createGame");
        }
        else if (Input.GetKeyUp("j"))
        {
            JSONObject json = new JSONObject();
            json.AddField("gameNum", 1);
            socket.Emit("joinGame", json);
        }
        else if (Input.GetKeyUp("s"))
        {
            
            JSONObject json = new JSONObject();
            json.AddField("teamNum", 1);
            socket.Emit("switchTeam", json );
        }
        else if (Input.GetKeyUp("d"))
        {

            JSONObject json = new JSONObject();
            json.AddField("teamNum", 2);
            socket.Emit("switchTeam", json);
        }
        else if (Input.GetKeyUp("l"))
        {
            socket.Emit("leaveGame");
        }
        else if (Input.GetKeyUp("t"))
        {
            socket.Emit("startGame");
        }*/
    }
}
