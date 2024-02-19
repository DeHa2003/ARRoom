using System.Collections;
using UnityEngine;

public delegate void OnHit(Item item);

namespace Lessons.Architecture
{
    public class HitItemsInteractor : Interactor
    {
        public event OnHit OnHitOther;
        public event OnHit OnHitChangeItem;

        private bool isActive = false;

        public void ActivateFind(bool activate)
        {
            if (activate)
            {
                isActive = true;
                Coroutines.StartRoutine(ActivateFind_Coroutine());
            }
            else
            {
                isActive = false;
            }
        }

        private IEnumerator ActivateFind_Coroutine()
        {
            while (isActive)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (hit.collider.TryGetComponent(out Item item))
                            {
                                if (item.ItemStatus == ItemStatus.Change)
                                {
                                    OnHitChangeItem?.Invoke(item);
                                    Debug.Log("Ударили правильный предмет");
                                }
                                else
                                {
                                    OnHitOther?.Invoke(item);
                                    Debug.Log("Ударили неправильный предмет");
                                }
                            }
                            else
                            {
                                OnHitOther?.Invoke(null);
                                Debug.Log("Ударили вообще не спавнящийся предмет");
                            }
                        }
                    }
                }
                yield return null;
            }
        }
    }
}
