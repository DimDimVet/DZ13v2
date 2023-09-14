using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public BullSettings BullSettings;

    [SerializeField] private GameObject decalGO;

    private int damage;
    private int speed;
    private Collider collaiderBullet;
    private Vector3 startPos;
    private void Start()
    {
        damage=BullSettings.Damage;
        speed=BullSettings.Speed;
        collaiderBullet =gameObject.GetComponent<Collider>();
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit hit;
        GameObject decal;
        if (Physics.Linecast(startPos, transform.position, out hit))
        {
                collaiderBullet.enabled = false;
                decal = Instantiate(decalGO);
                decal.transform.position = hit.point + hit.normal * 0.001f;
                decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
                Destroy(decal, 1);

                Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5);
        }
        startPos = transform.position;
    }
}
