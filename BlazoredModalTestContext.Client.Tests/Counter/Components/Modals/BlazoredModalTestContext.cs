using System;
using Blazored.Modal;
using Blazored.Modal.Services;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace BlazoredModalTestContext.Client.Counter.Components.Modals
{
    public abstract class BlazoredModalTestContext : TestContext
    {
        private readonly ModalOptions defaultModalOptions = new()
        {
            Position = ModalPosition.Center,
            Class = "test",
            HideHeader = true,
            HideCloseButton = true,
            DisableBackgroundCancel = true,
            UseCustomLayout = false,
            Animation = new ModalAnimation(ModalAnimationType.FadeOut, 1),
            OverlayCustomClass = "overlay",
            FocusFirstElement = true
        };

        protected BlazoredModalTestContext()
        {
            Services.AddSingleton<IModalService>(new ModalService());
            JSInterop.Mode = JSRuntimeMode.Loose;
        }

        protected IRenderedComponent<TComponent> RenderModalComponentInsideCascadingBlazoredModal<TComponent>(
            Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder) where TComponent : class, IComponent
        {
            var blazoredModalInstanceComponent = RenderComponent<BlazoredModalInstance>(pb =>
                pb.Add(p => p.Options, defaultModalOptions));

            var modal = RenderComponent<CascadingBlazoredModal>(parameters =>
                parameters.AddCascadingValue(blazoredModalInstanceComponent.Instance)
                    .AddCascadingValue(new ModalOptions { Position = ModalPosition.Center })
                    .AddChildContent(parameterBuilder));

            return modal.FindComponent<TComponent>();
        }

        protected IRenderedComponent<TComponent> RenderModalComponentInsideCascadingBlazoredModal<TComponent>() where TComponent : class, IComponent
        {
            var blazoredModalInstanceComponent = RenderComponent<BlazoredModalInstance>(pb =>
                pb.Add(p => p.Options, defaultModalOptions));

            var modal = RenderComponent<CascadingBlazoredModal>(parameters =>
                parameters.AddCascadingValue(blazoredModalInstanceComponent.Instance)
                    .AddCascadingValue(new ModalOptions { Position = ModalPosition.Center })
                    .AddChildContent<TComponent>());

            return modal.FindComponent<TComponent>();
        }
    }
}