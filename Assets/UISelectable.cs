using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIHandler
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class UISelectable : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] protected bool interactable = true;
        [SerializeField] Image targetImage;

        [Header("Highlight")]
        [SerializeField] bool overrideManager;
        [SerializeField] Transition transition;
        [SerializeField] HighlightColor highlightColor;
        [SerializeField] HighlightSprite highlightSprite;
        [SerializeField] HighlightAnimation highlightAnimation;
        [Min(0.05f)] [SerializeField] float fadeDuration = 0.1f;
        [Space(8)]
        [SerializeField] NavigationUI navigation;

        protected UIControllerManager controllerManager;
        Coroutine fadeCoroutine;

        public NavigationUI NavigationUI { get => navigation; }
        public HighlightColor HighlightColor { get => highlightColor; set => highlightColor = value; }
        public HighlightSprite HighlightSprite { get => highlightSprite; set => highlightSprite = value; }
        public HighlightAnimation HighlightAnimation { get => highlightAnimation; set => highlightAnimation = value; }
        public Image TargetImage { get => targetImage; set => targetImage = value; }
        public bool Override { get => overrideManager; set => overrideManager = value; }
        public bool Interactable { get => interactable; set => interactable = value; }
        public Transition Transition { get => transition; set => transition = value; }

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
        public void Fade(Sprite spriteToUse)
        {
            targetImage.sprite = spriteToUse;
        }
        public void Fade(Animation animationToUse)
        {

        }
        protected void FadeClick(bool upClick = false)
        {
            if (Override)
            {
                if (Transition == Transition.Color)
                {
                    Color normal, click;

                    normal = highlightColor.Enter;
                    click = highlightColor.Click;

                    if (fadeCoroutine != null)
                    {
                        StopCoroutine(fadeCoroutine);
                    }

                    if (upClick)
                    {
                        fadeCoroutine = StartCoroutine(FadeUpColor(normal, click));
                    }
                    else
                    {
                        fadeCoroutine = StartCoroutine(FadeDownColor(normal, click));
                    }
                }
                else if (Transition == Transition.Sprite)
                {
                    Sprite normal, click;

                    normal = highlightSprite.Enter;
                    click = highlightSprite.Click;

                    if (fadeCoroutine != null)
                    {
                        StopCoroutine(fadeCoroutine);
                    }

                    if (upClick)
                    {
                        fadeCoroutine = StartCoroutine(FadeUpSprite(normal));
                    }
                    else
                    {
                        targetImage.sprite = click;
                    }
                }
                else
                {

                }
            }
            else
            {
                if (controllerManager.Transition == Transition.Color)
                {
                    Color normal, click;

                    normal = controllerManager.HighlightColor.Enter;
                    click = controllerManager.HighlightColor.Click;

                    if (fadeCoroutine != null)
                    {
                        StopCoroutine(fadeCoroutine);
                    }

                    if (upClick)
                    {
                        fadeCoroutine = StartCoroutine(FadeUpColor(normal, click));
                    }
                    else
                    {
                        fadeCoroutine = StartCoroutine(FadeDownColor(normal, click));
                    }
                }
                else if (controllerManager.Transition == Transition.Sprite)
                {
                    Sprite normal, click;

                    normal = controllerManager.HighlightSprite.Enter;
                    click = controllerManager.HighlightSprite.Click;

                    if (fadeCoroutine != null)
                    {
                        StopCoroutine(fadeCoroutine);
                    }

                    if (upClick)
                    {
                        fadeCoroutine = StartCoroutine(FadeUpSprite(normal));
                    }
                    else
                    {
                        targetImage.sprite = click;
                    }
                }
                else
                {

                }
            }
        }

        IEnumerator FadeUpSprite(Sprite normal)
        {
            float fade = overrideManager ? fadeDuration : controllerManager.FadeDuration;

            yield return new WaitForSecondsRealtime(fade);

            targetImage.sprite = normal;
        }

        IEnumerator FadeColor(Color colorToUse)
        {
            float count = 0;
            Color color = targetImage.color;

            float fade = overrideManager ? fadeDuration : controllerManager.FadeDuration;

            while (count < fade)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(color, colorToUse, count / fade);

                yield return null;
            }
        }
        IEnumerator FadeDownColor(Color normal, Color click)
        {
            float count = 0;

            float fade = overrideManager ? fadeDuration : controllerManager.FadeDuration;

            while (count < fade)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(normal, click, count / fade);

                yield return null;
            }
        }
        IEnumerator FadeUpColor(Color normal, Color click)
        {
            float count = 0;

            float fade = overrideManager ? fadeDuration : controllerManager.FadeDuration;

            while (count < fade)
            {
                count += Time.unscaledDeltaTime;
                targetImage.color = Color.Lerp(click, normal, count / fade);

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
        public void OnPointerDown(PointerEventData eventData)
        {
            if (interactable)
            {
                FadeClick(false);
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (interactable && controllerManager.IsSelected(this))
            {
                FadeClick(true);
            }
        }

        public void ClickDown()
        {
            if (interactable)
            {
                FadeClick(false);
            }
        }
        public void ClickUp()
        {
            if (interactable && controllerManager.IsSelected(this))
            {
                FadeClick(true);
                Click();
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
                highlightColor.Normal = controllerManager.HighlightColor.Normal;
                highlightColor.Enter = controllerManager.HighlightColor.Enter;
                highlightColor.Click = controllerManager.HighlightColor.Click;
                highlightColor.Disabled = controllerManager.HighlightColor.Disabled;
                targetImage.color = highlightColor.Normal;
            }
            else
            {
                highlightColor.Normal = Color.white;
                highlightColor.Enter = Color.red;
                highlightColor.Click = Color.green;
                highlightColor.Disabled = Color.gray;
                targetImage.color = highlightColor.Normal;
            }
        }
        void OnValidate()
        {
            if (controllerManager != null)
            {
                if (Interactable)
                {
                    targetImage.color = controllerManager.HighlightColor.Normal;
                }
                else
                {
                    targetImage.color = controllerManager.HighlightColor.Disabled;
                }
            }
            else
            {
                if (Interactable)
                {
                    targetImage.color = highlightColor.Normal;
                }
                else
                {
                    targetImage.color = highlightColor.Disabled;
                }
            }
        }
    }
}
