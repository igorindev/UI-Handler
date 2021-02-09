using UnityEngine;
using UnityEngine.Events;

namespace UIHandler
{
    public class UIButton : UISelectable
    {
        [SerializeField] UnityEvent onClick;

        public override void Click()
        {
            if (interactable)
            {
                FadeClick();
                onClick.Invoke();
            }
        }
    }
}
