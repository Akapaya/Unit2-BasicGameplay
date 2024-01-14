using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public int AmountEnemies;
    public GameObject[] EnemyPrefab;
    public List<GameObject> EnemiesList = new();

    public float MinRandomNumber = 0;
    public float MaxRandomNumber = 2;

    public Vector3[] AvailablePositions;

    private void Start()
    {
        CreateEnemiesPool();

        StartCoroutine(SpawnEnemy());
    }

    public void CreateEnemiesPool()
    {
        for (int t = 0; t < EnemyPrefab.Length; t++)
        {
            for (int i = 0; i < AmountEnemies; i++)
            {
                GameObject enemy = Instantiate(EnemyPrefab[t], transform.position, new Quaternion(0, 0, 180, 0));
                enemy.transform.SetParent(transform);
                enemy.SetActive(false);
                EnemiesList.Add(enemy);
            }
        }

        ListExtensions.Shuffle(EnemiesList);
    }

    public GameObject GetEnemiesObject(Vector3 position)
    {
        GameObject enemy = EnemiesList[0];
        enemy.SetActive(true);
        enemy.transform.position = position;
        EnemiesList.RemoveAt(0);
        EnemiesList.Add(enemy);
        return enemy;
    }

    public IEnumerator SpawnEnemy()
    {
        GetEnemiesObject(AvailablePositions[Random.Range(0, AvailablePositions.Length)]);

        yield return new WaitForSecondsRealtime(Random.Range(MinRandomNumber, MaxRandomNumber));

        StartCoroutine(SpawnEnemy());
    }    
}