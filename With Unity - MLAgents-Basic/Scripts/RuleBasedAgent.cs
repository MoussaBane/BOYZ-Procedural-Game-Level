using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBasedAgent : MonoBehaviour
{
    public int position;
    public GameObject smallGoal;
    public GameObject largeGoal;

    private int smallGoalPosition;
    private int largeGoalPosition;

    private float timeSinceLastChange = 0f;
    private float changeInterval = 5f; // Hedef pozisyonlarını değiştirme süresi (saniye cinsinden)

    private void Start()
    {
        position = 10; // Başlangıç pozisyonu
        smallGoalPosition = 7;
        largeGoalPosition = 17;

        transform.position = new Vector3(position - 10f, 0f, 0f);
        smallGoal.transform.position = new Vector3(smallGoalPosition - 10f, 0f, 0f);
        largeGoal.transform.position = new Vector3(largeGoalPosition - 10f, 0f, 0f);
    }

    private void Update()
    {
        // Zamanın geçmesini bekleyip hedef pozisyonlarını değiştir
        timeSinceLastChange += Time.deltaTime;

        if (timeSinceLastChange >= changeInterval)
        {
            timeSinceLastChange = 0f;
            ChangeGoalPositions();
        }

        // Hedefe doğru hareket et
        MoveTowardsGoal();
    }

    private void ChangeGoalPositions()
    {
        // Hedef pozisyonlarını rastgele değiştir
        smallGoalPosition = Random.Range(0, 10); // 0-9 arası
        largeGoalPosition = Random.Range(11, 20); // 11-19 arası

        // Hedeflerin pozisyonlarını güncelle
        smallGoal.transform.position = new Vector3(smallGoalPosition - 10f, 0f, 0f);
        largeGoal.transform.position = new Vector3(largeGoalPosition - 10f, 0f, 0f);

        Debug.Log("Hedef pozisyonları değiştirildi: Küçük Hedef - " + smallGoalPosition + ", Büyük Hedef - " + largeGoalPosition);
    }

    private void MoveTowardsGoal()
    {
        // Hedef seçim stratejisi
        int targetPosition = Mathf.Abs(position - smallGoalPosition) < Mathf.Abs(position - largeGoalPosition) ? smallGoalPosition : largeGoalPosition;

        // Hedefe doğru hareket et
        if (position < targetPosition)
        {
            position++;
        }
        else if (position > targetPosition)
        {
            position--;
        }

        // Pozisyonu güncelle
        transform.position = new Vector3(position - 10f, 0f, 0f);

        // Hedefe ulaşıldı mı kontrol et
        if (position == smallGoalPosition || position == largeGoalPosition)
        {
            Debug.Log("Hedefe ulaşıldı: " + position);
            ResetAgent();
        }
    }

    private void ResetAgent()
    {
        position = 10; // Başlangıç pozisyonuna dön
        Debug.Log("Ajan yeniden başlatıldı.");
    }
}
