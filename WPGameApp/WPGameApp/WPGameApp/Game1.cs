using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace WPGameApp
{
    /// <summary>
    /// Tipo principal del juego
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // This is a texture we can render.
        Texture2D Background;

        Texture2D Skeleton1;
        Texture2D Skeleton2;
        Texture2D Skeleton3;
        Texture2D Skeleton4;
        Texture2D Skeleton5;

        Texture2D Zombie1;
        Texture2D Zombie2;
        Texture2D Zombie3;
        Texture2D Zombie4;
        Texture2D Zombie5;

        Texture2D ZombieX1;
        Texture2D ZombieX2;
        Texture2D ZombieX3;
        Texture2D Dead;

        Texture2D Linea;
        Texture2D Corazon1;
        Texture2D Corazon2;
        Texture2D Corazon3;

        // T - Tamaño
        // FA - Fotograma Actual
        // H - Hoja / Imágen
        Point T_Skeleton = new Point(64, 68);
        Point FA_Skeleton = new Point(0, 0);
        Point H_Skeleton = new Point(7, 1);

        /*Point T_Skeleton = new Point(64, 68);
        Point FA_Skeleton = new Point(0, 0);
        Point H_Skeleton = new Point(8, 1);
        */
        Point T_Zombie = new Point(32, 49);
        Point FA_Zombie = new Point(0, 0);
        Point H_Zombie = new Point(2, 3);

        Point T_ZombieX = new Point(58, 50);
        Point FA_ZombieX = new Point(0, 0);
        Point H_ZombieX = new Point(5, 1);

        Point T_Dead = new Point(43, 53);
        Point FA_Dead = new Point(0, 0);
        Point H_Dead = new Point(5, 2);

        Point T_Linea = new Point(10, 100);

        // P - Posición
        Vector2 P_Skeleton1 = new Vector2(10, -100);
        Vector2 P_Skeleton2 = new Vector2(100, -280);
        Vector2 P_Skeleton3 = new Vector2(200, -350);
        Vector2 P_Skeleton4 = new Vector2(300, -180);
        Vector2 P_Skeleton5 = new Vector2(400, -250);

        Vector2 P_Zombie1 = new Vector2(50, -160);
        Vector2 P_Zombie2 = new Vector2(150, -250);
        Vector2 P_Zombie3 = new Vector2(250, -370);
        Vector2 P_Zombie4 = new Vector2(350, -320);
        Vector2 P_Zombie5 = new Vector2(450, -190);
        
        Vector2 P_Dead;
        Vector2 P_ZombieX1 = new Vector2(-100, -100);
        Vector2 P_ZombieX2 = new Vector2(-100, -100);
        Vector2 P_ZombieX3 = new Vector2(-100, -100);
        Vector2 P_Corazon1 = new Vector2(200, 745);
        Vector2 P_Corazon2 = new Vector2(280, 745);
        Vector2 P_Corazon3 = new Vector2(360, 745);

        // Sonido 
        SoundEffect Bang;

        // Letras
        string Puntos = " Puntos : 0.0";
        SpriteFont Fuente;

        int Score = 0;
        int Corazon = 3;

        int TimeCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // La velocidad de fotogramas predeterminada para Windows Phone es de 30 fps.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
      
            // Amplía la duración de la batería con bloqueo.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            // Pantalla Completa!
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;

            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;         
        }

        /// <summary>
        /// Permite que el juego realice la inicialización que necesite para empezar a ejecutarse.
        /// Aquí es donde puede solicitar cualquier servicio que se requiera y cargar todo tipo de contenido
        /// no relacionado con los gráficos. Si se llama a base.Initialize, todos los componentes se enumerarán
        /// e inicializarán.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: agregue aquí su lógica de inicialización
            base.Initialize();
        }

        /// <summary>
        /// LoadContent se llama una vez por juego y permite cargar todo el contenido.
        /// </summary>

        protected override void LoadContent()
        {
            // Crea un SpriteBatch nuevo para dibujar texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content para cargar aquí el contenido del juego
            
            // Cargar los Sprites
            Background = Content.Load<Texture2D >("Background");
            Skeleton1 = Content.Load<Texture2D>("SkeletonXX");
            Skeleton2 = Content.Load<Texture2D>("SkeletonXX");
            Skeleton3 = Content.Load<Texture2D>("SkeletonXX");
            Skeleton4 = Content.Load<Texture2D>("SkeletonXX");
            Skeleton5 = Content.Load<Texture2D>("SkeletonXX");

            Zombie1 = Content.Load <Texture2D>("ZombiesXX");
            Zombie2 = Content.Load<Texture2D>("ZombiesXX");
            Zombie3 = Content.Load<Texture2D>("ZombiesXX");
            Zombie4 = Content.Load<Texture2D>("ZombiesXX");
            Zombie5 = Content.Load<Texture2D>("ZombiesXX");
            
            ZombieX1 = Content.Load<Texture2D>("ZombieUnborn");
            ZombieX2 = Content.Load<Texture2D>("ZombieUnborn");
            ZombieX3 = Content.Load<Texture2D>("ZombieUnborn");
            Dead = Content.Load<Texture2D>("Dead");

            // Cargar los Rectangulos
            Linea = Content.Load<Texture2D>("Linea");
            Corazon1 = Content.Load<Texture2D>("Corazon");
            Corazon2 = Content.Load<Texture2D>("Corazon");
            Corazon3 = Content.Load<Texture2D>("Corazon");

            // Cargar el Texto
            Fuente = Content.Load<SpriteFont>("MsgFont");
        }

        /// <summary>
        /// UnloadContent se llama una vez por juego y permite descargar
        /// todo el contenido.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: descargue aquí todo el contenido que no pertenezca a ContentManager
        }

        /// <summary>
        /// Permite al juego ejecutar lógica para, por ejemplo, actualizar el mundo,
        /// buscar colisiones, recopilar entradas y reproducir audio.
        /// </summary>
        /// <param name="gameTime">Proporciona una instantánea de los valores de tiempo.</param>

        protected override void Update(GameTime gameTime)
        {
            // Permite salir del juego
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: agregue aquí su lógica de actualización
            UpdateSprite(gameTime);

            // Touch

            TouchCollection Touches = TouchPanel.GetState();

            if (Touches.Count > 0 && Touches[0].State == TouchLocationState.Moved)
            {
                Point Touch = new Point((int)Touches[0].Position.X, (int)Touches[0].Position.Y);

                if (Touch.X > P_Zombie1.X && Touch.X < P_Zombie1.X + Zombie1.Bounds.Right && Touch.Y > P_Zombie1.Y && Touch.Y < P_Zombie1.Y + Zombie1.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Zombie1.X, P_Zombie1.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;

                    if (P_Zombie1.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Zombie1.X += 50;
                        P_Zombie1.Y = -100;
                    }
                    else
                    {
                        P_Zombie1.X = 20;
                        P_Zombie1.Y = -1000;
                    }
                }

                if (Touch.X > P_Zombie2.X && Touch.X < P_Zombie2.X + Zombie2.Bounds.Right && Touch.Y > P_Zombie2.Y && Touch.Y < P_Zombie2.Y + Zombie2.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Zombie2.X, P_Zombie2.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Zombie2.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Zombie2.X += 30;
                        P_Zombie2.Y = -280;
                    }
                    else
                    {
                        P_Zombie2.X = 10;
                        P_Zombie2.Y = -280;
                    }
                }

                if (Touch.X > P_Zombie3.X && Touch.X < P_Zombie3.X + Zombie3.Bounds.Right && Touch.Y > P_Zombie3.Y && Touch.Y < P_Zombie3.Y + Zombie3.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Zombie3.X, P_Zombie3.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Zombie3.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Zombie3.X += 50;
                        P_Zombie3.Y = -350;
                    }
                    else
                    {
                        P_Zombie3.X = 30;
                        P_Zombie3.Y = -350;
                    }
                }

                if (Touch.X > P_Zombie4.X && Touch.X < P_Zombie4.X + Zombie4.Bounds.Right && Touch.Y > P_Zombie4.Y && Touch.Y < P_Zombie4.Y + Zombie4.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Zombie4.X, P_Zombie4.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Zombie4.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Zombie4.X += 30;
                        P_Zombie4.Y = -180;
                    }
                    else
                    {
                        P_Zombie4.X = 10;
                        P_Zombie4.Y = -180;
                    }
                }

                if (Touch.X > P_Zombie5.X && Touch.X < P_Zombie5.X + Zombie5.Bounds.Right && Touch.Y > P_Zombie5.Y && Touch.Y < P_Zombie5.Y + Zombie5.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Zombie5.X, P_Zombie5.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Zombie5.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Zombie5.X += 30;
                        P_Zombie5.Y = -250;
                    }
                    else
                    {
                        P_Zombie5.X = 20;
                        P_Zombie5.Y = -250;
                    }
                }

                if (Touch.X > P_Skeleton1.X && Touch.X < P_Skeleton1.X + Skeleton1.Bounds.Right && Touch.Y > P_Skeleton1.Y && Touch.Y < P_Skeleton1.Y + Skeleton1.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Skeleton1.X, P_Skeleton1.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Skeleton1.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Skeleton1.X += 30;
                        P_Skeleton1.Y = -160;
                    }
                    else
                    {
                        P_Skeleton1.X = 30;
                        P_Skeleton1.Y = -160;
                    }
                }

                if (Touch.X > P_Skeleton2.X && Touch.X < P_Skeleton2.X + Skeleton2.Bounds.Right && Touch.Y > P_Skeleton2.Y && Touch.Y < P_Skeleton2.Y + Skeleton2.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Skeleton2.X, P_Skeleton2.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Skeleton2.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Skeleton2.X += 50;
                        P_Skeleton2.Y = -250;
                    }
                    else
                    {
                        P_Skeleton2.X = 10;
                        P_Skeleton2.Y = -250;
                    }
                }

                if (Touch.X > P_Skeleton3.X && Touch.X < P_Skeleton3.X + Skeleton3.Bounds.Right && Touch.Y > P_Skeleton3.Y && Touch.Y < P_Skeleton3.Y + Skeleton3.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Skeleton3.X, P_Skeleton3.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Skeleton3.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Skeleton3.X += 30;
                        P_Skeleton3.Y = -370;
                    }
                    else
                    {
                        P_Skeleton3.X = 40;
                        P_Skeleton3.Y = -370;
                    }
                }

                if (Touch.X > P_Skeleton4.X && Touch.X < P_Skeleton4.X + Skeleton4.Bounds.Right && Touch.Y > P_Skeleton4.Y && Touch.Y < P_Skeleton4.Y + Skeleton4.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Skeleton4.X, P_Skeleton4.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Skeleton4.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Skeleton4.X += 30;
                        P_Skeleton4.Y = -20;
                    }
                    else
                    {
                        P_Skeleton4.X = 10;
                        P_Skeleton4.Y = -20;
                    }
                }

                if (Touch.X > P_Skeleton5.X && Touch.X < P_Skeleton5.X + Skeleton5.Bounds.Right && Touch.Y > P_Skeleton5.Y && Touch.Y < P_Skeleton5.Y + Skeleton5.Bounds.Bottom)
                {
                    FA_Dead = new Point(0, 0);
                    P_Dead = new Vector2(P_Skeleton5.X, P_Skeleton5.Y);
                    Score += 10;
                    Puntos = "Puntos : " + Score;
                    if (P_Skeleton5.X < GraphicsDevice.DisplayMode.Width - 50)
                    {
                        P_Skeleton5.X += 50;
                        P_Skeleton5.Y = -200;
                    }
                    else
                    {
                        P_Skeleton5.X = 30;
                        P_Skeleton5.Y = -200;
                    }
                }
            }

            // Linea

            if (P_Zombie1.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Zombie1.X, P_Zombie1.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                //DeadShot(P_Zombie1);
                if (P_Zombie1.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Zombie1.X += 30;
                    P_Zombie1.Y = -200;
                }
                else
                {
                    P_Zombie1.X = 10;
                    P_Zombie1.Y = -200;
                }
                GameOver();
            }

            if (P_Zombie2.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Zombie2.X, P_Zombie2.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Zombie2.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Zombie2.X += 30;
                    P_Zombie2.Y = -200;
                }
                else
                {
                    P_Zombie2.X = 20;
                    P_Zombie2.Y = -200;
                }
                GameOver();
            }

            if (P_Zombie3.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Zombie3.X, P_Zombie3.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Zombie3.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Zombie3.X += 30;
                    P_Zombie3.Y = -200;
                }
                else
                {
                    P_Zombie3.X = 30;
                    P_Zombie3.Y = -200;
                }
                GameOver();
            }

            if (P_Zombie4.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Zombie4.X, P_Zombie4.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Zombie4.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Zombie4.X += 30;
                    P_Zombie4.Y = -200;
                }
                else
                {
                    P_Zombie4.X = 10;
                    P_Zombie4.Y = -200;
                }
                GameOver();
            }

            if (P_Zombie5.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Zombie5.X, P_Zombie5.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Zombie5.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Zombie5.X += 30;
                    P_Zombie5.Y = -200;
                }
                else
                {
                    P_Zombie5.X = 20;
                    P_Zombie5.Y = -200;
                }
                GameOver();
            }

            if (P_Skeleton1.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Skeleton1.X, P_Skeleton1.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Skeleton1.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Skeleton1.X += 30;
                    P_Skeleton1.Y = -110;
                }
                else
                {
                    P_Skeleton1.X = 30;
                    P_Skeleton1.Y = -110;
                }
                GameOver();
            }

            if (P_Skeleton2.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Skeleton2.X, P_Skeleton2.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Skeleton2.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Skeleton2.X += 30;
                    P_Skeleton2.Y = -110;
                }
                else
                {
                    P_Skeleton2.X = 10;
                    P_Skeleton2.Y = -110;
                }
                GameOver();
            }

            if (P_Skeleton3.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Skeleton3.X, P_Skeleton3.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Skeleton3.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Skeleton3.X += 30;
                    P_Skeleton3.Y = -110;
                }
                else
                {
                    P_Skeleton3.X = 30;
                    P_Skeleton3.Y = -110;
                }
                GameOver();
            }

            if (P_Skeleton4.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Skeleton4.X, P_Skeleton4.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Skeleton4.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Skeleton4.X += 30;
                    P_Skeleton4.Y = -110;
                }
                else
                {
                    P_Skeleton4.X = 10;
                    P_Skeleton4.Y = -110;
                }
                GameOver();
            }

            if (P_Skeleton5.Y > 630)
            {
                FA_Dead = new Point(0, 0);
                P_Dead = new Vector2(P_Skeleton5.X, P_Skeleton5.Y);
                Score -= 100;
                Puntos = "Puntos : " + Score;
                if (P_Skeleton5.X < GraphicsDevice.DisplayMode.Width - 50)
                {
                    P_Skeleton5.X += 30;
                    P_Skeleton5.Y = -110;
                }
                else
                {
                    P_Skeleton5.X = 30;
                    P_Skeleton5.Y = -110;
                }
                GameOver();
            }


            base.Update(gameTime);
        }

        void GameOver()
        {
            if (Corazon == 3)
            {
                P_Corazon3 = new Vector2(-100, -100);
                FA_ZombieX = new Point(0,0);
                P_ZombieX3 = new Vector2(380, 725);        
            }
            if (Corazon == 2)
            {
                P_Corazon2 = new Vector2(-100, -100);
                FA_ZombieX = new Point(0,0);
                P_ZombieX2 = new Vector2(300, 725);
            }
            if (Corazon == 1)
            {
                P_Corazon1 = new Vector2(-100, -100);
                FA_ZombieX = new Point(0,0);
                P_ZombieX1 = new Vector2(220, 725);
            }
            if (Corazon <= 0)
            {
                Puntos = "Game Over! - Puntos : " + Score;
                P_ZombieX1 = new Vector2(-100, -100);
                P_ZombieX2 = new Vector2(-100, -100);
                P_ZombieX3 = new Vector2(-100, -100);
            }
            Corazon--;
        }

        void UpdateSprite(GameTime gameTime)
        {
            TimeCount += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeCount < 100)
            {
                ++FA_Skeleton.X;
                if (FA_Skeleton.X >= H_Skeleton.X)
                {
                    FA_Skeleton.X = 0;
                    ++FA_Skeleton.Y;
                    if (FA_Skeleton.Y >= H_Skeleton.Y)
                    {
                        FA_Skeleton.Y = 0;
                    }
                    ++FA_Skeleton.X;
                }
            }

            if (TimeCount < 40)
            {
                
                ++FA_Zombie.X;
                if (FA_Zombie.X >= H_Zombie.X)
                {
                    FA_Zombie.X = 0;
                    ++FA_Zombie.Y;
                    if (FA_Zombie.Y >= H_Zombie.Y)
                    {
                        FA_Zombie.Y = 0;
                    }
                    ++FA_Zombie.X;
                }
            }

            if (TimeCount < 100)
            {
                ++FA_Dead.X;
                if (FA_Dead.X >= H_Dead.X)
                {
                    FA_Dead.X = 0;
                    ++FA_Dead.Y;
                    ++FA_Dead.X;
                }
            }

           
            if (TimeCount < 200)
            {
                if (FA_ZombieX.X >= H_ZombieX.X)
                {
                    FA_ZombieX.X = 3;
                   // FA_ZombieX.Y = 0;
                }
                else
                {
                    if (TimeCount < 40 && FA_ZombieX.X < 3)
                    {
                        ++FA_ZombieX.X;
                    }
                }
            }

            P_Skeleton1.Y += 2;
            P_Skeleton2.Y += 2;
            P_Skeleton3.Y += 2;
            P_Skeleton4.Y += 2;
            P_Skeleton5.Y += 2;

            P_Zombie1.Y += 1;
            P_Zombie2.Y += 1;
            P_Zombie3.Y += 1;
            P_Zombie4.Y += 1;
            P_Zombie5.Y += 1;
            
            if (TimeCount > 200)
                TimeCount = 0;
            
        }


            
            //SpritePosicion.X += 5f;
            //SpritePosicion.Y += 5f;
            /*
            // Move the sprite by speed, scaled by elapsed time.
            SpritePosicion += SpriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            int MaxX = graphics.GraphicsDevice.Viewport.Width - MyTexture.Width;
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - MyTexture.Height;
            int MinY = 0;

            // Check for bounce.
            if (SpritePosicion.X > MaxX)
            {
                SpriteSpeed.X *= -1;
                SpritePosicion.X = MaxX;
            }

            else if (SpritePosicion.X < MinX)
            {
                SpriteSpeed.X *= -1;
                SpritePosicion.X = MinX;
            }

            if (SpritePosicion.Y > MaxY)
            {
                SpriteSpeed.Y *= -1;
                SpritePosicion.Y = MaxY;
            }

            else if (SpritePosicion.Y < MinY)
            {
                SpriteSpeed.Y *= -1;
                SpritePosicion.Y = MinY;
            }
            */
        
            

        /// <summary>
        /// Se llama cuando el juego debe realizar dibujos por sí mismo.
        /// </summary>
        /// <param name="gameTime">Proporciona una instantánea de los valores de tiempo.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);

            // TODO: agregue aquí el código de dibujo

            // Draw the sprite.
            spriteBatch.Begin();

            spriteBatch.Draw (Background, new Rectangle(0, 0, GraphicsDevice .DisplayMode.Width , GraphicsDevice.DisplayMode.Height), Color.White);
            spriteBatch.DrawString(Fuente, Puntos, new Vector2(20, 750), Color.White);
            
            spriteBatch.Draw(Skeleton1, P_Skeleton1, new Rectangle(FA_Skeleton.X * T_Skeleton.X, FA_Skeleton.Y * T_Skeleton.Y, T_Skeleton.X, T_Skeleton.Y), Color.White);
            spriteBatch.Draw(Skeleton2, P_Skeleton2, new Rectangle(FA_Skeleton.X * T_Skeleton.X, FA_Skeleton.Y * T_Skeleton.Y, T_Skeleton.X, T_Skeleton.Y), Color.White);
            spriteBatch.Draw(Skeleton3, P_Skeleton3, new Rectangle(FA_Skeleton.X * T_Skeleton.X, FA_Skeleton.Y * T_Skeleton.Y, T_Skeleton.X, T_Skeleton.Y), Color.White);
            spriteBatch.Draw(Skeleton4, P_Skeleton4, new Rectangle(FA_Skeleton.X * T_Skeleton.X, FA_Skeleton.Y * T_Skeleton.Y, T_Skeleton.X, T_Skeleton.Y), Color.White);
            spriteBatch.Draw(Skeleton5, P_Skeleton5, new Rectangle(FA_Skeleton.X * T_Skeleton.X, FA_Skeleton.Y * T_Skeleton.Y, T_Skeleton.X, T_Skeleton.Y), Color.White);
            
            spriteBatch.Draw(Zombie1, P_Zombie1, new Rectangle(FA_Zombie.X * T_Zombie.X, FA_Zombie.Y * T_Zombie.Y, T_Zombie.X, T_Zombie.Y), Color.White);
            spriteBatch.Draw(Zombie2, P_Zombie2, new Rectangle(FA_Zombie.X * T_Zombie.X, FA_Zombie.Y * T_Zombie.Y, T_Zombie.X, T_Zombie.Y), Color.White);
            spriteBatch.Draw(Zombie3, P_Zombie3, new Rectangle(FA_Zombie.X * T_Zombie.X, FA_Zombie.Y * T_Zombie.Y, T_Zombie.X, T_Zombie.Y), Color.White);
            spriteBatch.Draw(Zombie4, P_Zombie4, new Rectangle(FA_Zombie.X * T_Zombie.X, FA_Zombie.Y * T_Zombie.Y, T_Zombie.X, T_Zombie.Y), Color.White);
            spriteBatch.Draw(Zombie5, P_Zombie5, new Rectangle(FA_Zombie.X * T_Zombie.X, FA_Zombie.Y * T_Zombie.Y, T_Zombie.X, T_Zombie.Y), Color.White);

            spriteBatch.Draw(ZombieX1, P_ZombieX1, new Rectangle(FA_ZombieX.X * T_ZombieX.X, FA_ZombieX.Y * T_ZombieX.Y, T_ZombieX.X, T_ZombieX.Y), Color.White);
            spriteBatch.Draw(ZombieX2, P_ZombieX2, new Rectangle(FA_ZombieX.X * T_ZombieX.X, FA_ZombieX.Y * T_ZombieX.Y, T_ZombieX.X, T_ZombieX.Y), Color.White);
            spriteBatch.Draw(ZombieX3, P_ZombieX3, new Rectangle(FA_ZombieX.X * T_ZombieX.X, FA_ZombieX.Y * T_ZombieX.Y, T_ZombieX.X, T_ZombieX.Y), Color.White);
            spriteBatch.Draw(Dead, P_Dead, new Rectangle(FA_Dead.X * T_Dead.X, FA_Dead.Y * T_Dead.Y, T_Dead.X, T_Dead.Y), Color.White);

            spriteBatch.Draw(Linea, new Vector2(0, 680), new Rectangle(0, 0, 480, 30), Color.White);
            spriteBatch.Draw(Corazon1, P_Corazon1, new Rectangle(0, 0, 100, 100), Color.White);
            spriteBatch.Draw(Corazon2, P_Corazon2, new Rectangle(0, 0, 100, 100), Color.White);
            spriteBatch.Draw(Corazon3, P_Corazon3, new Rectangle(0, 0, 100, 100), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
