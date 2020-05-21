using UnityEngine;

public class CarsDestructionScript : MonoBehaviour
{
    public LevelDataScript levelData;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        levelData.currentCarsAmountOnLevel--;
        Destroy(collision.gameObject);
    }
}
