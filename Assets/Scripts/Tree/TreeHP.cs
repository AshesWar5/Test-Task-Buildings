using UnityEngine;

public class TreeHP : HPBehaviour
{
    [SerializeField] private int HP = 5;
    [SerializeField] private GameObject ThisResourceInstance;
    public override bool SetDamege(int damege)
    {
        HP -= damege;
        if (HP > 0)
        {
            return true;
        }
        else
        {
            GameObject Wood = Instantiate(ThisResourceInstance, transform.position, transform.rotation);
            Destroy(Wood, 3f);
             Wood = Instantiate(ThisResourceInstance, transform.position, transform.rotation);
            Destroy(Wood, 3f);
            Destroy(gameObject);
            return false;
        }
    }
}
