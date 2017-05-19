using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    public int pollen = 5;
    public bool alive = true;
    public GameObject[] bees;
    public GameObject bee = null;
    // Use this for initialization
    void Start()
    {
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
            bees = GameObject.FindGameObjectsWithTag("Bee");
            if (bees.Length == 0)
            {
                bees = GameObject.FindGameObjectsWithTag("Bee");
            }
            foreach(GameObject b in bees)
            {
                if (bee == null || Vector3.Distance(b.transform.position, transform.position) < Vector3.Distance(bee.transform.position, transform.position))
                    bee = b;
            }
            if(pollen == 0)
            {
                alive = false;
                gameObject.SetActive(false);
                
            }
            if (Vector3.Distance(bee.transform.position, transform.position) < 2)
            {
                pollen--;
                bee.GetComponent<BeeFSM>().pollen++;
            }
            yield return new WaitForSeconds(1);
        }
    }

    
}
