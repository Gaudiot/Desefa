using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource soundEffect, backgroundSound;
    public AudioClip Death;
    public AudioClip King;
    public AudioClip Queen;
    public AudioClip Pawn;
    public AudioClip Knight;
    public AudioClip Bishop;
    public AudioClip Rook;
    
    public static SoundPlayer instance;

    private void Awake(){
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
}
