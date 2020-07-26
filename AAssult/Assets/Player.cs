using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float speedx = 4f;
    [Tooltip("In m")] [SerializeField] float xrange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float offsetx = xthrow * speedx * Time.deltaTime;
        float rawoffsetx = transform.localPosition.x + offsetx;
        float clamppos = Mathf.Clamp(rawoffsetx, -xrange,xrange);
        transform.localPosition = new Vector3(clamppos, transform.localPosition.y, transform.localPosition.z);
    }
}
