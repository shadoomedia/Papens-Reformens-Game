using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerDeath : MonoBehaviour
{
    public Transform pDeathParticles;
    public Transform pDeathParticles2;
    public Transform pExplosionParticles;
    [SerializeField] AudioSource playerExplosion;
    [SerializeField] AudioSource groundHit;
    PlayerMovement playerMovement;


     void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body") || collision.gameObject.CompareTag("Lava"))
            {
            Die();
            Destroy(GameObject.FindGameObjectWithTag("Enemy Body"));
            groundHit.Play();
          }
    }

    public void Die()
    {
        //Audio
        playerExplosion.Play();
        
        //
        Invoke(nameof(ReloadLevel), 3f);
        pDeathParticles.GetComponent<ParticleSystem>().enableEmission = false;
        pDeathParticles2.GetComponent<ParticleSystem>().enableEmission = false;
        pExplosionParticles.GetComponent<ParticleSystem>().Play(pExplosionParticles);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("PlayerLights"));
        playerMovement.movingSound.Stop();        
        
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
