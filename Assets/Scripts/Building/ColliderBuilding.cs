using UnityEngine.Events;
using UnityEngine;

public class ColliderBuilding : MonoBehaviour
{

    [SerializeField] private UnityEvent OnCollised = new UnityEvent();
    [SerializeField] private UnityEvent OnFree = new UnityEvent();
    [SerializeField] private UnityEvent OnDisabled = new UnityEvent();
    [SerializeField] private GameObject thisObject;
    private bool isCollised, IsDisabled;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody rigidbody = thisObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            OnDisabled.Invoke();
            Destroy(this); //Скрипт больше нам не ненужен из - за этого уничтожаем его
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!isCollised && !IsDisabled)
        {
            OnCollised.Invoke();
        }
        isCollised = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!IsDisabled)
        {
            OnFree.Invoke();
            isCollised = false;
        }
    }
}
