using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
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
<<<<<<< HEAD
   
    public float damageEnemy;// the amount of damage the gun will do
=======
    [SerializeField]
    float damageEnemy = 30f;// the amount of damage the gun will do
<<<<<<< HEAD
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b

    
    public Transform shootPoint;// where the ray cast is going to go from on screen

<<<<<<< HEAD
 
   public int currentAmmo = 20;//ammo left in the gun
=======
    [SerializeField]
    int currentAmmo = 20;//ammo left in the gun
<<<<<<< HEAD
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b

    
    public int ClipSize;//the amount of ammo pere clip

  
   public int ClipsLeft = 8;//the amount of clips left to reload

    //Weapon effects
    public ParticleSystem muzzleFlash;

    
    public float rateOfFire;//rate of fire
    public float nextFire = 0;

    
<<<<<<< HEAD
<<<<<<< HEAD
    public float weaponRange;//how far the weapon can shoot
=======
  
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
  
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b

    // stuff for setting up the classes
    public FirstPersonController FPC;
    public MainMenu Menu;
    public PlayerHealth hp;
   
    bool setUp = true;

    //stamina bar
   public float stamina = 10;
    public float maxStamina = 10;
    public float Sprint;
     Rect staminaBar;
     Texture2D staminaTexture;
   

    void Start()
    {

        staminaBar = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white);
        staminaTexture.Apply();       

        setUp = true;
        SetAmmoText();
        SetClipText();
        muzzleFlash.Stop();//turns of the muzzleFlash
        SetKillsText();
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
    }

    void Update(){
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("running");
            stamina -= Time.deltaTime;
            if(stamina < 0)
            {
                stamina = 0;
                FPC.m_RunSpeed = FPC.m_WalkSpeed;
               
            }
        }
        if (stamina < maxStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            FPC.m_RunSpeed = Sprint;
        }

        if (MainMenu.heavy == true && setUp == true)
        {
            
            FPC.m_WalkSpeed = 4;
            FPC.m_RunSpeed = 6;
            FPC.m_JumpSpeed = 6;
            hp.health = 200;
            damageEnemy = 10;
            rateOfFire = 0.05f;
            ClipsLeft = ClipsLeft + 25;
            currentAmmo = currentAmmo + 40;
            ClipSize = 60;
            SetAmmoText();
            SetClipText();
            SetKillsText();
            hp.SetHealthText();
            stamina = 5;
            maxStamina = 5;
            Sprint = FPC.m_RunSpeed;
            setUp = false;
        }
       else if (MainMenu.balance == true && setUp == true)
        {
            FPC.m_WalkSpeed = 8;
            FPC.m_RunSpeed = 11;
            FPC.m_JumpSpeed = 8;
            hp.health = 150;
            damageEnemy = 50;
            rateOfFire = 0.2f;
            ClipsLeft = ClipsLeft + 15;
            currentAmmo = 20 ;
            ClipSize = 20;
            SetAmmoText();
            SetClipText();
            SetKillsText();
            hp.SetHealthText();
            stamina = 7.5f;
            maxStamina = 7.5f;
            Sprint = FPC.m_RunSpeed;
            setUp = false;
        }
        else if (MainMenu.fast == true && setUp == true)
        {
            FPC.m_WalkSpeed = 10;
            FPC.m_RunSpeed = 15;
            FPC.m_JumpSpeed = 10;
            hp.health = 100;
            weaponRange = 30;
            damageEnemy = 100;
            rateOfFire = 0.6f;
            ClipsLeft = ClipsLeft + 25;
            currentAmmo = currentAmmo  - 10;
            ClipSize = 10;
            SetAmmoText();
            SetClipText();
            SetKillsText();
            hp.SetHealthText();
            stamina = 10;
            maxStamina = 10;
            Sprint = FPC.m_RunSpeed;
            setUp = false;
        }


      
       
        if (kills == 50 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// goes to the next scene
        }
        
        if (moreAmmo == 0)
        {
            ClipsLeft = ClipsLeft + 30;
            moreAmmo = 50;
        }

        if (moreAmmo == 0)
        {
            ClipsLeft = ClipsLeft + 15;
            moreAmmo = 50;
        }

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
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetButton("Reload") && currentAmmo < ClipSize && ClipsLeft > 0){
=======
        if (Input.GetButton("Reload") && currentAmmo < 20 && ClipsLeft > 0){
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
        if (Input.GetButton("Reload") && currentAmmo < 20 && ClipsLeft > 0){
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
            ClipsLeft = ClipsLeft - 1;//subtracts one clip from ClipsLeft
            SetClipText();
            
            // if the number of ClipsLeft is greater than or equal to zero
            if (ClipsLeft >= 0){
                currentAmmo = ClipSize;//reloads the gun
                Debug.Log("reload");
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
<<<<<<< HEAD
<<<<<<< HEAD
                    if(enemyHealthScript.enemyHealth <= 0){
=======
                    if(enemyHealthScript.enemyHealth < 0){
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
                    if(enemyHealthScript.enemyHealth < 0){
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
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

<<<<<<< HEAD
<<<<<<< HEAD
    private void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaBar.width = rectWidth;
        GUI.DrawTexture(staminaBar, staminaTexture);
    }
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
=======
>>>>>>> 739f643bd71e054994b0f7923c14028e64d1748b
}


    
