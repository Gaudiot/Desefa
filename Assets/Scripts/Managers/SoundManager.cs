using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource, backgroundSource;
    public AudioClip background;
    public AudioClip death;
    public AudioClip king;
    public AudioClip queen;
    public AudioClip pawn;
    public AudioClip knight;
    public AudioClip bishop;
    public AudioClip rook;

    public static SoundManager instance;

    private void Awake(){
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    void Start(){
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        backgroundSource = GameObject.Find("BackgroundSource").GetComponent<AudioSource>();
    }

    public void Stop(){
        audioSource.Stop();
    }

    public void PlayPiece(GameObject piece){
        Piece.PieceType pieceType = piece.GetComponent<Piece>().GetPieceType();

        Stop();
        switch (pieceType){
            case Piece.PieceType.pawn:
                audioSource.PlayOneShot(pawn);
                break;
            case Piece.PieceType.knight:
                audioSource.PlayOneShot(knight);
                break;
            case Piece.PieceType.bishop:
                audioSource.PlayOneShot(bishop);
                break;
            case Piece.PieceType.king:
                audioSource.PlayOneShot(king);
                break;
            case Piece.PieceType.queen:
                audioSource.PlayOneShot(queen);
                break;
            case Piece.PieceType.rook:
                audioSource.PlayOneShot(rook);
                break;

        }
    }

    public void PlayDeath(){
        Stop();
        audioSource.PlayOneShot(death);
    }
}