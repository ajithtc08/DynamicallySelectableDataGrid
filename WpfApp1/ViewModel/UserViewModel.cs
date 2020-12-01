using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private List<User> users;
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private User selectedItem;
        public User SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }


        public UserViewModel()
        {
            SearchCommand = new DelegateCommand(OnSearchExecute);
            users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Sooraj" });
            users.Add(new User() { Id = 2, Name = "Sunil" });
            users.Add(new User() { Id = 3, Name = "Senthil" });
            users.Add(new User() { Id = 4, Name = "Madan" });
            users.Add(new User() { Id = 5, Name = "Ajith" });
            users.Add(new User() { Id = 6, Name = "Anil" });
            users.Add(new User() { Id = 7, Name = "Vivek" });
            users.Add(new User() { Id = 8, Name = "Abin" });

            SelectedItem = Users.FirstOrDefault();
        }

        public void OnSearchExecute()
        {
            SelectedItem = Users.FirstOrDefault(x => x.Id == Id);
        }

        public ICommand SearchCommand { get; }
    }
}
