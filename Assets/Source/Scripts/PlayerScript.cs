using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform BladeSpawn;
    public float force;
    public Transform dead;
    public Rigidbody rb;
    public EnemyScript Player;
    private bool isMobile;
    public TapToStart p;
    public static FirstForce lastSwipe;
    public Transform parent;
    public GameObject cube;
    public static GameObject pl;
    public static Transform MyPosition;
    public static bool IsDead;
    public class FirstForce
    {
        public Vector3 SecondPoint;
        public Vector3 FirstPoint;
        public Vector3 Forvard { get { return SecondPoint - FirstPoint; } }
        public bool b;

        public FirstForce()
        {
        }
        public Vector3 GetDirection(Vector3 ForvardPlauer)
        {
            var a = Forvard;
            var b = (a.x + a.y)/85;
            return new Vector3(ForvardPlauer.x+ a.x, b*15, ForvardPlauer.y+ a.y).normalized;
        }
        public float GetForce()
        {
            return Forvard.magnitude;
        }
    }
    
    void Start()
    {
        IsDead = false;
        MyPosition = transform;
        rb = GetComponent<Rigidbody>();
        Player = FindObjectOfType<EnemyScript>();
        p = FindObjectOfType<TapToStart>();
        lastSwipe = new FirstForce();
        isMobile = Application.isMobilePlatform;
        cube.transform.position = new Vector3(parent.position.x, parent.position.y - 1, parent.position.z);
        pl = gameObject;
    }

    void Update()
    {
        if (p.p)
        {
            if (!isMobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lastSwipe.FirstPoint = Input.mousePosition;
                    
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    lastSwipe.SecondPoint = Input.mousePosition;
                    // var t = camera.ScreenToWorldPoint(lastSwipe.FirstPoint);wa
                    //print(t.x + " " + t.y);
                    var p = BladeSpawn.position;
                    p.y +=  lastSwipe.FirstPoint.y*2/Screen.height-1 ;
                    // p.x+=  Screen.width/ 2-lastSwipe.FirstPoint.x;
                    var whi = (lastSwipe.FirstPoint.x+lastSwipe.SecondPoint.x) / Screen.width-1;
                    print(whi);
                    var i=Instantiate(cube,p,Quaternion.identity);
                    i.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0,whi*15,0)*BladeSpawn.forward*lastSwipe.GetForce()*force);
                    i.transform.LookAt(BladeSpawn.position+lastSwipe.Forvard);

                }

            }
            else
            {
                if (Input.touchCount > 0)
                {

                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        lastSwipe.FirstPoint = Input.GetTouch(0).position;

                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        lastSwipe.SecondPoint = Input.GetTouch(0).position;
                        var i = Instantiate(cube, BladeSpawn.position, Quaternion.identity);
                        i.GetComponent<Rigidbody>().AddForce(BladeSpawn.forward * lastSwipe.GetForce() * force);
                        i.transform.LookAt(BladeSpawn.position + lastSwipe.Forvard);
                    }
                }
            }

        }
        
        if(Player.PlayerDead)
        {
            transform.position = new Vector3(transform.position.x, dead.position.y, transform.position.z);
        }
    }
}


