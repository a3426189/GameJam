using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float speed = 80f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
