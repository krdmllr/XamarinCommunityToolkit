﻿using Microsoft.Toolkit.Xamarin.Forms.UI.Views;
using Xamarin.Forms;

namespace Microsoft.Toolkit.Xamarin.Forms.Sample.Pages.Views
{
    public partial class RangeSliderPage
    {
        public RangeSliderPage()
            => InitializeComponent();

        void OnThumbSizeSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                RangeSlider.SetBinding(RangeSlider.LowerThumbSizeProperty, GetSliderValueBinding(LowerThumbSizeSlider));
                RangeSlider.SetBinding(RangeSlider.UpperThumbSizeProperty, GetSliderValueBinding(UpperThumbSizeSlider));
                return;
            }
            RangeSlider.LowerThumbSize = (double)RangeSlider.LowerThumbSizeProperty.DefaultValue;
            RangeSlider.UpperThumbSize = (double)RangeSlider.UpperThumbSizeProperty.DefaultValue;
        }

        Binding GetSliderValueBinding(object source)
            => new Binding
            {
                Path = Slider.ValueProperty.PropertyName,
                Source = source
            };

        void OnThumbRadiusSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (sender == LowerUpperThumbRadiusSwitch)
            {
                if (e.Value)
                {
                    RangeSlider.SetBinding(RangeSlider.LowerThumbRadiusProperty, GetSliderValueBinding(LowerThumbRadiusSlider));
                    RangeSlider.SetBinding(RangeSlider.UpperThumbRadiusProperty, GetSliderValueBinding(UpperThumbRadiusSlider));
                    return;
                }

                RangeSlider.LowerThumbRadius = (double)RangeSlider.LowerThumbRadiusProperty.DefaultValue;
                RangeSlider.UpperThumbRadius = (double)RangeSlider.UpperThumbRadiusProperty.DefaultValue;
                return;
            }

            if (sender == ThumbRadiusSwitch)
            {
                if (e.Value)
                {
                    RangeSlider.SetBinding(RangeSlider.ThumbRadiusProperty, GetSliderValueBinding(ThumbRadiusSlider));
                    OnThumbRadiusSwitchToggled(LowerUpperThumbRadiusSwitch, new ToggledEventArgs(LowerUpperThumbRadiusSwitch.IsToggled));
                    return;
                }

                RangeSlider.ThumbRadius = (double)RangeSlider.ThumbRadiusProperty.DefaultValue;
                OnThumbRadiusSwitchToggled(LowerUpperThumbRadiusSwitch, new ToggledEventArgs(false));
                return;
            }
        }

        void OnTrackRadiusSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                RangeSlider.SetBinding(RangeSlider.TrackRadiusProperty, GetSliderValueBinding(TrackRadiusSlider));
                return;
            }

            RangeSlider.TrackRadius = (double)RangeSlider.TrackRadiusProperty.DefaultValue;
        }
    }
}
