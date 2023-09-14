using System.Collections;
using UnityEngine;
using Zenject;

public class ShootPlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные в структуре
    //
    public ActionSettings ActionSettings;
    //
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform outBullet;

    [SerializeField] private ParticleSystem gunExitParticle;//система частиц

    //соберем в лист стороние скрипты

    private float shootDelay;
    private float shootTime = float.MinValue;

    private void Start()
    {
        shootDelay=ActionSettings.ShootDelay;
        StartCoroutine(Example());
    }

    void Update()
    {
        if (userInput.InputData.Shoot != 0)//получим нажатие
        {
            Shoot();
        }
    }
    private IEnumerator Example()
    {
        int i = 0;
        while (i < 3)
        {
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }

    public void Shoot()
    {
        if (Time.time < shootTime + shootDelay)
        {
            return;
        }
        else
        {
            shootTime = Time.time;
        }

        Instantiate(bullet, outBullet.position, outBullet.rotation);
        gunExitParticle.Play();

    }
}
