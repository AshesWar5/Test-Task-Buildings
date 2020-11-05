using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
    private GameObject Object;

    private EventController EventController;
     private void Start()
    {
        EventController = GameObject.FindObjectOfType<EventController>();
        EventController.Point += (pos) => { Object.transform.position = pos; };
    }
    public void Create_Building(GameObject building)
    {
        Object = Instantiate(building, new Vector3(0f,0f,0f), Quaternion.identity);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Object.GetComponent<BUILD_BEHAVIOUR>().Task();
            Object = null;
        }
    }
}