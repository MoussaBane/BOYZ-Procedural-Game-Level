using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBasedGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Platform için prefab
    public GameObject enemyPrefab; // Düşman için prefab
    public int platformCount = 10; // Platform sayısı
    public float levelWidth = 10f; // Platform genişlik sınırı
    public float minHeight = 1f; // Minimum yükseklik farkı
    public float maxHeight = 3f; // Maksimum yükseklik farkı

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        float lastYPosition = 0f;

        for (int i = 0; i < platformCount; i++)
        {
            // Platform pozisyonunu belirle
            Vector3 position = new Vector3(
                Random.Range(-levelWidth, levelWidth),
                lastYPosition + Random.Range(minHeight, maxHeight),
                0f
            );

            // Platform oluştur
            Instantiate(platformPrefab, position, Quaternion.identity);

            // Rastgele düşman ekle
            if (Random.value > 0.7f) // %30 şansla düşman ekle
            {
                Instantiate(enemyPrefab, position + Vector3.up * 1.5f, Quaternion.identity);
            }

            lastYPosition = position.y;
        }
    }
}
