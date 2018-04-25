using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Halls_of_Valhalla
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 portalTextbox, spdText, attText, defText, dexText, wisText, vitText;
        Rectangle mapWindow, UIWindow, playerbox, roombox, portalOne, portalTwo, portalThree, portalFour, portalFive;
        Rectangle weapdownBox, armorBox, armordownBox, useBox2, lootBox, shotBox, oldmouseBox;
        Rectangle healthBar, healthBarBack, magicBar, magicBarBack, titleScreenBox, enterbox, weaponBox, useBox;
        Texture2D weapdown, armor, armordown, lootbag, shot;
        Texture2D none, playerW, playerA, playerS, playerD, player, mainroom, titleScreen, door, enter, tutorial, tutorialflipped, deathscreen, weapon, useslots;
        KeyboardState keypad, oldpad;
        MouseState mouse;
        SpriteFont font, font2;

        int lootx, looty;
        int hp, titleTF, mp, att, def, dex, wis, vit, vitTick, vitTime, wisTick, wisTime, r, g, b, clockTick, playerx, playery, weaponDMG, weaponMP;
        string portalName = "Testing";
        double hpscaler, hpbarWidth, maxhp, mpscaler, mpbarWidth, maxmp, spd, pixelSpd;

        //controls rooms/screens
        bool enterboxTF, levelChange, weapdownTF, armordownTF, isWeaponLoot = false, isArmorLoot = false, playerLB = false, isWeapDragging = false, isArmorDragging = false;
        //variables used to test the game
        Vector2 testbox1, testbox2, testbox3, testbox4;
        //string 1, 2, 3, 4;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            //boxes used for testing the game variables
            testbox1 = new Vector2(0, 0);
            testbox2 = new Vector2(0, 50);
            testbox3 = new Vector2(0, 100);
            testbox4 = new Vector2(0, 150);

            //essential rectangles
            mapWindow = new Rectangle(0, 0, (GraphicsDevice.Viewport.Width * 3/4), GraphicsDevice.Viewport.Height);
            UIWindow = new Rectangle((GraphicsDevice.Viewport.Width * 3/4), 0, 200, GraphicsDevice.Viewport.Height);
            playerbox = new Rectangle(0, 0, 32, 32);
            titleScreenBox = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            enterbox = new Rectangle(UIWindow.X + 120, UIWindow.Height - 276, 60, 30);
            useBox = new Rectangle(UIWindow.X + 36, UIWindow.Y + 150, 128, 40);
            useBox2 = new Rectangle(UIWindow.X + 36, UIWindow.Y + 450, 128, 40);
            weaponBox = new Rectangle(useBox.X+4, useBox.Y + 4, 32, 32);
            armorBox = new Rectangle(weaponBox.Right + 12, useBox.Y + 4, 32, 32);

            //vectors for text on UI
            portalTextbox = new Vector2(UIWindow.X + 10, UIWindow.Height - 275);

            attText = new Vector2(UIWindow.X + 10, (UIWindow.Height / 3) + 50);
            defText = new Vector2(UIWindow.X + 100, (UIWindow.Height / 3) + 50);
            spdText = new Vector2(UIWindow.X + 10, (UIWindow.Height / 3) + 65);
            dexText = new Vector2(UIWindow.X + 100, (UIWindow.Height / 3) + 65);
            vitText = new Vector2(UIWindow.X + 10, (UIWindow.Height / 3) + 80);
            wisText = new Vector2(UIWindow.X + 100, (UIWindow.Height / 3) + 80);

            //playerbox is set to the middle of the mapWindow
            playerbox.X = (mapWindow.Height / 2) - 16;
            playerbox.Y = (mapWindow.Width / 2) - 16;

            //initializes values for a new character
            maxhp = 100;
            maxmp = 100;
            hp = 100;
            mp = 100;
            spd = 75;
            att = 0;
            def = 0;
            dex = 10;
            wis = 10;
            vit = 10;

            //75 milliseconds per 1 hp/mp
            vitTime = 75;
            wisTime = 75;

            //damage = att * multiplier
            weaponDMG = att * 1;
            weaponMP = 10;

            //makes cursor appear
            this.IsMouseVisible = true;

            //starts game at title screen
            titleTF = 0;

            //player coords for color detection
            playerx = 563;
            playery = 447;

            //starts colors at blue
            r = 0;
            g = 0;
            b = 100;

            //
            levelChange = true;

            //loads starter weapon
            weapdownTF = false;

            //loads starter armor
            armordownTF = false;

            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads font and default blank texture
            none = Content.Load<Texture2D>("none");
            font = Content.Load<SpriteFont>("SpriteFont1");
            font2 = Content.Load<SpriteFont>("SpriteFont2");

            //loads player textures
            playerW = Content.Load<Texture2D>("PlayerW");
            playerS = Content.Load<Texture2D>("PlayerS");
            playerA = Content.Load<Texture2D>("PlayerA");
            playerD = Content.Load<Texture2D>("PlayerD");
            player = Content.Load<Texture2D>("PlayerS");

            shot = Content.Load<Texture2D>("shot");

            //loads map textures
            mainroom = Content.Load<Texture2D>("mainroom");
            door = Content.Load<Texture2D>("door");
            tutorial = Content.Load<Texture2D>("Tutorial");
            tutorialflipped = Content.Load<Texture2D>("Tutorial Flipped");
            lootbag = Content.Load<Texture2D>("lootbag");

            //title screen texture
            titleScreen = Content.Load<Texture2D>("titlescreen");
            deathscreen = Content.Load<Texture2D>("deathscreen");

            //loads UI textures
            enter = Content.Load<Texture2D>("enter");
            useslots = Content.Load<Texture2D>("usageslots");

            //weapon textures
            weapon = Content.Load<Texture2D>("starter weapon");
            weapdown = Content.Load<Texture2D>("weapdown");

            //armor textures
            armor = Content.Load<Texture2D>("starter armor");
            armordown = Content.Load<Texture2D>("armordown");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keypad = Keyboard.GetState();
            mouse = Mouse.GetState();

            //defines mouse cursor as rectangle
            Rectangle mousepixel = new Rectangle(mouse.X, mouse.Y, 1, 1); 


            //allows game to exit
            if (keypad.IsKeyDown(Keys.Escape))
                this.Exit();

            ///If game is on title screen
            ///

            if (titleTF == -1)
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                    this.Exit();
            }

            if (titleTF == 0)
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                    titleTF = 1;
            }

            ///
            ///If game is on title screen


            ///IF GAME IS ON MAIN ROOM
            ///

            if (titleTF == 1)
            {
                if (levelChange == true)
                {
                    hp = (int)maxhp;
                    mp = (int)maxmp;
                    roombox = new Rectangle(-256, -596, 1120, 1344);
                    portalOne = new Rectangle((roombox.X + 544), (roombox.Y + 408), 32, 32);
                    portalTwo = new Rectangle((roombox.X + 410), (roombox.Y + 656), 32, 32);
                    portalThree = new Rectangle((roombox.X + 410), (roombox.Y + 528), 32, 32);
                    portalFour = new Rectangle((roombox.X + 679), (roombox.Y + 528), 32, 32);
                    portalFive = new Rectangle((roombox.X + 679), (roombox.Y + 656), 32, 32);
                    playerx = 563;
                    playery = 447;
                    lootx = 300;
                    looty = 300;
                    levelChange = false;
                }

                // needed for character movement and stats
                
                Color[] CharTopColorData = new Color[1];
                mainroom.GetData<Color>(0, new Rectangle(playerx, (playery-17), 1, 1), CharTopColorData, 0, 1);

                Color[] CharBottomColorData = new Color[1];
                mainroom.GetData<Color>(0, new Rectangle(playerx, (playery+17), 1, 1), CharBottomColorData, 0, 1);

                Color[] CharLeftColorData = new Color[1];
                mainroom.GetData<Color>(0, new Rectangle((playerx-17), playery, 1, 1), CharLeftColorData, 0, 1);

                Color[] CharRightColorData = new Color[1];
                mainroom.GetData<Color>(0, new Rectangle((playerx+17), playery, 1, 1), CharRightColorData, 0, 1);

                pixelSpd = spd * .12;

                if (keypad.IsKeyDown(Keys.W))
                {
                    if(CharBottomColorData[0] != new Color(0, 0, 0, 255))
                    {
                        roombox.Y += (int)pixelSpd;
                        portalOne.Y += (int)pixelSpd;
                        portalTwo.Y += (int)pixelSpd;
                        portalThree.Y += (int)pixelSpd;
                        portalFour.Y += (int)pixelSpd;
                        portalFive.Y += (int)pixelSpd;
                        playery += (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        looty += (int)pixelSpd;

                        shotBox.Y += (int)pixelSpd;
                        oldmouseBox.Y += (int)pixelSpd;
                    }
                    player = playerW;
                }

                if (keypad.IsKeyDown(Keys.S))
                {
                    if(CharTopColorData[0] != new Color(0, 0, 0, 255))
                    {
                        roombox.Y -= (int)pixelSpd;
                        portalOne.Y -= (int)pixelSpd;
                        portalTwo.Y -= (int)pixelSpd;
                        portalThree.Y -= (int)pixelSpd;
                        portalFour.Y -= (int)pixelSpd;
                        portalFive.Y -= (int)pixelSpd;
                        playery -= (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        looty -= (int)pixelSpd;

                        shotBox.Y -= (int)pixelSpd;
                        oldmouseBox.Y -= (int)pixelSpd;
                    }
                    player = playerS;
                }

                if (keypad.IsKeyDown(Keys.A))
                {
                    if (CharRightColorData[0] != new Color(0, 0, 0, 255))
                    {
                        roombox.X += (int)pixelSpd;
                        portalOne.X += (int)pixelSpd;
                        portalTwo.X += (int)pixelSpd;
                        portalThree.X += (int)pixelSpd;
                        portalFour.X += (int)pixelSpd;
                        portalFive.X += (int)pixelSpd;
                        playerx += (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        lootx += (int)pixelSpd;

                        shotBox.X += (int)pixelSpd;
                        oldmouseBox.X += (int)pixelSpd;
                    }
                    player = playerA;
                }

                if (keypad.IsKeyDown(Keys.D))
                {
                    if(CharLeftColorData[0] != new Color(0, 0, 0, 255))
                    {
                        roombox.X -= (int)pixelSpd;
                        portalOne.X -= (int)pixelSpd;
                        portalTwo.X -= (int)pixelSpd;
                        portalThree.X -= (int)pixelSpd;
                        portalFour.X -= (int)pixelSpd;
                        portalFive.X -= (int)pixelSpd;
                        playerx -= (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        lootx -= (int)pixelSpd;

                        shotBox.X -= (int)pixelSpd;
                        oldmouseBox.X -= (int)pixelSpd;
                    }
                    player = playerD;    
                }


                if (portalOne.Intersects(playerbox))
                {
                    portalName = "Main Menu:";
                    enterboxTF = true;
                }

                else if (portalTwo.Intersects(playerbox))
                {
                    portalName = "Tutorial:";
                    enterboxTF = true;
                }
                else if (portalThree.Intersects(playerbox))
                {
                    portalName = "Level 1:";
                    enterboxTF = true;
                }
                else if (portalFour.Intersects(playerbox))
                {
                    portalName = "Level 2:";
                    enterboxTF = true;
                }
                else if (portalFive.Intersects(playerbox))
                {
                    portalName = "Level 3:";
                    enterboxTF = true;
                }
                else
                {
                    portalName = " ";
                    enterboxTF = false;
                 
                }

                if (keypad.IsKeyDown(Keys.T) && oldpad.IsKeyUp(Keys.T) && playerbox.Intersects(portalTwo))
                {
                    titleTF = 2;
                    levelChange = true;
                }

                if (keypad.IsKeyDown(Keys.T) && oldpad.IsKeyUp(Keys.T) && playerbox.Intersects(portalOne))
                {
                    titleTF = 0;
                    levelChange = true;
                }

            }

            ///
            ///IF GAME IS ON MAIN ROOM


            ///IF GAME IS ON TUTORIAL LEVEL
            ///
            if (titleTF == 2)
            {
                if (levelChange == true)
                {
                    hp = (int)maxhp;
                    mp = (int)maxmp;
                    playerx = 392;
                    playery = 143;
                    portalOne = new Rectangle(396, 145, 32, 32);
                    portalTwo = new Rectangle(288, -1043, 32, 32);
                    portalThree = new Rectangle(-10000, 0, 32, 32);
                    portalFour = new Rectangle(-10000, 0, 32, 32);
                    portalFive = new Rectangle(-10000, 0, 32, 32);
                    roombox = new Rectangle(-92, -1165, 784, 1608);
                    lootx = 300;
                    looty = 300;
                    levelChange = false;
                }

                Color[] CharTopColorData = new Color[1];
                tutorialflipped.GetData<Color>(0, new Rectangle(playerx, (playery-17), 1, 1), CharTopColorData, 0, 1);

                Color[] CharBottomColorData = new Color[1];
                tutorialflipped.GetData<Color>(0, new Rectangle(playerx, (playery+17), 1, 1), CharBottomColorData, 0, 1);

                Color[] CharLeftColorData = new Color[1];
                tutorialflipped.GetData<Color>(0, new Rectangle((playerx-17), playery, 1, 1), CharLeftColorData, 0, 1);

                Color[] CharRightColorData = new Color[1];
                tutorialflipped.GetData<Color>(0, new Rectangle((playerx+17), playery, 1, 1), CharRightColorData, 0, 1);

                pixelSpd = spd * .12;

                if (keypad.IsKeyDown(Keys.W))
                {
                    if(CharBottomColorData[0] != new Color(0, 0, 0, 255))
                    {
                        portalOne.Y += (int)pixelSpd;
                        portalTwo.Y += (int)pixelSpd;
                        roombox.Y += (int)pixelSpd;
                        playery += (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        looty += (int)pixelSpd;

                        shotBox.Y += (int)pixelSpd;
                        oldmouseBox.Y += (int)pixelSpd;
                    }
                    player = playerW;
                }

                if (keypad.IsKeyDown(Keys.S))
                {
                    if(CharTopColorData[0] != new Color(0, 0, 0, 255))
                    {
                        portalOne.Y -= (int)pixelSpd;
                        portalTwo.Y -= (int)pixelSpd;
                        roombox.Y -= (int)pixelSpd;
                        playery -= (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        looty -= (int)pixelSpd;

                        shotBox.Y -= (int)pixelSpd;
                        oldmouseBox.Y -= (int)pixelSpd;
                    }
                    player = playerS;
                }

                if (keypad.IsKeyDown(Keys.A))
                {
                    if (CharRightColorData[0] != new Color(0, 0, 0, 255))
                    {
                        portalOne.X += (int)pixelSpd;
                        portalTwo.X += (int)pixelSpd;
                        roombox.X += (int)pixelSpd;
                        playerx += (int)pixelSpd;

                        if(isWeaponLoot == true || isArmorLoot == true)
                        lootx += (int)pixelSpd;

                        shotBox.X += (int)pixelSpd;
                        oldmouseBox.X += (int)pixelSpd;
                    }
                    player = playerA;
                }

                if (keypad.IsKeyDown(Keys.D))
                {
                    if(CharLeftColorData[0] != new Color(0, 0, 0, 255))
                    {
                        portalOne.X -= (int)pixelSpd;
                        portalTwo.X -= (int)pixelSpd;
                        roombox.X -= (int)pixelSpd;
                        playerx -= (int)pixelSpd;

                        if (isWeaponLoot == true || isArmorLoot == true)
                        lootx -= (int)pixelSpd;

                        shotBox.X -= (int)pixelSpd;
                        oldmouseBox.X -= (int)pixelSpd;
                    }
                    player = playerD;    
                }

                if (portalOne.Intersects(playerbox))
                {
                    portalName = "Empty Portal";
                }

                else if (portalTwo.Intersects(playerbox))
                {
                    portalName = "Finished!";
                    enterboxTF = true;
                }
                else
                    portalName = " ";

                if (CharTopColorData[0] == new Color(255, 4, 4, 255) || CharTopColorData[0] == new Color(255, 80, 4, 255))
                {
                    if ((clockTick%2)==1)
                    hp -= 2;
                }
                if (keypad.IsKeyDown(Keys.T) && oldpad.IsKeyUp(Keys.T) && playerbox.Intersects(portalTwo))
                {
                    titleTF = 1;
                    levelChange = true;
                }

            }
                ///
                ///IF GAME IS ON TUTORIAL LEVEL


                ///stats adjusting themselves
                ///

                if (vitTick == vitTime)
                {
                    if (hp < maxhp)
                        hp += 1;

                    vitTick = 0;
                }

                if (wisTick == wisTime)
                {
                    if (mp < maxmp)
                        mp += 1;

                    wisTick = 0;
                }
                hpscaler = 180 / maxhp;
                hpbarWidth = hpscaler * hp;
                healthBar = new Rectangle(UIWindow.X + 10, (UIWindow.Height / 3), (int)hpbarWidth, 15);
                healthBarBack = new Rectangle(UIWindow.X + 10, (UIWindow.Height / 3), 180, 15);

                mpscaler = 180 / maxmp;
                mpbarWidth = mpscaler * mp;
                magicBar = new Rectangle(UIWindow.X + 10, (UIWindow.Height / 3) + 25, (int)mpbarWidth, 15);
                magicBarBack = new Rectangle(UIWindow.X + 10, (UIWindow.Height / 3) + 25, 180, 15);
                ///
                /// Stats adjusting themselves

                
                /// TESTING THE FUNCTIONALITY OF THE GAME
                if (keypad.IsKeyDown(Keys.M) && oldpad.IsKeyUp(Keys.M) && wis < 75)
                {
                    wis++;
                    wisTime--;
                    wisTick = 0;

                    if (wisTime <= 0)
                    {
                        wisTime = 1;
                        wisTick = 0;
                    }
                }

                if (keypad.IsKeyDown(Keys.G) && oldpad.IsKeyUp(Keys.G))
                    maxhp += 50;

                /// TESTING THE FUNCTIONALITY OF THE GAME



            //press space to shoot
                if (keypad.IsKeyDown(Keys.Space) && oldpad.IsKeyUp(Keys.Space))
                {
                    if (mp >= weaponMP && isWeaponLoot == false)
                    {
                        mp -= weaponMP;
                        shotBox = new Rectangle(playerbox.X + 8, playerbox.Y - 8, 20, 35);
                        oldmouseBox = new Rectangle(shotBox.X+8, shotBox.Y - 296, 10, 10);
                    }
                }

                    if(isWeaponLoot == false)
                        if (shotBox.Y > oldmouseBox.Y)
                            shotBox.Y -= 5;
                    if(shotBox.Intersects(oldmouseBox))
                        shotBox = new Rectangle();


                    // draws a dropdown box for item stats
                    //for weapon
                    if (mousepixel.Intersects(weaponBox))
                        weapdownTF = true;
                    else
                        weapdownTF = false;


            if (weapdownTF == true)
                weapdownBox = new Rectangle(mousepixel.X-150, mousepixel.Y, 150, 200);



            //allows items to be dragged off and on to useBox
            if (mousepixel.Intersects(weaponBox) && mouse.LeftButton == ButtonState.Pressed && isArmorDragging == false)
            {
                isWeapDragging = true;
                weapdownTF = false;
                isWeaponLoot = false;
            }

            if (isWeapDragging == true)
            {
                weaponBox.X = mousepixel.X - 16;
                weaponBox.Y = mousepixel.Y - 16;
            }

                //if not dragged to UIWindow, weaponbox goes back to its slot
            if (mouse.LeftButton == ButtonState.Released && weaponBox.Intersects(UIWindow))
            {
                weaponBox = new Rectangle(useBox.X + 4, useBox.Y + 4, 32, 32);
                isWeapDragging = false;
            }

                //if dragged to mapWindow, weaponbox.X = Bag.X and weaponbox.X goes to a loot slot on bottom of screen
            if (mouse.LeftButton == ButtonState.Released && weaponBox.Intersects(mapWindow))
            {
                isWeaponLoot = true;
                isWeapDragging = false;
            }

                if (isWeaponLoot == true)
                {
                    weaponBox = new Rectangle(useBox2.X + 4, useBox2.Y + 4, 32, 32);
                    lootBox = new Rectangle(lootx-14, looty-6, 32, 32);
                }
                

            if (weapdownTF == true)
            {
                if (weaponBox.Intersects(useBox))
                    weaponBox = new Rectangle(useBox.X + 4, useBox.Y + 4, 32, 32);
            }


                //for armor
                if (mousepixel.Intersects(armorBox))
                    armordownTF = true;
                else
                    armordownTF = false;


            if (armordownTF == true)
                armordownBox = new Rectangle(mousepixel.X-150, mousepixel.Y, 150, 200);


            if (mousepixel.Intersects(armorBox) && mouse.LeftButton == ButtonState.Pressed && isWeapDragging == false)
            {
                isArmorDragging = true;
                armordownTF = false;
                isArmorLoot = false;
            }

            if (isArmorDragging == true)
            {
                armorBox.X = mousepixel.X - 16;
                armorBox.Y = mousepixel.Y - 16;
            }

            //if not dragged to mapwindow, weaponbox goes back to its slot
            if (mouse.LeftButton == ButtonState.Released && armorBox.Intersects(UIWindow))
            {
                armorBox = new Rectangle(useBox.X + 48, useBox.Y + 4, 32, 32);
                isArmorDragging = false;
            }

            //if dragged to mapWindow, weaponbox.X = Bag.X and weaponbox.X goes to a loot slot on bottom of screen
            if (mouse.LeftButton == ButtonState.Released && armorBox.Intersects(mapWindow))
            {
                isArmorLoot = true;
                isArmorDragging = false;
            }

            if (isArmorLoot == true)
            {
                armorBox = new Rectangle(useBox2.X + 48, useBox2.Y + 4, 32, 32);
                lootBox = new Rectangle(lootx-14, looty-6, 32, 32);
            }

            if (armordownTF == true)
            {
                if (armorBox.Intersects(useBox))
                    armorBox = new Rectangle(useBox.X + 48, useBox.Y + 4, 32, 32);
            }
            

            //calculates damage and bonuses if an item is in a box
            if (weaponBox.Intersects(useBox))
            {
                weaponDMG = att; //* multiplier *//
                att = 10;
            }
            else
            {
                att = 0;
                weaponMP = 0;
            }

                if (armorBox.Intersects(useBox))
                    def = 3;
                else
                    def = 0;


            //displays second usebox if player is standing on lootbag
                if (playerbox.Intersects(lootBox))
                    playerLB = true;
                else
                    playerLB = false;

                if (isWeaponLoot == false && isArmorLoot == false)
                    playerLB = false;

            //displays death screen if hp is less than 0
            if (hp <= 0)
                titleTF = -1;

            if (clockTick == 60)
            {
                r += 1;
                g += 1;
                b += 3;

                clockTick = 0;
            }

                vitTick++;
                wisTick++;

            oldpad = keypad;
            clockTick++;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color UIColor = new Color(64, 64, 66);
            Color background = new Color(r, g, b);
            GraphicsDevice.Clear(background);

            spriteBatch.Begin();

            if (titleTF == -1)
                spriteBatch.Draw(deathscreen, titleScreenBox, Color.White);

            ///if game is on title screen
            ///
            if (titleTF == 0)
                spriteBatch.Draw(titleScreen, titleScreenBox, Color.White);
            ///
            ///if game is not on title screen



            ///if game is not on title screen
            ///

            if (titleTF > 0)
            {
                // Draws Split Screen: 
                /* gamewindow */
                spriteBatch.Draw(none, mapWindow, Color.Black);

            if (titleTF == 1)
            {

                //Displays Map inside of the mapWindow
                spriteBatch.Draw(mainroom, roombox, Color.White);

                //Displays doors inside of gameroom
                spriteBatch.Draw(door, portalOne, Color.White);
                spriteBatch.Draw(door, portalTwo, Color.White);
                spriteBatch.Draw(door, portalThree, Color.White);
                spriteBatch.Draw(door, portalFour, Color.White);
                spriteBatch.Draw(door, portalFive, Color.White);
            }
            if (titleTF == 2)
            {
                //displays map for tutorial level
                spriteBatch.Draw(tutorial, roombox, Color.White);
                spriteBatch.Draw(door, portalOne, Color.White);
                spriteBatch.Draw(door, portalTwo, Color.White);
            }
                //shotBox is drawn
                spriteBatch.Draw(shot, shotBox, Color.White);

                //lootbag is drawn
                if (isWeaponLoot == true || isArmorLoot == true)
                spriteBatch.Draw(lootbag, lootBox, Color.White);

                //character displays according to button pressed
                spriteBatch.Draw(player, playerbox, Color.White);

                /* UI */
                spriteBatch.Draw(none, UIWindow, UIColor);

                //draws the health bar
                spriteBatch.Draw(none, healthBarBack, Color.Black);
                spriteBatch.Draw(none, healthBar, Color.Red);

                //draws the magic bar
                spriteBatch.Draw(none, magicBarBack, Color.Black);
                spriteBatch.Draw(none, magicBar, Color.CornflowerBlue);

                //draws the stats below hp/mp bars
                spriteBatch.DrawString(font2, "ATT: " + att.ToString(), attText, Color.White);
                spriteBatch.DrawString(font2, "DEF: " + def.ToString(), defText, Color.White);
                spriteBatch.DrawString(font2, "DEX: " + dex.ToString(), dexText, Color.White);
                spriteBatch.DrawString(font2, "SPD: " + spd.ToString(), spdText, Color.White);
                spriteBatch.DrawString(font2, "WIS: " + wis.ToString(), wisText, Color.White);
                spriteBatch.DrawString(font2, "VIT: " + vit.ToString(), vitText, Color.White);



                //portalText displays string value of portalName and enterbox is drawn
                spriteBatch.DrawString(font2, portalName, portalTextbox, Color.White);
                if (enterboxTF == true)
                {
                    spriteBatch.Draw(enter, enterbox, Color.White);
                    enterboxTF = false;
                }
                
                //main slots
                spriteBatch.Draw(useslots, useBox, Color.White);
                //loot slot 2
                if (playerLB == true)
                spriteBatch.Draw(useslots, useBox2, Color.White);
                //weapon
                spriteBatch.Draw(weapon, weaponBox, Color.White);
                //armor
                spriteBatch.Draw(armor, armorBox, Color.White);
                //covers 2nd loot slot
                if (playerLB == false && isWeapDragging == false && playerLB == false && isArmorDragging == false)
                    spriteBatch.Draw(none, useBox2, UIColor);

                //dropdowns
                if (weapdownTF == true && playerLB == false && weaponBox.Intersects(useBox))
                    spriteBatch.Draw(weapdown, weapdownBox, Color.White);
                if (armordownTF == true && playerLB == false && armorBox.Intersects(useBox))
                    spriteBatch.Draw(armordown, armordownBox, Color.White);
            }

            ///
            ///If game is not on title screen   




                //displays test varibales
                spriteBatch.DrawString(font2, (clockTick%2).ToString(), testbox1, Color.White);
                spriteBatch.DrawString(font2, hp.ToString(), testbox2, Color.White);
                //spriteBatch.DrawString(font2, playerLB.ToString(), testbox3, Color.White);
                //spriteBatch.DrawString(font2, CharRightColorData[0], testbox4, Color.White);
            



            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
