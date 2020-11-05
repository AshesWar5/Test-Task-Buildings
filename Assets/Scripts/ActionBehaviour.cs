using UnityEngine;

public class ActionBehaviour : MonoBehaviour
{
    virtual public void SetDamege(int damege, GameObject ObjectBusy)
    {
        
    }
    
    virtual public void Building()
    {

    }
    virtual public void Resource(string nameResource, int countResource)
    {

    }


    virtual public bool BusyObjectAction(GameObject busy)
    {
        return true;
    }
}