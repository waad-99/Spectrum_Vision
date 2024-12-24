using UnityEngine;

public static class ResultManager
{
    private static string nearSightednessResult;
    private static string colorBlindnessResult;

    // ����� ����� ��� �����
    public static void SetNearSightednessResult(string result)
    {
        nearSightednessResult = result;
        Debug.Log($"Near Sightedness Result Set: {nearSightednessResult}");  // ������ �� �� ������� �� �������
    }

    // ����� ����� ��� �������
    public static void SetColorBlindnessResult(string result)
    {
        colorBlindnessResult = result;
        Debug.Log($"Color Blindness Result Set: {colorBlindnessResult}");  // ������ �� �� ������� �� �������
    }

    // ������ ��� ����� ��� �����
    public static string GetNearSightednessResult()
    {
        Debug.Log($"Getting Near Sightedness Result: {nearSightednessResult}");  // ������ �� �� ������� ��� ������� ���� ����
        return nearSightednessResult;
    }

    // ������ ��� ����� ��� �������
    public static string GetColorBlindnessResult()
    {
        Debug.Log($"Getting Color Blindness Result: {colorBlindnessResult}");  // ������ �� �� ������� ��� ������� ���� ����
        return colorBlindnessResult;
    }
}
