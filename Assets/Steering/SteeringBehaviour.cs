using UnityEngine;
using System.Collections;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public Boid boid;
    public GameObject targetObj;
    public Vector3 target = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateTarget()
    {
        if(targetObj != null)
        {
            target = targetObj.transform.position;
        }
    }
    public abstract Vector3 Calculate();
}
