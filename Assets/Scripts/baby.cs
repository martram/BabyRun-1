using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour
{
    //from baby controller
    public TextMesh babyDist;

    private const float m2ft = 3.280839895f;
    private const float physScale = 200f;
    public float health = 100f;

    private const string cannonPrefix = "Baby Distance: ";
    private const string cannonSuffix = " ft";

    public bool isTossed = false;
    private Vector3 tossStart;


    public float babyTimer;
    public string babyName;
    public int babyID;
    public float statusHealth;
    public float statusHead;
    public float statusLegLeft;
    public float statusLegRight;
    public float statusArmLeft;
    public float statusArmRight;
    public float statusTorso;
    public float hunger;
    public float sleepiness;
    public float happiness;
    public float maxHunger = 10000;
    public float maxSleepiness = 10000;
    public float maxHappiness = 10000;
    public float poop;
    public int foodEatenCounter;
    public float diseaseCounter;

    public BabyArm babyArmLeft;
    public BabyArm babyArmRight;
    public BabyLeg babyLegLeft;
    public BabyLeg babyLegRight;
    public BabyHead babyHead;
    public GameObject babyTorso;
    public GameObject babyObject;
    public GameObject babyArmLeftObject;
    public GameObject babyArmRightObject;
    public GameObject babyLegLeftObject;
    public GameObject babyLegRightObject;
    public GameObject babyHeadObject;

    public GameObject babyArmLeftNode;
    public GameObject babyArmRightNode;
    public GameObject babyLegLeftNode;
    public GameObject babyLegRightNode;
    public GameObject babyHeadNode;


    public MeshCollider babyArmLeftCollider;
    public MeshCollider babyArmRightCollider;
    public MeshCollider babyLegLeftCollider;
    public MeshCollider babyLegRightCollider;
    public MeshCollider babyHeadCollider;
    public MeshCollider babyTorsoCollider;

    public Joint babyArmLeftJoint;
    public Joint babyArmRightJoint;
    public Joint babyLegLeftJoint;
    public Joint babyLegRightJoint;
    public Joint babyHeadJoint;

    public string armLeftPart;
    public string armRightPart;
    public string legLeftPart;
    public string legRightPart;
    public string headPart;
    public string torsoPart;

    public bool isArmLeftAttached = false;
    public bool isArmRightAttached = false;
    public bool isLegLeftAttached = false;
    public bool isLegRightAttached = false;
    public bool isHeadAttached = false;



    public GameObject babyObjectPart1;
    public GameObject babyObjectPart2;
    public GameObject babyObjectF;

    public Vector3 leftArmPos;
    public Vector3 rightArmPos;
    public Vector3 leftLegPos;
    public Vector3 rightLegPos;
    public Vector3 headPos;
    public bool deadBaby = false;
    public bool isCat = false;
    public bool isItABoy = false;

    public int race;

    public System.DateTime timeOfBirth;
    //public Baby(string babyNameIn, int babyIDin){

    /*	babyObjectPart1 = (GameObject) GameObject.Instantiate (babyObjectF, babyObject.transform.position, Quaternion.identity);
   -			babyObjectPart2 = (GameObject) GameObject.Instantiate (babyObjectF, babyObject.transform.position, Quaternion.identity);
   -		
   -			babyObjectPart1.transform.parent= babyObject.transform;
   -			babyObjectPart2.transform.parent= babyObject.transform;*/


    //	babyObject =(GameObject)Instantiate(Resources.Load("Baby"));
    //}
    // Use this for initialization


    void Start()
    {

        print("baby Start");
        babyTimer = 0;
        statusHealth = 100;
        statusHead = 100;
        statusLegLeft = 100;
        statusLegRight = 100;
        statusArmLeft = 100;
        statusArmRight = 100;
        statusTorso = 100;
        hunger = maxHunger;
        sleepiness = maxSleepiness;

        StartCoroutine(statusUpdate(1.0F));
        //from babycontroller
        //babyDist.text = "";

    }
    public void createIdentity(string babyNameIn, int babyIDin, System.DateTime creationDate)
    {

        babyName = babyNameIn;
        babyID = babyIDin;
        timeOfBirth = creationDate;
        // 		babyObject = GameObject.Find("Baby");
        //	babyObject
        babyObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyTorsoBaby"), Vector3.zero, Quaternion.identity);
        //gameObject.AddComponent<BoxCollider>().size = new Vector3(1.8f, 0.9f, 0.9f);
        gameObject.AddComponent<Rigidbody>();
	
        babyObject.name = "babyObject";
        babyTorso = GameObject.Find("babyTorso");

        babyTorsoCollider = babyTorso.AddComponent<MeshCollider>();
        babyTorsoCollider.sharedMesh = babyTorso.GetComponent<MeshFilter>().sharedMesh;
        babyTorsoCollider.enabled = false;

        babyArmLeftNode = GameObject.Find("babyLeftArmNode");
        babyArmRightNode = GameObject.Find("babyRightArmNode");
        babyLegLeftNode = GameObject.Find("babyLeftLegNode");
        babyLegRightNode = GameObject.Find("babyRightLegNode");
        babyHeadNode = GameObject.Find("babyHeadNode");
        leftArmPos = babyArmLeftNode.transform.position;
        leftArmPos.x -= 0.2f;
        rightArmPos = babyArmRightNode.transform.position;
        rightArmPos.x += 0.2f;

        leftLegPos = babyLegLeftNode.transform.position;
        leftLegPos.x -= 0.2f;
        rightLegPos = babyLegRightNode.transform.position;
        rightLegPos.x += 0.2f;

        headPos = babyTorso.transform.position;
        headPos.y -= 0.2f;

        // 	babyObjectPart1 = (GameObject) GameObject.Instantiate (babyObjectF, leftArmPos, Quaternion.identity);
        // 	babyObjectPart2 = (GameObject) GameObject.Instantiate (babyObjectF, rightArmPos, Quaternion.identity);



        createMembers();

    }
    private void createMembers()
    {

        babyArmLeftObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyArmBaby"), Vector3.zero, Quaternion.identity);

        babyArmLeft = babyArmLeftObject.AddComponent<BabyArm>();

        babyArmLeft.createPart(isCat, leftArmPos, false);
        /*
        babyArmLeftCollider = babyArmLeftObject.AddComponent<MeshCollider>();
        babyArmLeftCollider.sharedMesh = babyArmLeftObject.GetComponent<MeshFilter>().sharedMesh;*/

        babyArmRightObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyArmBaby"), Vector3.zero, Quaternion.identity);

        babyArmRight = babyArmRightObject.AddComponent<BabyArm>();
        babyArmRight.createPart(isCat, rightArmPos, true);
        //babyArmRightCollider = babyArmRightObject.AddComponent<MeshCollider>();
        //babyArmRightCollider.sharedMesh = babyArmRightObject.GetComponent<MeshFilter>().sharedMesh;

        babyLegLeftObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyLegBaby"), Vector3.zero, Quaternion.identity);

        babyLegLeft = babyLegLeftObject.AddComponent<BabyLeg>();
        babyLegLeft.createPart(isCat, leftLegPos, false);
        //babyLegLeftCollider = babyLegLeftObject.AddComponent<MeshCollider>();
        //babyLegLeftCollider.sharedMesh = babyLegLeftObject.GetComponent<MeshFilter>().sharedMesh;

        babyLegRightObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyLegBaby"), Vector3.zero, Quaternion.identity);

        babyLegRight = babyLegRightObject.AddComponent<BabyLeg>();
        babyLegRight.createPart(isCat, rightLegPos, true);
        //babyLegRightCollider = babyLegRightObject.AddComponent<MeshCollider>();
        //babyLegRightCollider.sharedMesh = babyLegRightObject.GetComponent<MeshFilter>().sharedMesh;

        babyHeadObject = (GameObject)GameObject.Instantiate(Resources.Load("babyParts/babyHeadBaby"), Vector3.zero, Quaternion.identity);

        babyHead = babyHeadObject.AddComponent<BabyHead>();
        babyHead.createPart(isCat, headPos, true);
        //babyHeadCollider = babyHeadObject.AddComponent<MeshCollider>();
        //babyHeadCollider.sharedMesh = babyHeadObject.GetComponent<MeshFilter>().sharedMesh;



        babyArmLeftObject.transform.parent = babyObject.transform;
        babyArmRightObject.transform.parent = babyObject.transform;

        babyLegLeftObject.transform.parent = babyObject.transform;
        babyLegRightObject.transform.parent = babyObject.transform;

        babyHeadObject.transform.parent = babyObject.transform;

    }


    public void TossBaby(Vector3 dir, float speed)
    {
        if (isTossed) return;

        isTossed = true;
        tossStart = transform.position;

        //transform.parent = null;
        babyTorsoCollider.enabled = true;
     //   collider.enabled = true;
      //  gameObject.AddComponent<Rigidbody>();

        Vector3 forceVec = (Vector3.up + dir) * physScale;
        rigidbody.AddForce(forceVec * rigidbody.mass);

    }
    public void reviveBaby()
    {

        statusHealth = 100;
        statusHead = 100;
        statusLegLeft = 100;
        statusLegRight = 100;
        statusArmLeft = 100;
        statusArmRight = 100;
        statusTorso = 100;
        hunger = maxHunger;
        sleepiness = maxSleepiness;


    }
    public void healBaby(int healAmount)
    {

        statusHealth += healAmount;
        statusHead += healAmount;
        statusLegLeft += healAmount;
        statusLegRight += healAmount;
        statusArmLeft += healAmount;
        statusArmRight += healAmount;
        statusTorso += healAmount;

        if (statusHealth > 100) { statusHealth = 100; }
        if (statusHead > 100) { statusHead = 100; }
        if (statusLegLeft > 100) { statusLegLeft = 100; }
        if (statusLegRight > 100) { statusLegRight = 100; }
        if (statusArmLeft > 100) { statusArmLeft = 100; }
        if (statusArmRight > 100) { statusArmRight = 100; }
        if (statusTorso > 100) { statusTorso = 100; }
    }
    public void healthDrop(string part, float dropAmount)
    {
        switch (part)
        {
            case "something":
                break;

        }
        statusHealth += dropAmount;
        statusHead += dropAmount;
        statusLegLeft += dropAmount;
        statusLegRight += dropAmount;
        statusArmLeft += dropAmount;
        statusArmRight += dropAmount;
        statusTorso += dropAmount;

    }
    public void killBaby()
    {


        statusHealth = 0;
        deadBaby = true;
    }
    public void resetBaby()
    {

        //reset all pos
        babyArmLeft.resetPart(leftArmPos);
        babyArmRight.resetPart(rightArmPos);
        babyLegLeft.resetPart(leftLegPos);
        babyLegRight.resetPart(rightLegPos);
        babyHead.resetPart(headPos);

        babyTorso.collider.enabled = false;


     //   babyTorso.rigidbody.useGravity = false;
     //   babyTorso.rigidbody.isKinematic = true;

    }
    public void showRenderer()
    {
        //renderer on parts



    }
    public void resetMembers()
    {


        //all members back on if attached

    }
    void OnCollisionEnter(Collision c)
    {

        //health-=rigidbody.maxAngularVelocity;
     //   babyDist.text += " health/velocity : " + rigidbody.maxAngularVelocity.ToString("F1");
        if (c.gameObject.tag == "Ground")
        {

            rigidbody.maxAngularVelocity = 0f;

        }
        print("speed of impact ?" + rigidbody.maxAngularVelocity);
        statusHealth -= rigidbody.maxAngularVelocity * 2;
        print("health  = " + health);

    }

    IEnumerator statusUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            hunger--;
            sleepiness--;
            babyTimer++;
        }
    }
}