using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableLogo : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    public float WaitTime = 1;
    float OffsetX = 0;

    SpriteRenderer ren;
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        //StartCoroutine(Scroll());

    }

    private void Update()
    {
        float offset = Time.time * ScrollSpeed;
        ren.material.mainTextureOffset = new Vector2(offset, 0);
    }

    IEnumerator Scroll()
    {
        print("Start scroll");

        while (OffsetX <= 1)
        {
            print("Scroll");
            OffsetX += Time.deltaTime * ScrollSpeed;
            yield return new WaitForEndOfFrame();

            ren.material.mainTextureOffset = new Vector2(OffsetX, 0);
        }
        
        yield return new WaitForSeconds(WaitTime);
        OffsetX = 0;
        //StartCoroutine(Scroll());

    }


}
