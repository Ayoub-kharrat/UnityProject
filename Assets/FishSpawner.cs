using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject	FishPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFish(int n) {
	//avoid out of bound
	n = n>SpawnPoints.Length?SpawnPoints.Length:n;
	int w = n;
	while (n >1) {
		int k = Random.Range(0, n--);
		GameObject temp = SpawnPoints[n];
		SpawnPoints[n] = SpawnPoints[k];
		SpawnPoints[k] = temp;
		Debug.Log(k);
	}

	
	//spawn fish at each
	for (int i = 0; i < w; i++) {
		GameObject spawner = SpawnPoints[i];
		Debug.Log(spawner);
		Instantiate(FishPrefab, spawner.transform.position, Quaternion.identity);
	}
    }
}
