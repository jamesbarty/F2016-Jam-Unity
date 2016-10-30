using UnityEngine;
using System.Collections;
using System;

public class BuildMap : MonoBehaviour {

    public GameObject floor;
    public GameObject wallBlock;
    public GameObject door;
    public GameObject button;
    public GameObject player;
    public GameObject enemyPlayer;

    private string[][] maplayout = new string[40][];

    private GameObject[][] mapLayoutGameObject = new GameObject[40][];

    // Use this for initialization
    void Start () {
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

    public void buildLevel(string[][] maplayout)
    {
        //GameObject playerNew = Instantiate(player);
        //playerNew.transform.position = new Vector3((float)(-18.5), (float)(0.25), (float)(-18.5));
        floor = Instantiate(floor);
        floor.transform.position += new Vector3(0, 0, 0);

        for (int i = 0; i < maplayout.Length; i++)
        {
            for (int j = 0; j < maplayout[i].Length; j++)
            {
                if (maplayout[i][j] == "w")
                {
                    var wallPiece = Instantiate(wallBlock);
                    Vector3 newPosition = new Vector3((float)(j - 19.5), (float)(0.5), (float)(i - 19.5));
                    wallPiece.transform.position = newPosition;
                }
                if (maplayout[i][j].Substring(0, 1) == "d")
                {
                    var doorPiece = Instantiate(door);
                    Vector3 newPosition = new Vector3((float)(j - 19.5), (float)(0.5), (float)(i - 19.5));
                    doorPiece.transform.position = newPosition;
                    if (maplayout[i][j].Substring(1, 1) == "h")
                    {
                        Vector3 newRotation = new Vector3(0, 90, 0);
                        doorPiece.transform.Rotate(newRotation);
                    }
                    if (maplayout[i][j].Substring(2, 1) == "R")
                    {
                        foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.red;
                    }
                    else if (maplayout[i][j].Substring(2, 1) == "B")
                    {
                        foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.blue;
                    }
                    else if (maplayout[i][j].Substring(2, 1) == "G")
                    {
                        foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.green;
                    }
                    else if (maplayout[i][j].Substring(2, 1) == "Y")
                    {
                        foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.yellow;
                    }
                    else if (maplayout[i][j].Substring(2, 1) == "P")
                    {
                        foreach (var child in doorPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.magenta;
                    }
                    if (maplayout[i][j].Substring(3, 1) == "c")
                    {
                        doorPiece.GetComponent<Animator>().Play("DoorClosing");
                    }
                }
                if (maplayout[i][j].Substring(0, 1) == "b")
                {
                    var buttonPiece = Instantiate(button);
                    Vector3 newPosition = new Vector3((float)(j - 19.5), (float)(0.05), (float)(i - 19.5));
                    buttonPiece.transform.position = newPosition;
                    if (maplayout[i][j].Substring(1, 1) == "R")
                    {
                        foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.red;
                    }
                    else if (maplayout[i][j].Substring(1, 1) == "B")
                    {
                        foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.blue;
                    }
                    else if (maplayout[i][j].Substring(1, 1) == "G")
                    {
                        foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.green;
                    }
                    else if (maplayout[i][j].Substring(1, 1) == "Y")
                    {
                        foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.yellow;
                    }
                    else if (maplayout[i][j].Substring(1, 1) == "P")
                    {
                        foreach (var child in buttonPiece.GetComponentsInChildren<Renderer>())
                            child.material.color = Color.magenta;
                    }
                }
            }
        }
    }
}
