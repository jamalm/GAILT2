using UnityEngine;
using System.Collections;
using System;

public class Arrive : SteeringBehaviour
{
    float slowingDistance = 5f;
    public override Vector3 Calculate()
    {
        Vector3 desiredVelocity = target - transform.position;
        float distance = desiredVelocity.magnitude;

        float ramped = boid.maxVelocity * (distance / slowingDistance);
        float clamped = Mathf.Min(ramped, boid.maxVelocity);

        desiredVelocity = clamped * (desiredVelocity / distance);
        return desiredVelocity - boid.velocity;
    }

    // Use this for initialization
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
    }
}
