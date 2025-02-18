using Dock.Model.Avalonia;
using Dock.Model.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;
using Docker.ViewModels;
using DockMvvmSample.ViewModels.Docks;

namespace DockMvvmSample.ViewModels;

public class DockFactory : Factory
{
    public DockFactory()
    {
        
    }
    
    public override IRootDock CreateLayout()
    {
        var document1 = new DocumentViewModel {Id = "Document1", Title = "Document1"};
        var document2 = new DocumentViewModel {Id = "Document2", Title = "Document2"};
        var document3 = new DocumentViewModel {Id = "Document3", Title = "Document3", CanClose = true};
        
        var documentDock = new CustomDocumentDock
        {
            IsCollapsable = false,
            ActiveDockable = document1,
            VisibleDockables = CreateList<IDockable>(document1, document2, document3),
            CanCreateDocument = true
        };

        var mainLayout = new ProportionalDock
        {
            Orientation = Orientation.Horizontal,
            VisibleDockables = CreateList<IDockable>
            (
              
                documentDock
               
            )
        };
        

        var rootDock = CreateRootDock();

        rootDock.IsCollapsable = false;
        rootDock.ActiveDockable = mainLayout;
        rootDock.DefaultDockable = mainLayout;
        rootDock.VisibleDockables = CreateList<IDockable>(mainLayout);
        
        return rootDock;
    }
}