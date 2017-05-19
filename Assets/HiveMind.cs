using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HiveMind : MonoBehaviour {

    public int pollen = 10;
    public GameObject beePrefab;
    List<GameObject> bees = new List<GameObject>();

	// Use this for initialization
	void Start () {
        StartCoroutine(CheckHive());
	}
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnBee()
    {
        //older API on lab machines? casting should no longer be needed
        bees.Add((GameObject)Instantiate(beePrefab, transform.position, Quaternion.identity));
        pollen -= 5;
    }


    IEnumerator CheckHive()
    {
        while (true)
        {
            if (bees.Count < 10 && pollen >= 5)
            {
                SpawnBee();
            }
            yield return new WaitForSeconds(2);
        }
    }
}
