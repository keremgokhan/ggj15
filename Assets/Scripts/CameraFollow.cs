using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float topBorder;
    public float bottomBorder;
    public float leftBorder;
    public float rightBorder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (transform.position.x < leftBorder)
            transform.position = new Vector3(leftBorder,transform.position.y, transform.position.z);
        if (transform.position.x > rightBorder)
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        if (transform.position.y < bottomBorder)
            transform.position = new Vector3(transform.position.x, bottomBorder, transform.position.z);
        if (transform.position.y > topBorder)
            transform.position = new Vector3(transform.position.x, topBorder, transform.position.z);
	}
}
