using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //��ը��Ч
    //OnCollisionEnter ��ײ��⣬��update��ͬ��ǰ��ֻҪ��ײ������Ż�ִ��{}�ڳ�ʽ��������һֱ��ִ��{}
    private void OnCollisionEnter(Collision collision)
    {
        var expFx = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(expFx, 5);//����5���ɾ��
        Destroy(gameObject);
    }
}
