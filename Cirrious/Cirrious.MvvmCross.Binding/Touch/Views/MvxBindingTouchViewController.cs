using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Binding.Touch.ExtensionMethods;
using Cirrious.MvvmCross.Binding.Touch.Interfaces;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Views;
using MonoTouch.Foundation;

namespace Cirrious.MvvmCross.Binding.Touch.Views
{
    public class MvxBindingTouchViewController<TViewModel>
        : MvxTouchViewController<TViewModel>
        , IMvxBindingTouchView 
        where TViewModel : class, IMvxViewModel
    {
        protected MvxBindingTouchViewController(MvxShowViewModelRequest request) 
            : base(request)
        {
        }

        protected MvxBindingTouchViewController(MvxShowViewModelRequest request, string nibName, NSBundle bundle) 
            : base(request, nibName, bundle)
        {
        }

        #region Shared area needed by all binding controllers

        private readonly List<IMvxUpdateableBinding> _bindings = new List<IMvxUpdateableBinding>();
        public List<IMvxUpdateableBinding> Bindings
        {
            get { return _bindings; }
        }

        public object DefaultBindingSource { get { return ViewModel; } }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.ClearBindings();
            }

            base.Dispose(disposing);
        }

        public override void ViewDidUnload()
        {
            this.ClearBindings();
            base.ViewDidUnload();
        }

        #endregion
    }
}