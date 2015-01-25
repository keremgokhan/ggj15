using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeafBehaviour : MonoBehaviour {

	public Slider aq;

    public Renderer fadeout;
    public GameObject endPart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (aq.value >= 0.99f)
		{
			if (PlayerPrefs.GetInt("CurrentLevel", 1) < 3)
				PlayerPrefs.SetInt("CurrentLevel", 3);
            Time.timeScale = 0;
            StartCoroutine(Fadeout());
		}

		aq.value -= 0.001f * Time.deltaTime * 60;
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
