using UnityEngine;

public class NearSightednessTestManager : MonoBehaviour
{
    // ÏÇáÉ áÊÍÏíË äÊíÌÉ ÇÎÊÈÇÑ ŞÕÑ ÇáäÙÑ
    public void CompleteNearSightednessTest(string result)
    {
        // ÊÍÏíË ÇáäÊíÌÉ İí ResultManager
        ResultManager.SetNearSightednessResult(result);
        Debug.Log($"Near Sightedness Test Completed: {result}");  // ÊÃßÏ ãä Ãä ÇáäÊíÌÉ Êã ÊÚííäåÇ
    }
}
