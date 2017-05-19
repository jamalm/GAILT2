using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour
{
    public GameObject pointerPrefab;
    public float radius = 20.0f;
    public Vector3 target = Vector3.zero;
    public GameObject currPoint = null;

    // Use this for initialization
    void Start()
    {
        target = Random.insideUnitSphere * radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnNewPoint()
    {
        DestroyPoint();
        target = Random.insideUnitSphere * radius;
        currPoint = (GameObject)Instantiate(pointerPrefab, target, Quaternion.identity);
        return currPoint;
    }
    public void DestroyPoint()
    {
        if(currPoint != null)
            Destroy(currPoint);
    }
}
