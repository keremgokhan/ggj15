using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {

    public float mass;
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
