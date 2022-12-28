using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    [Header ("References")]
    public Transform target;
    public Vector3 offset;
    public float speed;
    Vector3 velocity = Vector3.zero;
    [Header("Borders")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private void FixedUpdate()
    {
        float xClamp = Mathf.Clamp(target.position.x, xMin, xMax);
        float yClamp = Mathf.Clamp(target.position.y, yMin, yMax);
        Vector3 targetPosition = target.position + offset;
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(targetPosition.x, xMin, xMax), Mathf.Clamp(targetPosition.y, yMin, yMax),-10);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity, speed * Time.deltaTime);

        transform.position = smoothPosition;
    }
}
