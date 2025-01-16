using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLearningGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject enemyPrefab;

    void Start()
    {
        GenerateDummyLevel();
    }

    public void GenerateDummyLevel()
    {
        // Sabit pozisyonlarda platformlar ve düşmanlar
        for (int i = 0; i < 5; i++)
        {
            Vector3 platformPosition = new Vector3(i * 2, i, 0);
            Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            if (i % 2 == 0) // Çift indeksli platformlara düşman koy
            {
                Vector3 enemyPosition = platformPosition + Vector3.up * 1.5f;
                Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            }
        }
    }
}
