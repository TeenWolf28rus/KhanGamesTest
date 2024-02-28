using UnityEngine;

namespace Source.Game.Player
{
    public class PlayerView : MonoBehaviour
    {

        public void ChangePosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}