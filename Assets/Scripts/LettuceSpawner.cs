using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceSpawner : MonoBehaviour
{
    public static LettuceSpawner instance;

    public GameObject lettuceToSpawn;
    public List<GameObject> lettuces;

    private int attemptCount;
    void Start()
    {
        instance = this;
        InvokeRepeating("LettuceSpawn", 2f, 2f);
    }

    private Vector3 GetProperSpawnPos(out bool isAvailable)
    {
        attemptCount = 0;
        Vector3 tempPosition;
        while (attemptCount<100)
        {
            tempPosition = new Vector3(Random.Range(-4.55f, -4.1f), Random.Range(1f, 1f), Random.Range(1.5f, -.65f));
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
        foreach (GameObject gameObject in lettuces)
        {
            float distance = Vector3.Distance(gameObject.transform.position, position);
            if (distance <= 0.5f) return false;
        }
        return true;
    }

    public void LettuceSpawn()
    {
        bool isAvailable;
        Vector3 spawnPosition = GetProperSpawnPos(out isAvailable);
        if (isAvailable)
        {
            GameObject lettuce = Instantiate(lettuceToSpawn, spawnPosition, Quaternion.identity);
            lettuces.Add(lettuce);
        }
    }
}
