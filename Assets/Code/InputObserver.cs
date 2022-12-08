using System;
using UnityEngine;



namespace MVVM
{
    public class InputObserver:IDisposable
    {

        public static event Action<KeyCode> InputEvent;
        public KeyCode[] trackedKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        public InputObserver()
        {
            EventSender.UpdateEvent += Update;
        }

        public void Dispose()
        {
            EventSender.UpdateEvent -= Update;
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in trackedKeys)
                {
                    if (Input.GetKey(keyCode))
                    {
                        InputEvent?.Invoke(keyCode);
                    }
                }
            }
        }
    }
}