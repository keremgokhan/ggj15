using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {

    public float angle;
    public float rotationSpeed;


    private Transform body;

    void Awake()
    {
        body = transform.GetChild(0).transform;
    }

    // Use this for initialization
    void Start()
    {
        body.localEulerAngles = new Vector3(0, 0, angle);
    }

    void Update()
    {
        body.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

    }


}
