using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndKick : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPow;
    public Vector2 maxPow;

    TrajectoryLine tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    public float slowDownFactor;

    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;

            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * .02f; 

            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPow.x, maxPow.x), 
                Mathf.Clamp(startPoint.y - endPoint.y, minPow.y, maxPow.y));

            source.Play();
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }



}
