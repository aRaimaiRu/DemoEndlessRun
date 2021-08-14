using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    public float tileLength = 10.0f;
    private int amnTilesOnScreen = 7;
    [SerializeField]
    private Transform startingPoint;
    private int lastprefabsIndex = 0;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i =0;i< amnTilesOnScreen;i++){
            if(i<2)
            {
                SpawnTile(0);
            }else{
                SpawnTile(RandomPrefabIndex());
            }
            
        }
            
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - tileLength*2> (spawnZ-amnTilesOnScreen*tileLength)){
            SpawnTile(RandomPrefabIndex());
            DeleteTile();
        }
    }
    private void SpawnTile(int prefabIndex =0){
        GameObject go;
        go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = startingPoint.position +Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
    private void DeleteTile(){
        Destroy(GameObject.Find("TilesManager").transform.GetChild(0).gameObject);
    }
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1) return 0;
        int randomIndex = lastprefabsIndex;
        while (randomIndex == lastprefabsIndex){
            randomIndex = Random.Range(0,tilePrefabs.Length);
        }
        lastprefabsIndex = randomIndex;
        return randomIndex;
    }
}