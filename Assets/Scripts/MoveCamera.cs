using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    private Vector3 CurrentCameraPosition;
    private Vector3 LastMousePosition;

    public bool canImove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        if (canImove)
        {

			Vector3 delta = LastMousePosition - Input.mousePosition;
            delta.y = 0;
            delta.z = 0;
            Camera.main.transform.position = CurrentCameraPosition + delta * 0.07f;
            LastMousePosition = Input.mousePosition;
            CurrentCameraPosition = Camera.main.transform.position;
            if (CurrentCameraPosition.x < -2f)
            {
                Camera.main.transform.position = new Vector3(-2.0f, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            else if (CurrentCameraPosition.x > 8f)
            {
                Camera.main.transform.position = new Vector3(8.0f, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            
        }

    }

    void OnMouseDown()
    {
        LastMousePosition = Input.mousePosition;
        CurrentCameraPosition = Camera.main.transform.position;
    }
}   
    
