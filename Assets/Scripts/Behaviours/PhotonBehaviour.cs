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

		
		
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Time.timeScale = 1;
			Application.LoadLevel(0); 
		}
	}

    public void ApplyForce(Vector2 force)
    {
        velocity += force;
    }


    public void Hit()
    {
        transform.collider2D.enabled = false;
        velocity = new Vector2(0,0);
        Invoke("Finish", 1.2f);
    }

	public void Hit2()
	{
		transform.collider2D.enabled = false;
		velocity = new Vector2(0,0);
		Invoke("Finish2", 1.2f);
	}

    public void Finish()
    {
        Time.timeScale = 1;
		Application.LoadLevel(0);
    }

	public void Finish2()
	{
		Time.timeScale = 0;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Core"))
        {
            Hit2();
        }
        else if (other.CompareTag("Earth"))
        {
			PlayerPrefs.SetInt("CurrentLevel", 2);
            Hit();
        }
    }
}
