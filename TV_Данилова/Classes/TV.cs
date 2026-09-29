using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace TV_Данилова.Classes
{
    public class TV
    {
       ///<summary> Канал который воспроизводится
        private int activeChannel;
       ///<summary> Звук который установлена телевизоре
       private int activeVolume;
                
       public int ActiveChannel
       {
            get
            {
                return activeChannel;
            }
            set
            {
                if(activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;


            }
       }
        public List<Channel> Channels = new List<Channel>();

        public TV()
        {
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №3 Объявление классов и создание объектов в C#.mp4",
                Src = @"C:\Users\aooshchepkov\Downloads\1.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №4 Использование методов в ООП Разница между простыми и статическими методами.mp4"
                Src = @"C: \Users\aooshchepkov\Downloads\2.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое задание №5 Конструкторы в ООП.mp4",
                Src = @"C:\Users\aooshchepkov\Downloads\3.mp4"
            });
        }
        public void SwapChanell(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);

            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content =  this.Channels[this.ActiveChannel].Name;
        }

        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);

        }
        public void UpSound()
        {

        }
        public
        void DownSound()
        {

        }










    }
}
