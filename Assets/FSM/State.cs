using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour
{
    public bool active = false;
    public BeeFSM brain;
    public SteeringBehaviour[] behaviours;
    // Use this for initialization
    void Start()
    {
        behaviours = GetComponents<SteeringBehaviour>();
        brain = GetComponent<BeeFSM>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        //set up new behaviour for this state
        if (!active)
        {
            foreach (SteeringBehaviour b in behaviours)
            {
                //unset all behaviours
                b.enabled = false;
            }
        }
    }
    public abstract void Run();
}
