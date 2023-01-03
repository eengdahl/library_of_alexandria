using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PingPingUI : MonoBehaviour
{
    RectTransform startPosition;
    RectTransform thisRectTransform;
    [SerializeField] float speed;
    [SerializeField] float distance;
    // Start is called before the first frame update
    void Start()
    {
        thisRectTransform = GetComponent<RectTransform>();
        startPosition = thisRectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        float size = Mathf.PingPong(Time.time * speed, 1) * distance;
        thisRectTransform.localScale = startPosition.localScale + new Vector3(size, size,0);
    }
}
