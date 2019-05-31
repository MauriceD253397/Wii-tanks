using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    public Rigidbody2D playerBarrel;
    public Rigidbody2D playerBody;
    public float speed;
    private Vector2 bulletForce;
    private Vector2 forceA;
    private Vector2 forceS;
    private Vector2 forceD;
    public Rigidbody2D bullet;
    private Rigidbody2D cloneRb;
    private bool moveBullet;
 
    // Start is called before the first frame update
    void Start()
    {   
        bulletForce = new Vector2(speed *= 2,0);

        //bullet.GetComponent<>
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {

            if (playerCollider.transform.rotation.z <= 0.70 || playerCollider.transform.rotation.z <= -0.90)
            {
               // print(playerCollider.transform.rotation.z);
                playerCollider.transform.Rotate(0, 0, 1);
            }
            else
            {
                playerCollider.transform.position += Vector3.up / 5;
            }
            
            //print("W was pressed");
        }
        if (Input.GetKey("a"))
        {
            playerCollider.transform.position += Vector3.left / 5;
            // rigidbody2D.position = new Vector2(-1, 0);
            //   rigidbody2D.AddForce(forceA);
        }
        if (Input.GetKey("s"))
        {
            if (playerCollider.transform.rotation.z <= 0.75)
            {
              //  print(playerCollider.transform.rotation.z);
                playerCollider.transform.Rotate(0, 0, -1);
            }
            else
            {
                playerCollider.transform.position += Vector3.down / 5;
            }
            
            
            // rigidbody2D.position = new Vector2(0, -1);
            //   rigidbody2D.AddForce(forceS);
        }
        if (Input.GetKey("d"))
        {
            playerCollider  .transform.position += Vector3.right / 5;
            // rigidbody2D.position = new Vector2(1, 0);
            //rigidbody2D.AddForce(forceD);
        }
        if (Input.GetKeyDown("q"))
        {
            Rigidbody2D cloneRb = Instantiate(bullet, playerBarrel.transform.position, Quaternion.identity) as Rigidbody2D;
            cloneRb.rotation = Input.mousePosition.x;
            cloneRb.AddForce(bulletForce);

            //cloneRb.AddForce(playerCollider.transform.forward * 25);
            //playerBody.AddForce(playerCollider.transform.forward * bulletSpeed);
            // rigidbody2D.position = new Vector2(1, 0);
            //rigidbody2D.AddForce(forceD);
            
        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        print(col.gameObject);
        if (col.gameObject.tag == "Barricade")
        {
            print(col.gameObject.tag);
            Destroy(col.gameObject);
        }
    }


}
