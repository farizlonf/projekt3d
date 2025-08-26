using UnityEngine;

public class ShotGunFunction : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed;

    Transform CameraTransform;

    Transform ShotGunTipTransform;

    [SerializeField] GameObject Projectile;

    CharacterController PlayerControl;

    Vector3 KnockbackVelocity;

    [SerializeField] float RecoilStrength;

    [SerializeField] float KnockbackDeceleration;

    void Start()
    {

        CameraTransform = GameObject.Find("FPS Cam").GetComponent<Transform>();

        ShotGunTipTransform = GameObject.Find("ShotGunTip").GetComponent<Transform>();

        PlayerControl = GameObject.Find("PlayerMesh").GetComponent<CharacterController>();

    }

    void Update()
    {
        Vector3 ShootDirection = CameraTransform.forward;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject projektil = Instantiate(Projectile, ShotGunTipTransform.position, Quaternion.LookRotation(CameraTransform.forward));

            projektil.GetComponent<Rigidbody>().linearVelocity = ShootDirection * ProjectileSpeed;

            KnockbackVelocity = -CameraTransform.forward * RecoilStrength;

            KnockbackVelocity.y = 0;

            PlayerControl.Move(KnockbackVelocity);

           

            
        }

       
    }
    
}
