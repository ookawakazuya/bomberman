using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// Õ“Ë‚µ‚½
    /// </summary>
    /// <param name="collision"></param>
    [SerializeField] private float speed = 30;
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider collider)
    {
		//Õ“Ë‚µ‚½‚Æ‚«‚É‘Šè‚ÉWallƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collider.gameObject.tag == "DestroyWall")
        {
			//5•bŒã‚ÉÁ‚¦‚é
            Destroy(gameObject,3.0f);
        }
    }
}
