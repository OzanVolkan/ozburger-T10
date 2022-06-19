using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollector : MonoBehaviour
{
    public bool isCarrying = false;

    public static playerCollector instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "Mustard") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .375f, this.gameObject.transform.position.z);
        }
        if ((other.tag == "Lettuce") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .2f, this.gameObject.transform.position.z);
        }
        if ((other.tag == "Bread") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .1f, this.gameObject.transform.position.z);
        }
        if ((other.tag == "Steak") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y +.1f, this.gameObject.transform.position.z);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if ((other.tag == "Sausage") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .1f, this.gameObject.transform.position.z);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 135, 0);

        }

        if ((other.tag == "Hamburger") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .125f, this.gameObject.transform.position.z);
        }


        if ((other.tag == "Hotdog") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + .125f, this.gameObject.transform.position.z);



        }
    }
}
