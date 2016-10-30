using UnityEngine;
using System.Collections;

public class NavigatePosition : MonoBehaviour {

    float startTime;
    Vector3 startPosition;
    Vector3 endPosition;
    bool moving = false;

	// Use this for initialization
	void Start () {

	}

    public void navigateTo(Vector3 startPos, Vector3 endPos)
    {
        startTime = Time.time;
        startPosition = startPos;
        endPosition = endPos;
        moving = true;
    }

    // Update is called once per frame
    void Update () {
        if (moving)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, 1 * (Time.time - startTime));

        }
    }
}
