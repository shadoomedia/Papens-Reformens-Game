using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationWORLD : MonoBehaviour
{
    [SerializeField] float rotation;


    // Start is called before the first frame update
    void Update()
    {
        

        // ...also rotate around the World's Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * rotation, Space.World);
    }


}
