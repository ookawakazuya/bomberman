using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// Õ“Ë‚µ‚½
    /// </summary>
    /// <param name="collision"></param>

    public GameObject effectPrefab;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Õ“Ë‚µ‚½‚Æ‚«‚É‘Šè‚ÉWallƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (other.CompareTag("Explosion"))
        {
            //1•bŒã‚ÉÁ–Å
            Destroy(gameObject);
            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            //Destroy(effect, 0.5f);
        }
    }
}
