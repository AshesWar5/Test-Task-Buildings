using UnityEngine;

public class RockHP : HPBehaviour
{
    [SerializeField] private int HP = 5;
    [SerializeField] private GameObject hisResourceInstance;
    public override bool SetDamege(int damege)
    {
        HP -= damege;
        if (HP > 0)
        {
            return true;
        }
        else
        {
            GameObject Wood = Instantiate(hisResourceInstance, transform.position, transform.rotation);
            Destroy(Wood, 3f);
            Wood = Instantiate(hisResourceInstance, transform.position, transform.rotation);
            Destroy(Wood, 3f);
            Destroy(gameObject);
            return false;
        }
    }
}
