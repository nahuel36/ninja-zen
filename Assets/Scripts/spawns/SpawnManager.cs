using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    [SerializeField] ItemsSpawner UL;
    [SerializeField] ItemsSpawner UR;
    [SerializeField] ItemsSpawner DL;
    [SerializeField] ItemsSpawner DR;

    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] float lastSpawnTime = 0;
    [SerializeField] float initialSpawnTime = 4;
    // public GameObject ExampleBottle;
    bool inInitialTime;
    bool loose;

    void Start() {
        inInitialTime = true;
        loose = false;
       // ExampleBottle.SetActive(false);
        LevelManager.looseGame += stop;
    }

    public void stop() {
        loose = true;
    }

    public bool IsSpawning => (Time.timeSinceLevelLoad > initialSpawnTime+spawnTime-0.8f) && !loose;

	// Update is called once per frame
	void Update () {
        if (inInitialTime && Time.timeSinceLevelLoad > initialSpawnTime)
            inInitialTime=false;

        if (loose || inInitialTime) return;

        if (lastSpawnTime > spawnTime)
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
