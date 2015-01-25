using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {

    private static float GRAVITY        = 9.81f;
    private static float DELAY          = 2f;

    private float time                  = 0f;

    public float scaleReduction;

    public Renderer fadeout;
    public GameObject endPart;

    public Transform holes;

    void Update()
    {
        //transform.forward = new Vector3(-Input.acceleration.x, -Input.acceleration.y, transform.forward.z);
        Physics2D.gravity = new Vector2(Input.acceleration.x, Input.acceleration.y) * GRAVITY;
        time += Time.deltaTime;
        if (time - DELAY > 0)
        {
            if (transform.localScale.x < 0.2f)
            {
                Time.timeScale = 0;
                return;
            }
            transform.localScale -= new Vector3(1,1,1) * scaleReduction;
            
            time = 0f;

        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.transform.CompareTag("btn_ok"))
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

    void End()
    {
        Time.timeScale = 1;
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
        if (other.CompareTag("Exit"))
        {
            Time.timeScale = 1;
			Application.LoadLevel(0);
        }
        if (other.CompareTag("Hole"))
        {
            if (other.name == "1")
            {
                transform.position = holes.GetChild(1).transform.position + new Vector3(1.5f,0,0);
            }
            if (other.name == "2")
            {
                transform.position = holes.GetChild(0).transform.position + new Vector3(-1.5f, 0, 0);
            } 

        }
    }
}
