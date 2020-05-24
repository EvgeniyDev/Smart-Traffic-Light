using UnityEngine;

public class WasCrossedTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PedestrianScript>() != null
            && collision.gameObject.GetComponent<PedestrianScript>().wasRoadCrossed)
        {
            var person = collision.gameObject.GetComponent<PedestrianScript>();

            switch (Random.Range(0, 2))
            {
                case 0:
                    person.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;

                case 1:
                    person.transform.eulerAngles = new Vector3(0, 0, -90);
                    break;
            }

        }
    }
}
