using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    [SerializeField] private TextMeshPro tileText;

    public void SetTileText(string text)
    { 
        tileText.text = text;
    }
}
