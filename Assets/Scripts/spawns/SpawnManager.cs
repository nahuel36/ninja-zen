using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public ItemsSpawner UL;
    public ItemsSpawner UR;
    public ItemsSpawner DL;
    public ItemsSpawner DR;

    public float spawnTime = 0.5f;
    public float lastSpawnTime = 0;
    public float initialSpawnTime = 4;
   // public GameObject ExampleBottle;

    public bool canSpawn;

    void Start() {
        canSpawn = true;
       // ExampleBottle.SetActive(false);
        LevelManager.looseGame += stop;
    }

    public void stop() {
        canSpawn = false;
    }

	// Update is called once per frame
	void Update () {
        if (!canSpawn) return;

        if (Time.timeSinceLevelLoad < initialSpawnTime) return;

        if(lastSpawnTime > spawnTime)
        {
            int rand = UnityEngine.Random.Range(0, 4);
            if(rand == 0)
                UL.Spawn();
            else if (rand == 1)
                UR.Spawn();
            else if (rand == 2)
                DL.Spawn();
            else if (rand == 3)
                DR.Spawn();

            lastSpawnTime = 0;

            if(spawnTime > 0.8f)
                spawnTime -= 0.2f;
        }
        lastSpawnTime += Time.deltaTime;

    }
}
