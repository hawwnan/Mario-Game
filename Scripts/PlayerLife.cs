using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    public AudioSource death;
    bool dead = false;
    void Update(){
        if(transform.position.y < -2.5f && !dead){
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die(){
        //to add dealy we use invoke method 
        dead = true;
        Invoke(nameof(ReloadLevel), 1.3f);
        death.Play();
    }

    void ReloadLevel(){
        //we reload the scene with scene manager
        //this way we keep the script independent of the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}