using System;
using Source.Common.Utils;
using Source.Game.Map.Configs;
using Source.Game.Map.Data;
using UnityEngine;
using Zenject;

namespace Source.Game.Map.MapGameLogic
{
    public class MapController : IInitializable, IDisposable
    {
        private readonly MapView _view;
        private readonly MapModel _model;
        private readonly MapConfig _mapConfig;

        public MapController(MapView view, MapModel model, MapConfig mapConfig)
        {
            _view = view;
            _model = model;
            _mapConfig = mapConfig;

            _view.Init(_mapConfig);
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void CreateMap()
        {
            _model.RecreateMap();
            _view.Create(_model.MapMatrix);
        }

        public bool TryGetIndexesBy(Vector2 position, out Vector2Int indexes)
        {
            return _view.TryGetIndexesBy(position, out indexes);
        }

        public bool TryGetPositionBy(Vector2Int indexes, out Vector2 position)
        {
            return _view.TryGetPositionBy(indexes, out position);
        }

        public Vector2Int GetStartedIndexes()
        {
            var rows = _model.MapMatrix.GetLength(0);
            var columns = _model.MapMatrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (CheckCanStayOn(r, c))
                    {
                        return new Vector2Int(r, c);
                    }
                }
            }

            return new Vector2Int(0, 0);
        }

        private bool CheckCanStayOn(int row, int column)
        {
            return _model.MapMatrix[row, column] != (int)EMapTileType.Blue;
        }

        public bool HasObstacleOn(Vector2Int startIndexes, Vector2Int targetIndexes)
        {
            var sR = startIndexes.x <= targetIndexes.x ? startIndexes.x : targetIndexes.x;
            var tR = startIndexes.x <= targetIndexes.x ? targetIndexes.x : startIndexes.x;
            var sC = startIndexes.y <= targetIndexes.y ? startIndexes.y : targetIndexes.y;
            var tC = startIndexes.y <= targetIndexes.y ? targetIndexes.y : startIndexes.y;

            for (int r = sR; r <= tR; r++)
            {
                for (int c = sC; c <= tC; c++)
                {
                    if (Utils.CheckOutOfBounds(_model.MapMatrix, r, c)) return true;

                    if (!CheckCanStayOn(r, c)) return true;
                }
            }

            return false;
        }

        public int CalculateCosts(Vector2Int startIndexes, Vector2Int targetIndexes)
        {
            int cost = 0;

            var sR = startIndexes.x <= targetIndexes.x ? startIndexes.x : targetIndexes.x;
            var tR = startIndexes.x <= targetIndexes.x ? targetIndexes.x : startIndexes.x;
            var sC = startIndexes.y <= targetIndexes.y ? startIndexes.y : targetIndexes.y;
            var tC = startIndexes.y <= targetIndexes.y ? targetIndexes.y : startIndexes.y;

            for (int r = sR; r <= tR; r++)
            {
                for (int c = sC; c <= tC; c++)
                {
                    if (Utils.CheckOutOfBounds(_model.MapMatrix, r, c)) return int.MaxValue;

                    var tileType = (EMapTileType)_model.MapMatrix[r, c];
                    var tileData = _mapConfig.GetTileData(tileType);
                    if (tileData == null)
                    {
                        cost += 0;
                    }
                    else
                    {
                        cost += tileData.Value.Cost;
                    }
                }
            }

            return cost;
        }
    }
}