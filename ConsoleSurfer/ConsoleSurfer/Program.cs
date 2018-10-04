using System;
using System.Collections.Generic;

namespace ConsoleSurfer
{
    class Program
    {
        static public int windowHeight = 23;
        static public int windowWidth = 60;

        static public DateTime startTime;
        static public float timeDelta = 0.05f;

        static public List<Renderable> gameObjects = new List<Renderable>();

        public static void Main(string[] args)
        {
            RunGameLoop();
        }

        static public void DisplayMenu()
        {
            WriteLine("CONTROLS", ConsoleColor.Green);
        }

        //Game functions
        static public void RunGameLoop()
        {
            startTime = DateTime.Now;
            //Instantiate gameObjects

            string[] r1_m = new string[1];
            r1_m[0] = CurrentTime().ToString();
            /*
            {
                "/---\\",
                "|010|",
                "\\---/"};
                */

            Renderable r1 = new Renderable(Vector2.Zero(), r1_m);
            gameObjects.Add(r1);

            float lastTickTime = CurrentTime();

            while (true)
            {
                if (CurrentTime() >= lastTickTime + timeDelta)
                {
                    lastTickTime = CurrentTime();

                    ClearConsole();
                    GameTick();
                    Render();
                }
            }
        }

        static public void GameTick()
        {
            
        }

        static public float CurrentTime()
        {
            TimeSpan time = DateTime.Now - startTime;

            float value = (float)time.Seconds + (float)time.Milliseconds / 1000f;
            return value;
        }

        //Rendering functions
        static public void Render()
        {
            if (gameObjects.Count >= 0)
            {
                string[] canvas = new string[windowHeight];

                //fill canvas
                for (int i = 0; i < windowHeight; i ++)
                {
                    string s = "";

                    for (int j = 0; j < windowWidth; j ++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                s += "/";
                            else if (j == windowWidth - 1)
                                s += "\\";
                            else
                                s += "-";
                        }
                        else if (i == windowHeight - 1)
                        {
                            if (j == 0)
                                s += "\\";
                            else if (j == windowWidth - 1)
                                s += "/";
                            else
                                s += "-";
                        }
                        else if (j == 0 || j == windowWidth - 1)
                        {
                            s += "|";
                        }
                        else
                            s += " ";
                    }
                    canvas[i] = s;
                }

                //Emplace gameObjects
                for (int i = 0; i < gameObjects.Count; i ++)
                {
                    DrawRenderableToCanvas(ref canvas, gameObjects[i]);
                }

                //put the time @ (0,0)
                //DrawStringToCanvas(ref canvas, Vector2.Zero(), CurrentTime().ToString());

                //Render canvas
                for (int i = 0; i < canvas.Length; i ++)
                {
                    WriteLine(canvas[i]);
                }
            }
        }


        //Draw functions
        static public void DrawRenderableToCanvas (ref string[] canvas, Renderable renderable)
        {
            Vector2 transformedPos = new Vector2();

            for (int i = 0; i < renderable.model.Length; i ++)
            {
                transformedPos = TransformPoint(renderable.position + new Vector2(0, (renderable.model.Length / 2) - i));

                DrawStringToCanvas(ref canvas, transformedPos, renderable.model[i]);
            }
        }

        static public void DrawStringToCanvas(ref string[] canvas, Vector2 pos, String str, bool centerPosition = true)
        {
            string cs = canvas[(windowHeight / 2) - pos.y];
            char[] cs_array = cs.ToCharArray();

            int emplacement = (windowWidth / 2) + pos.x - ((centerPosition)? (str.Length / 2):0);

            for (int i = 0; i < cs_array.Length; i++)
            {
                if (i >= emplacement)
                {
                    int index = i - emplacement;

                    if (index < str.Length)
                    {
                        cs_array[i] = str[index];
                    }
                }
            }

            string result = "";
            for (int i = 0; i < cs_array.Length; i++)
            {
                result += cs_array[i].ToString();
            }

            canvas[(windowHeight / 2) - pos.y] = result;
        }

        //Math Functions

        static public float WaveFunction(float t, float verticalCoefficient, float horizontalCoefficient, float verticalOffset, bool absValue = false)
        {
            float value = verticalCoefficient * MathF.Sin(t * horizontalCoefficient) + verticalOffset;

            if (absValue)
                return Math.Abs(value);
            else
                return value;
        }

        /// <summary>
        /// Transforms the point from it's own space into screen space
        /// </summary>
        /// <returns>The point in screen space.</returns>
        /// <param name="point">Point.</param>
        static public Vector2 TransformPoint (Vector2 point)
        {
            return point + new Vector2(windowWidth / 2, windowHeight / 2);
        }

        //Console Methods
        static public void Space(int i = 1)
        {
            for (int index = 0; index < i; index++)
            {
                WriteLine("");
            }
        }

        static public void WriteLine(string txt)
        {
            Console.WriteLine(txt);
        }

        static public void WriteLine(string txt, ConsoleColor colour, bool resetColour = true)
        {
            SetConsoleColour(colour);
            WriteLine(txt);

            if (resetColour)
                ResetConsoleColour();
        }

        static public void EmplaceChar(char c, int emplacement)
        {
            for (int i = 0; i < emplacement; i++)
            {
                Write(" ");
            }

            Console.WriteLine(c.ToString());
        }

        static public void Write(string txt)
        {
            Console.Write(txt);
        }

        static public void SetConsoleColour(ConsoleColor colour)
        {
            Console.BackgroundColor = colour;
        }

        static public void ResetConsoleColour()
        {
            Console.BackgroundColor = ConsoleColor.White;
        }

        static public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
