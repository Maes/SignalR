﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.AspNet.SignalR.Hosting.Common;

namespace Microsoft.AspNet.SignalR.Stress.Infrastructure
{
    internal static class Utility
    {
        public static void InitializePerformanceCounters(IDependencyResolver resolver, CancellationToken cancellationToken)
        {
            resolver.InitializePerformanceCounters(Process.GetCurrentProcess().GetUniqueInstanceName(cancellationToken), cancellationToken);
        }

        public static string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return String.Format("{0:##.##} {1}", Decimal.Divide(bytes, max), order);
                }

                max /= scale;
            }
            return "0 Bytes";
        }
    }
}
