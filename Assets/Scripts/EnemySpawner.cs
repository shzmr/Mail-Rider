using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyToSpawn
{
    public EnemyType enemy; //Enemy Prefab
    public float yPos;
    public float time; //Time after which the next enemy can spawn
}

[System.Serializable]
public enum EnemyType
{  
    ShootingSingle,
    ShootingMultiple,
    Spinning,
    BigStraight,
    FastStraight,
    BigBobble,
    FastBobble
}

/*[System.Serializable]
public enum MovementType
{
    Bobble,
    Static,
    Straight
}*/

/*[System.Serializable]
public class Enemy
{
    public GameObject prefab;
    public MovementType moveType;
}*/

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public EnemyToSpawn[] spawnOrder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnAll");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(EnemyToSpawn ets)
    {
        GameObject enemyObject = Instantiate(enemies[(int)ets.enemy], transform.position, Quaternion.identity);
        EnemyMovement em = enemyObject.GetComponent<EnemyMovement>();
        if (em != null)
        {
            em.time = ets.yPos;
        }
    }

    IEnumerator SpawnAll()
    {
        for (int i = 0; i < spawnOrder.Length ; i++)
        {
            spawnOrder[i].time -= 0.1f;
            if (spawnOrder[i].time <= 0)
            {
                Spawn(spawnOrder[i]);
            }
            else
            {
                i--;
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
