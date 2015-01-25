using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {

    private static float GRAVITY        = 9.81f;
    private static float DELAY          = 2f;

    private float time                  = 0f;

    public float scaleReduction;

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

    }

    void End()
    {
        Time.timeScale = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Time.timeScale = 0;
        }
        if (other.CompareTag("Hole"))
        {
            Debug.Log(other.name);
            if (other.name == "1")
            {
                transform.position = holes.GetChild(2).transform.position + new Vector3(2,0,0);
            }
            if (other.name == "2")
            {
                transform.position = holes.GetChild(1).transform.position + new Vector3(-2, 0, 0);
            } 
            if (other.name == "3")
            {
                transform.position = holes.GetChild(1).transform.position + new Vector3(-2, 0, 0);
            }
        }
    }
}
