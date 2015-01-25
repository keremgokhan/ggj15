using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private bool isStarted = false;
    public PhotonBehaviour photon;

	public Sprite restartSprite;

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
            Camera.main.GetComponent<CameraFollow>().enabled = true;
            photon.GetComponent<PhotonBehaviour>().velocity = new Vector2(8, 0);
            isStarted = true;
			transform.GetComponent<SpriteRenderer>().sprite = restartSprite;
        }
        else 
        {
            Time.timeScale = 1;
            Application.LoadLevel(1);
        }

    }
}
