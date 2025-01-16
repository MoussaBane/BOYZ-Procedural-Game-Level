using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents;


public class DeepLearningAgent : Agent
{
    public BasicController basicController;

    public override void Initialize()
    {
        // Başlangıçta hedef pozisyonları belirleyelim
        basicController.position = 10;
    }

    public override void OnEpisodeBegin()
    {
        // Ajan her bölüm başında yeniden başlatılacak
        basicController.ResetAgent();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Ajanın gözlemleri
        sensor.AddObservation(basicController.position);  // Ajanın mevcut pozisyonu
        sensor.AddObservation(basicController.smallGoal.transform.position);  // Küçük hedefin pozisyonu
        sensor.AddObservation(basicController.largeGoal.transform.position);  // Büyük hedefin pozisyonu
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Ajanın aldığı aksiyonla hareket etmesini sağla
        int movement = actionBuffers.DiscreteActions[0];
        basicController.MoveDirection(movement);
    }

    public override void Heuristic(in ActionBuffers actionBuffersOut)
    {
        // Kullanıcıdan manuel giriş alınması durumunda
        float direction = Input.GetAxis("Horizontal");
        var discreteActions = actionBuffersOut.DiscreteActions;
        if (Mathf.Approximately(direction, 0.0f))
        {
            discreteActions[0] = 0;
        }
        else
        {
            discreteActions[0] = direction < 0 ? 1 : 2;
        }
    }
}
