using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public GameObject ultimatePrefab;

    void Start()
    {
        Invoke("Ult", 3f);
    }

    private void Ult()
    {
        Instantiate(ultimatePrefab, transform.position, Quaternion.identity);
        StartCoroutine(CreateUltimate(Vector3.right));
        //Destroy(gameObject, 0.3f);
    }

    private IEnumerator CreateUltimate(Vector3 direction)
    {
        for (int i = 1; i < 20;  i++)
        {
            Instantiate
                (
                ultimatePrefab,
                transform.position + (i * direction),
                ultimatePrefab.transform.rotation
                );
            Debug.Log($"{i}");
            // 0.2 •b‘Ò‚Á‚Ä‚©‚çAŽŸ‚Ìƒ}ƒX‚É”š•—‚ðL‚°‚é
            yield return new WaitForSeconds(0.2f);

            if(i == 9)
            {
                Destroy(gameObject);
            }
        }

    }

    void Update()
    {

    }
}
