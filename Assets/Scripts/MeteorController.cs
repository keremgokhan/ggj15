using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {

    public Transform blackhole;
    
    
    public float scalefactor = 1.3f;
    private float x;
    private float y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
	}

    void OnMouseDown()
    {
        this.transform.parent = null;
        transform.position += new Vector3(0, 30, 0);

        //Vector3 temp = this.transform.localScale;
        //temp.x *= scalefactor;
        //temp.y *= scalefactor;

        //this.transform.localScale = temp;
        GameObject.FindGameObjectWithTag("background").GetComponent<MoveCamera>().canImove = false;
    }

    void OnMouseUp()
    {
        //Vector3 temp = this.transform.localScale;
        //temp.x /= scalefactor;
        //temp.y /= scalefactor;

        //this.transform.localScale = temp;
        GameObject.FindGameObjectWithTag("background").GetComponent<MoveCamera>().canImove = true;
    }

    void OnMouseDrag()
    {
        //this.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f) );
        blackhole.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 40));
      
    }
}
