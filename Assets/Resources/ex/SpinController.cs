using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    public GameObject CameraObject;


    public List<GameObject> Atoms;


    public float MinRangeAtomColorBlend = 0.1f;

    public GameObject left;
    public GameObject right;




    public float VerticalSpeedFactor = 6;

    [Range(-3, 3)]
    public float Range = 2;

    [Range(0, 3.5f)]
    public float MaxAbsRange = 2;


    [Range(0, 13)]
    public float GravityCollapseFactor = 0.2f;

    [Range(0, 13)]
    public float GravityExpandFactor = 0.1f;


    public float factor = 8f;
    public float vfactor = 1f;

    [Range(-2 , 2)]
    public float BaseX = 0;

    [Range(1, 30)]
    public float zAxisDivider = 3;

    public float currentAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float horizontalVelMax = 3f;
    public float horizontalVelDrag= 0.4f;
    public float horizontalVel  = 0;

    public float lastUserRotationSign = 1;

    void Update()
    {

        // camera update
        float newY = CameraObject.transform.position.y + VerticalSpeedFactor * Time.deltaTime;
        CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, newY, CameraObject.transform.position.z);



        // color change ???
        if (Atoms != null && Atoms.Count > 1)
        {


            var left = Atoms[0];
            var right = Atoms[1];
            float rangeX = Mathf.Abs(right.transform.position.x - left.transform.position.x);
            float rangeY = Mathf.Abs(right.transform.position.z - left.transform.position.z);

            float range = Mathf.Sqrt(rangeX * rangeX + rangeY * rangeY);
            if (range <= MinRangeAtomColorBlend)
            {
                float dist = (1.0f - range / MinRangeAtomColorBlend);

                var leftc = Color.Lerp(Color.red, Color.magenta, dist);
                var rightc = Color.Lerp(Color.blue, Color.magenta, dist);

                left.GetComponent<SpriteRenderer>().color = leftc;
                left.GetComponent<TrailRenderer>().startColor = leftc;
                left.GetComponent<TrailRenderer>().endColor = leftc;


                right.GetComponent<SpriteRenderer>().color = rightc;
                right.GetComponent<TrailRenderer>().startColor = rightc;
                right.GetComponent<TrailRenderer>().endColor = rightc;

                //if (range < 0.25)
                //{
                //    float newX = (left.transform.position.x + right.transform.position.x) / 2f;
                //    left.transform.position = new Vector2(newX, left.transform.position.y);
                //    right.transform.position = new Vector2(newX, right.transform.position.y);
                //    //left.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                //    //right.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                //}
            }
            else
            {
                var leftc = Color.red;// Color.Lerp(, Color.magenta, dist);
                var rightc = Color.blue;// Color.Lerp(, Color.magenta, dist);

                left.GetComponent<SpriteRenderer>().color = leftc;
                left.GetComponent<TrailRenderer>().startColor = leftc;
                left.GetComponent<TrailRenderer>().endColor = leftc;


                right.GetComponent<SpriteRenderer>().color = rightc;
                right.GetComponent<TrailRenderer>().startColor = rightc;
                right.GetComponent<TrailRenderer>().endColor = rightc;


            }
        }










        // ftf control range with some buttons ?
        float vx = Input.GetAxis("Vertical") * vfactor * Time.deltaTime ;
        if (Mathf.Abs(Range) <= MaxAbsRange ||  (Range * vx < 0))
            Range += vx;
 



        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1) 
        {
            // normal movement
            currentAngle += Input.GetAxis("Horizontal") * factor * Time.deltaTime / Range;


            // velocity based controller attempt
            //horizontalVel += Input.GetAxis("Horizontal") * factor * Time.deltaTime / Range;


            // another range mechnaics
            //Range -= Mathf.Sin(Range) * GravityCollapseFactor * Time.deltaTime;

            lastUserRotationSign = Mathf.Sin(Input.GetAxis("Horizontal"));
        }
        else
        {

            // normal movement
            currentAngle -= Mathf.Sin(Input.GetAxis("Horizontal")) * factor * Time.deltaTime / Range;


            // velocity based controller attempt
            //horizontalVel -= lastUserRotationSign * factor * Time.deltaTime / Range;
            //horizontalVel = Mathf.Lerp(horizontalVel, 0, Time.deltaTime * horizontalVelDrag);

            // range mechanics....
            // float rangeChange =  Mathf.Sin(Range) * GravityExpandFactor * Time.deltaTime;
            //if (Mathf.Abs(Range) <= MaxAbsRange || rangeChange * Range < 0)
            //    Range +=
        }


        // velocity based controller..... >
        //horizontalVel = Mathf.Clamp(horizontalVel, -horizontalVelMax, horizontalVelMax);
        //currentAngle += horizontalVel * Time.deltaTime;




        if (Atoms != null && Atoms.Count > 0)
        {
            float exAngle = currentAngle;

            for (int i = 0; i < Atoms.Count; i++)
            {
                var beam = Atoms[i];
                if (beam == null) continue;

                float x0 = Range * Mathf.Cos(exAngle);
                float y0 = Range * Mathf.Sin(exAngle) / zAxisDivider;


                beam.transform.position = new Vector3(x0 + BaseX, beam.transform.position.y, y0);

                exAngle -= Mathf.PI * 2 / Atoms.Count;
            }
        }
         else
         {
         
             float exAngle = currentAngle - Mathf.PI;
         
             float x0 = Range * Mathf.Cos(currentAngle);
             float y0 = Range * Mathf.Sin(currentAngle) / zAxisDivider;
         
             float x1 = Range * Mathf.Cos(exAngle);
             float y1 = Range * Mathf.Sin(exAngle) / zAxisDivider;
         
             left.transform.position = new Vector3(x0 + BaseX, left.transform.position.y, y0);
             right.transform.position = new Vector3(x1 + BaseX, right.transform.position.y, y1);
         
         }



        



    }
}
