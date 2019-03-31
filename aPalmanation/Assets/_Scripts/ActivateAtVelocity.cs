using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;


public class ActivateAtVelocity : MonoBehaviour
{
   // public GameObject activationObject;
    public TagDestroyer tagDestroyField;
    public VelocityEstimator velocityEstimator;
    public float threshold = 2;
    public bool set = false;

    private void Update()
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();

        if(velocity.magnitude > threshold)
        {
            set = true;
            //tagDestroyField.SetActivator(set);
            tagDestroyField.gameObject.SetActive(true);
        }
        else
        {
            set = false;
            tagDestroyField.gameObject.SetActive(false);
            //tagDestroyField.SetActivator(set);
        }
    }
}

