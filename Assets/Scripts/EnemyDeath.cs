using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Transform enemyDeathParticles;
   
    
    

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {

        //Platform stick
        if (other.gameObject.name == "Player") { 
            enemyDeathParticles.GetComponent<ParticleSystem>().Play(enemyDeathParticles);
       
        }
    }


}
