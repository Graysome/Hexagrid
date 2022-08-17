using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int width = 20;
    private int height = 40;
    [SerializeField] private Transform hexPrefab;

    private void Start()
    {
        float xOffset = 2f;
        float zOffset = 1.75f;

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
                hexTile.SetParent(transform);
            }
        }
    }
}
