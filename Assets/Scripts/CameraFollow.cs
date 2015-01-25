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


		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				string tag = hit.transform.tag;
				Debug.Log ("Target Position: " + hit.transform.tag);

				
				if (tag == "btn_play") 
				{
					Vector3 temp = hit.transform.localScale;
					temp.x *= 1.2f;
					temp.y *= 1.2f;
					hit.transform.localScale = temp;


					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Time.timeScale = 1;
			Application.LoadLevel(0); 
		}


	}
}
