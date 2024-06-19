using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float shotSpeed;
    [SerializeField] private float fireRate;
    private float nextShotTime;

    private Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponentInParent<Animator>();
        nextShotTime = 0;
    }

    public void Shoot()
    {
        if(Time.time >= nextShotTime) {
            GameObject shot = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D shotRb = shot.GetComponent<Rigidbody2D>();

            if (playerTransform.localScale.x == 1)
                shotRb.velocity = new Vector2(shotSpeed * 1, shotRb.velocity.y);
            else
                shotRb.velocity = new Vector2(shotSpeed * -1, shotRb.velocity.y);

            Destroy(shot.gameObject, 1f);

            nextShotTime = Time.time + fireRate;
        }
    }

    public void SetShootingAnimation(bool isShooting)
    {
        playerAnim.SetBool("isShooting", isShooting);
    }
}