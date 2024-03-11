using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jun.UI
{
    public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerDownHandler, IPointerExitHandler
    , IPointerUpHandler
    {
        public Action<PointerEventData> OnClickHandler = null;
        public Action<PointerEventData> OnDragHandler = null;
        public Action<PointerEventData> OnPointerDownHandler = null;
        public Action<PointerEventData> OnPointerUpHandler = null;
        public Action<PointerEventData> OnPointerExitHandler = null;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (OnClickHandler != null) OnClickHandler.Invoke(eventData);
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            if (OnDragHandler != null) OnDragHandler.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (OnPointerDownHandler != null) OnPointerDownHandler.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (OnPointerExitHandler != null) OnPointerExitHandler.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (OnPointerUpHandler != null) OnPointerUpHandler.Invoke(eventData);
        }
    }
}
