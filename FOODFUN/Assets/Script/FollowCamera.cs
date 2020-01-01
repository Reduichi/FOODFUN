using UnityEngine;

namespace RED
{
    public class FollowCamera : MonoBehaviour
    {
        [Header("速度"), Range(0, 100)]
        public float speed = 1.5f;
        [Header("左方限制")]
        public float left;
        [Header("右方限制")]
        public float right;

        private Transform player;

        private void Start()
        {
            player = GameObject.Find("玩家").transform;
        }

        // 在 Update 之後才執行 : 攝影機追蹤，物件追蹤
        private void LateUpdate()
        {
            Track();
        }

        /// <summary>
        /// 攝影機追蹤效果
        /// </summary>
        private void Track()
        {
            Vector3 posP = player.position;         // 玩家
            Vector3 posC = transform.position;      // 攝影機

            posP.x -= 3;        // 放在玩家後面
            posP.y = 0;         // 固定 Y 軸
            posP.z = -10;       // 固定 Z 軸

            posP.x = Mathf.Clamp(posP.x, left, right);    // 玩家.x 夾住 左方限制 ~ 右方限制
            // 攝影機.座標 = 三維向量(A座標，B座標，百分比)
            transform.position = Vector3.Lerp(posC, posP, 0.3f * Time.deltaTime * speed);
        }
    }
}
