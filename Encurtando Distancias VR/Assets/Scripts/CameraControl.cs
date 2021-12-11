using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool W = Input.GetKey(KeyCode.W);
        bool A = Input.GetKey(KeyCode.A);
        bool S = Input.GetKey(KeyCode.S);
        bool D = Input.GetKey(KeyCode.D);

        if (W)
            camera.transform.Rotate(Vector3.left, 50.0f * Time.deltaTime);
        if (A)
            camera.transform.Rotate(Vector3.down, 50.0f * Time.deltaTime);
        if (S)
            camera.transform.Rotate(Vector3.right, 50.0f * Time.deltaTime);
        if (D)
            camera.transform.Rotate(Vector3.up, 50.0f * Time.deltaTime);

    }
}