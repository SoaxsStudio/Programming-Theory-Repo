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

    public override void Breed()
    {
        Debug.Log("A Chipmunk has been cloned!");
        base.Breed();
    }
}
