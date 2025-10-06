using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{

    public AudioClip clickSound;
    private AudioSource audioSource;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        audioSource = FindAnyObjectByType<AudioSource>();

        button.onClick.AddListener(PlaySound);
    }


    void PlaySound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
