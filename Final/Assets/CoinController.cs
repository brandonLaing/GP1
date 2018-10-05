using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
  public float coinSpeed = 5;

  public IEnumerator CoinPickedUp()
  {

    while (coinSpeed < 50)
    {
      coinSpeed += 1;

      yield return new WaitForSeconds(.5F);

      yield return null;

    }

    Destroy(this.gameObject);

  }

  public IEnumerator RotateCoin()
  {
    while (true)
    {
      transform.Rotate(0, coinSpeed, 0);
      transform.position += new Vector3(0, Random.Range(-.01F, .01F), 0);


      yield return null;

    }
  }
}
