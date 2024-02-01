using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public GameObject ultimatePrefab;
    private void Ult()
    {
        Instantiate(ultimatePrefab, transform.position, Quaternion.identity);
        StartCoroutine(CreateUltimate(Vector3.right));
        Destroy(gameObject, 0.3f);
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

            // 0.5 •b‘Ò‚Á‚Ä‚©‚çAŽŸ‚Ìƒ}ƒX‚É”š•—‚ðL‚°‚é
            yield return new WaitForSeconds(0.5f);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
