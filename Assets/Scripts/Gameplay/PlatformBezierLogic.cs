using UnityEngine;

public class PlatformBezierLogic : MonoBehaviour {


    public GameObject CurveParent;

    //public GameObject[] platformList;
    private Vector2 Edge1;
    private Vector2 Edge2;


    // Curve
    private BezierCurve CurveLtoR;
    private BezierCurve CurveRtoL;

    private GameObject BPoint0;
    private GameObject BPoint1;

    private float max;


    // Trigger
    private GameObject Trigger1;
    private GameObject Trigger2;




  
    public void SetUp( GameObject[] list)
    {
        for (int i = 0; i < list.Length - 1; i++)
        {
            SetUpHelper(list[i], list[i + 1]);
        }

    }
    public void SetUpHelper(GameObject leftPlatform, GameObject rightPlatform)
    {
        //////Curve 1//////

        // Get edge of platforms
        Edge1 = leftPlatform.GetComponent<EdgeCollider2D>().points[1];
        Edge2 = rightPlatform.GetComponent<EdgeCollider2D>().points[0];

        // Initialize curves
        CurveLtoR = (new GameObject("CurveLtoR")).AddComponent<BezierCurve>();
        CurveRtoL = (new GameObject("CurveRtoL")).AddComponent<BezierCurve>();

        // Initialize positions
        BPoint0 = new GameObject("Pos 0");
        BPoint1 = new GameObject("Pos 0");

        // Set positions
        BPoint0.transform.position = leftPlatform.transform.position + new Vector3(Edge1.x, Edge1.y + 0.2f, 0);
        BPoint1.transform.position = rightPlatform.transform.position + new Vector3(Edge2.x, Edge2.y + 0.2f, 0);

        // Get max between two platforms
        max = Mathf.Max(BPoint1.transform.position.y, BPoint0.transform.position.y);


        // Add 3 points to each platform and set x handle (smoothenes of curve)
        CurveLtoR.AddPointAt(BPoint0.transform.position);
        CurveLtoR.AddPointAt(new Vector2((BPoint1.transform.position.x + BPoint0.transform.position.x) / 2f, max + 1f)).setHandleX(1);
        CurveLtoR.AddPointAt(BPoint1.transform.position);
        CurveLtoR.transform.parent = CurveParent.transform;

        CurveRtoL.AddPointAt(BPoint1.transform.position);
        CurveRtoL.AddPointAt(new Vector2((BPoint0.transform.position.x + BPoint1.transform.position.x) / 2f, max + 1f)).setHandleX(-1);
        CurveRtoL.AddPointAt(BPoint0.transform.position);
        CurveRtoL.transform.parent = CurveParent.transform;


        // Triggers
        Trigger1 = new GameObject("Trigger1");
        Trigger1.AddComponent<BoxCollider2D>().size = new Vector2(0.02f, 1);
        Trigger1.transform.parent = CurveLtoR.gameObject.transform;
        Trigger1.tag = "LeftJumpPathTrigger";
        Trigger1.GetComponent<BoxCollider2D>().isTrigger = true;

        Trigger2 = new GameObject("Trigger2");
        Trigger2.AddComponent<BoxCollider2D>().size = new Vector2(0.02f, 1);
        Trigger2.transform.parent = CurveRtoL.gameObject.transform;
        Trigger2.tag = "RightJumpPathTrigger";
        Trigger2.GetComponent<BoxCollider2D>().isTrigger = true;

        Trigger1.transform.position = BPoint0.transform.position;
        Trigger2.transform.position = BPoint1.transform.position;


        Destroy(BPoint0);
        Destroy(BPoint1);
    }
}
