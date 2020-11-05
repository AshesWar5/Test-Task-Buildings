using UnityEngine;

public class TreeBehaviour : ActionBehaviour
{
    [SerializeField] private int CountResourceDeath;
    private HPBehaviour thisHP;
    private GameObject ObjectBusy;
    
   

    public override void SetDamege(int damege, GameObject ObjectBusy)
    {
        if (thisHP.SetDamege(damege))
        {

        }
        else
        {
            ObjectBusy.GetComponent<CollectionBehaviour>().Collection(CountResourceDeath, "Wood");
            ObjectBusy.GetComponent<MotorBehaviour>().GoToPoint();
        }
    }

    public override bool BusyObjectAction(GameObject busy)
    {
        if (ObjectBusy == null)
        {
            ObjectBusy = busy;
            return false;
        }
        else
        {
            if (busy == ObjectBusy)
            {
                return false;
            }
            return true;
        }
    }
    private void Start()
    {
        thisHP = GetComponent<HPBehaviour>();
    }
}