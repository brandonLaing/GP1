using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInfoToStation : MonoBehaviour
{
  public GameObject station;

  public void SendMessage()
  {
    station.GetComponent<PickupStation>().SetPickupCooldowntimer((Time.time + station.GetComponent<PickupStation>().pickupTimer));

    Destroy(gameObject);

  }
}
