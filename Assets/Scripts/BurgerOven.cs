using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerOven : MonoBehaviour
{
    //Burger => Kofte, 2 * ekmek, marul
    [SerializeField] private GameObject burgerCollectPoint;

    public List<GameObject> hamburgerList;
    public GameObject hamburger;

    private int steakCount;
    private int breadCount;
    private int lettuceCount;

    private void Update()
    {
        if (hamburgerList.Count==4)
        {
            foreach (GameObject item in hamburgerList)
            {
                Destroy(item);
            }

            hamburgerList.Clear();
            burgerCollectPoint.transform.position = new Vector3(4.5f, 1,-3.5f);
            Instantiate(hamburger, burgerCollectPoint.gameObject.transform.position, Quaternion.identity);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Steak") && steakCount == 0)
        {
            MeatSpawner.instance.meats.Remove(other.gameObject);

            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = burgerCollectPoint.gameObject.transform.position;

            burgerCollectPoint.transform.position = new Vector3(burgerCollectPoint.transform.position.x, burgerCollectPoint.transform.position.y + .35f, burgerCollectPoint.transform.position.z);

            steakCount++;
            Invoke("Drop", 2f);
            hamburgerList.Add(other.gameObject);
        }
        if (other.CompareTag("Bread") && breadCount < 2)
        {
            SpawnManager.instance.breads.Remove(other.gameObject);

            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = burgerCollectPoint.gameObject.transform.position;

            burgerCollectPoint.transform.position = new Vector3(burgerCollectPoint.transform.position.x, burgerCollectPoint.transform.position.y + .35f, burgerCollectPoint.transform.position.z);

            breadCount++;
            Invoke("Drop", 2f);
            hamburgerList.Add(other.gameObject);

        }
        if (other.CompareTag("Lettuce") && lettuceCount == 0)
        {
            LettuceSpawner.instance.lettuces.Remove(other.gameObject);

            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = burgerCollectPoint.gameObject.transform.position;

            burgerCollectPoint.transform.position = new Vector3(burgerCollectPoint.transform.position.x, burgerCollectPoint.transform.position.y + .35f, burgerCollectPoint.transform.position.z);

            lettuceCount++;
            Invoke("Drop", 2f);
            hamburgerList.Add(other.gameObject);

        }

    }
    public void Drop()
    {
        playerCollector.instance.isCarrying = false;
    }
}
