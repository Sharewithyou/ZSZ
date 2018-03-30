using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdminWeb.App_Start
{
    public class MiniProfilerModule : IHttpModule
    {
        private bool _enableProfiling = false;
        public bool enableProfiling
        {
            get
            {
                if (!this._enableProfiling)
                {
                    this._enableProfiling = bool.Parse(ConfigurationManager.AppSettings["enable_profiling"]);
                }
                return this._enableProfiling;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            if (!this.enableProfiling)
            {
                context.BeginRequest += (sender, e) =>
                {
                    var request = ((HttpApplication)sender).Request;
                    //TODO: By default only local requests are profiled, optionally you can set it up
                    //  so authenticated users are always profiled
                    if (request.IsLocal) { MiniProfiler.Start(); }
                };


                // TODO: You can control who sees the profiling information
                /*
                context.AuthenticateRequest += (sender, e) =>
                {
                    if (!CurrentUserIsAllowedToSeeProfiler())
                    {
                        StackExchange.Profiling.MiniProfiler.Stop(discardResults: true);
                    }
                };
                */

                context.EndRequest += (sender, e) =>
                {
                    MiniProfiler.Stop();
                };
            }
        }
    }
}