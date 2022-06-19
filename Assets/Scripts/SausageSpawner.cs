using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageSpawner : MonoBehaviour
{
    public GameObject sausageToSpawn;
    public List<GameObject> sausages;

    private int attemptCount;
    void Start()
    {
        InvokeRepeating("SausageSpawn", 2f, 7f);
    }

    private Vector3 GetProperSpawnPos(out bool isAvailable)
    {
        attemptCount = 0;
        Vector3 tempPosition;
        while (attemptCount < 100)
        {
            tempPosition = new Vector3(Random.Range(-.57f, -3.2f), Random.Range(1f, 1f), Random.Range(-4.26f, -4.57f));
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
        foreach (GameObject gameObject in MeatSpawner.instance.meats)
        {
            float distance = Vector3.Distance(gameObject.transform.position, position);
            if (distance <= 0.5f) return false;
        }
        return true;
    }
    public void SausageSpawn()
    {
        bool isAvailable;
        Vector3 spawnPosition = GetProperSpawnPos(out isAvailable);
        if (isAvailable)
        {
            GameObject steak = Instantiate(sausageToSpawn, spawnPosition, Quaternion.identity);
            MeatSpawner.instance.meats.Add(steak);
        }
    }
}
