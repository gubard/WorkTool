﻿namespace WorkTool.Core.Modules.AvaloniaUi.Controls;

public class SBytePropertyInfoTemplatedControl : PropertyInfoTemplatedControl<sbyte, NumericUpDown>
{
    static SBytePropertyInfoTemplatedControl()
    {
        IObjectValue.ObjectProperty.AddOwner<SBytePropertyInfoTemplatedControl>(x => x.Object);
    }

    public SBytePropertyInfoTemplatedControl()
        : base(
            (property, _, control, _) =>
            {
                control
                    .GetObservable(NumericUpDown.ValueProperty)
                    .Subscribe(x => property.Value = (sbyte)x);

                property.GetObservable(ValueProperty).Subscribe(x => control.Value = x);
            }
        ) { }
}
