using UnityEngine;
using System.Collections;

public class CO2Level : MonoBehaviour {

	public GameObject overlay;

	public Transform OxygenPrefab;
	public Transform CarbonDioxidePrefab;
	public Transform NitrogenPrefab;

	public float BubbleVelocity = 0;
	public int NumberOfCO2 = 2;
	public int NumberOfO2 = 5;
	public int NumberOfN = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				string tag = hit.transform.tag;
				Debug.Log ("Target Position: " + hit.transform.tag);
				
				Vector3 temp = hit.transform.localScale;
				temp.x *= 1.2f;
				temp.y *= 1.2f;
				hit.transform.localScale = temp;
			}
		}

		if (Input.GetMouseButtonUp(0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				string tag = hit.transform.tag;
				Debug.Log ("Target Position: " + hit.transform.tag);
				
				Vector3 temp = hit.transform.localScale;
				temp.x /= 1.2f;
				temp.y /= 1.2f;
				hit.transform.localScale = temp;
				
				if (tag == "btn_play") 
				{
					overlay.SetActive(false);
				}
			}
		}
	}
}
