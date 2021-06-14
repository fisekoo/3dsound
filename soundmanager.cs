using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public AudioClip takeItem, Jumpscare, Thunder, Fire, putWood, putMouse, fire2, walk;
    public AudioSource source;
    public AudioSource walking;
    public AudioSource carNoise;
    karakter karakter;
    void Start()
    {
        karakter = GameObject.FindGameObjectWithTag("Player").GetComponent<karakter>();
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        sound3D(7, karakter.transform, this.transform, carNoise);
        walkSound();
    }

    // Update is called once per frame
    public void walkSound()
    {
        if (karakter.input != 0)
        {
            walking.loop = true;
            if (!walking.isPlaying) walking.Play();
        }
        else walking.Stop();
    }
    public void sound3D(float maxDistance, Transform characterPos, Transform sourcePos, AudioSource audio)
    {
        float distance = Vector2.Distance(characterPos.position, sourcePos.position);
        float temp = distance / maxDistance;
        float volume = 1 - temp;
        audio.volume = volume;

        // LOG INFORMATION //
        Debug.Log("distance between character and audioSource " + distance);
        Debug.Log("distance / maxDistance " + temp);
        Debug.Log("volume (1 - distance / maxDistance) " + volume);
    }
}
