using System;
using GlazeWM.Domain.Containers;
using GlazeWM.Infrastructure;
using GlazeWM.Infrastructure.WindowsApi;

namespace GlazeWM.Domain.Windows
{
  public sealed class TilingWindow : Window, IResizable
  {
    public double SizePercentage { get; set; } = 1;

    private readonly ContainerService _containerService =
      ServiceLocator.GetRequiredService<ContainerService>();

    public override int Width => _containerService.GetWidthOfResizableContainer(this);
    public override int Height => _containerService.GetHeightOfResizableContainer(this);
    public override int X => _containerService.GetXOfResizableContainer(this);
    public override int Y => _containerService.GetYOfResizableContainer(this);

    public TilingWindow(
      IntPtr handle,
      Rect floatingPlacement,
      RectDelta borderDelta
    ) : base(handle, floatingPlacement, borderDelta)
    {
    }

    public TilingWindow(
      IntPtr handle,
      Rect floatingPlacement,
      RectDelta borderDelta,
      double sizePercentage
    ) : base(handle, floatingPlacement, borderDelta)
    {
      SizePercentage = sizePercentage;
    }
    public void EnterBSPMode()
{
    // Create a BSP tree for the window.
    bsp.BSPTree tree = new bsp.BSPTree(this.Position, this.Size);

    // Add the window to the BSP tree.
    tree.AddWindow(this.Handle);

    // Calculate the BSP layout for the window.
    bsp.BSPLayout layout = tree.CalculateLayout();

    // Set the window's position and size to the BSP layout.
    this.Position = layout.Position;
    this.Size = layout.Size;
}
  }
}
