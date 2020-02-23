using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameColors;

public class Atom : MonoBehaviour
{
    public ColorType colorType;


    public GameObject passEffect;
    public GameObject ExplodeEffect;
    public GameObject CrushEffect;


    public GameObject LightningObjectPowerUp;

    void DoPassEffect(GameObject other = null)
    {
        if(passEffect)
        { 
      //  GameObject firework = Instantiate(passEffect, this.transform.position, Quaternion.identity);
     
           // var bd = firework.AddComponent<Rigidbody2D>();
            GameObject firework = Instantiate(passEffect, this.transform);
            //bd.isKinematic = true;
            //bd.velocity = new Vector2(0, GameController.Instance.GetVerticalSpeedFactor);


            //firework.GetComponent<ParticleSystem>().Play();

            GameObject.Destroy(firework, 5.2f);
        }
    }
    void DoExplodeEfecet(GameObject other =null)
    {
        if (passEffect)
        {
            //  GameObject firework = Instantiate( ExplodeEffect, this.transform.position, Quaternion.identity);
            // GameObject firework = Instantiate( ExplodeEffect, this.transform);


            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;
            GameObject firework = Instantiate( ExplodeEffect, new Vector3(x, y, z+2) , Quaternion.identity  , this.transform);

            // var bd = firework.AddComponent<Rigidbody2D>();
            // bd.isKinematic = true;
            // bd.velocity = new Vector2(0, GameController.Instance.GetVerticalSpeedFactor);

            //firework.GetComponent<ParticleSystem>().Play();
            // GameObject.Destroy(firework, 1.2f);


        }
    }
    void DoCrushEffect(GameObject other = null)
    {
        if (passEffect)
        {
            GameObject firework = Instantiate(CrushEffect, other.transform.position, Quaternion.identity);

            var attractor = firework.GetComponent<particleAttractorLinear>();
            attractor.target = this.transform ;

            var bd = firework.AddComponent<Rigidbody2D>();
            bd.isKinematic = true;
            bd.velocity = new Vector2(0, GameController.Instance.GetVerticalSpeedFactor);


            firework.GetComponent<ParticleSystem>().Play();
            GameObject.Destroy(firework, 1.2f);

        }
    }

    public float powerupduration = 5;

    bool powerupEnabled = false;
    float poweruptimer = 0;

    public float extendPowerUpDuration = 0;



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("other tab" + other.gameObject.tag);

        if (other.gameObject.tag == "Obstacle")
        {
            if (colorType == other.gameObject.GetComponent<ObstacleComponent>().colorType)
            {


                ScoreManager.Instance.IncrementScore(100);
                DoPassEffect(other.gameObject);

            }
            else
            {
                if (powerupEnabled)
                {
                    DoCrushEffect(other.gameObject);
                }
                else
                {
                    //Time.timeScale = 0;
                    DoExplodeEfecet(other.gameObject);

                    //StartCoroutine("DoGameOver");

                   
                    GameController.Instance.GameOver = true;
                    
                    
                }

              
            }
        }
        else
        if (other.gameObject.tag == "PowerUp" )
        {
            if (powerupEnabled)
            {
                extendPowerUpDuration += powerupduration;
            }

            powerupEnabled = true;

            SpinController.Instance.EnableLightning(true);
            // poweruptimer = Time.time + powerupduration;

            StartCoroutine("DisablePowerUp");
        }
    }


    public IEnumerator DoGameOver()
    {
        yield return new WaitForSeconds(0.6f);
        GameController.Instance.GameOver = true;

    }
    public  IEnumerator DisablePowerUp()
    {
        yield return new WaitForSeconds(powerupduration);

        while (extendPowerUpDuration != 0)
        {
            extendPowerUpDuration = 0;
            yield return new WaitForSeconds(extendPowerUpDuration);
        }

        SpinController.Instance.EnableLightning(false);

        powerupEnabled = false;
    }

}
