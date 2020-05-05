using Assets.Models;
using UnityEngine;

public class TrafficLightGameObject : MonoBehaviour
{
    private readonly TrafficLight trafficLightLogic = new TrafficLight();

    private int delay;

    void Start()
    {
        delay = trafficLightLogic.Delay;
    }

    void Update()
    {
        
    }
}
