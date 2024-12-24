using UnityEngine;

public class ToggleObjectsOnButtonPress : MonoBehaviour
{
    public GameObject objectToHide;  // ������ ���� ���� ������
    public GameObject objectToShow; // ������ ���� ���� ������

    public void ToggleObjects()
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // ����� ������ �����
        }

        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // ����� ������ ������
        }
    }
}
