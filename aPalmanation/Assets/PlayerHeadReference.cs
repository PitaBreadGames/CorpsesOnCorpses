using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadReference : MonoBehaviour
{
    public static PlayerHeadReference instance;
    public Transform playerHeadTransform;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }
}
