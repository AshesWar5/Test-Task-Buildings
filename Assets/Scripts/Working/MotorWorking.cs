using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MotorWorking : MotorBehaviour
{
    private NavMeshAgent agent;
    private CollectionWorking collectionWorking;
    private GameObject buildObject;
    private Animator animator;
    private string lastTagResource; // узнаём какой последний тег ресурса
    private List<GameObject> targetGoResourceCollection = new List<GameObject>(); // В массив добавятся все найденные ресурсы, которые нужны для стройки
    
    public override void GoToCollectionResource(string tagTarget)
    {
        if (targetGoResourceCollection.Count == 0 || lastTagResource != tagTarget) {
            targetGoResourceCollection.Clear();
            GameObject[] target = GameObject.FindGameObjectsWithTag(tagTarget);
            for (int b = 0; b < target.Length; b++)
            {
                targetGoResourceCollection.Add(target[b]);
            }
        }
        for (int b = 0; b < targetGoResourceCollection.Count; b++)
        {
            if (targetGoResourceCollection[b] == null)
                targetGoResourceCollection.RemoveAt(b);
        }
            try
            {
                foreach (var Object in targetGoResourceCollection)
                {
                    if (Vector3.Distance(transform.position, Object.transform.position) <= 300f && !Object.GetComponent<ActionBehaviour>().BusyObjectAction(gameObject))
                    {
                    lastTagResource = tagTarget;
                    StartAgentNavigation(Object.transform, 7f);
                    StartAnimation(0f,1f);
                        break;
                    }
                    else if (Object.GetComponent<ActionBehaviour>().BusyObjectAction(gameObject))
                    StartAnimation(0f, 0f);
                }
            }
            catch
            {
            GoToCollectionResource(tagTarget);
        }
    }
    public override void GoToPoint() // Движение к цели
    {
        StartAgentNavigation(buildObject.transform, 5f);
        StartAnimation(0f, -1f);
    }

    public override void Object(GameObject Target) // Этот метод нужен для, того чтобы наш рабочий знал о объекте, которое он строит
    {
        buildObject = Target;
    }


    public override void ResetDataScript()
    {
        buildObject = null;
        GetComponent<WorkingBehaviour>().ResetDataScript();
        StartAnimation(0f, 0f);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == buildObject && other.GetComponent<BUILD_BEHAVIOUR>())
        {
            collectionWorking.SendData(buildObject);
        }
    }
    public override void StartAnimation(float animationX, float animationY)
    {
        animator.SetFloat("NumberAnimationX", animationX);
        animator.SetFloat("NumberAnimationY", animationY);
    }
    private void StartAgentNavigation(Transform Target, float speed)
    {
        agent.SetDestination(Target.position);
        agent.speed = speed;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        collectionWorking = GetComponent<CollectionWorking>();
    }
}