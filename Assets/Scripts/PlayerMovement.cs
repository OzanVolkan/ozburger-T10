using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public GameObject background;
    public Animator playerAnimator;
    private void Update()
    {

        if (JoystickPlayerExample.instance.isMoving)
        {
            transform.rotation = Quaternion.AngleAxis(-(Mathf.Atan2(JoystickPlayerExample.instance.direction.y, JoystickPlayerExample.instance.direction.x) * Mathf.Rad2Deg - 90), transform.up);

        }

        if (JoystickPlayerExample.instance.direction.magnitude > 0.1f)
        {
            playerAnimator.SetBool("IsWalking", true);
        }


        if (background.activeInHierarchy == false)
        {
            playerAnimator.SetBool("IsWalking", false);
        }

    }
}
