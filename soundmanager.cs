using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource carNoise;

    [SerializeField]
    private Transform character;
    // Don't forget to assign both variables on inspector.
    
    // if you want sound to come from a special place, use this variable instead of "this.transform"
    [SerializeField]
    private Transform particularAreaPos;
    
    public float maxDistance = 5f;
    // You can change max distance if you want.
    
    private void Start()
    {
        // Find character with tag "Player"
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    // You can use Update or FixedUpdate too. But in my case, i used LateUpdate
    private void LateUpdate()
    {
        /* this script attached to the audio source itself. That's why i used "this.transform"
        if you want sound to come from a special place, use particularAreaPos instead of "this.transform"*/
        sound3D(maxDistance, character.transform, this.transform, carNoise);
    }


    // Method for 3D sound effect.
    public void sound3D(float maxDistance, Transform characterPos, Transform sourcePos, AudioSource audio)
    {
        // Distance between character and audioSource.
        float distance = Vector2.Distance(characterPos.position, sourcePos.position);
        
        // for normalizing distance.
        float temp = distance / maxDistance;
        
        // if we didn't substract 1, volume would be max(1) at maxDistamce.
        float volume = 1 - temp;
        
        // Setting the volume.
        audio.volume = volume;

        // LOG INFORMATION //
        Debug.Log("distance between character and audioSource " + distance);
        Debug.Log("distance / maxDistance " + temp);
        Debug.Log("volume (1 - distance / maxDistance) " + volume);
    }
}

// SOURCE //
/*
Reddit thread: https://www.reddit.com/r/Unity2D/comments/43swwk/quick_3d_audio_question_for_2d_games/
Thanks to Proximal_Pyro (https://www.reddit.com/user/Proximal_Pyro/)
*/
