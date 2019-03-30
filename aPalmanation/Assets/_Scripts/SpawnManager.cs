using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }
    private void OnDisable()
    {
        instance = null;
        StopCoroutine(CoSpawnItem());
    }

    [SerializeField]
    private List<GameObject> _Spawnables = new List<GameObject>();
    [SerializeField]
    private List<Transform> _SpawnPoints = new List<Transform>();
    [SerializeField]
    int _NumberOfSpawns;
    [SerializeField]
    private float _SpawnWait,
        _StartWait,
        _SpawnMinWait,
        _SpawnMaxWait;
    [SerializeField]
    private bool _StopSpawning;

    private void Start()
    {
        StartCoroutine(CoSpawnItem());
    }

    IEnumerator CoSpawnItem()
    {
        yield return new WaitForSeconds(_StartWait);
        while (_StopSpawning == false)
        {
            int _SpawnablesIndex = Random.Range(0, _Spawnables.Count - 1);
            GameObject _ObjectToSpawn = _Spawnables[_SpawnablesIndex];
            int _SpawnPosIndex = Random.Range(0, _SpawnPoints.Count - 1);
            Vector3 _SpawnPos = _SpawnPoints[_SpawnPosIndex].position;

            Instantiate(_ObjectToSpawn, _SpawnPos, Quaternion.identity);

            _SpawnWait = Random.Range(_SpawnMinWait, _SpawnMaxWait);
            ++_NumberOfSpawns;
            yield return new WaitForSeconds(_SpawnWait);
        }

        yield return null;
    }

}
//private void Start()
//{
//    StartCoroutine(CoSpawnItem());
//    startMinSpawnWait = spawnMinWait;
//    startMaxSpawnWait = spawnMaxWait;
//}
//#endregion

//#region VARIABLES
//public List<GameObject> spawnablesInGame = new List<GameObject>();
//public List<GameObject> pooledObjectsList = new List<GameObject>();

//// Wait time before checking if can spawn
//public float startWait;
//// bool that stops spawning when true. 
//public bool stop;

//public float spawnMinWait;
//public float spawnMaxWait;
//public float spawnWait;
//public float startMinSpawnWait;
//public float startMaxSpawnWait;

//// Defines where objects can spawn
//public Vector3 spawningZone;
//// Where objects do spawn
//public Vector3 spawnPosition;
//#endregion

//IEnumerator CoSpawnItem()
//{
//    yield return new WaitForSeconds(startWait);
//    while (!stop)
//    {
//        spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
//        spawnPosition = new Vector3(Random.Range(-spawningZone.x, spawningZone.x), Random.Range(-spawningZone.y, spawningZone.y), 1);
//        GameObject spawnable = null;
//        int index = 0;
//        bool spawnPooledObject = false;

//        // 1. Select item to spawn
//        spawnable = ItemSelector.instance.SelectItem();

//        // 2. Check object pool for matching item
//        while (index < pooledObjectsList.Count)
//        {
//            // iterate through pooled obj list. if equivalent obj, spawn it.
//            if (pooledObjectsList[index].tag == spawnable.tag)
//            {
//                spawnPooledObject = true;
//                spawnable = pooledObjectsList[index];
//                break;
//            }
//            index++;
//        }

//        // Unpool and move GameObject to spawnPosition. Add item to spawnablesInGameList.
//        // random spawn position on x and z axis min/max of spawn values. spawn position does not go above 1 on the y axis.  <---- ???
//        if (spawnPooledObject)
//        {
//            spawnable.SetActive(true);
//            spawnable.transform.position = spawnPosition + transform.TransformPoint(0, 0, 0);
//            spawnablesInGame.Add(spawnable);
//            pooledObjectsList.Remove(spawnable);
//        }

//        // Instantiate GameObject at spawn position. Add to spawnablesInGameList.
//        if (spawnPooledObject == false)
//        {
//            spawnablesInGame.Add(Instantiate(spawnable, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation));
//            spawnable.SetActive(true);
//        }

//        yield return new WaitForSeconds(spawnWait);
//    }
//}

///// Sets passed object to inactive and pools it. Called by OutOfBounds and BallCollisions Script
//public void PoolObject(GameObject ball)
//{
//    ball.SetActive(false);
//    pooledObjectsList.Add(ball);
//    spawnablesInGame.Remove(ball);
//}

//public void ResetSpawnListsAndTimers()
//{
//    // Pools all items in spawnablesInGameList into pooledObjectsList
//    for (int index = 0; index < SpawnManager.instance.spawnablesInGame.Count; index++)
//    {
//        GameObject currentBall = (GameObject)SpawnManager.instance.spawnablesInGame[index];
//        pooledObjectsList.AddRange(spawnablesInGame);
//        spawnablesInGame.RemoveRange(0, spawnablesInGame.Count);
//    }

//    spawnablesInGame.Clear();
//}
//}