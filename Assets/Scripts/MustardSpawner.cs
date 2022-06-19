using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustardSpawner : MonoBehaviour
{
    public static MustardSpawner instance;

    public GameObject mustardToSpawn;
    public List<GameObject> mustards;

    private int attemptCount;
    void Start()
    {
        instance = this;
        InvokeRepeating("MustardSpawn", 2f, 6f);
    }

    private Vector3 GetProperSpawnPos(out bool isAvailable)
    {
        attemptCount = 0;
        Vector3 tempPosition;
        while (attemptCount < 100)
        {
            tempPosition = new Vector3(Random.Range(-4.65f, -4f), Random.Range(1.3f, 1.3f), Random.Range(-1.2f, -3.4f));
            if (IsPositionSafe(tempPosition))
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
        foreach (GameObject gameObject in mustards)
        {
            float distance = Vector3.Distance(gameObject.transform.position, position);
            if (distance <= 0.5f) return false;
        }
        return true;
    }

    public void MustardSpawn()
    {
        bool isAvailable;
        Vector3 spawnPosition = GetProperSpawnPos(out isAvailable);
        if (isAvailable)
        {
            GameObject mustard = Instantiate(mustardToSpawn, spawnPosition, Quaternion.identity);
            mustards.Add(mustard);
        }
    }
}
