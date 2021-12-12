using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWPF
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get;  } // состояние блока, вращение, перемещение
        protected abstract Position StartOffset { get;  } // точка стартовой позиции
        public abstract int Id { get;  } // ид блока

        private int rotationState; // вращение
        private Position offset; // перемещение 

        public Block() // стартовая позиция блока
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilesPositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW() // поворот на 90 градусов по часовой стрелке блока
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW() // поворот на 90 градусов против часовой стрелке блока
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns) // перемещает блок на заданное кол-во секций
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset() // обнуляет позицию и вращение
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
