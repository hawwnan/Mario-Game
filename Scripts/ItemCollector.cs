using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
   int coins = 0;
   public Text score;

   public AudioSource collectSound;

   private void OnTriggerEnter(Collider collider)
   {
       if(collider.gameObject.CompareTag("Coin"))
       {
        Destroy(collider.gameObject);
        collectSound.Play();
        coins++;
        score.text = "Coins " + coins; 
       }
   }
}
