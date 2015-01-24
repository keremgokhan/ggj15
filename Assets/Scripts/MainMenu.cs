using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject part1;
	public GameObject part2;

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
				if (tag == "btn_play") 
				{
					part1.SetActive(false);
					part2.SetActive(true);
				}
				if (tag == "btn_lvl1") 
				{
					Vector3 temp = hit.transform.localScale;
					temp.x *= 1.3f;
					temp.y *= 1.3f;
					hit.transform.localScale = temp;

					Application.LoadLevel(1);
				}
			}
		}
	
	}
}
