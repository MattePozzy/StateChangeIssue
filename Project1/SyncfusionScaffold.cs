using MauiReactor;
using MauiReactor.Internals;

namespace SgatOffline2.Components
{
    [Scaffold(typeof(Syncfusion.Maui.Core.SfView))]
    public abstract partial class SfView { }

    [Scaffold(typeof(Syncfusion.Maui.Core.SfContentView))]
    public abstract partial class SfContentView { }

    public abstract partial class SfContentView<T>
    {
        protected override void OnAddChild(VisualNode widget, MauiControls.BindableObject childControl)
        {
            NativeControl.EnsureNotNull();
            if (childControl is MauiControls.View content)
            {
                NativeControl.Content = content;
            }

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, MauiControls.BindableObject childControl)
        {
            NativeControl.EnsureNotNull();
            if (childControl is MauiControls.View content &&
                NativeControl.Content == content)
            {
                NativeControl.Content = null;
            }


            base.OnRemoveChild(widget, childControl);
        }
    }

    [Scaffold(typeof(Syncfusion.Maui.Inputs.SfMaskedEntry))]
    public partial class SfMaskedEntry { }

    [Scaffold(typeof(Syncfusion.Maui.Core.SfTextInputLayout))]
    public partial class SfTextInputLayout { }

    [Scaffold(typeof(Syncfusion.Maui.Inputs.SfNumericEntry))]
    public partial class SfNumericEntry { }
}