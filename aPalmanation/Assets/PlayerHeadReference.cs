using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadReference : MonoBehaviour
{
    public static PlayerHeadReference instance;

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
