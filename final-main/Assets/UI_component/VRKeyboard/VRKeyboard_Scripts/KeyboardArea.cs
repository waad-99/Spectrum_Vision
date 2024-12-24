using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public int backWaitingTime = 3;
    private OpenVirtualKeyboard keyboardController;
    private Coroutine closeKeyboardCoroutine;

    private void Awake()
    {
        if (keyboardController == null)
            keyboardController = GameObject.Find("Virtual Keyboard Controller").GetComponent<OpenVirtualKeyboard>();

        keyboardController.onExitKeyboardArea = true;
    }

    private void OnEnable()
    {
        if (keyboardController == null)
            keyboardController = GameObject.Find("Virtual Keyboard Controller").GetComponent<OpenVirtualKeyboard>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (closeKeyboardCoroutine != null)
            StopCoroutine(closeKeyboardCoroutine);

        keyboardController.onExitKeyboardArea = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        closeKeyboardCoroutine = StartCoroutine(RecordExitTime());
    }

    private IEnumerator RecordExitTime()
    {
        yield return new WaitForSeconds(backWaitingTime);
        keyboardController.onExitKeyboardArea = true;
    }

    public void OnPointerDown(PointerEventData eventData) { }
    public void OnPointerUp(PointerEventData eventData) { }
    public void OnPointerClick(PointerEventData eventData) { }
}
