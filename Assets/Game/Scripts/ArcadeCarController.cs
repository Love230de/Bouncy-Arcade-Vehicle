using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeCarController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
       
         
       
    }

    private void FixedUpdate()
    {
        Vector3 carUp = transform.TransformDirection(Vector3.up);
        Vector3 axis = Vector3.Cross(Vector3.up,carUp);
        axis.Normalize();
       //rb.AddTorque(axis * rb.mass  * 5);
    }
}
