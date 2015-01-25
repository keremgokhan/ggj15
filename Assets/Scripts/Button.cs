using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private bool isStarted = false;
    public PhotonBehaviour photon;
	// Use this for initialization
	void Start () {
        isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (!isStarted)
        {
            photon.GetComponent<PhotonBehaviour>().velocity = new Vector2(8, 0);
            isStarted = true;
        }
        else 
        {
            Time.timeScale = 1;
            Application.LoadLevel(1);
        }

    }
}
