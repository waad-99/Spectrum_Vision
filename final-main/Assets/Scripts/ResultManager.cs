using UnityEngine;

public static class ResultManager
{
    private static string nearSightednessResult;
    private static string colorBlindnessResult;

    // ÊÚííä äÊíÌÉ ŞÕÑ ÇáäÙÑ
    public static void SetNearSightednessResult(string result)
    {
        nearSightednessResult = result;
        Debug.Log($"Near Sightedness Result Set: {nearSightednessResult}");  // ÇáÊÃßÏ ãä Ãä ÇáäÊíÌÉ Êã ÊÚííäåÇ
    }

    // ÊÚííä äÊíÌÉ Úãì ÇáÃáæÇä
    public static void SetColorBlindnessResult(string result)
    {
        colorBlindnessResult = result;
        Debug.Log($"Color Blindness Result Set: {colorBlindnessResult}");  // ÇáÊÃßÏ ãä Ãä ÇáäÊíÌÉ Êã ÊÚííäåÇ
    }

    // ÇáÍÕæá Úáì äÊíÌÉ ŞÕÑ ÇáäÙÑ
    public static string GetNearSightednessResult()
    {
        Debug.Log($"Getting Near Sightedness Result: {nearSightednessResult}");  // ÇáÊÃßÏ ãä Ãä ÇáäÊíÌÉ íÊã ÅÑÌÇÚåÇ ÈÔßá ÕÍíÍ
        return nearSightednessResult;
    }

    // ÇáÍÕæá Úáì äÊíÌÉ Úãì ÇáÃáæÇä
    public static string GetColorBlindnessResult()
    {
        Debug.Log($"Getting Color Blindness Result: {colorBlindnessResult}");  // ÇáÊÃßÏ ãä Ãä ÇáäÊíÌÉ íÊã ÅÑÌÇÚåÇ ÈÔßá ÕÍíÍ
        return colorBlindnessResult;
    }
}
