using UnityEngine;

public class BUILD_BEHAVIOUR : MonoBehaviour
{
    virtual public bool Building()
    {
        return true;
    }
    virtual public void Task()
    {
        
    }
    virtual public void Resource(string nameResource, int countResource)
    {

    }
}