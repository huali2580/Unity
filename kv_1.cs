using UnityEngine;

public class kv_1 : MonoBehaviour
{
    public float mSpeed = 1f;//�Ƅ��ٶ�
    public float rSpeed = 1f;//���D�ٶ�

    //��������
    public Transform tower;//��������
    public float towerSpeed = 1f;//��̨�ٶ�

    //�ڹ����ǵĿ���
    public Transform barrel;//��¼�ڹܻ����ı���ֵ
    public float barrelSpeed = 1;//���Ǳ仯�ٶ�

    //�ڹ������нǶ�����,��¼������
    public float maxAngle = 25;
    public float minAngle = -5;

    //�ڹܵ����Ǹ���������ת��ͬ������һ����������¼
    private float angle;

    //�Ĵ����ڻ�
    //�����¼�����Ĵ��ı������Ĵ�ת�����ٶ�
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
        var h = Input.GetAxis("Horizontal");//�@ȡˮƽ�S���I
        var v = Input.GetAxis("Vertical");//�@ȡ��ֱ�S���I

        transform.Translate(0, 0, mSpeed * -v);//����ˮƽ�S���I��ǰ�M������
        transform.Rotate(0, rSpeed * h, 0);//������ֱ�S���I�����D

        //��������
        var X = Input.GetAxis("Mouse X");
        tower.Rotate(0, 0, towerSpeed * X);

        //�������ǿ���
        angle += Input.GetAxis("Mouse ScrollWheel") * barrelSpeed;//MouseScrollWheel Ϊ������ֵ�ֵ
        //�������ǵĽǶ�
        angle = Mathf.Clamp(angle, minAngle, maxAngle);//Mathf.Clamp�������﷨��
        
        Vector3 barrelAngle = barrel.localEulerAngles;//localEulerAnglesshi ��ֱ�Ӹı�����������ת�Ƕȵ��﷨������Rotate��ͬ�������޷�ָ���Ƕȣ�ǰ�߿���֪���Ƕ�
        
        barrelAngle.x = angle;
        barrel.localEulerAngles = barrelAngle;

        //�Ĵ����ڻ�
        //�Ĵ�ת���ķ����ǿ���ʽ�����Ʋ������offset����������ͼƫ�ƣ�
        Vector2 trackLOffset = trackL.material.mainTextureOffset;
        trackLOffset.x += v != 0 ? trackSpeed * v : trackSpeed * h;
        trackL.material.mainTextureOffset = trackLOffset;

        Vector2 trackROffset = trackR.material.mainTextureOffset;
        trackROffset.x += v != 0 ? trackSpeed * v : trackSpeed * h;
        trackR.material.mainTextureOffset = trackLOffset;






    }
}
