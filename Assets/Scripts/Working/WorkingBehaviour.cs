using UnityEngine;

public class WorkingBehaviour : ActionBehaviour
{
    [SerializeField] private bool busy = false;
    private GameObject ObjectBusy;
    

    public override bool BusyObjectAction(GameObject busy)
    {
        if (ObjectBusy == null)
        {
            this.busy = true;
            ObjectBusy = busy;
            return false;
        }
        else
        {
            if (busy == ObjectBusy)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public void ResetDataScript()
    {
        busy = false;
        ObjectBusy = null;
    }

}