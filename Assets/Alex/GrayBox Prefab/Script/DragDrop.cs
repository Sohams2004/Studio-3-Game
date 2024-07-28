using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform recTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        /* throw new System.NotImplementedException();*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        recTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        /* throw new System.NotImplementedException();*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        /* throw new System.NotImplementedException();*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        /* throw new System.NotImplementedException();*/
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
