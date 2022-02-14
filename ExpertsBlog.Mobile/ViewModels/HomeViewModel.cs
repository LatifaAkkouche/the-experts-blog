using ExpertsBlog.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExpertsBlog.Mobile.ViewModels
{
    internal class HomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BlogPost> blogposts;
        public ObservableCollection<BlogPost> BlogPosts
        {
            get => blogposts;
            set => SetProperty(ref blogposts, value);
        }

        public HomeViewModel()
        {
            BlogPosts = new ObservableCollection<BlogPost>();

            for (int i = 0; i < 10; i++)
            {
                BlogPost post = new BlogPost();
                BlogPosts.Add(post);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetProperty<T>(ref T storage, T value, Action afterAction = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            afterAction?.Invoke();
            return true;
        }
    }
}
