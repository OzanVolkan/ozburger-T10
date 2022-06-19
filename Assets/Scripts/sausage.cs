using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sausage : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine lastRoutine = null;
    void Start()
    {
        lastRoutine = StartCoroutine(spoil());
    }
    IEnumerator spoil()
    {
        yield return new WaitForSeconds(70);
        MeatSpawner.instance.meats.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine(lastRoutine);
        }
    }
}
