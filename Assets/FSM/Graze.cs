using UnityEngine;
using System.Collections;
using System;

public class Graze : State
{
    PathFinding pathfinder;
    // Use this for initialization
    void Start()
    {
        behaviours = GetComponents<SteeringBehaviour>();
        brain = GetComponent<BeeFSM>();
        pathfinder = GetComponent<PathFinding>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Run()
    {
        if (!active)
        { 
            Activate();
            //set our behaviour
            GetComponent<Arrive>().enabled = true;
            GetComponent<Arrive>().targetObj = pathfinder.SpawnNewPoint();
        }
        if(Vector3.Distance(pathfinder.currPoint.transform.position ,transform.position) < 2)
        {
            GetComponent<Arrive>().targetObj = pathfinder.SpawnNewPoint();
        }
        else if(Vector3.Distance(brain.flower.transform.position, transform.position) < 20)
        {
            pathfinder.DestroyPoint();
            brain.PushState(brain.seek);
        }
    }
}
