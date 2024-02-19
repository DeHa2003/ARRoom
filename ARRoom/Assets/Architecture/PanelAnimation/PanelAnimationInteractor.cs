using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class PanelAnimationInteractor : Interactor
    {
        public void CanvasGroupAlpha(CanvasGroup canvasGroup, float from, float to, float time)
        {
            Coroutines.StartRoutine(CanvasGroup_Alpha_Coroutine(canvasGroup, from, to, time));
        }

        public void ChangeGridLayoutSpacing(GridLayoutGroup gridLayoutGroup, Vector2 from, Vector2 to, float timer)
        {
            Coroutines.StartRoutine(GridLayot_Spacing_Coroutine(gridLayoutGroup, from, to, timer));
        }

        private IEnumerator GridLayot_Spacing_Coroutine(GridLayoutGroup gridLayoutGroup, Vector2 from, Vector2 to, float timer)
        {
            float t = 0.0f;
            gridLayoutGroup.spacing = from;

            while (t < 1.0f)
            {
                t += Time.deltaTime * (1.0f / timer);
                if (gridLayoutGroup != null)
                    gridLayoutGroup.spacing = new Vector2(Mathf.Lerp(from.x, to.x, t), Mathf.Lerp(from.y, to.y, t));
                yield return 0;
            }
        }

        private IEnumerator CanvasGroup_Alpha_Coroutine(CanvasGroup canvasGroup, float from, float to, float timer)
        {
            float t = 0.0f;
            canvasGroup.alpha = from;
            
            while (t < 1.0f)
            {
                t += Time.deltaTime * (1.0f / timer);
                if(canvasGroup != null)
                   canvasGroup.alpha = Mathf.Lerp(from, to, t); //Может быть удалён
                yield return 0;
            }
        }
    }
}
