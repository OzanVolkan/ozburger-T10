using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject breadToSpawn;
    public List<GameObject> breads;

    private int attemptCount;

    private void Start()
    {
        instance = this;
        InvokeRepeating("BreadSpawn", 2.0f, 3f);
    }

    private Vector3 GetProperSpawnPos(out bool isAvailable)
    {
        attemptCount = 0;
        Vector3 tempPosition;
        while (attemptCount <100)
        {
            tempPosition = new Vector3(Random.Range(-4.60f, -4.20f), Random.Range(1.05f, 1.05f), Random.Range(2f, 4.4f));
            if(IsPositionSafe(tempPosition))
            {                   
                isAvailable = true;
                return tempPosition;
            }
            attemptCount++;
        }
        isAvailable = false;
        return Vector3.zero;
    }

    private bool IsPositionSafe(Vector3 position)
    {
        foreach (GameObject gameObject in breads)
        {
            float distance = Vector3.Distance(gameObject.transform.position, position);
            if (distance <= 0.5f) return false;
        }
        return true;
    }

    public void BreadSpawn()
    {
        bool isAvailable;
        Vector3 spawnPosition = GetProperSpawnPos(out isAvailable);
        if (isAvailable)
        {
            GameObject bread = Instantiate(breadToSpawn, spawnPosition, Quaternion.identity);
            breads.Add(bread);
        }
    }
}
