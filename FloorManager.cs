using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] FloorPrefabs;
    public void SpawnFloor()
    {
       int r = Random.Range(0, FloorPrefabs.Length);
        GameObject floor = Instantiate(FloorPrefabs[r], transform);
        floor.transform.position = new Vector3(Random.Range(-4.2f, 2.7f), -6f, 0f);
    }
}
