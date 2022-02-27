using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchArea : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [HideInInspector]
    public Vector2 Touchdis;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerID;
    [HideInInspector]
    public bool touched;
   

    void Update()
    {
       
        if (touched)
        {
            
            if(PointerID>=0 && PointerID < Input.touches.Length)
            {
                Touchdis = Input.touches[PointerID].position - PointerOld;
                PointerOld = Input.touches[PointerID].position;
            }
            else
            {
                Touchdis = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            Touchdis = new Vector2();
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touched = true;
        PointerID = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touched = false;
    }
}
