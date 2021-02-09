using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIHandler
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public abstract class UISelectable : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [SerializeField] protected bool interactable = true;
        [SerializeField] Image targetImage;

        [Header("Highlight")]
        [SerializeField] bool overrideManagerColors;
        [SerializeField] Highlight highlight;
        [Space(8)]
        [SerializeField] NavigationUI navigation;

        protected UIControllerManager controllerManager;
        Coroutine fadeCoroutine;

        public NavigationUI NavigationUI { get => navigation; }
        public Highlight Highlight { get => highlight; set => highlight = value; }
        public Image TargetImage { get => targetImage; set => targetImage = value; }
        public bool OverrideColors { get => overrideManagerColors; set => overrideManagerColors = value; }
        public bool Interactable { get => interactable; set => interactable = value; }

        void Start()
        {
            controllerManager = UIControllerManager.instance;
        }

        public void Fade(Color colorToUse)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            fadeCoroutine = StartCoroutine(FadeColor(colorToUse));
        }
        IEnumerator FadeColor(Color colorToUse)
        {
            float count = 0;
            Color color = targetImage.color;
            while (count < highlight.FadeDuration)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(color, colorToUse, count / highlight.FadeDuration);

                yield return null;
            }
        }
        protected void FadeClick()
        {
            Color normal, click;

            if (OverrideColors)
            {
                normal = highlight.EnterColor;
                click = highlight.ClickColor;
            }
            else
            {
                normal = controllerManager.Highlight.EnterColor;
                click = controllerManager.Highlight.ClickColor;
            }

            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            fadeCoroutine = StartCoroutine(FadeClickColor(normal, click));
        }
        IEnumerator FadeClickColor(Color normal, Color click)
        {
            float count = 0;

            while (count < highlight.FadeDuration)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(normal, click, count / highlight.FadeDuration);

                yield return null;
            }

            count = 0;
            while (count < highlight.FadeDuration)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(click, normal, count / highlight.FadeDuration);

                yield return null;
            }
        }

        public UISelectable GetNextInteractableUp()
        {
            if (NavigationUI.up != null)
            {
                if (NavigationUI.up.interactable)
                {
                    return NavigationUI.up;
                }
                else
                {
                    return NavigationUI.up.GetNextInteractableUp();
                }
            }
            else
            {
                return null;
            }
        }
        public UISelectable GetNextInteractableDown()
        {
            if (NavigationUI.down != null)
            {
                if (NavigationUI.down.interactable)
                {
                    return NavigationUI.down;
                }
                else
                {
                    return NavigationUI.down.GetNextInteractableDown();
                }
            }
            else
            {
                return null;
            }
        }
        public UISelectable GetNextInteractableLeft()
        {
            if (NavigationUI.left != null)
            {
                if (NavigationUI.left.interactable)
                {
                    return NavigationUI.left;
                }
                else
                {
                    return NavigationUI.left.GetNextInteractableLeft();
                }
            }
            else
            {
                return null;
            }
        }
        public UISelectable GetNextInteractableRight()
        {
            if (NavigationUI.right != null)
            {
                if (NavigationUI.right.interactable)
                {
                    return NavigationUI.right;
                }
                else
                {
                    return NavigationUI.right.GetNextInteractableRight();
                }
            }
            else
            {
                return null;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Click();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (interactable)
            {
                controllerManager.Select(this);
            }
        }

        public virtual void Click() { }

        void Reset()
        {
            controllerManager = FindObjectOfType<UIControllerManager>();

            if (controllerManager == null)
            {
                Debug.LogError("TO USE SELECTABLES, THE SCENE MUST HAVE A UI CONTROLLER MANAGER");
            }

            targetImage = GetComponent<Image>();
            Navigation nav = new Navigation();
            nav.mode = Navigation.Mode.None;

            if (controllerManager != null)
            {
                highlight.NormalColor = controllerManager.Highlight.NormalColor;
                highlight.EnterColor = controllerManager.Highlight.EnterColor;
                highlight.ClickColor = controllerManager.Highlight.ClickColor;
                highlight.DisabledColor = controllerManager.Highlight.DisabledColor;
                targetImage.color = highlight.NormalColor;
            }
            else
            {
                highlight.NormalColor = Color.white;
                highlight.EnterColor = Color.red;
                highlight.ClickColor = Color.green;
                highlight.DisabledColor = Color.gray;
                targetImage.color = highlight.NormalColor;
            }
        }
        void OnValidate()
        {
            if (highlight.FadeDuration <= 0)
            {
                highlight.FadeDuration = 0.1f;
            }

            if (controllerManager != null)
            {
                if (Interactable)
                {
                    targetImage.color = controllerManager.Highlight.NormalColor;
                }
                else
                {
                    targetImage.color = controllerManager.Highlight.DisabledColor;
                }
            }
            else
            {
                if (Interactable)
                {
                    targetImage.color = Highlight.NormalColor;
                }
                else
                {
                    targetImage.color = Highlight.DisabledColor;
                }
            }


        }
    }
}
