using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCar : MonoBehaviour
{

    //This is a test for a raycast cars

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float suspensionStrength;

    [SerializeField] private float dampStrength;

    [SerializeField] private float suspensionDistance;

    [SerializeField] private float sideFrictionStrength;

    [SerializeField] private float frictionStrength;
    private float currentCompression = 0;
    private float prevCompression = 0;
    private bool isGrounded = false;
    private RaycastHit wheelHit = new RaycastHit();


    private float SuspensionForce()
    {
        Vector3 contactPointVelocity = rb.GetPointVelocity(wheelHit.point);
        if(Physics.Raycast(transform.position,-transform.up, out wheelHit,suspensionDistance) && !isGrounded)
        {
            isGrounded = true;
            if(wheelHit.collider.isTrigger)
            {
                return 0;
            }
            if(wheelHit.collider.attachedRigidbody == rb)
            {
                return 0;
            }

            if(wheelHit.collider == null)
            {
                return 0;
            }
            if(Vector3.Dot(wheelHit.normal,Vector3.up) < 0.6)
            {
                return 0;
            }
            currentCompression =  Mathf.Abs(wheelHit.distance - suspensionDistance)/suspensionDistance;
            prevCompression = currentCompression;  

            Vector3 direction = transform.up;

            Vector3 suspensionForce = direction * suspensionStrength;
            Vector3 suspensionDampForce = contactPointVelocity * -dampStrength;

            Vector3 totalSuspensionVelocity = (suspensionDampForce + suspensionForce);

            float suspensionUpwardForce = Vector3.Dot(totalSuspensionVelocity * currentCompression,transform.up);
          
            return suspensionUpwardForce;
        }
        currentCompression = prevCompression;
        isGrounded = false;
        return 0;
    }
    private float WheelFrictionForceForward()
    {
        Vector3 contactPointVelocity = rb.GetPointVelocity(wheelHit.point);

        float forwardFrictionForce =( Vector3.Dot(contactPointVelocity,transform.forward))* -frictionStrength;

        return forwardFrictionForce;
    }

    private float WheelSideFrictionForce()
    {
        Vector3 contactPointVelocity = rb.GetPointVelocity(wheelHit.point);
        float sideFrictionForce =   Vector3.Dot(contactPointVelocity, transform.right) *-sideFrictionStrength;
        return sideFrictionForce;
    }
    private void FixedUpdate()
    {
       
          rb.AddForceAtPosition((SuspensionForce() *transform.up) +((WheelFrictionForceForward() * transform.forward) + (WheelSideFrictionForce() * transform.right)), wheelHit.point);
            
        
    }

}
