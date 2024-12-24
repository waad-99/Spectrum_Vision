using UnityEngine;
using UnityEngine.UI; // �������� ������� ������ ���� UI

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject objectToToggle; // ������ ���� ���� ������� ��� ����� ��������
    public Button toggleButton; // ���� ���� ���� ����� ���� �� ��� Canvas

    private void Start()
    {
        // ������ �� �� ������ ��� ���� ��� ����� ������
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false); // ����� ������
        }

        // ������ ��� �� ����� ����
        if (toggleButton != null)
        {
            // ��� ���� ���� ����� ����
            toggleButton.onClick.AddListener(ToggleObject); // ����� ������� ���� ����� ��� ����
        }
        else
        {
            Debug.LogError("Button is not assigned!");
        }
    }

    // ������ ���� ����� ��� ����� ��� ����
    public void ToggleObject()
    {
        if (objectToToggle != null)
        {
            // ������� ��� ����� ������ �� ������
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
