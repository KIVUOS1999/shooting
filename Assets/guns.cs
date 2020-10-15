using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class guns : MonoBehaviour
{
    public LayerMask whometoactive;
    public static bool is_picked = false;public bool aim_down_sight = false;
    public float rad, range;
    public GameObject canvas, cam;
    public Transform Gungrab, shooting_area;
    public ParticleSystem gun_flash;
    public GameObject bullet_effect;
    public float damage_amount = 10f;
    // Update is called once per frame

    
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        bool someonenear = Physics.CheckSphere(transform.position, rad, whometoactive);
        
        if (someonenear)
        {
            /*if(is_picked == false)
                canvas.SetActive(true);

	     else
		{
                canvas.SetActive(false);
            }*/

            if (Input.GetKeyDown(KeyCode.F) && is_picked == false)
            {
                is_picked = true;
                Grab();
            }
        }
        /*else
        {
            canvas.SetActive(false);
        }*/

        if (Input.GetMouseButtonDown(0) && is_picked ==true)
        {
            shoot();
            gun_flash.Play();
        }

        if (is_picked && someonenear)
        {
            Grab();
        }        
    }

    public void Grab()
    {
        transform.position = Gungrab.position;
        transform.rotation = cam.transform.rotation;
    }


    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //health health = hit.transform.GetComponent<health>();
            //if (health != null)
            //{
            //    health.damage(damage_amount);
            //}            
            GameObject b = Instantiate(bullet_effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(b, .1f);
        }
    }
}
