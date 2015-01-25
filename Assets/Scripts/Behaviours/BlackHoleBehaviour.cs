using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CircleCollider2D))]
public class BlackHoleBehaviour : MonoBehaviour {

    public float mass;
    public float angle;
    public float rotationSpeed;


    private Transform ring;
    private Transform body;

    void Awake()
    {
        body = transform.GetChild(0).transform;
        ring = transform.GetChild(1).transform;
    }

    // Use this for initialization
    void Start()
    {
        body.localEulerAngles = new Vector3(0, 0, angle);
        ring.localScale *= transform.gameObject.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        //body.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
        ring.Rotate(new Vector3(0, 0, 1), 10 * Time.deltaTime);

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Photon")) 
        {
            PhotonBehaviour photonScript = other.GetComponent<PhotonBehaviour>();
            Vector3 f = (transform.position - other.transform.position);

            float distance = f.magnitude;
            f.Normalize();
            Vector2 force = new Vector2(f.x, f.y);
            force *= (mass / (distance * distance));

            photonScript.ApplyForce(force);
        }

    }
}
