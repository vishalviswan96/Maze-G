using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScale : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        ResizeSpriteToScreen();
    }

    void ResizeSpriteToScreen()
    {
        sr = GetComponent<SpriteRenderer>();
        {
            if (sr == null) return;
        }

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = (float)(Camera.main.orthographicSize * 2.0);
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3((float)(worldScreenWidth / width), (float)(worldScreenHeight / height), 0);

    }
}