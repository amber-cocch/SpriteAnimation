using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Diagnostics;

namespace monogame_assignment
{
    public class Sprite
    {
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;

        protected Texture2D _texture;
        public Input Input;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationManager != null)
                {
                    _animationManager.Position = _position;
                }
            }
        }

        public float Speed = 1f;
        public Vector2 Velocity;

        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
                Debug.WriteLine("Move up");
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
                Debug.WriteLine("Move doen");
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
                Debug.WriteLine("Move L");
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
                Debug.WriteLine("Move R");
            }
        }

        protected virtual void SetAnimation()
        {
            if(Velocity.X > 0)
            {
                _animationManager.Play(_animations["walkRight"]);

            }
            else if (Velocity.X <0)
            {
                _animationManager.Play(_animations["walkLeft"]);

            }
            else if (Velocity.Y > 0)
            {
                _animationManager.Play(_animations["walkDown"]);

            }
            else if (Velocity.Y < 0)
            {
                _animationManager.Play(_animations["walkUp"]);

            }

        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        //for no animation sprites
        /*
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }*/

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            
            SetAnimation();

            _animationManager.Update(gameTime);

            Position += Velocity;
            Debug.WriteLine("Position changed:" + Position);
            Velocity = Vector2.Zero;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, Color.White);
            }
            else if (_animationManager != null)
            {
                _animationManager.Draw(spriteBatch);
            }
            else throw new Exception("Something not right :/");
        }

    }
}
