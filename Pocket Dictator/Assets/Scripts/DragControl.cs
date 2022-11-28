using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragControl : MonoBehaviour
{
    [SerializeField]
    private float power = 10f;
    [SerializeField]
    private float maxDrag = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                {
                    touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        DragStart();
                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        Dragging();
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        DragRelease();
                    }
                }
            }
        }
    }

    void DragStart() 
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }

    void Dragging() 
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }

    void DragRelease() 
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragReleasePos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
}
