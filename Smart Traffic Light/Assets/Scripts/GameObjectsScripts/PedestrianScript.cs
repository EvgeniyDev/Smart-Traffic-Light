using UnityEngine;

public class PedestrianScript : MonoBehaviour
{
    public int currentSpeed;
    public int baseSpeed;

    public Vector3 moveTo;

    public bool wasRoadCrossed;
    public bool isGoingToCrossTheRoad;

    private void Start()
    {
        currentSpeed = baseSpeed;

        wasRoadCrossed = false;
        isGoingToCrossTheRoad = false;
    }

    private void Update()
    {
        gameObject.transform.Translate(moveTo * Time.deltaTime * (int)(currentSpeed * 0.25));
    }
}
