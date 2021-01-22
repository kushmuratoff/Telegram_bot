using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Args;
using System.IO;
using Telegram.Bot.Requests;

namespace tg_bot
{
    class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("670612603:AAEvEFVifdn3jBv00S3QVi_AxvCNTg-xw7s");
        static ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup();
        static ReplyKeyboardMarkup markup1 = new ReplyKeyboardMarkup();
        public string xabar="";
        static InlineKeyboardMarkup inline = new InlineKeyboardMarkup();
        static void Main(string[] args)
        {
            bot.StartReceiving();
            bot.OnMessage += bot_xabar;
          //  bot.OnCallbackQuery += bot_chaqirish;
          //  bot.OnMessage += dars_jadval;
            Console.ReadLine();
             
        }
        private static async void bot_chaqirish(object sender,Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            if(!string.IsNullOrEmpty(e.CallbackQuery.Data))
            {
                var data=e.CallbackQuery.Data;
                var cid=e.CallbackQuery.Message.Chat.Id;
                var cbid=e.CallbackQuery.Id;
                if(data=="sayhi")
                {
                    await bot.AnswerCallbackQueryAsync(cbid,"salom foydalanuvchi");
                    await bot.SendTextMessageAsync(cid, "sdfsdfsd");

                }
                else  if(data=="saybye")
                {
                    await bot.AnswerCallbackQueryAsync(cbid,"Xayr foydalanuvchi",true);
                }
            }
        }
        private static async void dars_jadval(object sender,Telegram.Bot.Args.MessageEventArgs e)
        {
            
        }

        private static async void bot_xabar(object sender,Telegram.Bot.Args.MessageEventArgs e)
        {
            var txt = e.Message.Text;
            var cid = e.Message.Chat.Id;
            var name = e.Message.From.FirstName + " " + e.Message.From.LastName;
            var vaqti = e.Message.Date;
            var vid = e.Message.From.Id;
            
            Console.WriteLine("{0}- {1} : {2} --{3}", vid, name, txt, vaqti);
            if(txt=="/start")
            {
                markup.ResizeKeyboard = true;
                markup.Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Talabalar Ro'yxati")
                     },
                      new KeyboardButton[]
                    {
                        new KeyboardButton("Dars Jadvali"),
                        new KeyboardButton("Semestr Natijalari"),
                        new KeyboardButton("Talabalar Ma'lumoti")
                        
                    
                     },
                     new KeyboardButton[]
                    {
                        new KeyboardButton("Ekranga")
                     }
                };
                inline.InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardCallbackButton("Dars Jadvali","sayhi"),
                        new InlineKeyboardCallbackButton("Talabalar","saybye")


                       }
                    
                };


                await bot.SendTextMessageAsync(cid, "inline bot", ParseMode.Default, false, false, 0, inline);
                
                await bot.SendTextMessageAsync(cid, "IAT Yo'nalishi Boti",ParseMode.Default,false,false,0,markup);
            }
            else if (txt == "Semestr Natijalari")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Talabalar_sem.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += i.ToString() + "    " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);


            }




            else if (txt == "Talabalar Ro'yxati")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Talabalar.txt");
            while(uqish.Peek()>=0)
            {
                i++;
                jadval+=i.ToString()+"    " + uqish.ReadLine()+"\n";
            }
            uqish.Close();
            Console.WriteLine(jadval);

            await bot.SendTextMessageAsync(cid, jadval);
           
            
            }

            else if (txt == "Haftalik")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Haftalik.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  "+ uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Dushanba")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Dush.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Seshanba")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Sesh.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Chorshanba")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Chor.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Payshanba")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Pay.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Juma")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Juma.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }
            else if (txt == "Shanba")
            {
                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Shan.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);
            }

            else if (txt == "Talabalar Ma'lumoti")
            {

                string jadval = "";
                int i = 0;
                StreamReader uqish = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//Talabalar_manzil.txt");
                while (uqish.Peek() >= 0)
                {
                    i++;
                    jadval += i.ToString() + "  " + uqish.ReadLine() + "\n";
                }
                uqish.Close();
                Console.WriteLine(jadval);

                await bot.SendTextMessageAsync(cid, jadval);



            }
                else if(txt=="Dars Jadvali")
            {
                markup.ResizeKeyboard = true;
                markup.Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
              
                        new KeyboardButton("Haftalik")
                      

                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Dushanba"),
                        new KeyboardButton("Seshanba"),
                        new KeyboardButton("Chorshanba")

                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Payshanba"),
                        new KeyboardButton("Juma"),
                        new KeyboardButton("Shanba")

                    },
                    new KeyboardButton[]
                    {
                          new KeyboardButton("ortga")
}
                       
                };



                await bot.SendTextMessageAsync(cid, "Hafta kunini tanlang ??", ParseMode.Default, false, false, 0, markup);
            
            }
                else if(txt=="ortga")
            {
                markup.ResizeKeyboard = true;
                markup.Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Talabalar Ro'yxati")
                     },
                      new KeyboardButton[]
                    {
                        new KeyboardButton("Dars Jadvali"),
                        new KeyboardButton("Semestr Natijalari"),
                        new KeyboardButton("Talabalar Ma'lumoti")
                        

                     }
                    // new KeyboardButton[]
                    //{
                    //    new KeyboardButton("Ekranga")
                    // }
                };               
                await bot.SendTextMessageAsync(cid, "Bosh Menyu", ParseMode.Default, false, false, 0, markup);
               
            }
            else if (txt == "Ekranga")
            {
                inline.InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardCallbackButton("Dars Jadvali","sayhi"),
                        new InlineKeyboardCallbackButton("Talabalar","saybye")


                       }
                    
                };

                await bot.SendTextMessageAsync(cid, "inline bot", ParseMode.Default, false, false, 0, inline);
            }
            else
            {
                await bot.SendTextMessageAsync(cid, txt);
            }
            

        }
       
    }
}
