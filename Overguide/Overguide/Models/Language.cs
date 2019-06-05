using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Overguide.Models
{
    public class Language
    {
        public string Name { get; set; }
        public ImageSource image { get; set; }
        public int audio { get; set; }
        public string nametag { get; set; }
        public string imageName { get; set; }

        public Language(string name, string nametag, ImageSource image)
        {
            this.Name = name;
            this.nametag = nametag;
            this.image = image;
        }

        public Language()
        {
        }
    }
}