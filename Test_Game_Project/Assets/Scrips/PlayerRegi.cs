using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRegi : MonoBehaviour
{
    public float speed = 1f;
    public float rotspeed = 1f;
    Rigidbody rb;
    float newrot = 0;
    public GameObject prefabbullet;
    public Transform GunPosition;
    public float gunPower = 15f;
    public float guncooldown = 2f;
    public float guncooldownCount = 0;
    public bool hasGun = false;
    public float hol;
    public float ver;
    public int bulletcount = 0;

    public int coincount = 0;
    PlaygroundSceneManager manager;
    public AudioSource audioCoin;
    public AudioSource audioGun;
    public AudioSource audioFire;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<PlaygroundSceneManager>();
        if (manager == null)
        {
            print("manager not found!");
        }

        if (PlayerPrefs.HasKey("coincount"))
        {
            coincount = PlayerPrefs.GetInt("coincount");
        }
        manager.setTextCoin(coincount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed, ForceMode.VelocityChange);
            newrot = -90;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed, ForceMode.VelocityChange);
            newrot = 90;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(+speed, 0, 0, ForceMode.VelocityChange);
            newrot = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed, 0, 0, ForceMode.VelocityChange);
            newrot = 180;
        }
        
        /*float horizontal = Input.GetAxis("Horizontal")*speed;
        float vertical = Input.GetAxis("Vertical")*speed;
        hol = horizontal;
        ver = vertical;
        if (horizontal > 0)
        {
            newrot = -90;
        }
        else if(horizontal<0)
        {
            newrot = 90;
        }
        if (vertical > 0)
        {
            newrot = 0;
        }
        else if (vertical < 0)
        {
            newrot = 180;
        }


        rb.AddForce(vertical, 0, horizontal, ForceMode.VelocityChange);*/
        rb.AddForce(0, 0, 0, ForceMode.VelocityChange);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newrot, 0), transform.rotation, rotspeed * Time.deltaTime);
    }

    private void Update()
    {
        guncooldownCount += Time.deltaTime;
        if (Input.GetButtonDown("Fire1")&&bulletcount>0&&guncooldownCount>=guncooldown)
        {
            guncooldownCount = 0;
            GameObject bullet= Instantiate(prefabbullet, GunPosition.position, GunPosition.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
            Rigidbody brb = bullet.GetComponent<Rigidbody>();
            brb.AddForce(transform.forward * gunPower, ForceMode.Impulse);

            Destroy(bullet, 2f);

            bulletcount--;
            manager.SetTextBullet(bulletcount);
            audioFire.Play();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "collectable")
        { Destroy(collision.gameObject); }
        if (collision.gameObject.tag == "Gun1")
        {
            print("Yea!!");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.tag == "collectable")
        { Destroy(other.gameObject);
          coincount++;
          manager.setTextCoin(coincount);
          audioCoin.Play();
        }

        if (other.gameObject.tag == "Gun1")
        {
            Destroy(other.gameObject);
            hasGun = true;
            bulletcount+=10;
            manager.SetTextBullet(bulletcount);
            audioGun.Play();
            PlayerPrefs.SetInt("bulletcount", bulletcount);
        }
    }
}
