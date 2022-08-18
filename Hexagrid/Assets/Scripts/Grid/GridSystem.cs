using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;

    private float xOffset = 2f;
    private float zOffset = 1.75f;

    public GridSystem(int width, int height)
    {
        this.width = width;
        this.height = height;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {

            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        float x, z;

        if (gridPosition.z % 2 == 0)
        {
            x = gridPosition.x;
            z = zOffset * gridPosition.z;
        }
        else
        {
            x = 0;
            z = 0;
        }

        return new Vector3(x, 0, z);
    }
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(0, 0);
    }

}
