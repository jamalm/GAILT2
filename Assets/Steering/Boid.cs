using UnityEngine;
using System.Collections;

public class Boid : MonoBehaviour {

    Vector3 force = Vector3.zero;
    Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;
    public float maxVelocity = 5;

    SteeringBehaviour[] behaviours;

	// Use this for initialization
	void Start () {
        behaviours = GetComponents<SteeringBehaviour>();
	}

    // Update is called once per frame
    void Update() {
        force = CalculateForces();
        //get acceleration
        Vector3 newAccel = force / mass;
        //lerp to new acceleration
        acceleration = Vector3.Lerp(acceleration, newAccel, 0.2f);
        //calc velocity
        velocity += acceleration * Time.deltaTime;
        //clamp to max velocity
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        //dampen
        if(velocity.magnitude > 0.00001f)
        {
            velocity *= 0.99f;
        }
        transform.position += velocity * Time.deltaTime;
    }

    Vector3 CalculateForces()
    {
        force = Vector3.zero;
        foreach(SteeringBehaviour b in behaviours)
        {
            if(b.isActiveAndEnabled)
            {
                force += b.Calculate();
            }
        }
        return force;
    }

    
}
