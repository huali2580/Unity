using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Rigidbody projectile;//宣告发射的炮弹变数
    public float speed = 80;//宣告炮弹的飞行速度





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*炮弹发射控制
        按下滑鼠左键或是键盘上的Ctrl键，才发射炮弹*/

        if (Input.GetButtonDown("Fire1")) 
        {
            /*程式中是以[;]来判断段落的，
             * Rigidbody shoot代表要记录产生的炮弹
             * Instantiate 是产生物件的语法，在使用上等于复制的指令
             * Instantiate {}内的三个参数分别是要负责的物件，被复制的位置与转轴向
             * 因为脚本是附加在发射点上所以，transform.positon与transform.rotation,就代表发射点的位置与转轴向
             * 产生的炮弹不会自动发射出去，必须给它一个方向力，velocity就是给它的方向力
             * transform.TransformDirection(new Vector3(0, 0, speed))，表示将炮弹往发射点的z轴发射出去，speed就是炮弹的飞行速度
             */
            Rigidbody shoot = Instantiate(projectile, transform.position, transform.rotation)
            as Rigidbody;
            shoot.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            /*避免自身碰撞
             * Physics.IgnoreCollision{}内可以忽略两个碰撞体之间的碰撞
             * root代表 该物件的根物件，发射点本身并没有碰撞框，坦克才有，而发射点的根物件就是指坦克
             */
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());

            
        }
    }
}
