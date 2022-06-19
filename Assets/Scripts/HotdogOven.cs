using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogOven : MonoBehaviour
{
    //Hotdog => Sosis, ekmek, hardal

    [SerializeField] private GameObject hotdogCollectPoint;

    public List<GameObject> hotdogList;

    public GameObject hotdog;

    private int sausageCount;
    private int breadCount;
    private int mustardCount;

    private void Update()
    {
        if (hotdogList.Count == 3)
        {
            foreach (GameObject item in hotdogList)
            {
                Destroy(item);
            }

            hotdogList.Clear();
            hotdogCollectPoint.transform.position = new Vector3(4.5f, 1, -4.5f);
            Instantiate(hotdog, hotdogCollectPoint.gameObject.transform.position, Quaternion.identity);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sausage") && sausageCount == 0)
        {
            MeatSpawner.instance.meats.Remove(other.gameObject);

            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = hotdogCollectPoint.gameObject.transform.position;

            hotdogCollectPoint.transform.position = new Vector3(hotdogCollectPoint.transform.position.x, hotdogCollectPoint.transform.position.y + .5f, hotdogCollectPoint.transform.position.z);

            sausageCount++;
            Invoke("Drop", 2f);
            hotdogList.Add(other.gameObject);
        }
        if (other.CompareTag("Bread") && breadCount < 2)
        {
            SpawnManager.instance.breads.Remove(other.gameObject);

            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = hotdogCollectPoint.gameObject.transform.position;

            hotdogCollectPoint.transform.position = new Vector3(hotdogCollectPoint.transform.position.x, hotdogCollectPoint.transform.position.y + .5f, hotdogCollectPoint.transform.position.z);

            breadCount++;
            Invoke("Drop", 2f);
            hotdogList.Add(other.gameObject);

        }
        if (other.CompareTag("Mustard") && mustardCount == 0)
        {
            MustardSpawner.instance.mustards.Remove(other.gameObject);

            other.gameObject.transform.localScale = other.gameObject.transform.localScale * .5f;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = hotdogCollectPoint.gameObject.transform.position;

            hotdogCollectPoint.transform.position = new Vector3(hotdogCollectPoint.transform.position.x, hotdogCollectPoint.transform.position.y + .5f, hotdogCollectPoint.transform.position.z);

            mustardCount++;
            Invoke("Drop", 2f);
            hotdogList.Add(other.gameObject);

        }

    }
    public void Drop()
    {
        playerCollector.instance.isCarrying = false;
    }
}
