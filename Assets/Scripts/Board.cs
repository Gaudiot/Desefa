using UnityEngine;

public class Board : MonoBehaviour
{   
    public TextAsset jsonMapa;
    public int[,] terrain;

    private Tile[,] board;
    private int height;
    private int width;

    private SpriteRenderer mapSprite;
    
    void Start()
    {
        this.height = JSONMapReader.GetMapHeight(jsonMapa);
        this.width = JSONMapReader.GetMapWidth(jsonMapa);
        this.board = new Tile[this.width,this.height];

        for(int x = 0; x < this.width ; x++)
            for(int y = 0; y < this.height ; y++)
                board[x,y] = new Tile(new Vector2Int(x,y));

        terrain = JSONMapReader.GetMapMatrix(jsonMapa);

        mapSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2Int tileSelect = OnTileSelect();
            Debug.Log(tileSelect);
            if(tileSelect.x > 0 && tileSelect.y > 0){

            }
        }
    }

    private Vector2 GetMapDimensions(){
        float scale = gameObject.transform.localScale.x;
        Vector2 mapDimensions = mapSprite.size*scale;

        return mapDimensions;
    }

    private Vector2 MousePositionOnBoard(){
        //Get actual map size in unity scale
        Vector2 mapDimensions = GetMapDimensions();

        //Mouse position and correction factor
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition += (mapDimensions/2);
        
        return mousePosition;
    }

    private Vector2Int OnTileSelect(){
        Vector2 mousePosition = MousePositionOnBoard();
        Vector2 mapDimensions = GetMapDimensions();
        
        if(mousePosition.x < 0 || mousePosition.x > mapDimensions.x) return new Vector2Int(0, 0);
        if(mousePosition.y < 0 || mousePosition.y > mapDimensions.y) return new Vector2Int(0, 0);
        

        float tile_width = mapDimensions.x/width;
        float tile_height = mapDimensions.y/height;

        Vector2Int selectedTile = new Vector2Int();
        selectedTile.x = Mathf.FloorToInt(mousePosition.x/tile_width) + 1;
        selectedTile.y = Mathf.FloorToInt(mousePosition.y/tile_height) + 1;

        return selectedTile;
    }

    public Piece GetPiece(Vector2Int position)
    {
        return this.board[position.x, position.y].GetPiece();
    }

    public bool PieceCanOccupy(Vector2Int position)
    {
        if(ValidPos(position) && !IsObstacle(position)) return true;
        return false;
    }

    public bool ValidPos(Vector2Int position)
    {
        if(position.x <= 0 || position.x > this.width) return false;
        if(position.y <= 0 || position.y > this.height) return false;
        return true;
    }

    public bool IsObstacle(Vector2Int vec){
        if (terrain[vec.x,vec.y] != 0 || terrain[vec.x,vec.y] != 453 || terrain[vec.x,vec.y] != 455){
            return true;
        }
        return false;
    }
}

