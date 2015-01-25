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

			RaycastHit hit2;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit2) && hit2.transform.tag != "Leaf")
			{
				string tag = hit2.transform.tag;
				Debug.Log ("Target Position: " + hit2.transform.tag);
				
				Vector3 temp = hit2.transform.localScale;
				temp.x *= 1.2f;
				temp.y *= 1.2f;
				hit2.transform.localScale = temp;
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
					StartTheLevel();
				}
			}

			RaycastHit hit2;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit2) && hit2.transform.tag != "Leaf")
			{
				string tag = hit2.transform.tag;
				Debug.Log ("Target Position: " + hit2.transform.tag);
				
				Vector3 temp = hit2.transform.localScale;
				temp.x /= 1.2f;
				temp.y /= 1.2f;
				hit2.transform.localScale = temp;
				
				hit2.transform.position = randomPosition();
				hit2.rigidbody.velocity = randomVelocity();
			}
		}
	}

	public Vector3 randomPosition()
	{
		float x, y, z;
		x = Random.Range(-5.8f, 5.0f);
		y = Random.Range(7.0f, 60.0f);
		z = Random.Range(-0.4f, 2.4f);
		return new Vector3(x,y,z);
	}

	public Vector3 randomRotation()
	{
		float x, y, z;
		x = 0;
		y = Random.Range(0, 360);
		z = 0;
		return new Vector3(x,y,z);
	}

	public Vector3 randomVelocity()
	{
		float x, y, z;
		x = 0;
		y = Random.Range(-10.0f, -5.0f);
		z = 0;
		return new Vector3(x,y,z);
	}

	public void StartTheLevel()
	{
		for (int i=0; i < NumberOfCO2; i++)
		{
			Transform temp = (Transform) Instantiate(CarbonDioxidePrefab, randomPosition(), CarbonDioxidePrefab.rotation);
			temp.rigidbody.velocity = randomVelocity();
			temp.transform.localEulerAngles = randomRotation();
		}

		for (int i=0; i < NumberOfO2; i++)
		{
			Transform temp = (Transform)Instantiate(OxygenPrefab, randomPosition(), OxygenPrefab.rotation);
			temp.rigidbody.velocity = randomVelocity();
			temp.transform.localEulerAngles = randomRotation();
		}

		for (int i=0; i < NumberOfN; i++)
		{
			Transform temp = (Transform)Instantiate(NitrogenPrefab, randomPosition(), NitrogenPrefab.rotation);
			temp.rigidbody.velocity = randomVelocity();
			temp.transform.localEulerAngles = randomRotation();
		}
	}
}
