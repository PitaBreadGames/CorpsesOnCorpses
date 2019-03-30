using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class LimbIKTargeter : MonoBehaviour
{
    public LimbIK limbIK;
    public AimIK aimIK; // Reference to the AimIK component
    public Transform playerHeadTransform; // The hitting point as in the animation
    public Transform reachPoint;

    public float meleeRange = 1.25f;


    private void OnEnable()
    {
        if (aimIK == null)
        {
            aimIK = GetComponent<AimIK>();
        }
        else
        {
            print("CAN'T FIND MY AIM IK!");
        }
        if(limbIK == null)
        {
            limbIK = GetComponent<LimbIK>();
        }

        if (playerHeadTransform == null && PlayerHeadReference.instance)
        {
            
            playerHeadTransform = PlayerHeadReference.instance.transform;
            //aimIK.solver.IKPosition = PlayerHeadReference.instance.transform.position;
        }
        if (playerHeadTransform == null)
        {
            print("I CAN'T FIND THE P-HEAD");
        }

        limbIK.solver.target = playerHeadTransform;
    }

    private void Update()
    {
        if(!playerHeadTransform && PlayerHeadReference.instance)
        {
            playerHeadTransform = PlayerHeadReference.instance.transform;
            limbIK.solver.target = playerHeadTransform;
        }
        if(playerHeadTransform)
        {
            if(IsInMeleeRangeOf(playerHeadTransform))
            {
                limbIK.solver.IKPositionWeight = 1;
            }
            else
            {
                limbIK.solver.IKPositionWeight = 0;
            }
        }
    }

    private bool IsInMeleeRangeOf(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < meleeRange;
    }

    void LateUpdate()
    {
        if (playerHeadTransform != null)
        {

            // Rotate the aim Transform to look at the point, where the fist hits it's target in the animation.
            // This will set the animated hit direction as the default starting point for Aim IK (direction for which Aim IK has to do nothing).
            aimIK.solver.transform.LookAt(reachPoint.position);

            // Set myself as IK target
            aimIK.solver.IKPosition = PlayerHeadReference.instance.transform.position;
            print(PlayerHeadReference.instance.transform.position);
        }
    }
}
