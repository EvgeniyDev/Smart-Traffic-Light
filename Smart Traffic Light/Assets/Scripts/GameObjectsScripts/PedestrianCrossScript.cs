using Assets.Scripts.Models;
using UnityEngine;

public class PedestrianCrossScript : MonoBehaviour
{
    public Collider2D[] carStoplines;

    public TrafficLightGameObject trafficLight;
    private int pedestriansAmount;

    private void Start()
    {
        pedestriansAmount = 0;
    }

    private void FixedUpdate()
    {
        if (pedestriansAmount == 0
            && trafficLight.trafficLightLogic.TrafficLightSignal == TrafficLightSignal.GreenLight)
        {
            foreach (var collider in carStoplines)
            {
                collider.enabled = false;
            }
        }
        else
        {
            foreach (var collider in carStoplines)
            {
                collider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PedestrianScript>() != null)
        {
            pedestriansAmount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PedestrianScript>() != null)
        {
            pedestriansAmount--;
        }
    }
}
