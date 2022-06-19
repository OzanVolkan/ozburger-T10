using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public GameObject winScreen;

    public int burgerCounter;
    public int hotdogCounter;

    private void Update()
    {
        if (burgerCounter >=5 && hotdogCounter >=5)
        {
            winScreen.SetActive(true);
            TimeManager.instance.timerIsRunning = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hamburger"))
        {
            burgerCounter++;
            Destroy(other.gameObject);
            playerCollector.instance.isCarrying = false;
        }
        if (other.CompareTag("Hotdog"))
        {
            hotdogCounter++;
            Destroy(other.gameObject);
            playerCollector.instance.isCarrying = false;
        }
    }
}
