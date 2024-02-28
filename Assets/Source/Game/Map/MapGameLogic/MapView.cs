using System;
using System.Collections.Generic;
using Source.Common.Utils;
using Source.Game.Map.Configs;
using Source.Game.Map.Data;
using UnityEngine;

namespace Source.Game.Map.MapGameLogic
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tileRendererPrefab;

        private Stack<SpriteRenderer> _tilesPool = new();
        private SpriteRenderer[,] _activeTiles = new SpriteRenderer[0, 0];
        private MapConfig _mapConfig;
        private Vector2 startOffset = new Vector2();

        public void Init(MapConfig mapConfig)
        {
            _mapConfig = mapConfig;
        }

        public void Create(int[,] mapMatrix)
        {
            ReturnAllToPool();

            var rows = mapMatrix.GetLength(0);
            var columns = mapMatrix.GetLength(1);
            _activeTiles = new SpriteRenderer[rows, columns];

            startOffset = new Vector2(-(columns - 1) / 2f, (rows - 1) / 2f);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var tile = GetTile();
                    tile.gameObject.SetActive(true);
                    tile.transform.localPosition = startOffset + new Vector2(c, -r);

                    var tileType = (EMapTileType)mapMatrix[r, c];
                    var tileData = _mapConfig.GetTileData(tileType);

                    tile.color = tileData?.Color ?? Color.white;
                    _activeTiles[r, c] = tile;
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

        public bool TryGetIndexesBy(Vector2 position, out Vector2Int indexes)
        {
            var value = position - startOffset;

            indexes = new Vector2Int(-(int)Math.Round(value.y, MidpointRounding.AwayFromZero),
                (int)Math.Round(value.x, MidpointRounding.AwayFromZero));

            if (Utils.CheckOutOfBounds(_activeTiles, indexes.x, indexes.y)) return false;
            return true;
        }

        public bool TryGetPositionBy(Vector2Int indexes, out Vector2 position)
        {
            position = Vector2.zero;
            if (Utils.CheckOutOfBounds(_activeTiles, indexes.x, indexes.y)) return false;

            position = _activeTiles[indexes.x, indexes.y].transform.position;
            return true;
        }
    }
}