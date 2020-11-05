using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HouseBuilding : BUILD_BEHAVIOUR
{
    [SerializeField] private int count_wood, count_rock;
    [SerializeField] private string tagWood = "Wood", tagRock = "Rock";
    [SerializeField] private Slider progressBarBuilding;
    [SerializeField] private GameObject SpawnHumanoid;
    private List<GameObject> working = new List<GameObject>(); // Список рабочих, которые строят этот объект
    private GameObject[] work; // Массив найденных рабочих
    private int _amountAllResources; // Сумма всех ресурсов для постройки этого объекта
    private float timeOneResources = 5f; // Время для кладки одного ресурса
    private float amountTimeBuilding; // Сумма времни, которое понадобиться для постройки объекта
    private bool toBuildingStart; // Начата стройка или нет

    
    public override void Task()
    {
        if (count_wood > 0)
        {
            FindWorking(tagWood);
        }
        if (count_rock > 0 && count_wood <= 0)
        {
            FindWorking(tagRock);
        }
    }
    public override bool Building()
    {
        if (!toBuildingStart && count_wood <= 0 && count_rock <= 0)
        {
            for (int b = 0; b <= working.Count;)
            {
                    if (Vector3.Distance(transform.position, working[b].transform.position) <= 10f)
                    {
                    working[b].GetComponent<MotorBehaviour>().StartAnimation(1f, 0f);
                    b++;
                        if (b >= working.Count)
                        {
                            amountTimeBuilding = (_amountAllResources / working.Count) * timeOneResources;
                            progressBarBuilding.maxValue = amountTimeBuilding;
                            progressBarBuilding.gameObject.SetActive(true);
                        toBuildingStart = true;
                            return true;
                        }
                    }
                    else
                    {
                        break;
                }
            }
        }
        return false;
    }
    public override void Resource(string nameResource, int countResource)
    {
        if (nameResource == "Wood")
        {
            count_wood -= countResource;
        }
        if (nameResource == "Rock")
        {
            count_rock -= countResource;
        }
        CheckResources();
    }
    private void Update()
    {
        if (toBuildingStart == true)
        {
            amountTimeBuilding -= Time.deltaTime;
            progressBarBuilding.value = amountTimeBuilding;
            if (amountTimeBuilding <= 0f)
            {
                for (int b = 0; b <= working.Count; b++)
                {
                    try
                    {
                        working[b].GetComponent<MotorBehaviour>().ResetDataScript();
                    }
                    catch
                    {
                    } 
                }
                Instantiate(SpawnHumanoid, transform.position, Quaternion.identity);
                Instantiate(SpawnHumanoid, transform.position, Quaternion.identity);
                StartCoroutine(DisabledUI());
                    toBuildingStart = false;
            }
        }
    }
    private void Start()
    {
        work = GameObject.FindGameObjectsWithTag("Working");
        _amountAllResources = count_wood + count_rock;
    }
    private void CheckResources()
    {
        if (count_wood <= 0 || count_wood > 0)
        {
            Task();
        }
        if (count_rock <= 0)
        {
            Building();
        }
        else if (count_rock > 0)
        {
            Task();
        }
    }
    private void FindWorking(string TargetTag)
    {
        if (working.Count != work.Length)
        {
            for (int b = 0; b <= work.Length; b++)
            {
                try
                {
                    if (!work[b].GetComponent<ActionBehaviour>().BusyObjectAction(gameObject) && !work[b].GetComponent<CollectionBehaviour>().CollectionBusy())
                    {
                        if (!working.Contains(work[b]))
                        {
                            working.Add(work[b]);
                        }
                        work[b].GetComponent<MotorBehaviour>().GoToCollectionResource(TargetTag);
                        work[b].GetComponent<MotorBehaviour>().Object(gameObject);
                    }
                }
                catch { }
            }
        }
        else
        {
            for (int b = 0; b <= work.Length; b++)
            {
                try
                {
                    if (!working[b].GetComponent<CollectionBehaviour>().CollectionBusy())
                    {
                        working[b].GetComponent<MotorBehaviour>().GoToCollectionResource(TargetTag);
                    }
                }
                catch { }
            }
        }
    }
    private IEnumerator DisabledUI()
    {
        yield return new WaitForSeconds(5f);
        progressBarBuilding.gameObject.SetActive(false);
    }
}