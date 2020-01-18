using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform Target;
    public float FollowSpeed = 10f;
    public float FollowY = 10f;
    public float FollowZ = 2.5f;

    Vector3 newPos;
    float h;

    // Use this for initialization
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        newPos.x = Target.position.x;
        newPos.y = Target.position.y + FollowY;
        newPos.z = Target.position.z - FollowZ;

        var result = Vector3.Slerp(transform.position, newPos, Time.deltaTime * FollowSpeed);

        transform.position = result;
    }
}
