using UnityEngine;

public class kv_1 : MonoBehaviour
{
    public float mSpeed = 1f;//移動速度
    public float rSpeed = 1f;//旋轉速度

    //炮塔控制
    public Transform tower;//宣告炮塔
    public float towerSpeed = 1f;//炮台速度

    //炮管仰角的控制
    public Transform barrel;//记录炮管基座的变数值
    public float barrelSpeed = 1;//仰角变化速度

    //炮管仰角有角度限制,记录上下限
    public float maxAngle = 25;
    public float minAngle = -5;

    //炮管的仰角跟炮塔的旋转不同，宣告一个变数来记录
    private float angle;

    //履带与炮击
    //宣告记录左右履带的变数与履带转动的速度
    public Renderer trackL;
    public Renderer trackR;
    public float trackSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");//獲取水平軸向按鍵
        var v = Input.GetAxis("Vertical");//獲取垂直軸向按鍵

        transform.Translate(0, 0, mSpeed * -v);//根據水平軸向按鍵來前進或後退
        transform.Rotate(0, rSpeed * h, 0);//根據垂直軸向按鍵來旋轉

        //炮塔控制
        var X = Input.GetAxis("Mouse X");
        tower.Rotate(0, 0, towerSpeed * X);

        //炮塔仰角控制
        angle += Input.GetAxis("Mouse ScrollWheel") * barrelSpeed;//MouseScrollWheel 为滑鼠滚轮的值
        //限制仰角的角度
        angle = Mathf.Clamp(angle, minAngle, maxAngle);//Mathf.Clamp是限制语法，
        
        Vector3 barrelAngle = barrel.localEulerAngles;//localEulerAnglesshi 是直接改变炮塔基座旋转角度的语法，它与Rotate不同，后者无法指定角度，前者可以知道角度
        
        barrelAngle.x = angle;
        barrel.localEulerAngles = barrelAngle;

        //履带与炮击
        //履带转动的方法是靠程式来控制材质球的offset，就是让贴图偏移，
        Vector2 trackLOffset = trackL.material.mainTextureOffset;
        trackLOffset.x += v != 0 ? trackSpeed * v : trackSpeed * h;
        trackL.material.mainTextureOffset = trackLOffset;

        Vector2 trackROffset = trackR.material.mainTextureOffset;
        trackROffset.x += v != 0 ? trackSpeed * v : trackSpeed * h;
        trackR.material.mainTextureOffset = trackLOffset;






    }
}
