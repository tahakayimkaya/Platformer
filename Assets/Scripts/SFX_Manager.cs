using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public AudioClip jump, melee;

    public GameObject player;

    public AudioSource background_music;

    public void JumpSound()
    {
        AudioSource.PlayClipAtPoint(jump,player.transform.position,1f);

    }

    public void AttackSound()
    {
        AudioSource.PlayClipAtPoint(melee,player.transform.position,1f);
    }

    public void StoppingMusic()
    {
        background_music.Stop();
    }

}
