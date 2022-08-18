using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    [SerializeField] private TextMeshPro tileText;
    [SerializeField] private TextMeshPro worldCoordText;

    public void SetTileText(string gridCoord, string worldCoord)
    { 
        tileText.text = gridCoord;
        worldCoordText.text = worldCoord;
    }

   

}
