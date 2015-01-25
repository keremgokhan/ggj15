using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {

    private static float GRAVITY        = 9.81f;
    private static float DELAY          = 5f;

    private float time                  = 0f;

    public float scaleReduction;


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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Time.timeScale = 0;
        }
        if (other.CompareTag("Hole"))
        {
            Time.timeScale = 0;
        }
    }
}
