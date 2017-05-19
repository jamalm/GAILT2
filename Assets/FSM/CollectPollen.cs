using UnityEngine;
using System.Collections;
using System;

public class CollectPollen : State
{
    public override void Run()
    {
        if(!active)
        {
            Activate();
            GetComponent<Arrive>().enabled = true;
            GetComponent<Arrive>().targetObj = brain.flower.gameObject;
            
        }

        if(!brain.flower.alive)
        {
            brain.PopState();
            brain.flower = null;
            brain.PushState(brain.runhome);
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
