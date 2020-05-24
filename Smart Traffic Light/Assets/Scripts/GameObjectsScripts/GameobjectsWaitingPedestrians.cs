using Assets.Scripts.Models;
using UnityEngine;

public class GameobjectsWaitingPedestrians : MonoBehaviour
{
    public readonly WaitingPeopleParameters waitingPeopleParameters = new WaitingPeopleParameters();

    void Start()
    {
        waitingPeopleParameters.WaitingPeopleAmount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Person"))
        {
            waitingPeopleParameters.WaitingPeopleAmount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Person"))
        {
            waitingPeopleParameters.WaitingPeopleAmount--;
        }
    }
}
