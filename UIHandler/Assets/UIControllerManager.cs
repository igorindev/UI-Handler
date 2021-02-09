using UnityEngine;
using UnityEngine.InputSystem;

namespace UIHandler
{
    [DisallowMultipleComponent]
    public class UIControllerManager : MonoBehaviour
    {
        public static UIControllerManager instance;

        [SerializeField] UISelectable currentSelected;

        [Header("Highlight")]
        [SerializeField] Highlight highlight;
        NavigationUI navigation; //Debug only

        UiInputs inputActions;

        public Highlight Highlight { get => highlight; }

        void Reset()
        {
            highlight.NormalColor = Color.white;
            highlight.EnterColor = Color.red;
            highlight.ClickColor = Color.green;
            highlight.DisabledColor = Color.gray;
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            AddInputs();

            if (currentSelected != null)
            {
                navigation = currentSelected.NavigationUI;
                ChangeHighlight(null, currentSelected);
            }
        }

        public void OverrideInput()
        {
            inputActions.UI.Disable();
            var operation = inputActions.UI.NavigateDown.PerformInteractiveRebinding(0).OnMatchWaitForAnother(0.1f).Start();

            operation.OnApplyBinding((op, path) =>
            {
                Debug.Log("Newly selected control path is " + path);

                // If you want to detect the device that was used and
                // decide based on that, you could do so here.
                var device = InputControlPath.TryGetDeviceLayout(path);
                //...
            });

            //operation.Dispose();
            //inputActions.Dispose();
        }

        void AddInputs()
        {
            inputActions = new UiInputs();

            inputActions.UI.NavigateUp.performed += ctx => SelectUp();
            inputActions.UI.NavigateDown.performed += ctx => SelectDown();
            inputActions.UI.NavigateLeft.performed += ctx => SelectLeft();
            inputActions.UI.NavigateRight.performed += ctx => SelectRight();
            inputActions.UI.Click.performed += ctx => Click();

            inputActions.Player.Test.performed += ctx => DebugMessage();
        }

        #region Inputs
        [ContextMenu("Up")]
        void SelectUp()
        {
            if (currentSelected.NavigationUI.up != null)
            {
                UISelectable old = currentSelected;

                if (currentSelected.NavigationUI.up.Interactable)
                {
                    currentSelected = currentSelected.NavigationUI.up;
                    navigation = currentSelected.NavigationUI;
                }
                else
                {
                    UISelectable temp = currentSelected.NavigationUI.up.GetNextInteractableUp();
                    if (temp == null)
                    {
                        return;
                    }

                    currentSelected = temp;
                    navigation = currentSelected.NavigationUI;
                }

                ChangeHighlight(old, currentSelected);
            }
        }
        [ContextMenu("Down")]
        void SelectDown()
        {
            if (currentSelected.NavigationUI.down != null)
            {
                UISelectable old = currentSelected;

                if (currentSelected.NavigationUI.down.Interactable)
                {
                    currentSelected = currentSelected.NavigationUI.down;
                    navigation = currentSelected.NavigationUI;
                }
                else
                {
                    UISelectable temp = currentSelected.NavigationUI.down.GetNextInteractableDown();
                    if (temp == null)
                    {
                        return;
                    }

                    currentSelected = temp;
                    navigation = currentSelected.NavigationUI;
                }

                ChangeHighlight(old, currentSelected);
            }
        }
        [ContextMenu("Left")]
        void SelectLeft()
        {
            if (currentSelected.NavigationUI.left != null)
            {
                UISelectable old = currentSelected;

                if (currentSelected.NavigationUI.left.Interactable)
                {
                    currentSelected = currentSelected.NavigationUI.left;
                    navigation = currentSelected.NavigationUI;
                }
                else
                {
                    UISelectable temp = currentSelected.NavigationUI.left.GetNextInteractableLeft();
                    if (temp == null)
                    {
                        return;
                    }

                    currentSelected = temp;
                    navigation = currentSelected.NavigationUI;
                }

                ChangeHighlight(old, currentSelected);
            }
        }
        [ContextMenu("Right")]
        void SelectRight()
        {
            if (currentSelected.NavigationUI.right != null)
            {
                UISelectable old = currentSelected;

                if (currentSelected.NavigationUI.right.Interactable)
                {
                    currentSelected = currentSelected.NavigationUI.right;
                    navigation = currentSelected.NavigationUI;
                }
                else
                {
                    UISelectable temp = currentSelected.NavigationUI.right.GetNextInteractableRight();
                    if (temp == null)
                    {
                        return;
                    }

                    currentSelected = temp;
                    navigation = currentSelected.NavigationUI;
                }

                ChangeHighlight(old, currentSelected);
            }
        }
        void Click()
        {
            currentSelected.Click();
        }
        #endregion

        public void Select(UISelectable newSelected)
        {
            UISelectable temp = currentSelected;
            currentSelected = newSelected;
            navigation = currentSelected.NavigationUI;

            ChangeHighlight(temp, currentSelected);
        }
        void ChangeHighlight(UISelectable old, UISelectable newSelected)
        {
            if (old != null)
            {
                if (old.OverrideColors)
                {
                    old.Fade(old.Highlight.NormalColor);
                }
                else
                {
                    old.Fade(Highlight.NormalColor);
                }
            }

            if (newSelected.OverrideColors)
            {
                newSelected.Fade(newSelected.Highlight.EnterColor);
            }
            else
            {
                newSelected.Fade(Highlight.EnterColor);
            }
        }
        public void FadeOutCurrent()
        {
            if (currentSelected != null)
            {
                if (currentSelected.OverrideColors)
                {
                    currentSelected.Fade(currentSelected.Highlight.NormalColor);
                }
                else
                {
                    currentSelected.Fade(Highlight.NormalColor);
                }
            }
        }

        public void DebugMessage()
        {
            Debug.Log("The Selectable was clicked");
        }

        private void OnEnable()
        {
            inputActions.UI.Enable();
            inputActions.Player.Disable();
        }

        private void OnDisable()
        {
            inputActions.UI.Disable();
            inputActions.Player.Enable();
        }

        void OnValidate()
        {
            if (highlight.FadeDuration <= 0)
            {
                highlight.FadeDuration = 0.1f;
            }
        }
    }

    [System.Serializable]
    public struct NavigationUI
    {
        public UISelectable up;
        public UISelectable down;
        public UISelectable left;
        public UISelectable right;
    }

    [System.Serializable]
    public struct Highlight
    {
        [SerializeField] Color normalColor;
        [SerializeField] Color overColor;
        [SerializeField] Color clickColor;
        [SerializeField] Color disabledColor;
        [SerializeField] float fadeDuration;

        public Color NormalColor { get => normalColor; set => normalColor = value; }
        public Color EnterColor { get => overColor; set => overColor = value; }
        public Color ClickColor { get => clickColor; set => clickColor = value; }
        public Color DisabledColor { get => disabledColor; set => disabledColor = value; }
        public float FadeDuration { get => fadeDuration; set => fadeDuration = value; }
    }
}
