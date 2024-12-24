using UnityEngine;

namespace YourNamespace // ����� ����� ��� ������� ������� ����� ������� �� ������ ������
{


    public class ColorBlindnessTestManager : MonoBehaviour
    {
        // ���� ������ ����� ������ ��� �������
        public void CompleteColorBlindnessTest(string result)
        {
            // ����� ������� �� ResultManager
            ResultManager.SetColorBlindnessResult(result);
            Debug.Log($"Color Blindness Test Completed: {result}");  // ���� �� �� ������� �� �������
        }
    }

}
