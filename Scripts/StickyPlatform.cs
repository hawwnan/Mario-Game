using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //we need to check when our player collides with the moving platform it moves with it.
    private void OnCollisionEnter(Collision collision){
        //the colliding info is in the collision variable
        if(collision.gameObject.name == "Player"){
            //we take the object we collided wth and make it the child of platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // to revert this when we jump off the moving platform
    private void OnCollisionExit(Collision collision){
          if(collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
