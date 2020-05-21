using UnityEngine;

public class CarOffsetScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CarsScript>() != null)
        {
            var car = collision.gameObject.GetComponent<CarsScript>();
            car.currentSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CarsScript>() != null)
        {
            var car = collision.gameObject.GetComponent<CarsScript>();
            car.currentSpeed = car.baseSpeed;
        }
    }
}
