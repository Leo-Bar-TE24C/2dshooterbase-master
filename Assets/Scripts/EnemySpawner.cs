using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
 [SerializeField]
    GameObject boltPrefab;

// -------------------------------------------------------------------------------------------------------------------

    float timeSinceSpawns = 0;
    [SerializeField]
    float timeBetwenSpawns = 3;


// ----------------------------------------------------------------------------------------------------------------

    [SerializeField]
    GameObject enemyPrefab;
    
    // ----------------------------------------------------------------------------------------------------------------
   
    void Update()
    {
        timeSinceSpawns += Time.deltaTime;

        if (timeSinceSpawns > timeBetwenSpawns)
        {
            Instantiate(enemyPrefab);
            timeSinceSpawns = 0;
        }

    }
}
