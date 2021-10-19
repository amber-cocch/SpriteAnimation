using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


using Microsoft.Xna.Framework.Input;

namespace monogame_assignment
{
    public class PlayGame : GameScreen
    {
        //public string Path;
        //public Image Image;

        //public ContentManager Content;
        [XmlIgnore]
        public Vector2 Position;
        [XmlIgnore]
        public List<Sprite> _sprites;

        public override void LoadContent()
        {
            base.LoadContent();
            //Image.LoadContent();

            
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            var animations = new Dictionary<string, Animation>()
            {
                {"walkUp", new Animation(content.Load<Texture2D>("Player/walkUp"), 3) },
                {"walkDown", new Animation(content.Load<Texture2D>("Player/walkDown"), 3) },
                {"walkLeft", new Animation(content.Load<Texture2D>("Player/walkLeft"), 3) },
                {"walkRight", new Animation(content.Load<Texture2D>("Player/walkRight"), 3) },
            };

            _sprites = new List<Sprite>()
            {
                new Sprite(animations)
                {
                    Position = new Vector2(100,100),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                }
            };


        }

        public override void UnloadContent()
        {
            base.UnloadContent();
           //Image.UnloadContent();

        }

        public override void Update(GameTime gameTime)
        {
            
           //Image.Update(gameTime);

            foreach(var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
                Debug.WriteLine("PlayGameSpriteUpdate called");
            }
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {


            
            //Image.Draw(spriteBatch);
          
            foreach(var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
                
            }
            base.Draw(spriteBatch);

        }
    }
}

