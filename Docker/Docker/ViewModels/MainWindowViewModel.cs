using Dock.Model.Core;

namespace Docker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   private readonly IFactory? m_Factory;

   public MainWindowViewModel()
   {
      m_Factory = new DockFactor();
      
   }
}