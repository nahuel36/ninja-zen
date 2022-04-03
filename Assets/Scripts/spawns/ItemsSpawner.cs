using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsSpawner : MonoBehaviour {

    private PoolingSystem poolingSystem;

    public Transform beginPoint;
    public Transform attackPoint;
    public Transform endPoint;
    public float velocity = 1;

    public float timeOfLastSpawn;
    
    public string spawnerID = "DR";

    public character actual_character;

    void Start () {
        timeOfLastSpawn = 0;
        poolingSystem = PoolingSystem.Instance;

        
    }

    public void Break()
    {
        if (!actual_character.canPunch()) return;

        List<GameObject> items = poolingSystem.GetAllItems("Bottle");

        for (int i=0;i<items.Count;i++)
        { 
            if(items[i].activeInHierarchy)
            {
                ThrowedItem itemScript = items[i].GetComponent<ThrowedItem>();
                if(itemScript.spawnerDIR == spawnerID)
                    itemScript.BreakItem();
            }
        }

    }



    public void Skip()
    {
        List<GameObject> items = poolingSystem.GetAllItems("Bottle");

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].activeInHierarchy)
            {
                ThrowedItem itemScript = items[i].GetComponent<ThrowedItem>();
                if (itemScript.spawnerDIR == spawnerID)
                    itemScript.Skip();
            }
        }
    }





    public void Spawn() {
        GameObject bottle = poolingSystem.InstantiateAPS("Bottle", beginPoint.position, Quaternion.identity);
        ThrowedItem bottleScript = bottle.GetComponent<ThrowedItem>();
        bottleScript.setValues(beginPoint.position, attackPoint.position, endPoint.position , velocity, spawnerID);
        timeOfLastSpawn = 0;

    }
    

    void Update () {
        timeOfLastSpawn += Time.deltaTime;

        if(velocity < 9)
        velocity += Time.deltaTime * 0.2f;
    }


}
