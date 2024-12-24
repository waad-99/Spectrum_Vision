using UnityEngine;

public class ToggleObjectsOnButtonPress : MonoBehaviour
{
    public GameObject objectToHide;  // «·ﬂ«∆‰ «·–Ì ‰—Ìœ ≈Œ›«¡Â
    public GameObject objectToShow; // «·ﬂ«∆‰ «·–Ì ‰—Ìœ ≈ŸÂ«—Â

    public void ToggleObjects()
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // ≈Œ›«¡ «·ﬂ«∆‰ «·√Ê·
        }

        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // ≈ŸÂ«— «·ﬂ«∆‰ «·À«‰Ì
        }
    }
}
