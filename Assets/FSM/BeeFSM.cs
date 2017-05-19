using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeFSM : MonoBehaviour
{
    public State CurrentState = null;
    Stack<State> states = new Stack<State>();
    public int pollen;

    public Graze graze;
    public SeekFlower seek;
    public CollectPollen collect;
    public RunHome runhome;

    public GameObject[] flowers;
    public Flower flower = null;
    public GameObject hive = null;

    // Use this for initialization
    void Start()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        hive = GameObject.FindGameObjectWithTag("Hive");
        SeekClosestFlower();
        seek = GetComponent<SeekFlower>();
        graze = GetComponent<Graze>();
        collect = GetComponent<CollectPollen>();
        runhome = GetComponent<RunHome>();
 
        StartCoroutine(Think());
    }

    void Update()
    {
        if(CurrentState == null)
        {
            PushState(graze);
        }
    }
    public void PushState(State newState)
    {
        states.Push(newState);
        CurrentState = newState;
    }
    public void PopState()
    {
        if(states.Count > 1)
        {
            states.Pop();
            CurrentState = states.Peek();
        }

    }

    IEnumerator Think()
    {
        while(true)
        {
            SeekClosestFlower();
            if(CurrentState != null)
            {
                CurrentState.Run();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SeekClosestFlower()
    {
        foreach (GameObject f in flowers)
        {
            
            if(f.activeInHierarchy || f.GetComponent<Flower>().alive)
            {
                if (flower == null)
                {
                    //random flower
                    flower = flowers[Random.Range(0, flowers.Length-1)].GetComponent<Flower>();
                }
                else if (Vector3.Distance(f.transform.position, transform.position) < Vector3.Distance(flower.transform.position, transform.position))
                {
                    flower = f.GetComponent<Flower>();
                }
            }
        }
    }
}
