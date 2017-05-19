using UnityEngine;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
    public GameObject flowerPrefab;
    public int flowerNum = 5;
    public int lowerThreshold = 2;
    public float flowerSpawnRadius = 50.0f;

    List<GameObject> flowers = new List<GameObject>();
	// Use this for initialization
	void Start () {
        for(int i=0;i< flowerNum;i++)
        {
            SpawnFlower();
        }
	}
	
	// Update is called once per frame
	void Update () {
        FlowerGrowth();
	}

    void FlowerGrowth()
    {
        if(flowers.Count < lowerThreshold)
        {
            SpawnFlower();
        }
    }

    void SpawnFlower()
    {
        Vector3 pos = new Vector3(Random.Range(-flowerSpawnRadius, flowerSpawnRadius), 0, Random.Range(-flowerSpawnRadius, flowerSpawnRadius));
        flowers.Add((GameObject)Instantiate(flowerPrefab, pos, Quaternion.identity));
    }

}
