using UnityEngine;
using System.Collections;

public class NavigatePosition : MonoBehaviour {

    float startTime;
    Vector3 startPosition;
    Vector3 endPosition;

    float t;
    float timeToReachTarget;
    bool moving = false;

	// Use this for initialization
	void Start () {

	}

    public void navigateTo(Vector3 startPos, Vector3 endPos, float dur)
    {
        t = 0;
        timeToReachTarget = dur / 1000; // In seconds
        startTime = Time.time;
        startPosition = startPos;
        endPosition = endPos;
        moving = true;
    }

    // Update is called once per frame
    void Update () {
        if (moving)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

        }
    }
}
