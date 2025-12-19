using UnityEngine;
using UnityEngine.Animations;

public class MovingObject : MonoBehaviour
{
    public Axis MovementAxis = Axis.X;
    public float distanceToStart;
    private Vector3 startPosition;
    public float distanceToEnd;
    private Vector3 endPosition;
    private Vector3 axisOrientation;
    public float speed = 0.5f;

    void Start()
    {
        switch (MovementAxis)
        {
            case Axis.X:
                axisOrientation = Vector3.right;
                break;
            case Axis.Y:
                axisOrientation = Vector3.up;
                break;
            case Axis.Z:
                axisOrientation = Vector3.forward;
                break;
        }
        startPosition = transform.position - distanceToStart * axisOrientation;
        endPosition = transform.position + distanceToEnd * axisOrientation;
    }

    void Update()
    {
        Vector3 movement = axisOrientation * Time.deltaTime * speed;
        if (getVectorDirection(endPosition - (transform.position + movement)) <= 0)
        {
            axisOrientation *= -1;
        }
        else if (getVectorDirection(startPosition + (transform.position + movement)) <= 0)
        {
            axisOrientation *= -1;
        }
        transform.Translate(movement);
    }

    private float getVectorDirection(Vector3 vector)
    {
        switch (MovementAxis)
        {
            case Axis.X:
                return vector.x;
            case Axis.Y:
                return vector.y;
            case Axis.Z:
                return vector.z;
            default:
                return 0;
        }
    }
}