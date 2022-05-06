using UnityEngine;
using TMPro;

public class currHPStatus : MonoBehaviour
{
    private string currHP;
    private TextMeshProUGUI ui; 

    void Start()
    {
        currHP = "? /";
        ui = gameObject.GetComponent<TextMeshProUGUI>();
        ui.text = currHP;
    }

    private Board board;

    void Update(){
        GameObject boardManager = GameObject.Find("Start");
        board = boardManager.GetComponent<Board>();
        ui.text = board.pieceCurrHP  + " /";
    }
}
