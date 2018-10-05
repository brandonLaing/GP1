using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledMovement : MonoBehaviour {

  public float moveSpeed = 1.0f;      //Movement speed of the object in Unity units per second
  public float constrainDistance = 5.0f;
  public float minSpeed = 1.0f;
  public float maxSpeed = 5.0f;
  public float moveSpeedAdded = 0.1f;
  public float moveSpeedMultiplier = 1.1f;
  public Vector3 movementDirection = Vector3.zero;
  public Material[] material;
  public AudioClip[] superSaiyan;
  Renderer rend;
  private bool playClipOne = true;



  private float elapsedTime = 0.0f;
  private AudioSource source;


	// Use this for initialization
	void Start () {
    rend = GetComponent<Renderer>();
    rend.sharedMaterial = material[0];
    source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        // TODO:
        // Gives the ball a min and max speed //
        // Ball stops moving when key is held down
        // When key is released it moves the ball based on how long you held it down

        

        // move ball UP
        ///Have it so while the W key is pressed it doesn't move but add 0.1 to the move speed.
        ///This also checks if the move speed is over the max and if it is the move speed is set to 
        ///the max.
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 0);
            movementDirection = targetDirection;
            moveSpeed = (moveSpeed * moveSpeedMultiplier) + moveSpeedAdded;
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }

        ///Checks when W is let go it give the mover the target direction
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            movementDirection = targetDirection;
        }

    ///When W is pressed down it resets the speed
    if (Input.GetKeyDown(KeyCode.W))
        {
            moveSpeed = minSpeed;

    }


    // move ball DOWN
    ///Have it so while the S key is pressed it doesn't move but add 0.1 to the move speed.
    ///This also checks if the move speed is over the max and if it is the move speed is set to the max.
    if (Input.GetKey(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, 0);
            movementDirection = targetDirection;
            moveSpeed = (moveSpeed * moveSpeedMultiplier) + moveSpeedAdded;
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }

        }

        ///Checks when S is let go it give the mover the target direction
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            movementDirection = targetDirection;
        }
        
        ///When s is pressed down it resets the speed
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveSpeed = minSpeed;
        }

        // move ball LEFT
        ///Have it so while the A key is pressed it doesn't move but add 0.1 to the move speed.
        ///This also checks if the move speed is over the max and if it is the move speed is set to 
        ///the max.
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 targetDirection = new Vector3(0, 0, 0);
            movementDirection = targetDirection;
            moveSpeed = (moveSpeed * moveSpeedMultiplier) + moveSpeedAdded;
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }

        ///Checks when A is let go it give the mover the target direction
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Vector3 targetDirection = new Vector3(-1, 0, 0);
            movementDirection = targetDirection;
        }

        ///When A is pressed down it resets the speed
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveSpeed = minSpeed;
        }


        // move ball RIGHT
        ///Have it so while the D key is pressed it doesn't move but add 0.1 to the move speed.
        ///This also checks if the move speed is over the max and if it is the move speed is set to 
        ///the max.
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 targetDirection = new Vector3(0, 0, 0);
            movementDirection = targetDirection;
            moveSpeed = (moveSpeed * moveSpeedMultiplier) + moveSpeedAdded;
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }

        ///Checks when D is let go it give the mover the target direction
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Vector3 targetDirection = new Vector3(1, 0, 0);
            //transform.position = transform.position + targetDirection * Time.deltaTime * moveSpeed;
            movementDirection = targetDirection;
        }

        ///When D is pressed down it resets the speed
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveSpeed = minSpeed;
        }

        transform.position = transform.position + movementDirection.normalized * Time.deltaTime * this.moveSpeed;



        // Constrain to <constrainDistance> units in X and Z from the origin
        bool theCleanWay = false;
        if(theCleanWay)
        {
            Vector3 clampedPositon = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y, Mathf.Clamp(transform.position.z, -5, 5));
            transform.position = clampedPositon;
        }
        else
        {
            if (transform.position.x > constrainDistance)
            {
                transform.position = new Vector3(constrainDistance, transform.position.y, transform.position.z);
            }

            if(transform.position.x < - constrainDistance)
            {
                transform.position = new Vector3(-constrainDistance, transform.position.y, transform.position.z);
            }

            if (transform.position.z > constrainDistance)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, constrainDistance);
            }

            if (transform.position.z < -constrainDistance)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -constrainDistance);
            }


        }

        //this next part will be to go over changing the color of the ball
        //and playing audio tracks with their speed

    ///Start from high to low with if else statements

    if (moveSpeed > 9000)
    {
      rend.sharedMaterial = material[4];
      if (playClipOne)
      {
        if ( !source.isPlaying)
        {
          source.PlayOneShot(superSaiyan[5], 1F);
          playClipOne = false;
        }
      }
    }

    else if (moveSpeed > 6000)
    {
      rend.sharedMaterial = material[3];
      if (!source.isPlaying)
      {
        source.PlayOneShot(superSaiyan[4], 1f);
      }
    }

    else if (moveSpeed > 3500)
    {
      if (!source.isPlaying)
      {
        source.PlayOneShot(superSaiyan[3], 1f);
      }
    }

    else if (moveSpeed > 3000)
    {
      rend.sharedMaterial = material[2];
      if (!source.isPlaying)
      {
        source.PlayOneShot(superSaiyan[2], 1f);
      }
    }

    else if (moveSpeed > 1000)
    {
      if (!source.isPlaying)
      {
        source.PlayOneShot(superSaiyan[1], 1f);
      }
    }

    else if (moveSpeed > 100)
    {
      rend.sharedMaterial = material[1];
      if (!source.isPlaying)
      {
        source.PlayOneShot(superSaiyan[0], 1f);
      }
    }

    else if (moveSpeed < 20)
    {
      rend.sharedMaterial = material[0];
      playClipOne = true;
    }
  }
}
