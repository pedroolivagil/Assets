﻿using UnityEngine;

public class player : Photon.MonoBehaviour{
    private Camera _camera;
    public float Speed = 3.0f;
    public float Rotate = 100f;
    public float ZoomCamera = -15f;

    void Start(){
        _camera = FindObjectOfType<Camera>();
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    void Update(){
        Movement();
        Shoot();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate(){
        UpdateCamera();
    }

    private void UpdateCamera(){
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, ZoomCamera);
    }

    private void Movement(){
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        var y = Time.deltaTime * Speed;
        Vector3 movement = new Vector3(0, 0, x * -1);
        transform.Rotate(movement, Time.deltaTime * Speed * Rotate);
        transform.Translate(x, y, 0);
    }

    private void Shoot(){
        if (Input.GetButtonDown("Jump")){
            PhotonNetwork.Instantiate("Actors/Ammo", transform.position, transform.rotation, 0);
        }
    }
}