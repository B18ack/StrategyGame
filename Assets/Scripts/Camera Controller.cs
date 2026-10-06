using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 10f, zoomsSpeed = 3000000000000f;
    

    private float _mult = 1f;
    private float _smoth = 1f;

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1f;

        _mult =Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        _smoth = Input.GetKey(KeyCode.LeftShift) ? Time.deltaTime * 35 : Time.deltaTime * 20;

        transform.position += transform.up * _smoth * zoomsSpeed * Input.mouseScrollDelta.y;

        transform.position = new Vector3(

            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 30f),
            transform.position.z);
    }
}
