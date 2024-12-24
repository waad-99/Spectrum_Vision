using UnityEngine;

public class PlaySoundAndShowCubes : MonoBehaviour
{
    public AudioSource audioSource; // ���� �����
    public GameObject[] cubes; // ������ ��������
    private bool cubesShown = false; // ������ �� �� �������� ���� ��� ����� ���

    private void Start()
    {
        if (cubes == null || cubes.Length == 0)
        {
            Debug.LogError("No cubes assigned to the script!"); // ���� ��� �� ��� ����� ��������
            return;
        }

        // ����� ���� �������� ��� ��� ������
        foreach (GameObject cube in cubes)
        {
            if (cube != null)
            {
                cube.SetActive(false);
            }
        }

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource assigned to the script!"); // ���� ��� �� ��� ����� �����
        }
    }

    private void Update()
    {
        if (audioSource != null && !audioSource.isPlaying && !cubesShown)
        {
            // ����� ���� �������� ��� ������ �����
            foreach (GameObject cube in cubes)
            {
                if (cube != null)
                {
                    cube.SetActive(true);
                }
            }

            // ��� ���� �������� ��� ����
            cubesShown = true;
            Debug.Log("Cubes are now shown!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ������ �� �� ������ �� �� ��� �������
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // ����� ����� ��� ���� ������ �������
                Debug.Log("Audio started playing!");
            }
        }
    }
}
