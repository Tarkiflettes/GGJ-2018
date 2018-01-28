using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Triggered {

    //public Transform SpawnPosition;
    public GameObject[] SpawnableObjects;

    public override void Action()
    {
        foreach (GameObject obj in SpawnableObjects)
        {
            //Instantiate(obj, SpawnPosition.position, SpawnPosition.rotation);
            obj.SetActive(true);
        }
    }
}
