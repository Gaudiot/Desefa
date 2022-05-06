using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{

    public TextMeshProUGUI attackTMP;
    public TextMeshProUGUI HpValueTMP;

    void Start(){
        SetNullStatus();
    }

    private void SetNullStatus(){
        attackTMP.text = "-";
        HpValueTMP.text = "-/-";
    }

    public void UpdatePieceStatus(GameObject piece){
        if(piece == null){
            SetNullStatus();
            return;
        }

        Piece pieceScript = piece.GetComponent<Piece>();

        attackTMP.text = pieceScript.GetAP().ToString();
        HpValueTMP.text = pieceScript.GetCurrHP().ToString() + "/" + pieceScript.GetMaxHP().ToString();
    }
}
