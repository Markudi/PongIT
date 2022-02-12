using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    
    public GameObject[] powerUps;
    public Transform[] spawnTransforms;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomSpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator randomSpawnTimer()
    {
        float randomTime = Random.Range(6, 8);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(SpawnThings());
    }
    
    
    IEnumerator SpawnThings()
    {
        Transform randomTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length)];
        // GameObject randomPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        GameObject instance = Instantiate(powerUps[Random.Range(0, powerUps.Length)]);

        instance.transform.position = randomTransform.position;

        yield return new WaitForSeconds(7);

        instance.GetComponent<SpriteRenderer>().enabled = false;
        instance.GetComponent<Collider2D>().enabled = false;
        
        
        StartCoroutine(randomSpawnTimer());

    }


    //Object will be destroyed within their own script
    // private void DestroyInstance(GameObject instance)
    // {
    //     Destroy(instance);
    // }
}
