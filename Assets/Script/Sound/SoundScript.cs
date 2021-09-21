using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip TabSound, EndGameSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        TabSound = Resources.Load<AudioClip>("Tab");
        EndGameSound = Resources.Load<AudioClip>("EndGame");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Tab":
                audioSource.PlayOneShot(TabSound);
                    break;
            case "EndGame":
                audioSource.PlayOneShot(EndGameSound);
                break;
        }
    }
}
