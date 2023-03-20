using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SarrrGames.GoldenRush.Gameplay.Entities
{
    public class BtnClicked : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Action OnPointDown;
        public Action OnPointUp;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointUp?.Invoke();
        }
    }
}
