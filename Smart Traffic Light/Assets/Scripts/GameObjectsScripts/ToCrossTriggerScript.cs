using System.Collections;
using UnityEngine;

public class ToCrossTriggerScript : MonoBehaviour
{
    private bool isCoroutineEnd;
    private Collider2D trigger;

    private void Start()
    {
        isCoroutineEnd = true;
        trigger = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isCoroutineEnd)
        {
            StartCoroutine(DisabledStatusDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PedestrianScript>() != null 
            && !collision.gameObject.GetComponent<PedestrianScript>().wasRoadCrossed)
        {
            collision.gameObject.GetComponent<PedestrianScript>().isGoingToCrossTheRoad = true;

            if (gameObject.name.Contains("Bottom"))
            {
                collision.gameObject.GetComponent<PedestrianScript>().transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (gameObject.name.Contains("Top"))
            {
                collision.gameObject.GetComponent<PedestrianScript>().transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
    }

    private IEnumerator DisabledStatusDelay()
    {
        isCoroutineEnd = false;
        trigger.enabled = false;

        // fallback
        yield return new WaitForSeconds(Random.Range(7, 10));

        trigger.enabled = true;

        yield return new WaitForSeconds(0.5f);

        isCoroutineEnd = true;
    }
}
