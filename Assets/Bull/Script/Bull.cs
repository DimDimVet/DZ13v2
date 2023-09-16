using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bull : MonoBehaviour
{
    [Inject] private IRegistrator dataReg;//получим данные управления в структуре
    public BullSettings BullSettings;

    [SerializeField] private GameObject decalGO;
    private int damage;
    private int speed;
    private Collider collaiderBullet;
    private Vector3 startPos;
    private int hashCod;

    private void Start()
    {
        damage = BullSettings.Damage;
        speed = BullSettings.Speed;
        collaiderBullet = gameObject.GetComponent<Collider>();

        transform.rotation = dataReg.OutPos.rotation;
        transform.position = dataReg.OutPos.position;
        startPos = transform.position;
        hashCod = gameObject.GetHashCode();

    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit hit;
        GameObject decal;
        if (Physics.Linecast(startPos, transform.position, out hit))
        {
            if (hashCod == hit.collider.gameObject.GetHashCode())
            {
                return;
            }
                Debug.Log(hit.collider.gameObject.name);
            

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

    public class Factory : PlaceholderFactory<Bull>
    {
    }
}
