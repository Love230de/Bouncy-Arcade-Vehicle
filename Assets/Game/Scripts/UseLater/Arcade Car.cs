using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeCar : MonoBehaviour
{
   public class WheelData
    {
        [HideInInspector]
        public float compression = 0.0f;

        [HideInInspector]
        public float prev_compression = 0.0f;

        [HideInInspector]
        public float wheelRotationRad = 0.0f;

        [HideInInspector]
        public float yawRad = 0.0f;

        [HideInInspector]
        public bool isGrounded = false;
       
        [HideInInspector]
        public RaycastHit touchPoint = new RaycastHit();
        
    }

    [Serializable]
    public class AxelData
    {

        public GameObject axelObject = null;

        public WheelData wheelRight = new WheelData();

        public WheelData wheelLeft = new WheelData();

        public GameObject wheelModel = null;

        public float stiffness = 8600.0f;

        public float damper = 4500.0f;

        public float rollBarCorrection = 1000.0f;

        public float restLength = 0.87f;

        public float maxLength = 1.0f;

        public float minLength = 0.25f;

        public bool isPowered = false;

        public bool isSteerable = false;
    }

    [SerializeField] private AxelData[] axels;
    [SerializeField] private Rigidbody rb;

    private RaycastHit[] wheelRayHits = new RaycastHit[16];



    private void FixedUpdate()
    {
        
    }
}
