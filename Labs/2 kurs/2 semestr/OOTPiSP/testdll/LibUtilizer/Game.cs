
using oop.DisplayObjects;

namespace oop
{
    public class Game
    { 

        private GameField gameField;
        public int FPS;

        public Game(GameField field, int fps) {
            gameField = field;
            FPS = fps;
        }

        public int? AddObject(DisplayObject obj)
        {
            return gameField.AddObject(obj);
        }

        public bool DeleteObject(int index)
        {
            return gameField.DeleteObject(index);

        }
        public bool DeleteObject(DisplayObject obj)
        {
            return gameField.DeleteObject(obj);
        }

        public void MoveObjects(double time) { 
            gameField.MoveObjects(time);
        }

        public void DrawGame(Graphics g) {
            gameField.Draw(g);
        }

        public bool HandleClick(int x, int y) {
            return gameField.Click(x, y);
        }
        
    }
}
