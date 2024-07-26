using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float speed = 20;
    public float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool IsOnGround = true;
    public Vector2 turn;
    public GameObject projectilePrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public ParticleSystem explosionParticle;






    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Launch a projectile from the player
            var bullet = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }





        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            playerRb.AddForce(Vector3.up * 500, ForceMode.Impulse);
            IsOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = true;  
    }


    
     
        
    
    
    
       
       

    
    
        
    

}
