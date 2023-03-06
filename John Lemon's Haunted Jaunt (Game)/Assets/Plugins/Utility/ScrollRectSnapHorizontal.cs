using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectSnapHorizontal : MonoBehaviour
{
    private ScrollRect ScrollRect;
    private RectTransform RectTransform;
    private GameObject lastSelectedGameObject;

    void Awake()
    {
        ScrollRect = GetComponent<ScrollRect>();
        RectTransform = ScrollRect.content;
    }

    void Update()
    {
        UpdateScrollToSelected();
    }

    void UpdateScrollToSelected()
    {
        GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
        if (currentSelectedGameObject == null ||
            currentSelectedGameObject.transform.parent != RectTransform.transform ||
            currentSelectedGameObject == lastSelectedGameObject) 
            {return;}
        Canvas.ForceUpdateCanvases();
        RectTransform.anchoredPosition = (Vector2)ScrollRect.transform.InverseTransformPoint(RectTransform.position) - (Vector2)ScrollRect.transform.InverseTransformPoint(currentSelectedGameObject.GetComponent<RectTransform>().position);
        RectTransform.localPosition = new Vector2(RectTransform.localPosition.x, 0);
        lastSelectedGameObject = currentSelectedGameObject;
    }
}
