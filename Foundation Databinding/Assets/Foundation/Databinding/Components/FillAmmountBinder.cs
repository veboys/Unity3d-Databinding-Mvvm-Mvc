// -------------------------------------
//  Domain		: Avariceonline.com
//  Author		: Nicholas Ventimiglia
//  Product		: Unity3d Foundation
//  Published		: 2015
//  -------------------------------------
using Foundation.Databinding.View;
using UnityEngine;
using UnityEngine.UI;

namespace Foundation.Databinding.Components
{
    /// <summary>
    /// Binds the image's fillAmount value. (CooldownTimer)
    /// </summary>
    [RequireComponent(typeof(Image))]
    [AddComponentMenu("Foundation/Databinding/FillAmmountBinder")]
    public class FillAmmountBinder : BindingBase
    {
        protected Image Target;

        [HideInInspector]
        public BindingInfo FillValueBinding = new BindingInfo { BindingName = "FillValue" };

        protected bool IsInit;

        protected void Awake()
        {
            Init();
        }

        public override void Init()
        {
            if (IsInit)
                return;
            IsInit = true;

            Target = GetComponent<Image>();

            FillValueBinding.Action = UpdateFill;
            FillValueBinding.Filters = BindingFilter.Properties;
            FillValueBinding.FilterTypes = new[] { typeof(float) };
        }


        private void UpdateFill(object arg)
        {
            if (Target)
            {
                Target.fillAmount = (float) arg;
            }
        }
    }
}