using UnityEngine;
using System.Collections;
using System;

public class RunHome : State
{
    public override void Run()
    {
        if(!active)
        {
            Activate();
            GetComponent<Arrive>().enabled = true;
            GetComponent<Arrive>().targetObj = brain.hive;
        }

        if(brain.pollen == 0)
        {
            brain.PopState();
        }
        if(Vector3.Distance(brain.hive.transform.position, transform.position) < 3 && brain.pollen > 0)
        {
            brain.hive.GetComponent<HiveMind>().pollen++;
            brain.pollen--;
        }
    }

    // Use this for initialization
    void Start()
    {
        brain = GetComponent<BeeFSM>();
        behaviours = GetComponents<SteeringBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
