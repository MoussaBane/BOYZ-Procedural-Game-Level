using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LevelGenerator ruleBasedGenerator; // Kural tabanlı seviyeler için
    public LevelGenerator deepLearningGenerator; // Derin öğrenme seviyeleri için
    public Text statusText; // Kullanıcıya durumu göstermek için

    public void GenerateRuleBasedLevel()
    {
        // Kural tabanlı seviyeyi temizleyip yeniden oluştur
        ClearLevel();
        ruleBasedGenerator.gameObject.SetActive(true);
        statusText.text = "Kural Tabanlı Seviye Üretildi.";
    }

    public void GenerateDeepLearningLevel()
    {
        // Derin öğrenme tabanlı seviyeyi temizleyip yeniden oluştur
        ClearLevel();
        deepLearningGenerator.gameObject.SetActive(true);
        statusText.text = "Derin Öğrenme Seviye Üretildi.";
    }

    private void ClearLevel()
    {
        // Sahnedeki tüm platform ve düşmanları temizler
        foreach (var obj in GameObject.FindGameObjectsWithTag("Platform"))
        {
            Destroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }
}
