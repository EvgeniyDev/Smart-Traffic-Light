using UnityEngine;

public class SpawnCheck : MonoBehaviour
{
    public bool isSpawnEmpty;

    private void Start()
    {
        isSpawnEmpty = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isSpawnEmpty = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSpawnEmpty = true;
    }
}
