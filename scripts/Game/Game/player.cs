using UnityEngine;

public class player : MonoBehaviour{
    private Camera _camera;
    public float Speed = 3.0f;
    public float Rotate = 100f;

    private Vector3 offset; //Private variable to store the offset distance between the player and camera

    void Start(){
        _camera = FindObjectOfType<Camera>();
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = _camera.transform.position - transform.position;
    }

    void Update(){
        Movement();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate(){
        UpdateCamera();
    }

    private void UpdateCamera(){
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        _camera.transform.position = transform.position + offset;
    }

    private void Movement(){
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        var y = Time.deltaTime * Speed;
        Vector3 movement = new Vector3(0, 0, x * -1);
        transform.Rotate(movement, Time.deltaTime * Speed * Rotate);
        transform.Translate(x, y, 0);
    }
}