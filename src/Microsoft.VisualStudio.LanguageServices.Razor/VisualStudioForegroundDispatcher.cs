﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.LanguageServices.Razor
{
    [Shared]
    [Export(typeof(ForegroundDispatcher))]
    [ExportWorkspaceService(typeof(ForegroundDispatcher), ServiceLayer.Host)]
    internal class VisualStudioForegroundDispatcher : ForegroundDispatcher
    {
        public override TaskScheduler BackgroundScheduler { get; } = TaskScheduler.Default;

        public override TaskScheduler ForegroundScheduler { get; } = TaskScheduler.FromCurrentSynchronizationContext();

        public override bool IsForegroundThread => ThreadHelper.CheckAccess();
    }
}
