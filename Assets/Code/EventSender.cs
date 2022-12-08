using System;
using UnityEngine;

namespace MVVM
{
    public class EventSender : MonoBehaviour
    {
        public static Action UpdateEvent;
        void Update()
        {
            UpdateEvent();
        }
    }
}