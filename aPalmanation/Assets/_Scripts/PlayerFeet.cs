using UnityEngine;public class PlayerFeet:MonoBehaviour{public Transform target;void Update(){transform.localPosition=new Vector3(target.localPosition.x,0f,target.localPosition.z);}}
