using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagDestroyer : MonoBehaviour
{
    //private bool activateDestroy = false;

    //public void SetActivator(bool set)
    //{
    //    activateDestroy = set;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (activateDestroy)
    //    {
    //        Destroy(GameObject.FindWithTag("EnemyArm"));
    //    }
        
    //}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyArm")
        {
            Destroy(other.gameObject);
        }
    }

}
