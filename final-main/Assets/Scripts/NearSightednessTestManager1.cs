using UnityEngine;

public class NearSightednessTestManager : MonoBehaviour
{
    // ���� ������ ����� ������ ��� �����
    public void CompleteNearSightednessTest(string result)
    {
        // ����� ������� �� ResultManager
        ResultManager.SetNearSightednessResult(result);
        Debug.Log($"Near Sightedness Test Completed: {result}");  // ���� �� �� ������� �� �������
    }
}
