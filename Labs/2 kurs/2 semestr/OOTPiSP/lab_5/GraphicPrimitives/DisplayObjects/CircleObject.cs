using System.Drawing;
using System;

namespace oop.DisplayObjects
{
    public class CircleObject : EllipseObject
    {
        int mass;

        // Constructor for circle with fill color
        public CircleObject(int centerX, int centerY, int radius, Color? fill = null) :
            base(centerX, centerY, radius, radius, fill)
        {
            mass = radius * radius;
        }

        // Constructor for circle with fill texture
        public CircleObject(int centerX, int centerY, int radius, Bitmap bmp) :
            base(centerX, centerY, radius, radius, bmp)
        { 
            mass = radius * radius;
        }


        public double GetCTForBorders(double borX1, double borY1, double borX2, double borY2) {
            double timeX = -1;
            double timeY = -1;

            double vx = velModulo * Math.Cos(velAlpha * Math.PI / 180);
            if (vx != 0) { 
                double distX = vx < 0 ? (borX1 - frameX1) : (borX2 - frameX2);
                timeX = distX / vx;
            }

            double vy = velModulo * Math.Sin(velAlpha * Math.PI / 180);
            if (vy != 0) { 
                double distY = vy == 0 ? -1 : (vy < 0 ? (borY1 - frameY1) : (borY2 - frameY2));
                timeY = distY / vy;
            }

            if (timeX * timeY > 0)
            {
                if (timeX < 0)
                {
                    return timeY;       // both are -1 or so; the obj isn't moving
                }
                else
                {
                    return timeX < timeY ? timeX : timeY;
                }
            }
            else { 
                return timeX < timeY ? timeY : timeX;       // ! different condition !
            }
            
        }

        public double GetCTForCircle(CircleObject obj) {
            /*            // works for non-accelerated
                        double ax1 = accModulo * Math.Cos(accAlpha * Math.PI / 180);
                        double ay1 = accModulo * Math.Sin(accAlpha * Math.PI / 180);
                        double ax2 = obj.accModulo * Math.Cos(obj.accAlpha * Math.PI / 180);
                        double ay2 = obj.accModulo * Math.Sin(obj.accAlpha * Math.PI / 180);

                        double vx1 = velModulo * Math.Cos(velAlpha * Math.PI / 180);
                        double vy1 = velModulo * Math.Sin(velAlpha * Math.PI / 180);
                        double vx2 = obj.velModulo * Math.Cos(obj.velAlpha * Math.PI / 180);
                        double vy2 = obj.velModulo * Math.Sin(obj.velAlpha * Math.PI / 180);

                        double x1 = centerX;
                        double y1 = centerY;
                        double r1 = radiusX;

                        double x2 = obj.centerX;
                        double y2 = obj.centerY;
                        double r2 = obj.radiusX;

                        double a = (ax1 - ax2) * (ax1 - ax2) + (ay1 - ay2) * (ay1 - ay2);

                        double b = 2 * ((x1 - x2) * (vx1 - vx2) + (y1 - y2) * (vy1 - vy2) - r1 * (ax1 - ax2) - r2 * (ax2 - ax1));

                        double c = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) - (r1 + r2) * (r1 + r2);

                        double disc = b * b - 4 * a * c;

                        double result = -1;
                        if (disc >= 0) {
                            if (a != 0) {
                                double t1 = (-b + Math.Sqrt(disc)) / (2 * a);
                                double t2 = (-b - Math.Sqrt(disc)) / (2 * a);
                                if(t1>=0 && t2>=0)
                                {
                                    result = t1 > t2 ? t2 : t1;
                                }
                                else if (t1 < 0)
                                {
                                    result = t2;
                                }
                                else if(t2 < 0)
                                {
                                    result = t1;
                                }
                            }
                            // else process a 1-dimensional equation
                        }*/

            double vx1 = velModulo * Math.Cos(velAlpha * Math.PI / 180);
            double vy1 = velModulo * Math.Sin(velAlpha * Math.PI / 180);
            double vx2 = obj.velModulo * Math.Cos(obj.velAlpha * Math.PI / 180);
            double vy2 = obj.velModulo * Math.Sin(obj.velAlpha * Math.PI / 180);

            double x1 = centerX;
            double y1 = centerY;
            double r1 = radiusX;

            double x2 = obj.centerX;
            double y2 = obj.centerY;
            double r2 = obj.radiusX;

            /*            double b = 2 * (((x1 - x2) * (vx1 - vx2) + (y1 - y2) * (vy1 - vy2)));
                        double c = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) - (r1 + r2) * (r1 + r2);

                        double result;
                        if (b != 0)
                        {
                            result = -c / b;
                        }
                        else {
                            result = -1;
                        }
            

                        return result;
            */
            double vrelx = vx2 - vx1;
            double vrely = vy2 - vy1;

            double xrel = x2 - x1;
            double yrel = y2 - y1;

            // Quadratic coefficients
            double a = vrelx * vrelx + vrely * vrely;
            double b = 2 * (xrel * vrelx + yrel * vrely);
            double c = xrel * xrel + yrel * yrel - (r1 + r2) * (r1 + r2);

            // Check for collision
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                // No real roots, no collision
                return -1;
            }
            else
            {
                // Calculate collision time
                double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);


                double result = -1;
                if (t1 * t2 > 0)
                {
                    if (t1 < 0)
                    {
                        result = t1;       // both are -1 or so; the obj isn't moving
                    }
                    else
                    {
                        result = t1 < t2 ? t1 : t2;
                    }
                }
                else
                {
                    result = t1 < t2 ? t2 : t1;       // ! different condition !
                }

                //if (result < 0.001) result = -1;
                return result;

                // Return the positive root if it exists
                //return (t1 >= 0) ? t1 : (t2 >= 0) ? t2 : -1;
            }
        }

        public bool CheckCircleCollision(CircleObject other) {
            double dx = this.centerX - other.centerX;
            double dy = this.centerY - other.centerY;
            double d =Math.Sqrt(dx*dx+dy*dy);
            return d <= (other.radiusX + this.radiusX);            
        }

        public void WallCollide(double borX1, double borY1, double borX2, double borY2) {
            double probX1 = frameX1 - borX1;        // must be < 0 to collide
            double probX2 = borX2 - frameX2;        // must be < 0 to collide
            double x = probX1 < probX2 ? probX1 : probX2;

            double probY1 = frameY1 - borY1;
            double probY2 = borY2 - frameY2;
            double y = probY1 < probY2 ? probY1 : probY2;

            if (x < y)
            {
                // process left-right collision
                velAlpha = 180 - velAlpha;
                if (velAlpha < 0) {
                    velAlpha += 360;
                }
            }
            else {
                velAlpha = 360 - velAlpha;
            }
        }

        public void CircleCollide(CircleObject obj) {
            double dx = obj.centerX - this.centerX;
            double dy = obj.centerY - this.centerY;

            double phiRad = Math.Atan2(dy, dx);
            double theta1Rad = this.velAlpha * Math.PI / 180;
            double theta2Rad = obj.velAlpha * Math.PI / 180;

            if (phiRad < 0) { phiRad += Math.PI; }
            int m1 = this.mass;
            int m2 = obj.mass;

            var temp1 = this.velModulo * Math.Cos(theta1Rad - phiRad) * (m1 - m2);
            var temp2 = 2 * m2 * obj.velModulo * Math.Cos(theta2Rad - phiRad);
            var temp3 = m1 + m2;

            var vx = ((temp1+temp2)/temp3)*Math.Cos(phiRad)+this.velModulo*Math.Sin(theta1Rad-phiRad)*Math.Cos(phiRad+Math.PI/2);
            var vy = ((temp1+temp2)/temp3)*Math.Sin(phiRad)+this.velModulo*Math.Sin(theta1Rad-phiRad)*Math.Sin(phiRad+Math.PI/2);


            this.newVelModulo = Math.Sqrt(vx * vx + vy * vy);
            this.newVelAlpha = Math.Atan2(vy, vx) * 180 / Math.PI;
            if (this.velAlpha < 0) {
                this.velAlpha += 360;
            }
            this.R = true;

            /*

                        var temp1 = (this.velModulo*Math.Cos(theta1-phi)*(m1-m2));

                        var temp2 = (2*m2*obj.velModulo*Math.Cos(theta2-phi));
                        var temp3 = (m1 + m2);

                        var vx = ((temp1 + temp2) / temp3) * Math.Cos(phi) + (this.velModulo * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2));
                        var vy = ((temp1 + temp2) / temp3) * Math.Sin(phi) + (this.velModulo * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2));

                        this.newVelModulo = (int)Math.Ceiling(Math.Sqrt(vx*vx+vy*vy));
                        this.newVelAlpha = (int)((Math.Atan2(vy, vx) * 180 / Math.PI))+360;

                        this.R = true;*/

        }
    }
}
