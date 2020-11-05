using UnityEngine;

public class CollectionBehaviour : MonoBehaviour
{
    virtual public void Collection(int countResource, string lastResource)
    {

    }
    virtual public void CollectionRock(int countRock, string lastResource)
    {

    }
    virtual public bool CollectionBusy()
    {
        return true;
    }
}