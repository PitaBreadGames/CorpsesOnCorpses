using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadReference : MonoBehaviour
{
    public static PlayerHeadReference instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance == null)
        {
            print("Didn't assign instance");
        }
    }

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
