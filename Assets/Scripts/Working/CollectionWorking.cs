using UnityEngine;

public class CollectionWorking : CollectionBehaviour
{
    private int countResource;
    private int collectionResourceCount;
    private string lastResource; // какой последний ресурс был собран

    public override void Collection(int countResource, string lastResource)
    {
        this.countResource += countResource;
        collectionResourceCount = this.countResource;
        this.lastResource = lastResource;
    }


    public void SendData(GameObject TargetSend)
    {
        collectionResourceCount = 0;
        TargetSend.GetComponent<BUILD_BEHAVIOUR>().Resource(lastResource, countResource);
        countResource -= countResource;
    }
    public override bool CollectionBusy()
    {
        if (collectionResourceCount == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (collectionResourceCount == 0 && other.GetComponent<ActionBehaviour>())
            other.GetComponent<ActionBehaviour>().SetDamege(5, gameObject);
    }
}
