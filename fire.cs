using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Rigidbody projectile;//���淢����ڵ�����
    public float speed = 80;//�����ڵ��ķ����ٶ�





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*�ڵ��������
        ���»���������Ǽ����ϵ�Ctrl�����ŷ����ڵ�*/

        if (Input.GetButtonDown("Fire1")) 
        {
            /*��ʽ������[;]���ж϶���ģ�
             * Rigidbody shoot����Ҫ��¼�������ڵ�
             * Instantiate �ǲ���������﷨����ʹ���ϵ��ڸ��Ƶ�ָ��
             * Instantiate {}�ڵ����������ֱ���Ҫ���������������Ƶ�λ����ת����
             * ��Ϊ�ű��Ǹ����ڷ���������ԣ�transform.positon��transform.rotation,�ʹ�������λ����ת����
             * �������ڵ������Զ������ȥ���������һ����������velocity���Ǹ����ķ�����
             * transform.TransformDirection(new Vector3(0, 0, speed))����ʾ���ڵ���������z�ᷢ���ȥ��speed�����ڵ��ķ����ٶ�
             */
            Rigidbody shoot = Instantiate(projectile, transform.position, transform.rotation)
            as Rigidbody;
            shoot.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            /*����������ײ
             * Physics.IgnoreCollision{}�ڿ��Ժ���������ײ��֮�����ײ
             * root���� ������ĸ����������㱾��û����ײ��̹�˲��У��������ĸ��������ָ̹��
             */
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());

            
        }
    }
}
