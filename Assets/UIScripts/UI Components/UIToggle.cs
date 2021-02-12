using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIHandler
{
    public class UIToggle : UISelectable
    {
        [Header("Conditions")]
        [SerializeField] bool isOn;
        [SerializeField] Image checkImage;
        [Space(5)]
        [SerializeField] UnityEvent onTrue;
        [SerializeField] UnityEvent onFalse;

        public bool IsOn
        {
            get => isOn;

            set
            {
                isOn = value;
                checkImage.gameObject.SetActive(isOn);
            }      
        }

        public void SetValueAndCallFunction(bool value)
        {
            //Set the inverse because the click function will reverse
            isOn = !value;

            if (interactable)
            {
                controllerManager.Select(this);
                Click();
            }
        }

        public override void Click()
        {
            if (interactable)
            {
                if (IsOn = !IsOn)
                {
                    checkImage.gameObject.SetActive(true);
                    onTrue.Invoke();
                }
                else
                {
                    checkImage.gameObject.SetActive(false);
                    onFalse.Invoke();
                }

            }
        }

        void OnValidate()
        {
            checkImage.gameObject.SetActive(isOn);
        }
    }
}
