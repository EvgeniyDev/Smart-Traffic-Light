using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    public LevelDataScript levelData;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CarsScript>() != null)
        {
            levelData.currentCarsAmountOnLevel--;
        }

        if (collision.gameObject.GetComponent<PedestrianScript>() != null)
        {
            levelData.currentPeopleAmountOnLevel--;
        }

        Destroy(collision.gameObject);
    }
}
