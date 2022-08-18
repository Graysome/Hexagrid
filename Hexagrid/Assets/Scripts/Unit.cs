using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    private Vector3 destination;

    private void Awake()
    {
        destination = transform.position;
    }

    private void Update()
    {
        Vector3 moveDir = (destination - transform.position).normalized;

        float distanceBeforeMoving = Vector3.Distance(transform.position, destination);

        float moveSpeed = 5f;
        transform.position += moveSpeed * Time.deltaTime * moveDir;

        float distanceAfterMoving = Vector3.Distance(transform.position, destination);

        if (distanceBeforeMoving < distanceAfterMoving)
        {
            transform.position = destination;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GridPosition gridPosition = Map.Instance.GetGridPosition(hit.point);
                destination = Map.Instance.GetWorldPosition(gridPosition);
            }
        }
    }
}
