using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;
    [SerializeField] private List<GameObject> itemPrefabList = new List<GameObject>();
    [SerializeField] private Transform[] pointTransformArray;



    [SerializeField] private int totalSampah;
    [SerializeField] private int spawnConcurrent;
    private int spawnedCount;
    private int counter = 0;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    private void Start()
    {
        SpawnConcurrentAtRandomPoint();
    }



    private void SpawnConcurrentAtRandomPoint()
    {
        while (counter < spawnConcurrent)
        {
            counter++;
            spawnedCount++;
            int randomPrefabIndex = Random.Range(0, itemPrefabList.Count);
            int randomPositionIndex = Random.Range(0, pointTransformArray.Length);

            Instantiate(itemPrefabList[randomPrefabIndex], pointTransformArray[randomPositionIndex].position, Quaternion.identity);
        }
    }

    

    public void ReduceCounter()
    {
        counter--;
    }
}
