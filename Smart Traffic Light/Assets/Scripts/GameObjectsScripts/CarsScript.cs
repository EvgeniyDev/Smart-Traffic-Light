using UnityEngine;

public class CarsScript : MonoBehaviour
{
    public int currentSpeed;
    public int baseSpeed;

    private void Start()
    {
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * (int)(currentSpeed * 0.25));
    }
}
