using UnityEngine;

public class StopLineScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CarsScript>() != null && !collision.isTrigger)
        {
            var car = collision.gameObject.GetComponent<CarsScript>();
            car.currentSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CarsScript>() != null && !collision.isTrigger)
        {
            var car = collision.gameObject.GetComponent<CarsScript>();
            car.currentSpeed = car.baseSpeed;
        }
    }
}
