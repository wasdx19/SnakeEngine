using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point myHeadPosition;
        private Point foodPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {

            /////////
            ///
            //#1 variant: high probabilty of collision 

            /*if (myHeadPosition.X > foodPosition.X)
            {
                return SnakeDirection.Left;
            }

            if (myHeadPosition.X < foodPosition.X)
            {
                return SnakeDirection.Right;
            }

            if (myHeadPosition.Y > foodPosition.Y)
            {
                return SnakeDirection.Up;
            }

            if (myHeadPosition.Y < foodPosition.Y)
            {
                return SnakeDirection.Down;
            }*/

            //#2 variant: less probabilty of collision, comment 1 variant to activate, this variant just takes better score than 1

            if (myHeadPosition.X == foodPosition.X && myHeadPosition.Y > foodPosition.Y)
            {
                return SnakeDirection.Up;
            }

            if (myHeadPosition.X == foodPosition.X && myHeadPosition.Y < foodPosition.Y)
            {
                return SnakeDirection.Down;
            }

            if (myHeadPosition.Y == foodPosition.Y && myHeadPosition.X < foodPosition.X)
            {
                return SnakeDirection.Right;
            }

            if (myHeadPosition.Y == foodPosition.Y && myHeadPosition.X > foodPosition.X)
            {
                return SnakeDirection.Left;
            }

            ///////
            //////////

            if (currentDirection == SnakeDirection.Up
                && myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }


            if(currentDirection == SnakeDirection.Right
                && myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            myHeadPosition = getMyHeadPosition(map);
            foodPosition = getFoodPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }

        private Point getFoodPosition(string map)
        {
            var foodIndex = map.IndexOf("7");
            return new Point(foodIndex % _width, foodIndex / _width); 
        }
    }
}
