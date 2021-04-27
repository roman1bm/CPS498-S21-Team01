using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform player;

    public float height = 1f;
    public float distance = 2f;

    private Vector3 offsetX;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        offsetX = new Vector3(0, height, distance);
    }

    void LateUpdate()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
        Vector3 pos = transform.position;

        pos.y += 2f;
        transform.position = pos;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0)), Time.deltaTime * 5);
    }
}