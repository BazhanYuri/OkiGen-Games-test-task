using System.Collections;
using System.Collections.Generic;
using UnityEngine;





namespace TestTask
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup _canvasGroup;



        protected void StartShowing()
        {
            StartCoroutine(ShowUI());
        }
        protected IEnumerator ShowUI()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSecondsRealtime(0.005f);
                _canvasGroup.alpha = i / 100f;
            }
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        protected void StartHidding()
        {
            StartCoroutine(HideUI());
        }
        protected IEnumerator HideUI()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSecondsRealtime(0.005f);
                _canvasGroup.alpha = 1 - (i / 100f);
            }
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }

}
