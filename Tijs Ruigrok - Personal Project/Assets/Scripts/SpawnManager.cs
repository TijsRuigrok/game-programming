using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomObject()
    {
        while(true)
        {
            float spawnRate = Random.Range(2, 4);
            yield return new WaitForSeconds(spawnRate);
            int objectIndex = Random.Range(0, spawnPrefabs.Length);

            Instantiate(spawnPrefabs[objectIndex], transform.position,
            spawnPrefabs[objectIndex].transform.rotation);
        }
    }
}
