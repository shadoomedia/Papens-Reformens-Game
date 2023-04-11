using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    
    int coins = 0;
    public GameObject blockedPath;
    public GameObject extraUItext;
    public GameObject gratz;

    [SerializeField] Text nitrousText;
    [SerializeField] int nitroCount;



    private void Awake()
    {
        gratz = GameObject.FindWithTag("gratz");
        gratz.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
            coins++;
            nitrousText.text = "Nitrous: " + coins + "/"+ nitroCount;
        }
        


    }
    private void Update()
    {
        if (coins == nitroCount) {
            Destroy(blockedPath);
            Destroy(extraUItext);
            Destroy(nitrousText);
            Invoke("gratzUP", 0.2f);

                }
    }

    void gratzUP()
    {
        gratz.SetActive(true);
    }
}
