using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetReference : MonoBehaviour
{
    public AimTargetReference instance;

    private void OnEnable()
    {
        if (instance == null)
            instance = this;    
    }

    private void OnDisable()
    {
        instance = null;
    }
}
