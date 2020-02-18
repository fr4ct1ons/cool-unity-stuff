using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airgun : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject currentBullet;

    public bool isReloaded = true;

    [SerializeField]
    float force = 1.49f;
    public float cooldownToReload = 1f;
    public float cooldownToReloadCount;    

    BBBullet bb;

    Vector3 startPointBullet;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        ReloadGun();

        if (Input.GetButton("Fire1") && isReloaded)
        {
            Debug.Log("Shot!");
            isReloaded = false;
            Shot();
        }

        Debug.DrawLine(Vector3.zero, Vector3.right * 1);
    }

    void ReloadGun()
    {
        if (isReloaded == false)
        {
            cooldownToReloadCount += Time.deltaTime;

            if (cooldownToReloadCount >= cooldownToReload)
            {
                cooldownToReloadCount = 0;
                isReloaded = true;
            }
        }
    }

    public void Shot()
    {
        startPointBullet = this.transform.position;
        currentBullet = Instantiate<GameObject>(prefabBullet, this.startPointBullet, this.transform.rotation);
        bb = currentBullet.GetComponent<BBBullet>();
        bb.IsShooted(this.transform.right * force);
    }
}
