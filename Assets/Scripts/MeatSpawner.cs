using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawner : MonoBehaviour
{
    public static MeatSpawner instance;

    public GameObject steakToSpawn;
    public List<GameObject> meats;

    private int attemptCount;
    void Start()
    {
        instance = this;
        InvokeRepeating("SteakSpawn", 2f, 9f);
    }

    private Vector3 GetProperSpawnPos(out bool isAvailable)
    {
        attemptCount = 0;
        Vector3 tempPosition;
        while (attemptCount < 100)
        {
            tempPosition = new Vector3(Random.Range(-3f, -.9f), Random.Range(.97f, .97f), Random.Range(-4.2f, -4.62f));
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
        foreach (GameObject gameObject in meats)
        {
            float distance = Vector3.Distance(gameObject.transform.position, position);
            if (distance <= .55f) return false;
        }
        return true;
    }
    public void SteakSpawn()
    {
        bool isAvailable;
        Vector3 spawnPosition = GetProperSpawnPos(out isAvailable);
        if (isAvailable)
        {
            GameObject steak = Instantiate(steakToSpawn, spawnPosition, Quaternion.identity);
            meats.Add(steak);
        }
    }
}
