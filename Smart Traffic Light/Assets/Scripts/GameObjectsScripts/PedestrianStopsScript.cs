using UnityEngine;

public class PedestrianStopsScript : MonoBehaviour
{
    public TrafficLightGameObject trafficLight;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PedestrianScript>() != null 
            && collision.gameObject.GetComponent<PedestrianScript>().isGoingToCrossTheRoad
            && !collision.gameObject.GetComponent<PedestrianScript>().wasRoadCrossed)
        {
            var person = collision.gameObject.GetComponent<PedestrianScript>();
            person.currentSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PedestrianScript>() != null)
        {
            var person = collision.gameObject.GetComponent<PedestrianScript>();
            person.currentSpeed = person.baseSpeed;
        }
    }
}
