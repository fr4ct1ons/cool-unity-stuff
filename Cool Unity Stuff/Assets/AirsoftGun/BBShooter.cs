using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBShooter : MonoBehaviour
{
    [SerializeField] GameObject gunTip, projectile, weaponAxis;
    [SerializeField] float force = 1.49f;
    float cameraSens = 1f;
    Camera fpsCamera;

    private void Start()
    {
        fpsCamera = Camera.main;
        weaponAxis = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fpsCamera.gameObject.SetActive(true);
        //tpsCamera.gameObject.SetActive(false);

        //tpsCamera.tag = "Untagged";
        fpsCamera.tag = "MainCamera";
        
        {
            fpsCamera.transform.position = transform.position;
            transform.Rotate(0, Input.GetAxis("Mouse X") * cameraSens, 0);;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(projectile, gunTip.transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(gunTip.transform.forward * force);
            Destroy(newProjectile, 5f);
        }
    }
}
