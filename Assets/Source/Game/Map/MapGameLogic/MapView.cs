using System.Collections.Generic;
using UnityEngine;

namespace Source.Game.Map.MapGameLogic
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tileRendererPrefab;

        private Stack<SpriteRenderer> _tilesPool = new();
        private SpriteRenderer[,] _activeTiles = new SpriteRenderer[0, 0];

        public void Display(int[,] mapMatrix)
        {
            ReturnAllToPool();

            var rows = mapMatrix.GetLength(0);
            var columns = mapMatrix.GetLength(1);
            _activeTiles = new SpriteRenderer[rows, columns];

            var startPosition = new Vector2(-(columns-1) / 2f, (rows-1) / 2f);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var tile = GetTile();
                    tile.gameObject.SetActive(true);
                    tile.transform.localPosition = startPosition + new Vector2(c, -r);
                }
            }
        }

        private SpriteRenderer GetTile()
        {
            if (_tilesPool.Count > 0)
            {
                return _tilesPool.Pop();
            }

            var tile = Instantiate(_tileRendererPrefab, transform, true);
            return tile;
        }

        private void ReturnAllToPool()
        {
            var rows = _activeTiles.GetLength(0);
            var columns = _activeTiles.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var tile = _activeTiles[r, c];
                    _tilesPool.Push(tile);
                    tile.gameObject.SetActive(false);
                }
            }

            _activeTiles = new SpriteRenderer[0, 0];
        }
    }
}