using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance { get; private set; }

    private int width = 20;
    private int height = 20;
    float xOffset = 2f;
    float zOffset = 1.75f;

    [SerializeField] private Transform hexPrefab;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float xPos = x * xOffset;
                if (z % 2 == 1)
                {
                    xPos += xOffset / 2;
                }
                Vector3 position = new Vector3(xPos, 0, z * zOffset);
                Transform hexTile = Instantiate(hexPrefab, position, Quaternion.identity);
                hexTile.name = x + ", " + z;
                hexTile.GetComponent<Tile>().SetTileText(hexTile.name, position.x + ", " + position.z);
                hexTile.SetParent(transform);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        float x, z;
        x = gridPosition.x * xOffset;

        if (gridPosition.z % 2 == 1)
        {
            x += xOffset / 2;
        }
        z = zOffset * gridPosition.z;

        return new Vector3(x, 0, z);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / xOffset);
        int z = Mathf.CeilToInt(worldPosition.z / zOffset);

        GridPosition gridPosition = new GridPosition(x, z);
        Debug.Log(gridPosition);
        return gridPosition;
    }
}
