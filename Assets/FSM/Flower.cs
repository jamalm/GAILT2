using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    public int pollen = 5;
    public bool alive = true;
    public GameObject[] bees;
    // Use this for initialization
    void Start()
    {
        bees = GameObject.FindGameObjectsWithTag("Bee");
        StartCoroutine(CheckForBees());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CheckForBees()
    {
        while(true)
        {
            if(bees.Length == 0)
            {
                bees = GameObject.FindGameObjectsWithTag("Bee");
            }
            foreach(GameObject bee in bees)
            {
                if(Vector3.Distance(bee.transform.position, transform.position) < 2)
                {
                    pollen--;
                    bee.GetComponent<BeeFSM>().pollen++;
                }
            }
            if(pollen == 0)
            {
                alive = false;
            }
            yield return new WaitForSeconds(1);
        }
    }

    
}
