using UnityEngine;
using System.Collections;

public class PhotonBehaviour : MonoBehaviour {
        
    public Vector2 velocity = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
	}

    public void ApplyForce(Vector2 force)
    {
        velocity += force;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Core"))
        {
            Debug.Log("Photon Crushed!");
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Earth"))
        {
            Debug.Log("Well Done!");
            Time.timeScale = 0;
        }
    }
}
