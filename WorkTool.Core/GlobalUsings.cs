﻿global using System.Collections;
global using System.Data;
global using System.Data.Common;
global using System.Linq.Expressions;
global using System.Net;
global using System.Net.Sockets;
global using System.Reactive.Disposables;
global using System.Reactive.Subjects;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Security.Cryptography;
global using System.Text;
global using System.Text.Json;
global using System.Text.RegularExpressions;
global using System.Windows.Input;
global using System.Globalization;
global using System.Xml.Serialization;
global using System.Collections.Specialized;
global using System;
global using System.Net.Http.Json;
global using System.Net.Http.Headers;
global using System.Text.Json.Serialization;
global using System.ComponentModel;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;

global using Avalonia.Controls.Notifications;
global using Avalonia.Threading;
global using Avalonia.Utilities;
global using Avalonia.Data.Converters;
global using Avalonia.Media.Immutable;
global using Avalonia.Controls.Metadata;
global using Avalonia;
global using Avalonia.Collections;
global using Avalonia.Controls;
global using Avalonia.Controls.ApplicationLifetimes;
global using Avalonia.Controls.Presenters;
global using Avalonia.Controls.Primitives;
global using Avalonia.Controls.Shapes;
global using Avalonia.Controls.Templates;
global using Avalonia.Data;
global using Avalonia.Input;
global using Avalonia.Layout;
global using Avalonia.Media;
global using Avalonia.Metadata;
global using Avalonia.Styling;
global using Avalonia.Markup.Xaml;
global using Avalonia.ReactiveUI;

global using DynamicData;

global using EntityFrameworkCore.Triggers;

global using Microsoft.Data.SqlClient;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.FileProviders;
global using Microsoft.Extensions.Configuration.Json;

global using ReactiveUI;

global using FormatWith;

global using Material.Icons;

global using WorkTool.Core.Modules.Json.Extensions;
global using WorkTool.Core.Modules.SmsClub.Helpers;
global using WorkTool.Core.Modules.SmsClub.Services;
global using WorkTool.Core.Modules.Http.Models;
global using WorkTool.Core.Modules.SmsClub.Excpetions;
global using WorkTool.Core.Modules.Expressions.Extensions;
global using WorkTool.Core.Modules.SmsClub.Views;
global using WorkTool.Core.Modules.SmsClub.Interfaces;
global using WorkTool.Core.Modules.SmsClub.ViewModels;
global using WorkTool.Core.Modules.Http.Exceptions;
global using WorkTool.Core.Modules.SmsClub.Extensions;
global using WorkTool.Core.Modules.SmsClub.Models;
global using WorkTool.Core.Modules.AdoDotNet.Extensions;
global using WorkTool.Core.Modules.AdoDotNet.Interfaces;
global using WorkTool.Core.Modules.AdoDotNet.Models;
global using WorkTool.Core.Modules.Aes.Models;
global using WorkTool.Core.Modules.Application.Interfaces;
global using WorkTool.Core.Modules.AvaloniaUi.Attributes;
global using WorkTool.Core.Modules.AvaloniaUi.Controls;
global using WorkTool.Core.Modules.AvaloniaUi.Extensions;
global using WorkTool.Core.Modules.AvaloniaUi.Helpers;
global using WorkTool.Core.Modules.AvaloniaUi.Interfaces;
global using WorkTool.Core.Modules.AvaloniaUi.ViewModels;
global using WorkTool.Core.Modules.AvaloniaUi.Views;
global using WorkTool.Core.Modules.CommandLine.Enums;
global using WorkTool.Core.Modules.CommandLine.Interfaces;
global using WorkTool.Core.Modules.CommandLine.Models;
global using WorkTool.Core.Modules.CommandLine.Services;
global using WorkTool.Core.Modules.Common.Exceptions;
global using WorkTool.Core.Modules.Common.Extensions;
global using WorkTool.Core.Modules.Common.Helpers;
global using WorkTool.Core.Modules.Common.Interfaces;
global using WorkTool.Core.Modules.Common.Models;
global using WorkTool.Core.Modules.Crypto.Interfaces;
global using WorkTool.Core.Modules.EntityFrameworkCore.Exceptions;
global using WorkTool.Core.Modules.EntityFrameworkCore.Models;
global using WorkTool.Core.Modules.Graph.Models;
global using WorkTool.Core.Modules.Graph.Services;
global using WorkTool.Core.Modules.Hash.Interfaces;
global using WorkTool.Core.Modules.Input.Models;
global using WorkTool.Core.Modules.SqlServer.Enums;
global using WorkTool.Core.Modules.SqlServer.Extensions;
global using WorkTool.Core.Modules.SqlServer.Models;
global using WorkTool.Core.Modules.StreamParser.Interfaces;
global using WorkTool.Core.Modules.Ui.Attributes;
global using WorkTool.Core.Modules.Ui.Extensions;
global using WorkTool.Core.Modules.Ui.Helpers;
global using WorkTool.Core.Modules.Ui.Interfaces;
global using WorkTool.Core.Modules.Ui.Models;
global using WorkTool.Core.Modules.Ui.Services;
global using WorkTool.SourceGenerator.Core.Attributes;
global using WorkTool.Core.Modules.AvaloniaUi.Converters;
global using WorkTool.Core.Modules.AvaloniaUi.Services;
global using WorkTool.SourceGenerator.Core.Models;
global using WorkTool.Core.Modules.Git.Exceptions;
global using WorkTool.Core.Modules.LibGit2Sharp.Helpers;
global using WorkTool.Core.Modules.Http.Extensions;
global using WorkTool.Core.Modules.Http.Helpers;
global using WorkTool.Core.Modules.DependencyInjection.Extensions;
global using WorkTool.Core.Modules.DependencyInjection.Interfaces;
global using WorkTool.Core.Modules.DependencyInjection.Services;
global using WorkTool.Core.Modules.DependencyInjection.Models;
global using WorkTool.Core.Modules.DependencyInjection.Exceptions;
global using WorkTool.Core.Modules.MaterialDesign.Controls;
global using WorkTool.Core.Modules.Common.Services;

global using LibGit2Sharp;

global using ConfigurationConstants = WorkTool.Core.Modules.Configuration.Helpers.Constants;
global using AvaloniaApplication = Avalonia.Application;
global using AvaloniaPath = Avalonia.Controls.Shapes.Path;
global using AvaloniaColor = Avalonia.Media.Color;
global using SystemColor = System.Drawing.Color;
global using SystemVersion = System.Version;
global using BalanceResponse = WorkTool.Core.Modules.SmsClub.Models.SmsResponse<WorkTool.Core.Modules.SmsClub.Models.ObjectSuccessRequest<WorkTool.Core.Modules.SmsClub.Models.Balance>>;
global using DictionarySmsResponse = WorkTool.Core.Modules.SmsClub.Models.SmsResponse<WorkTool.Core.Modules.SmsClub.Models.DictionarySuccessRequest>;
global using ArraySmsResponse = WorkTool.Core.Modules.SmsClub.Models.SmsResponse<WorkTool.Core.Modules.SmsClub.Models.ArraySuccessRequest>;
