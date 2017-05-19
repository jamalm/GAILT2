using UnityEngine;
using System.Collections;
using System;

public class SeekFlower : State
{
    
    public override void Run()
    {
        if(!active)
        {
            Activate();
            GetComponent<Seek>().enabled = true;
            GetComponent<Seek>().targetObj = brain.flower.gameObject;
        }

        if(Vector3.Distance(brain.flower.transform.position, transform.position) < 1)
        {
            brain.PopState();
            brain.PushState(brain.collect);
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
