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
        }

        public void OnSearchExecute()
        {
            SelectedItem = Users.FirstOrDefault(x => x.Id == Id);
        }

        public ICommand SearchCommand { get; }
    }
}
