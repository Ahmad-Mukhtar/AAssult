using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
   
    [Tooltip("In ms^-1")][SerializeField] float speedx = 70f;
    [Tooltip("In ms^-1")] [SerializeField] float speedy = 70f;
    [Tooltip("In m")] [SerializeField] float xrange = 30f;
    [Tooltip("In m")] [SerializeField] float yrange = 25f;

    [SerializeField] float positionpitchfactor = -1.2f;
    [SerializeField] float controlpitchfactor = -1.2f;
    [SerializeField] float positionyawfactor = 0.5f;
    [SerializeField] float positionrollfactor = -10f;

    float xthrow;
    float ythrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playermovement();
        playerRotation();

    }

    void playerRotation()
    {
        float poscal = transform.localPosition.y * positionpitchfactor;
        float ycal=ythrow* controlpitchfactor;
        float pitch = poscal + ycal;
        float yaw = transform.localPosition.x * positionyawfactor;
        float roll = xthrow * positionrollfactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void playermovement()
    {

            xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
            float offsetx = xthrow * speedx * Time.deltaTime;
            float rawoffsetx = transform.localPosition.x + offsetx;
            float clampposx = Mathf.Clamp(rawoffsetx, -xrange, xrange);
            ythrow = CrossPlatformInputManager.GetAxis("Vertical");
            float offsety = ythrow * speedy * Time.deltaTime;
            float rawoffsety = transform.localPosition.y + offsety;
            float clampposy = Mathf.Clamp(rawoffsety, -yrange, yrange);
            transform.localPosition = new Vector3(clampposx, clampposy, transform.localPosition.z);
        }

}
