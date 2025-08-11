using UnityEngine;
using System.Collections;
public class EnemySpanwer : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    //Boss location spawns randomly
    [SerializeField] private float timeBetweenSpawns = 2f;
    //The time boss automatically spawns
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }
    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);//TIme Boss born
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];//Random boss 
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];//Random where boss start
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);//sinh quai vi tri duoc sinh ra 
        }
    }

}
