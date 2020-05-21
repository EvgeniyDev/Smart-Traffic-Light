using Assets.Scripts.Models;
using UnityEngine;

public class WaitingCarsHolderConstrainments : MonoBehaviour
{
    public int maxCarsAmount;
    public GameObject trafficLightGameObject;
    public BoxCollider2D stopline;

    private WaitingCarsParameters waitingCarsParaeters;
    private TrafficLight trafficLightLogic;

    void Start()
    {
        if (maxCarsAmount < 0)
        {
            throw new System.Exception("Negative amount of cars!");
        }

        waitingCarsParaeters = GetComponent<GameobjectsWaitingCars>().waitingCarsParameters;
        trafficLightLogic = trafficLightGameObject.GetComponent<TrafficLightGameObject>().trafficLightLogic;
    }

    void Update()
    {
        CheckAmount();
    }

    private void CheckAmount()
    {
        if (waitingCarsParaeters.WaitingCarsAmount >= maxCarsAmount)
        {
            stopline.enabled = true;
        }
        else if (trafficLightLogic.TrafficLightSignal == TrafficLightSignal.GreenLight)
        {
            stopline.enabled = false;
        }
    }
}
