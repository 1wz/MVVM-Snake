
using UnityEngine;

namespace MVVM
{
    public class GameStarter : MonoBehaviour
    {
        void Start()
        {
            new InputObserver();
            new ViewModel();
        }
    }
}