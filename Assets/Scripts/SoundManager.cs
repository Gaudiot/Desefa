using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager : object
{
    public static void Play(string sound){
        if(sound == "Background"){
            SoundPlayer.instance.backgroundSound.Play();
        }
        if(sound == "Death"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Death);
        }
        if(sound == "Pawn"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Pawn);
        }
        if(sound == "Knight"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Knight);
        }
        if(sound == "Bishop"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Bishop);
        }
        if(sound == "King"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.King);
        }
        if(sound == "Queen"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Queen);
        }
        if(sound == "Rook"){
            SoundPlayer.instance.soundEffect.PlayOneShot(SoundPlayer.instance.Rook);
        }
    }

    public static void Stop(string sound){
        if(sound == "Background"){
            SoundPlayer.instance.backgroundSound.Stop();
        }else{
            SoundPlayer.instance.soundEffect.Stop();
        }
    }
}
