using Dock.Model.Controls;
using Dock.Model.Core;
using Dock.Model.Mvvm;

namespace Docker.ViewModels;

public class DockFactor : Factory
{
    private IRootDock? m_RootDock;
    
    public override IRootDock CreateLayout()
    {
        m_RootDock = CreateRootDock();
        return m_RootDock;
    }

    public override void InitLayout(IDockable layout)
    {
        
    }
}