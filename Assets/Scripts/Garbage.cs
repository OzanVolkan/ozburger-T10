using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    private void DestroyFood(string tag, GameObject garbage)
    {
        switch (tag)

        {
            case "Bread":
                SpawnManager.instance.breads.Remove(garbage);
                Destroy(garbage);
                break;


            case "Lettuce":
                LettuceSpawner.instance.lettuces.Remove(garbage);
                Destroy(garbage);

                break;

            case "Mustard":
                MustardSpawner.instance.mustards.Remove(garbage);
                Destroy(garbage);

                break;

            case "Sausage":
                MeatSpawner.instance.meats.Remove(garbage);
                Destroy(garbage);

                break;

            case "Steak":
                MeatSpawner.instance.meats.Remove(garbage);
                Destroy(garbage);

                break;

            case "Hamburger":
                Destroy(garbage);

                break;

            case "Hotdog":
                Destroy(garbage);

                break;


            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            DestroyFood(other.tag, other.gameObject);
            playerCollector.instance.isCarrying = false;
        }
    }
}
