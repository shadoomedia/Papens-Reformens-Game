using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
   Rigidbody rb;
    [SerializeField] float y_Rotation = 100;
    Vector3 RotationSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
        RotationSpeed = new Vector3(0, y_Rotation, 0);
        
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(RotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
