using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ScrollerStatic : MonoBehaviour
{
    // Start is called before the first frame update


 

    public GameObject upperObject;
    public GameObject lowerObject;

    public float height;
    public float speed = 10;

    public float initUpperY;

    void Start()
    {
        // height = tile0.GetComponent<SpriteRenderer>().sprite.rect.height;
 

        initUpperY = upperObject.transform.position.y;

        height = upperObject.transform.position.y - lowerObject.transform.position.y;

  
    }

    // Update is called once per frame



    void Update()
    {
        var val = speed * Time.deltaTime;

        upperObject.transform.position = new Vector3(upperObject.transform.position.x,
                upperObject.transform.position.y - val,
                upperObject.transform.position.z);
        lowerObject.transform.position = new Vector3(lowerObject.transform.position.x,
                lowerObject.transform.position.y - val,
                lowerObject.transform.position.z);


        if (lowerObject.transform.position.y <= -height/2 )
        {
            lowerObject.transform.position = new Vector3(lowerObject.transform.position.x,
                initUpperY,
                lowerObject.transform.position.z);

            Debug.Log("bir giris eylemi erceklesti");
             var temp = upperObject;
             upperObject = lowerObject;
             lowerObject = temp;
        }else
        {

            Debug.Log($"BU boyle mi l:{lowerObject.transform.position.y}  <=  pos:{ -height / 2}");
            
        }

        //if (upperObject.transform.position.y <= -height / 2)
        //{
        //    upperObject.transform.position = new Vector3(upperObject.transform.position.x,
        //        initUpperY,
        //        upperObject.transform.position.z);

        //    var temp = upperObject;
        //    upperObject = lowerObject;
        //    lowerObject = temp;
        //}



    }
}
