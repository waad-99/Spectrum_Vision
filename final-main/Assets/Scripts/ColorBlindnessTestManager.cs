using UnityEngine;

namespace YourNamespace // íãßäß ÊÛííÑ åĞå ÇáãÓÇÍÉ ÇáÇÓãíÉ áÊÌäÈ ÇáÊÚÇÑÖ ãÚ ÇáİÆÇÊ ÇáÃÎÑì
{


    public class ColorBlindnessTestManager : MonoBehaviour
    {
        // ÏÇáÉ áÊÍÏíË äÊíÌÉ ÇÎÊÈÇÑ Úãì ÇáÃáæÇä
        public void CompleteColorBlindnessTest(string result)
        {
            // ÊÍÏíË ÇáäÊíÌÉ İí ResultManager
            ResultManager.SetColorBlindnessResult(result);
            Debug.Log($"Color Blindness Test Completed: {result}");  // ÊÃßÏ ãä Ãä ÇáäÊíÌÉ Êã ÊÚííäåÇ
        }
    }

}
