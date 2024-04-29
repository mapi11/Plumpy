using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScript : MonoBehaviour
{
   public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touch");
    }
}
