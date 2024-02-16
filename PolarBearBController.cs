using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarBearBController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    private AudioSource audioSource;
    public AudioClip sealSFX;
    public AudioClip oilSFX;
    public GameObject sealBubble;
    public GameObject oilBubble;
    private float sealBubbleTimer;
    private float oilBubbleTimer;
    public static int energy;
    public static bool TouchedOil;

    // Reference to the sprites you want to use
    public Sprite pb2_swim_L, pb2_swim_R, pb2_walk_L, pb2_walk_R;
    public Sprite pb2_swim_oil_L, pb2_swim_oil_R, pb2_walk_oil_L, pb2_walk_oil_R;
    public Sprite pb2_walk_seal_L, pb2_walk_seal_R;
    public Sprite pb2_walk_oil_seal_L, pb2_walk_oil_seal_R;
    public bool EatingSeal;
    public int SpriteLR; //0=L,1=R
    public static int OnIceWater;//0=Ice,1=Water,2=HomeIce


    float speed;

    public GameObject ice;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        audioSource = GetComponent<AudioSource>();
        energy = 10;
        //InvokeRepeating("Reduceenergy", 18f, 18f);
        speed = Parameter.speedFactor;
        StartCoroutine(ReduceEnergy());
        TouchedOil = false;
        EatingSeal = false;
        SpriteLR = 0;
        OnIceWater = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = this.transform.position;

        UpdateSprite();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpriteLR = 0;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.transform.Rotate(0, 0, 5f * speed);
                this.transform.position += transform.up * 0.1f * speed;

            }
            else
            {
                this.transform.Rotate(0, 0, -5f * speed);
                this.transform.position += transform.up * 0.1f * speed * 0.3f;


            }

            //UpdateCollider();

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpriteLR = 1;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.transform.Rotate(0, 0, -5f * speed);
                this.transform.position += transform.up * 0.1f * speed;

            }
            else
            {
                this.transform.Rotate(0, 0, 5f * speed);
                this.transform.position += transform.up * 0.1f * speed * 0.3f;


            }
            //UpdateCollider();
        }

        if (Functions.IsTouched("Ice", this.gameObject, 0f))
        {

            speed = Parameter.speedFactor * 3f;
            OnIceWater = 0;
        }
        else if (Functions.IsTouched("HomeIce", this.gameObject, 0f))
        {
            speed = Parameter.speedFactor * 3f;
            OnIceWater = 2;
        }
        else
        {
            speed = Parameter.speedFactor;
            OnIceWater = 1;
        }

        //if (Functions.IsTouched("Seal", this.gameObject, 0.0001f))
        //{
        //    Debug.Log(this.gameObject.name + " touched seal!");
        //    energy += 2;
        //    if (energy >= 10)
        //    {
        //        energy = 10;
        //    }
        //    EatingSeal = true;
        //    StartCoroutine(ResetSealFlag());
        //}
        //if (Functions.IsTouched("Oil", this.gameObject, -0.0001f))
        //{
        //    Debug.Log(this.gameObject.name + " touched oil!");
        //    energy -= 2;
        //    if (energy <= 0)
        //    {
        //        Debug.Log("Polar Bear A died");
        //        Destroy(this.gameObject);
        //    }
        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the collision is with a specific tag, for example, "Player"
        if (collision.gameObject.CompareTag("Oil"))
        {
            TouchedOil = true;
            StartCoroutine(OilBubble());
            audioSource.clip = oilSFX;
            audioSource.Play();
            Debug.Log(this.gameObject.name + " touched oil!");
            energy -= 2;
            if (energy <= 0)
            {
                Debug.Log("Polar Bear A died");
                Destroy(this.gameObject);
            }
            
        }
        if (collision.gameObject.CompareTag("Seal"))
        {
            StartCoroutine(SealBubble());
            audioSource.clip = sealSFX;
            audioSource.Play();
            Debug.Log(this.gameObject.name + " touched seal!");
            energy += 2;
            if (energy >= 10)
            {
                energy = 10;
            }
            EatingSeal = true;
            StartCoroutine(ResetSealFlag());
        }

    }
    void UpdateSprite()
    {
        //Decide LR, Ice or Water, Oil or not, eating seals or not;
        if (SpriteLR == 0)//L
        {
            if (OnIceWater == 0 || OnIceWater == 2)//Ice
            {
                if (TouchedOil == false)
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_walk_L;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_walk_seal_L;
                    }
                }
                else
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_walk_oil_L;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_walk_oil_seal_L;
                    }
                }
            }
            else if (OnIceWater == 1)//Water
            {
                if (TouchedOil == false)
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_swim_L;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_swim_L;
                    }
                }
                else
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_swim_oil_L;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_swim_oil_L;
                    }
                }
            }
        }
        else if (SpriteLR == 1)//R
        {
            if (OnIceWater == 0 || OnIceWater == 2)//Ice
            {
                if (TouchedOil == false)
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_walk_R;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_walk_seal_R;
                    }
                }
                else
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_walk_oil_R;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_walk_oil_seal_R;
                    }
                }
            }
            else if (OnIceWater == 1)//Water
            {
                if (TouchedOil == false)
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_swim_R;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_swim_R;
                    }
                }
                else
                {
                    if (EatingSeal == false)
                    {
                        spriteRenderer.sprite = pb2_swim_oil_R;
                    }
                    else
                    {
                        spriteRenderer.sprite = pb2_swim_oil_R;
                    }
                }
            }
        }
    }

    //void Reduceenergy()
    //{
    //    energy -= 1;
    //    if (energy <= 0){
    //        Debug.Log("Polar Bear A died");
    //        Destroy(this.gameObject);
    //    }
    //}
    void UpdateCollider()
    {
        for (int i = 0; i < polygonCollider.pathCount; i++) polygonCollider.SetPath(i, new Vector2[0]);
        polygonCollider.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();

        List<Vector2> path = new List<Vector2>();
        for (int i = 0; i < polygonCollider.pathCount; i++)
        {
            path.Clear();
            spriteRenderer.sprite.GetPhysicsShape(i, path);
            polygonCollider.SetPath(i, path.ToArray());
        }

    }
    IEnumerator ReduceEnergy()
    {
        // Wait for the specified delay
        while (true)
        {
            yield return new WaitForSeconds(18f);


            energy -= 1;
            if (energy <= 0)
            {
                Debug.Log("Polar Bear A died");
                Destroy(this.gameObject);


            }
        }
    }
    IEnumerator ResetSealFlag()
    {
        yield return new WaitForSeconds(2f);
        EatingSeal = false;
    }
    IEnumerator SealBubble()
    {
        sealBubble.SetActive(true); // Activate the assigned GameObject
        yield return new WaitForSeconds(1f); // Wait for three seconds
        sealBubble.SetActive(false); // Deactivate the assigned GameObject
    }
    IEnumerator OilBubble()
    {
        oilBubble.SetActive(true); // Activate the assigned GameObject
        yield return new WaitForSeconds(1f); // Wait for three seconds
        oilBubble.SetActive(false); // Deactivate the assigned GameObject
    }
}