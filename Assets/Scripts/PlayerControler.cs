using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.Translate(
            speed * Time.deltaTime * Input.GetAxis("Horizontal"),
            0,
            speed * Time.deltaTime * Input.GetAxis("Vertical"));
        }
}
