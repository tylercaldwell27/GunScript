using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShot : MonoBehaviour
{

    //text
    public Text ammoText;
    public Text clipText;
    public Text killText;
    //audio Sounds For the players
    public AudioSource gunfire;
    public AudioSource hitSoundEffect;

    RaycastHit hit;//sets a rayCast to hit

    public int moreAmmo = 50;
    public float kills = 0;

    //this is for damaging the enemy
    [SerializeField]
    float damageEnemy = 30f;// the amount of damage the gun will do

    [SerializeField]
    Transform shootPoint;// where the ray cast is going to go from on screen

    [SerializeField]
    int currentAmmo = 20;//ammo left in the gun

    [SerializeField]
    int ClipSize;//the amount of ammo pere clip

    [SerializeField]
    int ClipsLeft = 8;//the amount of clips left to reload

    //Weapon effects
    public ParticleSystem muzzleFlash;

    [SerializeField]
    float rateOfFire;//rate of fire
    float nextFire = 0;

    [SerializeField]
    float weaponRange;//how far the weapon can shoot

    
  



    void Start()
    {
        SetAmmoText();
        SetClipText();
        muzzleFlash.Stop();//turns of the muzzleFlash
        SetKillsText();
    }

    void Update(){

        if (moreAmmo == 0)
        {
            ClipsLeft = ClipsLeft + 15;
            moreAmmo = 50;
        }

        //if the left mouse button is pressed and the gun has ammo in it
        if (Input.GetButton("Fire1") && currentAmmo > 0){
            Shoot();//shoots the gun
            if (currentAmmo == 0)
            {// if the gun is out of ammo

            }
        }
        //if the r key is pressed and theres less then 12 bullets in the gun and the player still has more clips for reloading
        if (Input.GetButton("Reload") && currentAmmo < 20 && ClipsLeft > 0){
            ClipsLeft = ClipsLeft - 1;//subtracts one clip from ClipsLeft
            SetClipText();
            
            // if the number of ClipsLeft is greater than or equal to zero
            if (ClipsLeft >= 0){
                currentAmmo = ClipSize;//reloads the gun
                SetAmmoText();
            }

            //if the number of ClipsLeft is less than zero
            else if (ClipsLeft < 0){
                Debug.Log("out of ammo");
            }

           
            
        }


    }
    //when the shoot gun methood is called
    void Shoot()
    {
        //if Time is greater than nextFire
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;// sets next fire equal to the time and rate of fire
            currentAmmo--;//and uses one ammo
            GunFire();// calls the GunFire method
            StartCoroutine(WeaponEffects());// calls the StartCoroutine method
            SetAmmoText();

            //checking for what the ray cast hits
            //if  the position of the ray cast has hit somthing and that it is still in the weapon range
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
            {
                //if the object hit was the enemy
                if (hit.transform.tag == "Enemy")
                {
                    HitSound();
                    Debug.Log("hit enemy");//prints to debug log that enemy was hit
                    EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();//sets the enemy health script the remaining health from the enemyhealth var
                    enemyHealthScript.DeductHealth(damageEnemy);//calls the deductHealth methood for class  the enemy health script to deduct the health
                    if(enemyHealthScript.enemyHealth < 0){
                         kills = kills + 1;
                        moreAmmo = moreAmmo - 1;// how many kills till you get more ammo
                        SetKillsText();
                       
                    }
                }
                else
                {
                    Debug.Log("hit Something Else");//prints to the de bug log saying somthing else was hit
                }
            }
        }
    }

    //GunFire sound  method
    public void GunFire()
    {
        gunfire.Play();// plays the gun fire sound effect
    }

    public void HitSound()
    {
        hitSoundEffect.Play();// plays the gun fire sound effect
    }

    // for usign weapon effects
    IEnumerator WeaponEffects()
    {
        muzzleFlash.Play();// plays the muzzleFlash
        yield return new WaitForEndOfFrame();//wait for the frame to end
        muzzleFlash.Stop();// stops playing the muzzleFlash
    }

    void SetAmmoText()
    {
       ammoText.text = "Ammo " + currentAmmo.ToString();
    }

    void SetClipText()
    {
        clipText.text = "Clips Left: " + ClipsLeft.ToString();
    }

    void SetKillsText(){
        killText.text = "Kills: " + kills.ToString();
    }

}
