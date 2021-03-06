using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExplorablePlace : MonoBehaviour
{

    void Update()
    {
        //if they get below the bottom border destroy the object
        if (this.transform.position.z < -1300)
        {
            //for the islands
            if (this.transform.parent != null)
                Destroy(this.transform.parent.gameObject);
            //for the boats
            else
                Destroy(this.gameObject);
        }
    }

 //Transition to something like this at a later date
 /*public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Explore_Border")
        {
            Debug.Log("trying to destroy");
            Destroy(this.gameObject);
        }
    }*/
}
