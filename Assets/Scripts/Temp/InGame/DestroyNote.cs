using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
  
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Entered");

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (collision.transform.tag == "lHit")
            {
                collision.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (collision.transform.tag == "rHit")
            {
                collision.gameObject.SetActive(false);
            }
        }
        
       
    }
}
