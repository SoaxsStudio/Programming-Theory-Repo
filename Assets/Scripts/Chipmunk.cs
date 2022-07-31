using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipmunk : Animal
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Beaver"))
        {
            Destroy(collision.gameObject);
        }
    }

}
