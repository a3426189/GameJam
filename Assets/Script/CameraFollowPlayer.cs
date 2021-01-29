using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform PlayerPos;
    // Start is called before the first frame update
    private void Update()
    {
        if (PlayerPos.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, PlayerPos.position.y, transform.position.z);
        }
    }
}
