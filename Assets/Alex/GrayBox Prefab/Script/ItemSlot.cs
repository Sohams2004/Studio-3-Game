using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            GameObject droppedObj = eventData.pointerDrag.gameObject;

            CheckAllObjectsInPlace();
        }


    }

    private void CheckAllObjectsInPlace()
    {
        GameObject momObject = GameObject.FindGameObjectWithTag("Mom");
        GameObject jakeObject = GameObject.FindGameObjectWithTag("Jake");
        GameObject eyeObject = GameObject.FindGameObjectWithTag("An Eye");
        GameObject discountObject = GameObject.FindGameObjectWithTag("Discount");
        GameObject aloneObject = GameObject.FindGameObjectWithTag("Alone");

        if (IsObjectInCorrectPosition(momObject, "MomSlot") &&
            IsObjectInCorrectPosition(jakeObject, "JakeSlot") &&
            IsObjectInCorrectPosition(eyeObject, "EyeSlot") &&
            IsObjectInCorrectPosition(discountObject, "DiscountSlot") &&
            IsObjectInCorrectPosition(aloneObject, "AloneSlot"))
        {
            Debug.Log("Mario mariosdsds");
        }
    }

    private bool IsObjectInCorrectPosition(GameObject obj, string slotTag)
    {
        if (obj == null)
        {
            return false;
        }

        GameObject slot = GameObject.FindGameObjectWithTag(slotTag);
        if (slot == null)
        {
            return false;
        }

        return Vector2.Distance(obj.GetComponent<RectTransform>().anchoredPosition,
                               slot.GetComponent<RectTransform>().anchoredPosition) < 1f;
    }

    private void Update()
    {
        CheckAllObjectsInPlace();
    }

}
