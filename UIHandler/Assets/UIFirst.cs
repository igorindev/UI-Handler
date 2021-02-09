using UnityEngine;
using System.Collections;

namespace UIHandler
{
    public class UIFirst : MonoBehaviour
    {
        [SerializeField] UISelectable firtsToSelect;

        void OnEnable()
        {
            if (UIControllerManager.instance == null)
            {
                StartCoroutine(TryGetController());
            }
            else
            {
                UIControllerManager.instance.Select(firtsToSelect);
            }
        }

        IEnumerator TryGetController()
        {
            while (UIControllerManager.instance == null)
            {
                yield return null;
            }

            UIControllerManager.instance.Select(firtsToSelect);
        }

        void Reset()
        {
            if (TryGetComponent(out UISelectable selectable))
            {
                firtsToSelect = selectable;
            }
        }
    }
}
