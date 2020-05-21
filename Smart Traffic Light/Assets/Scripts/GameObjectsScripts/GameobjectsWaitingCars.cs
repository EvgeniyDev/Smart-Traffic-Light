using Assets.Scripts.Models;
using UnityEngine;

public class GameobjectsWaitingCars : MonoBehaviour
{
    public readonly WaitingCarsParameters waitingCarsParameters = new WaitingCarsParameters();

    void Start()
    {
        waitingCarsParameters.WaitingCarsAmount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Car") && !other.isTrigger)
        {
            waitingCarsParameters.WaitingCarsAmount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Car") && !other.isTrigger)
        {
            waitingCarsParameters.WaitingCarsAmount--;
        }
    }
}
