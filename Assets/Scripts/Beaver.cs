using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaver : Animal
{

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rabbit"))
        {
            Destroy(collision.gameObject);
        }
    }
}
