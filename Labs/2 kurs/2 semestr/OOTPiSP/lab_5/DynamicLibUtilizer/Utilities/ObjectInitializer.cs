using oop.DisplayObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace oop
{
    public class ObjectInitializer
    {
        private static Random rand = new Random();

        // Limits for width and height
        private static readonly int WIDTH_MIN = 50;
        private static readonly int WIDTH_MAX = 150;
        private static readonly int HEIGHT_MIN = 50;
        private static readonly int HEIGHT_MAX = 150;
        
        // Limits for velocity vector values
        private static readonly int velModuloMin = 50;
        private static readonly int velModuloMax = 300;
        
        // Limits for acceleration vector values
        private static readonly int accModuloMin = 20;
        private static readonly int accModuloMax = 100;

        public static int generateWidth() => rand.Next(WIDTH_MIN, WIDTH_MAX);
        public static int generateHeight() => rand.Next(HEIGHT_MIN, HEIGHT_MAX);
        public static int generateAngle() => (int)(rand.NextDouble() * 360);


        public static (int, int) generateVelocityVector() => (rand.Next(velModuloMin, velModuloMax), generateAngle());
        public static (int, int) generateAccelerationVector() => (rand.Next(accModuloMin, accModuloMax), generateAngle());


        private static int actualW = 0, actualH = 0;

        //delegate DisplayObject genObject();
        private static readonly int amntOfObjects = 80;
        private static bool textureMode = false;
        private static int textureIndices = 10;
        private static string txtrDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\textures\"));
        private static Bitmap[] txtrBmps = new Bitmap[textureIndices];

        //private static genObject[] genDelegates = new genObject[] { genRandomRect, genRandomSquare, genRandomEllipse, genRandomCircle, genRandomLine, genRandomTriangle };
        //private static genObject[] genDelegates = new genObject[] { genRandomRect };
        //private static genObject[] genDelegates = new genObject[] { genRandomCircle };
        private static string[] genDelegates = new string[] { "Rectangle", "Square", "Ellipse", "Circle", "Line", "Triangle"};
       
        public static (GameField, DisplayObject[]) generateDrawField(int leftTopX, int leftTopY, int bottomRightX, int bottomRightY, int thickness, bool acceleration)
        {

            GameField CDrawField = new GameField(leftTopX, leftTopY, bottomRightX, bottomRightY, thickness);
            CDrawField.fillColor = Color.FromArgb(255, 255, 218);
            CDrawField.strokeColor = Color.FromArgb(128, 128, 128);

            InitializeGenerators(bottomRightX - leftTopX, bottomRightY - leftTopY, thickness);

            DisplayObject[] objects = genObjects(genDelegates, acceleration);
            objects = genObjectsCircles();

            return (CDrawField, objects);

        }
        private static DisplayObject[] genObjectsCircles()
        {
            DisplayObject[] objects = new DisplayObject[amntOfObjects];
            CircleObject obj;

            for (int j = 0; j < amntOfObjects; j++)
            {
                // acquire current generation 
                bool isValid = false;
                obj = genRandomObject("Circle") as CircleObject;
                while (!isValid)
                {
                    isValid = true;
                    obj = genRandomObject("Circle") as CircleObject;
                    for (int i = 0; i < j; i++)
                    {
                        if (isValid)
                        {
                            isValid = !obj.CheckCircleCollision(objects[i] as CircleObject);
                        }
                    }
                }

                if (textureMode)
                {
                    obj.fillBMP = txtrBmps[j % textureIndices];
                }
                else
                {
                    Color clr = getRandomColor();
                    obj.fillColor = Color.FromArgb(clr.R, clr.G, clr.B);
                }

                //field.AddObject(obj);
                objects[j] = obj;
                (int velocityModulo, int velocityAngle) = generateVelocityVector();
                obj.velModulo = velocityModulo;
                obj.velAlpha = velocityAngle;
                
                //if (isAccelerated)
                //{
                //    (int accelerationModulo, int accelerationAngle) = generateAccelerationVector();
                //    obj.accModulo = accelerationModulo;
                //    obj.accAlpha = accelerationAngle;
                //}

            }

            return objects;
        }

        private static DisplayObject[] genObjects(string[] generationArr, bool isAccelerated)
        {
            DisplayObject[] objects = new DisplayObject[generationArr.Length * amntOfObjects];
            DisplayObject obj;
            for (int i = 0; i < generationArr.Length; i++)
            {
                for (int j = 0; j < amntOfObjects; j++)
                {
                    // acquire current generation 
                    //obj = generationArr[i]();
                    obj = genRandomObject(generationArr[i]);
                    if (textureMode)
                    {
                        obj.fillBMP = txtrBmps[j % textureIndices];
                    }
                    else
                    {
                        Color clr = getRandomColor();
                        obj.fillColor = Color.FromArgb(clr.R, clr.G, clr.B);
                    }

                    //field.AddObject(obj);
                    objects[i * amntOfObjects + j] = obj;
                    (int velocityModulo, int velocityAngle) = generateVelocityVector();
                    obj.velModulo = velocityModulo;
                    obj.velAlpha = velocityAngle;

                    if (isAccelerated)
                    {
                        (int accelerationModulo, int accelerationAngle) = generateAccelerationVector();
                        obj.accModulo = accelerationModulo;
                        obj.accAlpha = accelerationAngle;
                    }

                }
            }
            return objects;
        }

        public static void InitializeGenerators(int fieldWidth, int fieldHeight, int borderThick)
        {
            actualW = fieldWidth - 2 * borderThick;
            actualH = fieldHeight - 2 * borderThick;

            for (int i = 0; i < textureIndices; i++)
            {
                //txtrBmps[i] = new Bitmap(Path.Combine(txtrDir, "txtr" + i % textureIndices + ".bmp"));
            }
        }

        public static DisplayObject genRandomObject(string objType) {
            int width = generateWidth();
            int height = generateHeight();
            int tlX, tlY;
            (tlX,tlY) = generateTopLeftRel(width, height);
            Color color = getRandomColor();

            //genRandomRect, genRandomSquare, genRandomEllipse, genRandomCircle, genRandomLine, genRandomTriangle

            DisplayObject obj;
            switch (objType) {
                case ("Rectangle"):
                    obj = new RectangleObject(tlX, tlY, tlX + width, tlY + height);
                    break;
                case ("Square"):
                    obj = new SquareObject(tlX, tlY, width);
                    break;
                case ("Ellipse"):
                    obj = new EllipseObject(tlX + width / 2, tlY + height / 2, width / 2, height / 2);
                    break;
                case ("Circle"):
                    obj = new CircleObject(tlX + width / 2, tlY + height / 2, width / 2);
                    break;
                case ("Line"):
                    int x1 = tlX;
                    int y1 = tlY;
                    int x2 = tlX + width;
                    int y2 = tlY + height;
                    obj = new LineObject(x1, y1, x2, y2);
                    break;
                case ("Triangle"):
                    obj = new TriangleObject(tlX, tlY, width, height);
                    break;
                default:
                    obj = new RectangleObject(tlX, tlY, tlX + width, tlY + height);
                    break;
            }
            obj.SetRotationAngle(generateAngle());
            return obj;
        }


        /// <summary>
        /// Given a width and a height, generates an anchor that will satisfy the quality of not being cut off by the window frame
        /// </summary>
        /// <param name="width">Width of the not-rotated frame of the object</param>
        /// <param name="height">Height of the not-rotated frame of the object</param>
        /// <returns>Anchor point</returns>
        //
        public static (int, int) generateAnchorRel(double width, double height)
        {
            // acquiring left top corner coordinates
            //
            // these coordinates must be calculated based on the idea
            // that the shape can be cut by window frame because of the 
            // position of the left top corner. So the top left corner
            // must be generated in bounds that include the case in which
            // the rotation is such that it is maximum length in any direction
            double maxBump;
            // as we calculate the rotation from the center of the object, the
            // maxBump will be calculated as half of the actual hypotenuse of
            // the frame
            maxBump = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2)) / 2;

            // that way, the minimum coordinate value for X is maxBump, while
            // the minimum is fieldWidth-maxBump. Same applies to Y coordinate
            int x = (int)Math.Floor(rand.NextDouble() * (actualW - 2 * maxBump) + maxBump);
            int y = (int)Math.Floor(rand.NextDouble() * (actualH - 2 * maxBump) + maxBump);
            return (x,y);
        }

        /*        public static Point generateAnchorAbs(double width, double height)
                {
                    Point p = generateAnchorRel(width, height);
                    p.X += topLeftX + borderT;
                    p.Y += topLeftY + borderT;
                    return p;
                }*/
        public static (int, int) generateTopLeftRel(int width, int height)
        {
            int x, y;
            (x, y) = generateAnchorRel(width, height);
            x -= width / 2;
            y -= height / 2;
            return (x,y);
        }
        /*        public static Point generateTopLeftAbs(int width, int height)
                {
                    Point topLeft = generateTopLeftRel(width, height);
                    topLeft.X += topLeftX;
                    topLeft.Y += topLeftY;
                    return topLeft;
                }*/

        public static Color getRandomColor()
        {
            return Color.FromArgb(255, (byte)rand.Next(), (byte)rand.Next(), (byte)rand.Next());
        }
    }
}
