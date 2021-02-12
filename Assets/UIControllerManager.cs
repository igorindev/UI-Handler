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
        [SerializeField] Transition transition;
        [SerializeField] HighlightColor highlightColor;
        [SerializeField] HighlightSprite highlightSprite;
        [SerializeField] HighlightAnimation highlightAnimation;
        [Min(0.05f)] [SerializeField] float fadeDuration = 0.1f;
        NavigationUI navigation; //Debug only

        UiInputs inputActions;

        public HighlightColor HighlightColor { get => highlightColor; }
        public HighlightSprite HighlightSprite { get => highlightSprite; }
        public HighlightAnimation HighlightAnimation { get => highlightAnimation; }
        public Transition Transition { get => transition; }
        public float FadeDuration { get => fadeDuration; }

        bool moved;

        void Reset()
        {
            highlightColor.Normal = Color.white;
            highlightColor.Enter = Color.red;
            highlightColor.Click = Color.green;
            highlightColor.Disabled = Color.gray;
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

            inputActions.UI.NavigateUp.canceled += ctx => CancelMovement();
            inputActions.UI.NavigateDown.canceled += ctx => CancelMovement();
            inputActions.UI.NavigateLeft.canceled += ctx => CancelMovement();
            inputActions.UI.NavigateRight.canceled += ctx => CancelMovement();

            inputActions.UI.Click.started += ctx => ClickDown();
            inputActions.UI.Click.performed += ctx => ClickUp();

            inputActions.Player.Test.performed += ctx => DebugMessage();
        }

        #region Inputs
        [ContextMenu("Up")]
        void SelectUp()
        {
            if (!moved)
            {
                moved = true;
            }
            else
            {
                return;
            }

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
            if (!moved)
            {
                moved = true;
            }
            else
            {
                return;
            }

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
            if (!moved)
            {
                moved = true;
            }
            else
            {
                return;
            }

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
            if (!moved)
            {
                moved = true;
            }
            else
            {
                return;
            }

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

        void CancelMovement()
        {
            moved = false;
        }

        void ClickUp()
        {
            if (currentSelected != null)
            {
                currentSelected.ClickUp();
            }
        }
        void ClickDown()
        {
            if (currentSelected != null)
            {
                currentSelected.ClickDown();
            }
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
                if (old.Override)
                {
                    if (old.Transition == Transition.Color)
                    {
                        old.Fade(old.HighlightColor.Normal);
                    }
                    else if (old.Transition == Transition.Sprite)
                    {
                        old.Fade(old.HighlightSprite.Normal);
                    }
                    else if (old.Transition == Transition.Animation)
                    {
                        //newSelected.Fade(newSelected.HighlightAnimation.EnterAnim);
                    }
                }
                else
                {
                    if (Transition == Transition.Color)
                    {
                        old.Fade(highlightColor.Normal);
                    }
                    else if (Transition == Transition.Sprite)
                    {
                        old.Fade(highlightSprite.Normal);
                    }
                    else if (Transition == Transition.Animation)
                    {
                        //newSelected.Fade(HighlightAnimation.EnterAnim);
                    }
                }
            }

            if (newSelected.Override)
            {
                if (newSelected.Transition == Transition.Color)
                {
                    newSelected.Fade(newSelected.HighlightColor.Enter);
                }
                else if (newSelected.Transition == Transition.Sprite)
                {
                    newSelected.Fade(newSelected.HighlightSprite.Enter);
                }
                else if (newSelected.Transition == Transition.Animation)
                {
                    //newSelected.Fade(newSelected.HighlightAnimation.EnterAnim);
                }
            }
            else
            {
                if (Transition == Transition.Color)
                {
                    newSelected.Fade(highlightColor.Enter);
                }
                else if (Transition == Transition.Sprite)
                {
                    newSelected.Fade(highlightSprite.Enter);
                }
                else if (Transition == Transition.Animation)
                {
                    //newSelected.Fade(HighlightAnimation.EnterAnim);
                }
            }
        }
        public void FadeOutCurrent()
        {
            if (currentSelected != null)
            {
                if (currentSelected.Override)
                {
                    currentSelected.Fade(currentSelected.HighlightColor.Normal);
                }
                else
                {
                    currentSelected.Fade(HighlightColor.Normal);
                }
            }
        }

        public void DebugMessage()
        {
            Debug.Log("The Selectable was clicked");
        }

        public bool IsSelected(UISelectable selected)
        {
            return currentSelected == selected;
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

    public enum Transition
    {
        Color, Sprite, Animation
    }

    [System.Serializable]
    public struct HighlightColor
    {
        [SerializeField] Color normal;
        [SerializeField] Color over;
        [SerializeField] Color click;
        [SerializeField] Color disabled;

        public Color Normal { get => normal; set => normal = value; }
        public Color Enter { get => over; set => over = value; }
        public Color Click { get => click; set => click = value; }
        public Color Disabled { get => disabled; set => disabled = value; }
    }

    [System.Serializable]
    public struct HighlightSprite
    {
        [SerializeField] Sprite normal;
        [SerializeField] Sprite over;
        [SerializeField] Sprite click;
        [SerializeField] Sprite disabled;

        public Sprite Normal { get => normal; set => normal = value; }
        public Sprite Enter { get => over; set => over = value; }
        public Sprite Click { get => click; set => click = value; }
        public Sprite Disabled { get => disabled; set => disabled = value; }
    }

    [System.Serializable]
    public struct HighlightAnimation
    {
        [SerializeField] string normal;
        [SerializeField] string over;
        [SerializeField] string click;
        [SerializeField] string disabled;

        public string Normal { get => normal; set => normal = value; }
        public string Enter { get => over; set => over = value; }
        public string Click { get => click; set => click = value; }
        public string Disabled { get => disabled; set => disabled = value; }
    }
}
