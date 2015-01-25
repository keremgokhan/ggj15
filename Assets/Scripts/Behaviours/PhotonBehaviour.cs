using UnityEngine;
using System.Collections;

public class PhotonBehaviour : MonoBehaviour {
        
    public Vector2 velocity = new Vector2(0, 0);

    public Renderer fadeout;
    public GameObject endPart;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null  && hit.transform.CompareTag("btn_ok"))
            {
                string tag = hit.transform.tag;
                Debug.Log("Target Position: " + hit.transform.tag);

                Vector3 temp = hit.transform.localScale;
                temp.x *= 1.3f;
                temp.y *= 1.3f;
                hit.transform.localScale = temp;

               
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.transform.CompareTag("btn_ok"))
            {
                string tag = hit.transform.tag;

                Vector3 temp = hit.transform.localScale;
                temp.x /= 1.3f;
                temp.y /= 1.3f;
                hit.transform.localScale = temp;

                if (tag == "btn_ok")
                {
                    Time.timeScale = 1;
                    Application.LoadLevel(0);
                }
                
            }
        }

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
        StartCoroutine(Fadeout());
    }

	public void Finish2()
	{
		Time.timeScale = 0;
	}

    IEnumerator Fadeout()
    {
        while (fadeout.material.color.a < 0.85f)
        {
            fadeout.material.color += new Color(0, 0, 0, 0.02f);

            yield return new WaitForEndOfFrame();
        }
        endPart.SetActive(true);
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
