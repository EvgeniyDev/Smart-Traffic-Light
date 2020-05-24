using UnityEngine;

public class WasCrossedSetter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PedestrianScript>() != null)
        {
            collision.gameObject.GetComponent<PedestrianScript>().wasRoadCrossed = true;
        }
    }
}
