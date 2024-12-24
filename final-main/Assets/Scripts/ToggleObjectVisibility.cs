using UnityEngine;
using UnityEngine.UI; // áÇÓÊíÑÇÏ ÇáãßÊÈÉ ÇáÎÇÕÉ ÈÇáÜ UI

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject objectToToggle; // ÇáßÇÆä ÇáĞí ÊÑíÏ ÇáÊÈÏíá Èíä ÙåæÑå æÇÎÊİÇÆå
    public Button toggleButton; // ÇáÒÑ ÇáĞí ÓíÊã ÇáÖÛØ Úáíå ãä ÇáÜ Canvas

    private void Start()
    {
        // ÇáÊÃßÏ ãä Ãä ÇáßÇÆä ÛíÑ ãİÚá ÚäÏ ÈÏÇíÉ ÇááÚÈÉ
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false); // ÅÎİÇÁ ÇáßÇÆä
        }

        // ÇáÊÍŞŞ ÅĞÇ Êã ÊÚííä ÇáÒÑ
        if (toggleButton != null)
        {
            // ÑÈØ ÇáÒÑ ÈÍÏË ÇáÖÛØ Úáíå
            toggleButton.onClick.AddListener(ToggleObject); // ÅÖÇİÉ ÇáãÓÊãÚ áÍÏË ÇáÖÛØ Úáì ÇáÒÑ
        }
        else
        {
            Debug.LogError("Button is not assigned!");
        }
    }

    // ÇáÏÇáÉ ÇáÊí ÓÊäİĞ ÚäÏ ÇáÖÛØ Úáì ÇáÒÑ
    public void ToggleObject()
    {
        if (objectToToggle != null)
        {
            // ÇáÊÈÏíá Èíä ÅÙåÇÑ ÇáßÇÆä Ãæ ÅÎİÇÆå
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
