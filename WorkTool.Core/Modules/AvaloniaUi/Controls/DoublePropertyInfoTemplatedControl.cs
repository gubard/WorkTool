﻿namespace WorkTool.Core.Modules.AvaloniaUi.Controls;

public class DoublePropertyInfoTemplatedControl
    : PropertyInfoTemplatedControl<double, NumericUpDown>
{
    static DoublePropertyInfoTemplatedControl()
    {
        IObjectValue.ObjectProperty.AddOwner<DoublePropertyInfoTemplatedControl>(x => x.Object);
    }

    public DoublePropertyInfoTemplatedControl()
        : base(
            (property, _, control, _) =>
            {
                control
                    .GetObservable(NumericUpDown.ValueProperty)
                    .Subscribe(x => property.Value = x.HasValue ? (double)x.Value : 0);

                property.GetObservable(ValueProperty).Subscribe(x => control.Value = (decimal?)x);
            }
        ) { }
}
