using UnityEngine;
using System.Collections;
using System;

public class Seek : SteeringBehaviour
{

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

    public override Vector3 Calculate()
    {
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= boid.maxVelocity;
        return desiredVelocity - boid.velocity;
    }
}
