using UnityEngine;
using UnityEngine.Events;

public class HouseBehaviour : ActionBehaviour
{

    private BUILD_BEHAVIOUR thisBuild;
   

    public override void Resource(string nameResource, int countResource)
    {
        Resource(nameResource, countResource);
    }

    private void Start()
    {
        thisBuild = GetComponent<BUILD_BEHAVIOUR>();
    }
}