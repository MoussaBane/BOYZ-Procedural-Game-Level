using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Platform için prefab
    public GameObject enemyPrefab; // Düşman için prefab
    public int platformCount = 10; // Toplam platform sayısı
    public float levelWidth = 8f; // Platformların yatay genişliği
    public float minY = 1f; // Platformlar arasındaki minimum dikey mesafe
    public float maxY = 3f; // Platformlar arasındaki maksimum dikey mesafe
    public float enemySpawnChance = 0.3f; // Düşman oluşturma ihtimali (30%)

    void Start()
    {
        Vector3 spawnPosition = Vector3.zero;

        for (int i = 0; i < platformCount; i++)
        {
            // Platform oluşturma
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            // Kural: Düşman yalnızca belirli bir ihtimalle oluşturulacak
            if (Random.value < enemySpawnChance)
            {
                Vector3 enemyPosition = spawnPosition + new Vector3(0, 0.5f, 0);
                Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            }
        }
    }
}
