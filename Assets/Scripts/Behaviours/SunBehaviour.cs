using UnityEngine;
using System.Collections;

public class SunBehaviour : MonoBehaviour {

    public float angle;
    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void Update()
    {
        transform.GetChild(0).Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
