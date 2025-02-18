using CommunityToolkit.Mvvm.ComponentModel;
using Dock.Model.Controls;
using Dock.Model.Core;
using DockMvvmSample.ViewModels;

namespace Docker.ViewModels;

public partial class MainWindowViewModel : ObservableValidator
{
   private readonly IFactory? _factory;
   [ObservableProperty] private IRootDock? _layout;
   
   public MainWindowViewModel()
   {
      _factory = new DockFactory();
      Layout = _factory?.CreateLayout();
   }
   
   public void CloseLayout()
   {
      if (Layout is IDock dock)
      {
         if (dock.Close.CanExecute(null))
         {
            dock.Close.Execute(null);
         }
      }
   }

   public void ResetLayout()
   {
      if (Layout is not null)
      {
         if (Layout.Close.CanExecute(null))
         {
            Layout.Close.Execute(null);
         }
      }

      var layout = _factory?.CreateLayout();
      if (layout is not null)
      {
         _factory?.InitLayout(layout);
         Layout = layout;
      }
   }
}