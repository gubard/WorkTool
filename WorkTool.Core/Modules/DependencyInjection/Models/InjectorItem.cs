﻿namespace WorkTool.Core.Modules.DependencyInjection.Models;

public readonly record struct InjectorItem(InjectorItemType Type, Expression Expression);
