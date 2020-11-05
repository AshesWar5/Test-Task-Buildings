using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EventController : MonoBehaviour, IPointerClickHandler
{


    public event UnityAction<Vector3> Point;
    public void OnPointerClick(PointerEventData eventData)
    {
        Point.Invoke(eventData.pointerPressRaycast.worldPosition);
    }
}