using UnityEngine;

public class OpenVirtualKeyboard : MonoBehaviour
{
    // public GameObject mainCanvas;                // gameObject - main canvas in your scene
    // private RectTransform canvasRectTransform;   // the RectTransform component on the gameObject - main canvas
    private GameObject virtualKeyboard;         // {virtual keyboard} prefabs in your scene
    private RectTransform keyboardBackground;   // the gameObject background in {virtual keyboard} prefabs in your scene

    [HideInInspector]
    public bool onExitKeyboardArea;

    private void Awake()
    {
        // Find the virtual keyboard in the scene by its name
        virtualKeyboard = GameObject.Find("Virtual Keyboard").gameObject;
        if (virtualKeyboard == null)
            Debug.LogError("Pls drag the {Virtual Keyboard} prefabs in your scene");
        else
        {
#if (UNITY_EDITOR)
            print("Get the {virtual keyboard} prefabs");
#endif
            // Find the background component of the keyboard
            keyboardBackground = virtualKeyboard.transform.Find("Background").gameObject.GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        // If the keyboard is not active and onExitKeyboardArea is not true, open the keyboard
        if (!virtualKeyboard.activeSelf && !onExitKeyboardArea)
        {
            OnOpenVirtualKeyboard();
        }
    }

    public void OnOpenVirtualKeyboard()
    {
        // If the virtual keyboard is already active, do nothing
        if (virtualKeyboard.activeSelf)
            return;

#if (UNITY_EDITOR)
        print("OnOpenVirtualKeyboard");
#endif

        // Setup the keyboard size and activate it
        SetupKeyboardSize();
        virtualKeyboard.SetActive(true);
    }

    private void SetupKeyboardSize()
    {
        // Set the size of the keyboard
        float keyboardWidth = 485;
        float keyboardHeight = 485;

#if(UNITY_EDITOR)
         print($"interface size is {keyboardWidth} x {keyboardHeight}");
#endif
        // Apply the size to the background RectTransform of the keyboard
        keyboardBackground.sizeDelta = new Vector2(keyboardWidth, keyboardHeight);
    }
}
