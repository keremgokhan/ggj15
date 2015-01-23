using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {

    public float mass;

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
