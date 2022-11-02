using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BlogApp.App_Classes
{
    public class Settings
    {
        public static Size Picture

        {
            get
            { 
                Size result= new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);  //Webconfig'den Appsettings de sw olanı alıyorum
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return result;
            }
        }
        public static Size PictureMediumSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return result;

            }
        }
        public static Size PictureLargeSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return result;

            }
        }
        public static Size WriterPhotoSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["writer"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["writer"]);
                return result;

            }
        }
    }
}