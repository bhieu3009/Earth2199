using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;//bullet shoot
    [SerializeField] private float shotDelay = 0.15f; //Speed of bullet
    private float nextShot; //tính toán lần bắn tiếp theo
    [SerializeField] private int maxAmmo = 24; //maxium bullet have to shoot
    [SerializeField] private TextMeshProUGUI ammoText;
    public int currentAmmo;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }
    void RotateGun()
    {   //Check mouse in screen if not in screen do nothing 
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Lật khẩu súng 
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        //Góc lật súng <-90
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
            audioManager.PlayShootSound();

        }
    }
    void Reload()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
            audioManager.PlayReLoadSound();

        }
    }
    private void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            if (currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Empty";
            }
        }
    }
}
