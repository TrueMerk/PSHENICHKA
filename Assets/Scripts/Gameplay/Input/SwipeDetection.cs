using System;
using UnityEngine;


namespace SarrrGames.GoldenRush.Gameplay.Input
{
    public class SwipeDetection : MonoBehaviour
    {
         public static event OnSwipeInput SwipeEvent;
         public delegate void OnSwipeInput(Vector2 direction);

         public static event OnTapInput TapEvent;
         public delegate void OnTapInput(Vector2 direction);
        
         private Vector2 _tapPosition;
         private Vector2 swipeDelta;
        
         [SerializeField] private float _deadZone = 0;
        
         private bool _isSwiping;
         private bool _isMobile;
        
         private void Start()
         {
             _isMobile = Application.isMobilePlatform;
         }
        
         private void Update()
         {
             Debug.Log("SWIPE");
             if (!_isMobile)
             {
                 if (UnityEngine.Input.GetMouseButtonUp(0))
                 { 
                     _isSwiping = true;
                     _tapPosition = UnityEngine.Input.mousePosition;
                 }
                 else if (UnityEngine.Input.GetMouseButtonUp(0))
                 {
                     ResetSwipe();
                 }
             }
             else
             {
                 if (UnityEngine.Input.touchCount>0)
                 {
                     if (UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
                     {
                         _isSwiping = true;
                         _tapPosition = UnityEngine.Input.GetTouch(0).position;
                     }
                     else
                     {
                         if (UnityEngine.Input.GetTouch(0).phase == TouchPhase.Canceled || UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
                         {
                              ResetSwipe();
                         }
                     }
                 }
             }
             //CheckTap();
             //CheckSwipe();
         }

         private void CheckTap()
         {
             TapEvent(_tapPosition);
         }
        
         private void CheckSwipe()
         {
             swipeDelta = Vector2.zero;
             if (_isSwiping)
             {
                 if (!_isMobile && UnityEngine.Input.GetMouseButton(0))
                 {
                     swipeDelta = (Vector2)UnityEngine.Input.mousePosition - _tapPosition;
                 }
                 else if (UnityEngine.Input.touchCount > 0)
                 {
                     swipeDelta = UnityEngine.Input.GetTouch(0).position - _tapPosition;
                 }
             }
        
             if (swipeDelta.magnitude > _deadZone)
             {
                 if (SwipeEvent!=null)
                 {
                     SwipeEvent(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
                     // if (Mathf.Abs(swipeDelta.x)>Mathf.Abs(swipeDelta.y))
                     // {
                     //     SwipeEvent(swipeDelta.x > 0 ? Vector2.right : Vector2.left);
                     // }
                     // else
                     // {
                     //     SwipeEvent(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
                     // }
                 }
                 ResetSwipe();
             }
         }
        
                private void ResetSwipe()
                {
                    _isSwiping = false;
                    _tapPosition = Vector2.zero;
                    swipeDelta = Vector2.zero;
                }
    }
}
