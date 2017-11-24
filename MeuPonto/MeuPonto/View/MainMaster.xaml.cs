using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuPonto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMaster : ContentPage
    {
        public ListView ListView;

        public MainMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuItem> MenuItems { get; set; }

            public MainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuItem>(new[]
                {
                    new MainMenuItem { Id = 0, IconSource = ImageSource.FromResource("MeuPonto.Imagens.home.png"), Title = "Home", TargetType = typeof(Home) },
                    new MainMenuItem { Id = 1, IconSource = ImageSource.FromResource("MeuPonto.Imagens.detalhes.png"),Title = "Dados Pessoais", TargetType = typeof(Usuario)},
                    new MainMenuItem { Id = 2, IconSource = ImageSource.FromResource("MeuPonto.Imagens.relatorio.png"),Title = "Relatórios", TargetType = typeof(Consulta) },                
                    new MainMenuItem { Id = 3, IconSource = ImageSource.FromResource("MeuPonto.Imagens.configuracao.png"),Title = "Configurações", TargetType = typeof(Home) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}