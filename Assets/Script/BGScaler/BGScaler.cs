using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Scale BG tương ứng với kích thước Screen
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
    }

  
}
