using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStation : MonoBehaviour
{
  public GameObject pickupPrefab;
  public Transform pickupLocation;

  public float bounceSpeed;
  public float bounceDistance;

  public float rotationSpeed;

  public float pickupTimer;
  public bool startWithPickup;

  private bool direction = true;
  private GameObject currentPickup;
  private float pickupCooldownTimer;

  private void Awake()
  {
    #region Pickup Initilization
    if (startWithPickup)
    {
      currentPickup = Instantiate(pickupPrefab, pickupLocation.transform.position, pickupLocation.transform.rotation);
      currentPickup.GetComponent<SendInfoToStation>().station = gameObject;
    }
    else
    {
      currentPickup = null;
      pickupCooldownTimer = Time.time + pickupTimer;

    }

    #endregion

  } // end awake

  private void Update()
  {
    if (currentPickup == null && pickupCooldownTimer <= Time.time)
    {
      currentPickup = Instantiate(pickupPrefab, pickupLocation.transform.position, pickupLocation.transform.rotation);
      currentPickup.GetComponent<SendInfoToStation>().station = gameObject;

    }

    if (currentPickup != null)
    {
      #region Bounce
      if (direction)
      {
        currentPickup.transform.position += new Vector3(0, bounceSpeed, 0) * Time.deltaTime;

      }
      else
      {
        currentPickup.transform.position -= new Vector3(0, bounceSpeed, 0) * Time.deltaTime;

      }


      if (currentPickup.transform.position.y > (pickupLocation.position.y + bounceDistance) || currentPickup.transform.position.y < (pickupLocation.position.y - bounceDistance))
      {
        direction = !direction;

      }


      #endregion

      #region Rotation
      currentPickup.transform.Rotate(0, rotationSpeed, 0);

      #endregion

    }

  } // end Update

  public void SetPickupCooldowntimer(float newTime)
  {
    pickupCooldownTimer = newTime;

  }

}
