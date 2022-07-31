using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chipmunk"))
        {
            Destroy(collision.gameObject);
        }
    }

}
