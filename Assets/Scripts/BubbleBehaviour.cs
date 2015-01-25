using UnityEngine;
using System.Collections;

public class BubbleBehaviour : MonoBehaviour {

	public Vector3 randomPosition()
	{
		float x, y, z;
		x = Random.Range(-5.8f, 5.0f);
		y = Random.Range(7.0f, 60.0f);
		z = Random.Range(-0.4f, 2.4f);
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -8)
		{
			transform.position = randomPosition();
			transform.rigidbody.velocity = randomVelocity();
		}

	}
}
