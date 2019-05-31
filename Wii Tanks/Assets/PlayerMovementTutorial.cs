using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTutorial : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    public BoxCollider2D weaponCollider;
    public Rigidbody2D playerBody;
    public Rigidbody2D bulletBody;
    public float movementSpeed;
    public Vector2 bulletSpeed;
    private int shootLoop = 0;
    public int fireRate = 50;
    Vector3 positionOfMouse;
    Quaternion rotationOfMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootLoop == fireRate) shootLoop = 0;
        else if (shootLoop > 0) shootLoop += 1;
        if (Input.GetKey("w"))
        {
            playerCollider.transform.position += new Vector3(0,movementSpeed);
        }
        if (Input.GetKey("s"))
        {
            playerCollider.transform.position += new Vector3(0, -movementSpeed);
        }
        if (Input.GetKey("a"))
        {
            playerCollider.transform.position += new Vector3(movementSpeed, 0);
        }
        if (Input.GetKey("d"))
        {
            playerCollider.transform.position += new Vector3(-movementSpeed,0);
        }
        if (Input.GetMouseButton(0) && shootLoop == 0)
        {
            positionOfMouse = Input.mousePosition;
            rotationOfMouse = new Quaternion(positionOfMouse.x, positionOfMouse.y, positionOfMouse.z, 0);
            Rigidbody2D bulletClone = Instantiate(bulletBody, playerCollider.transform.position, Quaternion.identity ) as Rigidbody2D;
            bulletBody.rotation = rotationOfMouse.x;
            bulletClone.AddForce(bulletSpeed);
            shootLoop = 1;
        }
       positionOfMouse = Input.mousePosition;
       print(positionOfMouse);
       weaponCollider.transform.Rotate(positionOfMouse.x,positionOfMouse.y,0);

    }
    
}
