using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts.Utils.AStar;
using UnityEngine;

namespace Assets.Scripts.Game.Impl.Bomber.Logic
{
    public class GameRoom
    {


        private BombGridCell[,] _mMap;


        public void InitRoomById(int roomId)
        {

        }

        public void InitRandomRoom(int weight, int height)
        {
            _mMap = new BombGridCell[weight, height];
            //  initialize the room  wall.
            for (var i = 0; i < weight; i++)
            {
                _mMap[0, i] = new BombGridCell(Point.Of(0, i), GridType.Wall, 0);
                _mMap[height - 1, i] = new BombGridCell(Point.Of(0, i), GridType.Wall, 0);
            }
            for (var i = 1; i < height - 1; i++)
            {
                _mMap[i, 0] = new BombGridCell(Point.Of(0, i), GridType.Wall, 0);
                _mMap[weight - 1, 0] = new BombGridCell(Point.Of(0, i), GridType.Wall, 0);
            }


        }


        public void Test()
        {

            InitRandomRoom(3, 3);

            BombGridCell[,] map = new BombGridCell[,]
            {
                { new BombGridCell(Point.Zero, GridType.Normal, 0),
                 new BombGridCell(Point.Zero, GridType.Normal, 0),
                 new BombGridCell(Point.Zero, GridType.Normal, 0),
                 new BombGridCell(Point.Zero, GridType.Normal, 0)},

                { new BombGridCell(Point.Zero, GridType.Normal, 0),
                    new BombGridCell(Point.Zero, GridType.Normal, 0),
                    new BombGridCell(Point.Zero, GridType.Normal, 0),
                    new BombGridCell(Point.Zero, GridType.Normal, 0)},
            };
            LinkedList<Point> linkedList = PathUtil.Find(0, 0, 1, 3, map, false);
            foreach (var point in linkedList)
            {
                Debug.Log(point);
            }
        }

    }
}