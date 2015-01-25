using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeafBehaviour : MonoBehaviour {

	public Slider aq;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (aq.value >= 0.99f)
		{
			Application.LoadLevel(0);
		}

		aq.value -= 0.001f * Time.deltaTime * 60;
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "CO2")
		{
			aq.value += 0.2f; 
		}
		else if(col.gameObject.tag == "Nitro")
		{
			aq.value -= 0.2f; 
		}
		else if(col.gameObject.tag == "O2")
		{
			aq.value -= 0.2f;
		}
	}
}
