using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public abstract class DisplayObject
    {
        protected double xP, yP; // точка привязки
        protected double x1, y1; // Левый верхний угол клиентской части
        protected double x2, y2; // Правый нижний угол клиентской части
        protected int fillColorR, fillColorG, fillColorB;
        protected int borderColorR, borderColorG, borderColorB;
        protected int borderWidth;
        protected double x1Bord, y1Bord; // Левый верхний угол рамки
        protected double x2Bord, y2Bord; // Правый нижний угол рамки
        protected double vel;
        protected double angle;
        protected double accel;
        protected double accelX, accelY;
        protected double initialVelocityX, initialVelocityY;
        public DateTime time0;

        public DisplayObject(double x1,double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, int vel,int angle, int accel, int time)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.borderWidth = borderWidth;
            this.borderColorR = borderColorR;
            this.borderColorG = borderColorG;
            this.borderColorB = borderColorB;
            this.fillColorB = fillColorB;
            this.fillColorR = fillColorR;
            this.fillColorG = fillColorG;
            this.vel = vel;
            this.angle = angle;
            this.time0 = DateTime.Now;
            CalculateBoundingRectangle();
        }
        public DisplayObject(int x1, int y1, int x2, int y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.borderWidth = borderWidth;
            this.borderColorR = borderColorR;
            this.borderColorG = borderColorG;
            this.borderColorB = borderColorB;
            this.fillColorB = fillColorB;
            this.fillColorR = fillColorR;
            this.fillColorG = fillColorG;
            CalculateBoundingRectangle();
        }

        public virtual void Draw(Graphics g)
        {

        }

        protected void SetBoundingRectangle(double x1BordN,double  y1BordN, double x2BordN, double y2BordN)
        {
            xP = (x2BordN - x1BordN)/2;
            yP = (y2BordN - y1BordN) / 2;
            x1Bord = x1BordN;
            y1Bord = y1BordN;
            x2Bord = x2BordN;
            y2Bord = y2BordN;
        }

        protected virtual void CalculateBoundingRectangle()
        {

        }
        public virtual void UpdateMove()
        {
            accelX = accel * Math.Cos(angle * (Math.PI / 180));
            accelY = accel * Math.Sin(angle * (Math.PI / 180));
            initialVelocityX = vel * Math.Cos(angle * (Math.PI / 180));
            initialVelocityY = vel * Math.Sin(angle * (Math.PI / 180));
        }
        public virtual void Move()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan deltaTime = currentTime - time0;
            double deltaTimeSeconds = deltaTime.TotalSeconds;
            UpdateMove();
            double deltaX = initialVelocityX * deltaTimeSeconds + accelX * deltaTimeSeconds * deltaTimeSeconds / 2;
            double deltaY = initialVelocityY * deltaTimeSeconds + accelY * deltaTimeSeconds * deltaTimeSeconds / 2;
            ShiftCoords(deltaX, deltaY);
        }
        protected abstract void ShiftCoords(double deltaX, double deltaY);
    }
}
