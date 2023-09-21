using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI win,Lose;
    public TMPro.TextMeshProUGUI scoreText; 
    public TMPro.TextMeshProUGUI viewpointsText;
    public AudioSource SoundBoat,SoundBoatSpeed;

   // public Button button; // Reference to the Button component
    public GameObject button;


    [Header("References")]
    public Rigidbody rb;
    //public Transform head;
    public Transform boat;
    public Transform flag;
    public Transform Terrain;






    [Header("References")]
    public float walkSpeed;
    public float runSpeed;
    public int  health;
    public int MaxHealth=5;
    public int Point;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        SoundBoat.Stop();
        SoundBoatSpeed.Stop();
        health=MaxHealth;
        Point=0;
        walkSpeed=40;
        runSpeed=60;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 cameraRotation = Vector3.zero;
    float speed;
    void FixedUpdate(){
        
         
        if (health <=0)
                    {
                        speed=0;            
                        Lose.text ="Lose"; 
                        Invoke("replay", 4f);


                    }
        else
         {speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;}
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            SoundBoatSpeed.Play();
            SoundBoat.Stop();

        }
        else
        {
            SoundBoatSpeed.Stop();
            SoundBoat.Play();
        }
        cameraRotation.y = Input.GetAxis("Horizontal")* speed/14;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90, 90);
        rb.transform.Rotate(cameraRotation);


        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        //newVelocity.x =Input.GetAxis("Vertical")* speed;
        newVelocity.z =Input.GetAxis("Vertical")* speed;
        rb.velocity = transform.TransformDirection(newVelocity);
        distance = Vector3.Distance(rb.position, flag.position);
        if (distance<12.0f && Point>4)
        {
            walkSpeed=0;
            runSpeed=0;            
            win.text ="win"; 
            Invoke("replay", 4f);



        }
       
       



       

    }




    

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si la collision a eu lieu avec le terrain
        if (collision.gameObject.CompareTag("Terrain"))
        {
            // Pénalisez le joueur ici, par exemple, en désactivant le script de contrôle du bateau
            if (health > 0)
            {
                health--;UpdateUI();
            }
            // Vous pouvez également ajouter d'autres actions de pénalisation, comme réduire la vitesse, afficher un message, etc.
        }


         if (collision.gameObject.CompareTag("Poisson"))
        {
            Point++;UpdateUI();
            Destroy(collision.gameObject);
        }
        

    }
    void UpdateUI()
        {
            scoreText.text = "Score: " + Point.ToString()+"/5";
            viewpointsText.text = "View Points: " + health.ToString()+"/"+MaxHealth.ToString();
        }
    void hideUI()
    {
        scoreText.text ="";
        viewpointsText.text ="";
        win.text =""; 
        Lose.text ="";
    }
    public void StartGame()
    {
        boat.position = new Vector3(457.89f, 7.7f, 44.42f);
        boat.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        health=MaxHealth;
        Point=0;
        walkSpeed=40;
        runSpeed=60;
        scoreText.text = "Score: " + Point.ToString()+"/5";
        viewpointsText.text = "View Points: " + health.ToString()+"/"+MaxHealth.ToString();
        button.SetActive(false);
        SoundBoat.Play();


    }
    public void replay()
    {
        hideUI();
        button.SetActive(true);
    }
   

    
}
