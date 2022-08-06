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

    public override void Breed()
    {
        Debug.Log("A Rabbit has been cloned!");
        base.Breed();
    }

}
