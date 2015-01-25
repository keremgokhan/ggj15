using UnityEngine;
using System.Collections;

public class BenjaminButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		Vector3 temp = transform.localScale;
		temp.x *= 1.2f;
		temp.y *= 1.2f;
		transform.localScale = temp;
	}

	void OnMouseUp () {
		Vector3 temp = transform.localScale;
		temp.x /= 1.2f;
		temp.y /= 1.2f;
		transform.localScale = temp;
		Application.LoadLevel(0);
	}
}
