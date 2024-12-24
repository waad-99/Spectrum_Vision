using UnityEngine;

public class PlaySoundAndShowCubes : MonoBehaviour
{
    public AudioSource audioSource; // ãÑÌÚ ááÕæÊ
    public GameObject[] cubes; // ãÕİæİÉ ááãßÚÈÇÊ
    private bool cubesShown = false; // ááÊÃßÏ ãä Ãä ÇáãßÚÈÇÊ ÊÙåÑ ãÑÉ æÇÍÏÉ İŞØ

    private void Start()
    {
        if (cubes == null || cubes.Length == 0)
        {
            Debug.LogError("No cubes assigned to the script!"); // ÊÍŞŞ ÅĞÇ áã íÊã ÊÚííä ÇáãßÚÈÇÊ
            return;
        }

        // ÅÎİÇÁ ÌãíÚ ÇáãßÚÈÇÊ ÚäÏ ÈÏÁ ÇááÚÈÉ
        foreach (GameObject cube in cubes)
        {
            if (cube != null)
            {
                cube.SetActive(false);
            }
        }

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource assigned to the script!"); // ÊÍŞŞ ÅĞÇ áã íÊã ÊÚííä ÇáÕæÊ
        }
    }

    private void Update()
    {
        if (audioSource != null && !audioSource.isPlaying && !cubesShown)
        {
            // ÅÙåÇÑ ÌãíÚ ÇáãßÚÈÇÊ ÚäÏ ÇäÊåÇÁ ÇáÕæÊ
            foreach (GameObject cube in cubes)
            {
                if (cube != null)
                {
                    cube.SetActive(true);
                }
            }

            // ãäÚ ÙåæÑ ÇáãßÚÈÇÊ ãÑÉ ÃÎÑì
            cubesShown = true;
            Debug.Log("Cubes are now shown!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ÇáÊÍŞŞ ãä Ãä ÇááÇÚÈ åæ ãä ÏÎá ÇáãäØŞÉ
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // ÊÔÛíá ÇáÕæÊ ÚäÏ ÏÎæá ÇááÇÚÈ ÇáãäØŞÉ
                Debug.Log("Audio started playing!");
            }
        }
    }
}
