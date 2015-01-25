using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject part1;
	public GameObject part2;

	public GameObject level2active;
	public GameObject level3active;

	void Awake () {
		int level = PlayerPrefs.GetInt("CurrentLevel", 1);

		if (level > 1) 
		{
			level2active.SetActive(true);
		}
		if (level == 3)
		{
			level3active.SetActive(true);
		}
	}

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
				temp.x *= 1.3f;
				temp.y *= 1.3f;
				hit.transform.localScale = temp;

				/*if (tag == "btn_play") 
				{
					part1.SetActive(false);
					part2.SetActive(true);
				}
				if (tag == "btn_lvl1") 
				{
					Application.LoadLevel(1);
				}*/
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
				temp.x /= 1.3f;
				temp.y /= 1.3f;
				hit.transform.localScale = temp;
				
				if (tag == "btn_play") 
				{
					part1.SetActive(false);
					part2.SetActive(true);
				}
				if (tag == "btn_info") 
				{
					Application.LoadLevel(4);
				}
				if (tag == "btn_lvl1") 
				{
					Application.LoadLevel(1);
				}
                if (tag == "btn_lvl2")
                {
                    Application.LoadLevel(2);
                }
                if (tag == "btn_lvl3")
                {
                    Application.LoadLevel(3);
                }
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.LoadLevel(0); 
		}
	
	}
}
