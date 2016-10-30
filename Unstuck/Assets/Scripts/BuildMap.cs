using UnityEngine;
using System.Collections;
using System;

public class BuildMap : MonoBehaviour {

    public GameObject floor;
    public GameObject wallBlock;
    public GameObject door;
    public GameObject button;
    public GameObject player;
    public Material floorMaterial;
    public Material wallMaterial;
    private int playerId;
    public GameObject enemyPlayer;
    private int enemyPlayerId;

    private string[][] maplayout = new string[40][];

    private GameObject[][] mapLayoutGameObject = new GameObject[40][];

    // Use this for initialization
    void Start () {
        floor = Instantiate(floor);
        floor.transform.position += new Vector3(0, 0, 0);
        floor.GetComponent<Renderer>().material = floorMaterial;
        floor.GetComponent<Renderer>().material.mainTextureScale = new Vector2(40, 40);
        floor.GetComponent<Renderer>().material.SetTextureScale("_BumpMap", new Vector2(40, 40));
        for (int i = 0; i < mapLayoutGameObject.Length; i++)
        {
            mapLayoutGameObject[i] = new GameObject[40];
        }
        maplayout[0] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", "w",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", "w",    "w" };
        maplayout[1] = new string[40]  { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    " ", " ",    " ", " ", " ", " ", " ", " ", " ",    " ",    " ",    " ", " ", " ", " ",    "w" };
        maplayout[2] = new string[40]  { "w", "w",  "w", "w", "w", " ", "w", "w", "w",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "dhRc", "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", "w",    "w" };
        maplayout[3] = new string[40]  { "w", "bB", " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", " ",    "w", "w", "w", "w", "w", " ", " ",    " ",    " ",    " ", " ", " ", "bG",   "w" };
        maplayout[4] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "dhGo", "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", " ",    "w", "w", "w", "w", "w", "w", "w",    "dhBc", "w",    "w", "w", "w", " ",    "w" };
        maplayout[5] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", "bB",   "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[6] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", "bY",   "w", "w", "w", "w", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "dhGc", "w", "dhYo", "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[7] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", "bR",   "w", "w", "w", "w", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    "w", " ",    " ", " ", " ", " ", " ", " ", "dvRo", " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[8] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", "bG",   "w", "w", "w", "w", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    "dhGc", "w",    "w", "w", "w", " ",    "w" };
        maplayout[9] = new string[40]  { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[10] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[11] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[12] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[13] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[14] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    "bR",   "w",    "w", "w", "w", " ",    "w" };
        maplayout[15] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[16] = new string[40] { "w", "bB", " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", "bG", "w",    "w", "w", "w", "w", " ",    " ", " ",    " ", " ",    " ", " ", " ", " ", " ", " ", " ",    " ",    " ",    "w", "w", "w", " ",    "w" };
        maplayout[17] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[18] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", "dhYc", "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[19] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", "bA",   " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[20] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "dvBo", " ", " ", " ", " ", " ",    " ", "dvGc", " ", " ",    "w", "w", "w", " ", " ", " ", " ",    " ",    " ",    " ", "w", "w", "dvPc", "w" };
        maplayout[21] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", " ", "w", "w", "w",    "w",    "w",    " ", "w", "w", " ",    "w" };
        maplayout[22] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", "dhRo", "w", "w",    "w", " ",    "w", "w", "w", " ", "w", "w", "w",    "w",    "w",    " ", "w", "w", " ",    "w" };
        maplayout[23] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", " ", "w", " ", "dvYc", "dvGc", "dvBc", " ", "w", "w", " ",    "w" };
        maplayout[24] = new string[40] { "w", "bR", " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", "bY", "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", " ", "w", " ", "w",    "w",    "w",    " ", "w", "w", " ",    "w" };
        maplayout[25] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", " ", " ", "bP", "w",   " ",    "dvRo", " ", "w", "w", " ",    "w" };
        maplayout[26] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", " ",    "w", "w",    "w", " ",    "w", "w", "w", "w", "w", "w", "w",    "bR",   "w",    "w", "w", "w", " ",    "w" };
        maplayout[27] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", " ",  "dvYo", " ", " ", " ", " ", " ",    " ", " ",    " ", " ",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[28] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "bP", "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[29] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[30] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[31] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "bG",   "w", "w", "w", "w", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    "dhGc", "w",    "w", "w", "w", " ",    "w" };
        maplayout[32] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "bR",   "w", "w", "w", "w", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    "w", " ",    " ", " ", " ", " ", " ", " ", "dvRo", " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[33] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "bY",   "w", "w", "w", "w", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "dhGc", "w", "dhYo", "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[34] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", " ",    "w", "w", "w", "w", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", "bB",   "w", "w", "w", "w", "w", "w", "w",    " ",    "w",    "w", "w", "w", " ",    "w" };
        maplayout[35] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "dhBo", "w", "w", "w", "w", "dhGo", "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", " ",    "w", "w", "w", "w", "w", "w", "w",    "dhBc", "w",    "w", "w", "w", " ",    "w" };
        maplayout[36] = new string[40] { "w", "bB", " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", " ",    " ", " ",    "w", "w", "w", "w", "w", " ", " ",    " ",    " ",    " ", " ", " ", "bG",   "w" };
        maplayout[37] = new string[40] { "w", "w",  "w", "w", "w", " ", "w", "w", "w",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "dhRc", "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", "w",    "w" };
        maplayout[38] = new string[40] { "w", " ",  " ", " ", " ", " ", " ", " ", " ",    " ", " ", " ", " ", " ",    " ", " ",  " ",    " ", " ", " ", " ", " ",    " ", " ",    " ", " ",    " ", " ", " ", " ", " ", " ", " ",    " ",    " ",    " ", " ", " ", " ",    "w" };
        maplayout[39] = new string[40] { "w", "w",  "w", "w", "w", "w", "w", "w", "w",    "w", "w", "w", "w", "w",    "w", "w",  "w",    "w", "w", "w", "w", "w",    "w", "w",    "w", "w",    "w", "w", "w", "w", "w", "w", "w",    "w",    "w",    "w", "w", "w", "w",    "w" };

        //buildLevel(maplayout);
    }

    public void toggleDoor(int xCoord, int yCoord, bool open)
    {
        if (open)
        {
            mapLayoutGameObject[yCoord][xCoord].GetComponent<Animator>().Play("DoorOpening");
        }
        else
        {
            mapLayoutGameObject[yCoord][xCoord].GetComponent<Animator>().Play("DoorClosing");
        }
    }

    public void movePlayer(int id, int xCord, int zCord, float dur)
    {
        GameObject target;
        if (id == playerId) {
            target = player;
        }
        else
        {
            target = enemyPlayer;
        }
        var navigateToPos = target.GetComponent<NavigatePosition>();
        Vector3 currentPos = target.transform.position;
        Vector3 endPos = new Vector3((float)(xCord-19.5), (float)(0.25), (float)(19.5 - zCord));
        navigateToPos.navigateTo(currentPos, endPos, dur);
    }

    public void createPlayer(int xPos, int zPos, int id, int me)
    {
        Vector3 startPos = new Vector3((float)(xPos-19.5), 0.25f, (float)(19.5 - zPos));
        if (me == 1)
        {
            player = Instantiate(player);
            player.transform.SetParent(transform);
            player.transform.position = startPos;
            playerId = id;
        }
        else
        {
            enemyPlayer = Instantiate(enemyPlayer);
            enemyPlayer.transform.SetParent(transform);
            enemyPlayer.transform.position = startPos;
            var renderer = enemyPlayer.GetComponent<Renderer>();
            renderer.material.color = new Color(230f/255f, 116f/255f, 0);
            enemyPlayerId = id;
        }
    }

    public void teleportPlayer(int id, int c, int r)
    {
        GameObject target;
        if (id == playerId)
        {
            target = player;
        }
        else
        {
            target = enemyPlayer;
        }
        var navigateToPos = target.GetComponent<NavigatePosition>();
        navigateToPos.stopMoving();
        target.transform.position = new Vector3((float)(c - 19.5), (float)(0.5), (float)(19.5 - r));
    }

    public void buildLevel(int c, int r, string input)
    {
        input = input.Replace("\"", "");
        if (input == "w")
        {
            var wallPiece = Instantiate(wallBlock);
            wallPiece.transform.SetParent(transform);
            Vector3 newPosition = new Vector3((float)(c - 19.5), (float)(0.5), (float)(19.5 - r));
            wallPiece.transform.position = newPosition;
            mapLayoutGameObject[r][c] = wallPiece;
        }
        if (input.Substring(0, 1) == "d")
        {
            var doorPiece = Instantiate(door);
            doorPiece.transform.SetParent(transform);
            Vector3 newPosition = new Vector3((float)(c - 19.5), (float)(0.5), (float)(19.5 - r));
            doorPiece.transform.position = newPosition;
            if (input.Substring(1, 1) == "h")
            {
                Vector3 newRotation = new Vector3(0, 90, 0);
                doorPiece.transform.Rotate(newRotation);
            }
            if (input.Substring(2, 1) == "R")
            {
                foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.red;
            }
            else if (input.Substring(2, 1) == "B")
            {
                foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.blue;
            }
            else if (input.Substring(2, 1) == "G")
            {
                foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.green;
            }
            else if (input.Substring(2, 1) == "Y")
            {
                foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.yellow;
            }
            else if (input.Substring(2, 1) == "P")
            {
                foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.magenta;
            }
            if (input.Substring(3, 1) == "c")
            {
                doorPiece.GetComponent<Animator>().Play("DoorClosing");
            }

            mapLayoutGameObject[r][c] = doorPiece;
        }
        if (input.Substring(0, 1) == "b")
        {
            var buttonPiece = Instantiate(button);
            buttonPiece.transform.SetParent(transform);
            Vector3 newPosition = new Vector3((float)(c - 19.5), (float)(0.05), (float)(19.5 - r));
            buttonPiece.transform.position = newPosition;
            if (input.Substring(1, 1) == "R")
            {
                foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.red;
            }
            else if (input.Substring(1, 1) == "B")
            {
                foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.blue;
            }
            else if (input.Substring(1, 1) == "G")
            {
                foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.green;
            }
            else if (input.Substring(1, 1) == "Y")
            {
                foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.yellow;
            }
            else if (input.Substring(1, 1) == "P")
            {
                foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                    child.material.color = Color.magenta;
            }

            mapLayoutGameObject[r][c] = buttonPiece;
        }
    }
}
